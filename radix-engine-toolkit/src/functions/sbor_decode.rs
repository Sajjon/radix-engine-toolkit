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

use crate::functions::traits::InvocationHandler;
use crate::model::address::Bech32Coder;
use crate::model::value::manifest_sbor::ManifestSborValueConversionError;
use crate::model::value::scrypto_sbor::ScryptoSborValue;
use crate::{model::value::manifest_sbor::ManifestSborValue, utils::debug_string};
use native_transaction::manifest::decompiler::{format_typed_value, DecompilationContext};
use sbor::DecodeError;
use scrypto::prelude::{
    manifest_decode, scrypto_decode, ManifestValue, ScryptoValue, MANIFEST_SBOR_V1_PAYLOAD_PREFIX,
    SCRYPTO_SBOR_V1_PAYLOAD_PREFIX,
};
use toolkit_derive::serializable;

// =================
// Model Definition
// =================

/// Takes in a byte array of SBOR byte and attempts to decode it to a [`Value`]. Since some of the
/// types in the [`Value`] model are network aware, this request also takes in a network id which
/// is primarily used for the Bech32m encoding of addresses.
#[serializable]
pub struct Input {
    /// A byte array serialized as a hex string of the SBOR buffer to attempt to decode as a
    /// [`Value`]
    #[schemars(with = "String")]
    #[schemars(regex(pattern = "[0-9a-fA-F]+"))]
    #[serde_as(as = "serde_with::hex::Hex")]
    pub encoded_value: Vec<u8>,

    /// An 8 bit unsigned integer serialized as a string which represents the id of the network
    /// that the decoded data will be used on. This is primarily used for the Bech32m encoding of
    /// addresses.
    #[schemars(with = "String")]
    #[schemars(regex(pattern = "[0-9]+"))]
    #[serde_as(as = "serde_with::DisplayFromStr")]
    pub network_id: u8,
}

/// The response from the [`Input`].
#[serializable]
#[serde(tag = "type")]
pub enum Output {
    ScryptoSbor {
        value: ScryptoSborValue,
    },
    ManifestSbor {
        manifest_string: String,
        value: ManifestSborValue,
    },
}

// ===============
// Implementation
// ===============

pub struct Handler;
impl InvocationHandler<Input, Output> for Handler {
    type Error = Error;

    fn pre_process(input: Input) -> Result<Input, Error> {
        Ok(input)
    }

    fn handle(input: &Input) -> Result<Output, Error> {
        let bech32_coder = Bech32Coder::new(input.network_id);
        match input.encoded_value.first().copied() {
            Some(SCRYPTO_SBOR_V1_PAYLOAD_PREFIX) => {
                scrypto_decode::<ScryptoValue>(&input.encoded_value)
                    .map(|scrypto_value| {
                        ScryptoSborValue::from_scrypto_sbor_value(&scrypto_value, input.network_id)
                    })
                    .map(|value| Output::ScryptoSbor { value })
                    .map_err(Error::from)
            }
            Some(MANIFEST_SBOR_V1_PAYLOAD_PREFIX) => {
                manifest_decode::<ManifestValue>(&input.encoded_value)
                    .map_err(Error::from)
                    .and_then(|manifest_value| {
                        ManifestSborValue::from_manifest_sbor_value(
                            &manifest_value,
                            input.network_id,
                        )
                        .map_err(Error::from)
                        .map(|value| (value, manifest_value))
                    })
                    .map(|(value, manifest_value)| Output::ManifestSbor {
                        value,
                        manifest_string: {
                            let mut string = String::new();
                            let mut context = DecompilationContext::new_with_optional_network(
                                Some(bech32_coder.encoder()),
                            );
                            format_typed_value(&mut string, &mut context, &manifest_value)
                                .expect("Impossible case! Valid SBOR can't fail here");
                            string.trim().to_owned()
                        },
                    })
                    .map_err(Error::from)
            }
            Some(p) => Err(Error::InvalidSborVariant {
                expected: vec![
                    SCRYPTO_SBOR_V1_PAYLOAD_PREFIX,
                    MANIFEST_SBOR_V1_PAYLOAD_PREFIX,
                ],
                actual: p,
            }),
            None => Err(Error::EmptyPayloadError),
        }
    }

    fn post_process(_: &Input, output: Output) -> Result<Output, Error> {
        Ok(output)
    }
}

#[serializable]
pub enum Error {
    /// An error emitted by the SBOR upstream functions that perform the decoding.
    Error { message: String },

    /// An error emitted when the passed SBOR payload is of an unknown variant and thus can not be
    /// decoded.
    InvalidSborVariant { expected: Vec<u8>, actual: u8 },

    /// Passed payload is empty; thus can not be decoded.
    EmptyPayloadError,

    /// Emitted if the conversion from the Native manifest SBOR model to the RET manifest SBOR
    /// model fails.
    ManifestSborValueConversionError(ManifestSborValueConversionError),
}

impl From<DecodeError> for Error {
    fn from(value: DecodeError) -> Self {
        Self::Error {
            message: debug_string(value),
        }
    }
}

impl From<ManifestSborValueConversionError> for Error {
    fn from(value: ManifestSborValueConversionError) -> Self {
        Self::ManifestSborValueConversionError(value)
    }
}
