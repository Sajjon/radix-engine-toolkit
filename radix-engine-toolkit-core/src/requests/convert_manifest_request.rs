//! Defines the request and response models for the convert manifest request. This request is made
//! when the client has a manifest in one format (JSON as an example) and they wish to convert
//! the manifest to another format (String as an example). The conversion between the supported
//! formats is dependent on two main factors: the transaction version, and the network id.

use serde::{Deserialize, Serialize};

use crate::error::Error;
use crate::model::address::Bech32Coder;
use crate::model::manifest_instructions::ManifestInstructionsKind;
use crate::model::TransactionManifest;
use crate::traits::{Request, Validate, ValidateWithContext};

// ==========================
// Request & Response Models
// ==========================

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct ConvertManifestRequest {
    /// The version of the passed transaction manifest. Used to determine how the manifest is
    /// interpreted by the library.
    pub transaction_version: u8,

    /// The network id of the network that this transaction manifest is meant for. This is used for
    /// the Bech32 address encoding and decoding.
    pub network_id: u8,

    /// Defines the output format that we would like the manifest to be in after this request is
    /// performed.
    pub manifest_instructions_output_format: ManifestInstructionsKind,

    /// The manifest that the conversion will happen on
    pub manifest: TransactionManifest,
}

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct ConvertManifestResponse {
    /// The manifest after it has been converted to the type specified in the [ConvertManifestRequest]
    #[serde(flatten)]
    pub manifest: TransactionManifest,
}

// ===========
// Validation
// ===========

impl Validate for ConvertManifestRequest {
    fn validate(&self) -> Result<(), Error> {
        self.manifest.validate(self.network_id)?;
        Ok(())
    }
}

impl Validate for ConvertManifestResponse {
    fn validate(&self) -> Result<(), Error> {
        Ok(())
    }
}

// =======================
// Request Implementation
// =======================

impl<'r> Request<'r, ConvertManifestResponse> for ConvertManifestRequest {
    fn handle_request(self) -> Result<ConvertManifestResponse, Error> {
        Ok(ConvertManifestResponse {
            manifest: TransactionManifest {
                instructions: self
                    .manifest
                    .instructions
                    .convert_to_manifest_instructions_kind(
                        self.manifest_instructions_output_format,
                        &Bech32Coder::new(self.network_id),
                        self.manifest.blobs.clone(),
                    )?,
                blobs: self.manifest.blobs,
            },
        })
    }
}

// ======
// Tests
// ======

#[cfg(test)]
mod tests {
    use super::*;
    use crate::model::address::NetworkAwarePackageAddress;
    use crate::model::{Instruction, TransactionManifest};
    use scrypto::prelude::PackageAddress;

    #[test]
    pub fn convert_manifest_with_mismatch_addresses_fails() {
        // Arrange
        let manifest_instructions = vec![Instruction::CallFunction {
            package_address: NetworkAwarePackageAddress {
                address: PackageAddress::Normal([1; 26]),
                network_id: 0x19,
            },
            blueprint_name: "HelloWorld".into(),
            function_name: "HelloWorld".into(),
            arguments: None,
        }];
        let network_id = 0xF2;

        let request = ConvertManifestRequest {
            transaction_version: 0x01,
            network_id,
            manifest_instructions_output_format: crate::model::ManifestInstructionsKind::String,
            manifest: TransactionManifest {
                instructions: crate::model::ManifestInstructions::JSON(manifest_instructions),
                blobs: vec![],
            },
        };

        // Act
        let response = request.fulfill_request();

        // Assert
        assert!(matches!(
            response,
            Err(Error::NetworkMismatchError {
                expected: 0xF2,
                found: 0x19
            })
        ))
    }
}
