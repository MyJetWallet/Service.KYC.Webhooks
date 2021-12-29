using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Service.KYC.Webhooks.Domain.Models
{
    public class KycAidResponse
    {
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("verification_id")] public string VerificationId { get; set; }
        [JsonPropertyName("applicant_id")] public string ApplicantId { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("verified")] public bool Verified { get; set; }
        [JsonPropertyName("verifications")] public Verifications Verifications { get; set; }
        [JsonPropertyName("applicant")] public Applicant Applicant { get; set; }
        [JsonPropertyName("request_id")] public string RequestId { get; set; }
    }

    public class VerificationResult
    {
        [JsonPropertyName("verified")] public bool Verified { get; set; }
        [JsonPropertyName("comment")] public string Comment { get; set; }
        [JsonPropertyName("decline_reasons")] public List<object> DeclineReasons { get; set; }
    }

    public class Verifications
    {
        [JsonPropertyName("document")] public VerificationResult Document { get; set; }
        [JsonPropertyName("facial")] public VerificationResult Facial { get; set; }
    }

    public class Document
    {
        [JsonPropertyName("document_id")] public string DocumentId { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("provider")] public string Provider { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("comment")] public string Comment { get; set; }
        [JsonPropertyName("document_number")] public string DocumentNumber { get; set; }
        [JsonPropertyName("issue_date")] public string IssueDate { get; set; }
        [JsonPropertyName("expiry_date")] public string ExpiryDate { get; set; }
        [JsonPropertyName("issuing_authority")] public string IssuingAuthority { get; set; }
        [JsonPropertyName("front_side_id")] public string FrontSideId { get; set; }
        [JsonPropertyName("front_side")] public string FrontSide { get; set; }
        [JsonPropertyName("back_side_id")] public string BackSideId { get; set; }
        [JsonPropertyName("back_side")] public string BackSide { get; set; }
        [JsonPropertyName("created_at")] public string CreatedAt { get; set; }
        [JsonPropertyName("decline_reasons")] public List<string> DeclineReasons { get; set; }
    }

    public class Applicant
    {
        [JsonPropertyName("applicant_id")] public string ApplicantId { get; set; }
        [JsonPropertyName("external_applicant_id")] public string ExternalApplicantId { get; set; }
        [JsonPropertyName("created_at")] public string CreatedAt { get; set; }
        [JsonPropertyName("profile_status")] public string ProfileStatus { get; set; }
        [JsonPropertyName("profile_comment")] public string ProfileComment { get; set; }
        [JsonPropertyName("first_name")] public string FirstName { get; set; }
        [JsonPropertyName("middle_name")] public string MiddleName { get; set; }
        [JsonPropertyName("last_name")] public string LastName { get; set; }
        [JsonPropertyName("residence_country")] public string ResidenceCountry { get; set; }
        [JsonPropertyName("dob")] public string DateOfBirth { get; set; }
        [JsonPropertyName("addresses")] public List<Address> Addresses { get; set; }
        [JsonPropertyName("documents")] public List<Document> Documents { get; set; }
        [JsonPropertyName("verification_status")] public string VerificationStatus { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("state_or_province")] public string StateOrProvince { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }
        [JsonPropertyName("postal_code")] public string PostalCode { get; set; }
        [JsonPropertyName("street_name")] public string StreetName { get; set; }
        [JsonPropertyName("building_number")] public string BuildingNumber { get; set; }
        [JsonPropertyName("unit_number")] public string UnitNumber { get; set; }
        [JsonPropertyName("decline_reasons")] public List<string> DeclineReasons { get; set; }
        
    }
}