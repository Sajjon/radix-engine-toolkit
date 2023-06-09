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

use std::convert::Infallible;

use sbor::prelude::*;
use scrypto::prelude::*;

use crate::instruction_visitor::core::traits::InstructionVisitor;
use crate::sbor::indexed_manifest_value::IndexedManifestValue;
use crate::statics::ACCOUNT_PROOF_CREATION_METHODS;
use crate::utils::is_account;

#[derive(Default, Clone)]
pub struct AccountProofsVisitor(HashSet<ResourceAddress>);

impl InstructionVisitor for AccountProofsVisitor {
    type Error = Infallible;
    type Output = HashSet<ResourceAddress>;

    fn visit_call_method(
        &mut self,
        address: &GlobalAddress,
        method_name: &str,
        args: &ManifestValue,
    ) -> Result<(), Self::Error> {
        if is_account(address.as_node_id())
            && ACCOUNT_PROOF_CREATION_METHODS.contains(&method_name.to_owned())
        {
            self.0.extend(
                IndexedManifestValue::from_manifest_value(args)
                    .addresses()
                    .iter()
                    .filter_map(|node_id| {
                        if node_id.is_global_resource_manager() {
                            Some(ResourceAddress::new_or_panic(node_id.0))
                        } else {
                            None
                        }
                    }),
            )
        }

        Ok(())
    }

    fn output(self) -> Self::Output {
        self.0
    }
}
