// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

use scrypto::prelude::*;
use transaction::prelude::*;

use radix_engine_interface::blueprints::account::*;

use crate::transaction_types::*;
use crate::utils;

pub struct AccountSettingsUpdateDetector {
    is_valid: bool,
    /// Updated resource preferences
    resource_preferences: IndexMap<
        ComponentAddress,
        IndexMap<ResourceAddress, Update<ResourcePreference>>,
    >,
    /// Updated default deposit rules
    default_deposit_rules: IndexMap<ComponentAddress, DefaultDepositRule>,
    /// Updates to the authorized depositors
    authorized_depositors:
        IndexMap<ComponentAddress, IndexMap<ResourceOrNonFungible, Update<()>>>,
}

impl ManifestSummaryCallback for AccountSettingsUpdateDetector {
    fn on_instruction(&mut self, instruction: &InstructionV1, _: usize) {
        // Determine the validity based on the instructions
        self.is_valid &= match instruction {
            /* Maybe Permitted - Need more info */
            InstructionV1::CallMethod {
                address,
                method_name,
                ..
            } => Self::construct_fn_rules(address).is_fn_permitted(method_name),
            /* Not Permitted */
            InstructionV1::BurnResource { .. }
            | InstructionV1::CallRoyaltyMethod { .. }
            | InstructionV1::CallMetadataMethod { .. }
            | InstructionV1::CallRoleAssignmentMethod { .. }
            | InstructionV1::CallDirectVaultMethod { .. }
            | InstructionV1::AllocateGlobalAddress { .. }
            | InstructionV1::ReturnToWorktop { .. }
            | InstructionV1::PopFromAuthZone
            | InstructionV1::PushToAuthZone { .. }
            | InstructionV1::CreateProofFromAuthZoneOfAmount { .. }
            | InstructionV1::CreateProofFromAuthZoneOfNonFungibles { .. }
            | InstructionV1::CreateProofFromAuthZoneOfAll { .. }
            | InstructionV1::DropAuthZoneProofs
            | InstructionV1::DropAuthZoneRegularProofs
            | InstructionV1::DropAuthZoneSignatureProofs
            | InstructionV1::CreateProofFromBucketOfAmount { .. }
            | InstructionV1::CreateProofFromBucketOfNonFungibles { .. }
            | InstructionV1::CreateProofFromBucketOfAll { .. }
            | InstructionV1::CloneProof { .. }
            | InstructionV1::DropProof { .. }
            | InstructionV1::DropNamedProofs
            | InstructionV1::DropAllProofs
            | InstructionV1::CallFunction { .. }
            | InstructionV1::TakeFromWorktop { .. }
            | InstructionV1::TakeNonFungiblesFromWorktop { .. }
            | InstructionV1::TakeAllFromWorktop { .. }
            | InstructionV1::AssertWorktopContainsAny { .. }
            | InstructionV1::AssertWorktopContains { .. }
            | InstructionV1::AssertWorktopContainsNonFungibles { .. } => false,
        };

        // Process the instructions
        let InstructionV1::CallMethod {
            address: dynamic_address @ DynamicGlobalAddress::Static(address),
            method_name,
            args,
        } = instruction
        else {
            // Case already accounted for in the above validity check - no need
            // to invalidate here as it's impossible for us to get here in the
            // first place.
            return;
        };
        if !utils::is_account(dynamic_address) {
            return;
        }

        let address =
            ComponentAddress::try_from(*address).expect("Must succeed");
        let encoded_args = manifest_encode(args).expect("Must succeed!");

        if method_name == ACCOUNT_SET_RESOURCE_PREFERENCE_IDENT {
            if let Ok(AccountSetResourcePreferenceInput {
                resource_address,
                resource_preference,
            }) = manifest_decode(&encoded_args)
            {
                self.resource_preferences
                    .entry(address)
                    .or_default()
                    .insert(resource_address, Update::Set(resource_preference));
            }
        } else if method_name == ACCOUNT_REMOVE_RESOURCE_PREFERENCE_IDENT {
            if let Ok(AccountRemoveResourcePreferenceInput {
                resource_address,
            }) = manifest_decode(&encoded_args)
            {
                self.resource_preferences
                    .entry(address)
                    .or_default()
                    .insert(resource_address, Update::Remove);
            }
        } else if method_name == ACCOUNT_ADD_AUTHORIZED_DEPOSITOR {
            if let Ok(AccountAddAuthorizedDepositorInput { badge }) =
                manifest_decode(&encoded_args)
            {
                self.authorized_depositors
                    .entry(address)
                    .or_default()
                    .insert(badge, Update::Set(()));
            }
        } else if method_name == ACCOUNT_REMOVE_AUTHORIZED_DEPOSITOR {
            if let Ok(AccountRemoveAuthorizedDepositorInput { badge }) =
                manifest_decode(&encoded_args)
            {
                self.authorized_depositors
                    .entry(address)
                    .or_default()
                    .insert(badge, Update::Remove);
            }
        } else if method_name == ACCOUNT_SET_DEFAULT_DEPOSIT_RULE_IDENT {
            if let Ok(AccountSetDefaultDepositRuleInput { default }) =
                manifest_decode(&encoded_args)
            {
                self.default_deposit_rules.insert(address, default);
            }
        }
    }
}

impl ExecutionSummaryCallback for AccountSettingsUpdateDetector {}

impl AccountSettingsUpdateDetector {
    pub fn is_valid(&self) -> bool {
        self.is_valid
    }

    fn construct_fn_rules(address: &DynamicGlobalAddress) -> FnRules {
        match address {
            DynamicGlobalAddress::Named(..) => FnRules::all_disallowed(),
            DynamicGlobalAddress::Static(address) => {
                address
                    .as_node_id()
                    .entity_type()
                    .map(|entity_type| {
                        match entity_type {
                        EntityType::GlobalAccount
                        | EntityType::GlobalVirtualSecp256k1Account
                        | EntityType::GlobalVirtualEd25519Account => FnRules {
                            allowed: &[
                                /* Resource Preference */
                                ACCOUNT_SET_RESOURCE_PREFERENCE_IDENT,
                                ACCOUNT_REMOVE_RESOURCE_PREFERENCE_IDENT,
                                /* Authorized Depositors */
                                ACCOUNT_ADD_AUTHORIZED_DEPOSITOR,
                                ACCOUNT_REMOVE_AUTHORIZED_DEPOSITOR,
                                /* Default Deposit Rule */
                                ACCOUNT_SET_DEFAULT_DEPOSIT_RULE_IDENT
                            ],
                            disallowed: &[],
                            default: FnRule::Disallowed,
                        },
                        /* Disallowed */
                        EntityType::GlobalGenericComponent
                        | EntityType::GlobalIdentity
                        | EntityType::GlobalVirtualSecp256k1Identity
                        | EntityType::GlobalVirtualEd25519Identity
                        | EntityType::InternalGenericComponent
                        | EntityType::GlobalPackage
                        | EntityType::GlobalValidator
                        | EntityType::GlobalFungibleResourceManager
                        | EntityType::GlobalNonFungibleResourceManager
                        | EntityType::GlobalConsensusManager
                        | EntityType::InternalFungibleVault
                        | EntityType::InternalNonFungibleVault
                        | EntityType::InternalKeyValueStore
                        | EntityType::GlobalTransactionTracker
                        | EntityType::GlobalAccessController
                        | EntityType::GlobalOneResourcePool
                        | EntityType::GlobalTwoResourcePool
                        | EntityType::GlobalMultiResourcePool
                         => FnRules::all_disallowed(),
                    }
                    })
                    .unwrap_or(FnRules::all_disallowed())
            }
        }
    }
}
