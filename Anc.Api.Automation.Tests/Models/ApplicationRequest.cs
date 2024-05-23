#pragma warning disable 649
#pragma warning disable 169

namespace Anc.Api.Automation.Tests.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApplicationRequest
    {
        [JsonProperty("ExperienceRequestBody")]
        public ExperienceRequestBody ExperienceRequestBody { get; set; }

        [JsonProperty("ExperienceProjectRequestBody")]
        public ExperienceProjectRequestBody ExperienceProjectRequestBody { get; set; }

        [JsonProperty("AddNewEducationRequestBody")]
        public AddNewEducationRequestBody AddNewEducationRequestBody { get; set; }

        [JsonProperty("AuditFailRequestBody")]
        public AuditFailRequestBody AuditFailRequestBody { get; set; }

        [JsonProperty("AuditResetRequestBody")]
        public AuditDueDateRequestBody AuditDueDateRequestBody { get; set; }

        [JsonProperty("EligibilityEndDateRequestBody")]
        public EligibilityEndDateRequestBody EligibilityEndDateRequestBody { get; set; }

        [JsonProperty("SubmitPaymentRequestBody")]
        public SubmitPaymentRequestBody SubmitPaymentRequestBody { get; set; }

        [JsonProperty("SendAuditReferenceRequestBody")]
        public SendAuditReferenceRequestBody SendAuditReferenceRequestBody { get; set; }

        [JsonProperty("BlobDocumentUploadRequestBody")]
        public BlobDocumentUploadRequestBody BlobDocumentUploadRequestBody { get; set; }

        [JsonProperty("SpecialAccommodationRequestBody")]
        public SpecialAccommodationRequestBody SpecialAccommodationRequestBody { get; set; }
    }

    public partial class SpecialAccommodationRequestBody
    {
        [JsonProperty("suppressNotifications")]
        public bool SuppressNotifications { get; set; }

        [JsonProperty("parameters")]
        public SpAccParameters SpAccParameters { get; set; }
    }

    public partial class SpAccParameters
    {
        [JsonProperty("ConditionsApproved")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ConditionsApproved { get; set; }
    }

    public partial class SubmitPaymentRequestBody
    {
        [JsonProperty("suppressNotifications")]
        public bool SuppressNotifications { get; set; }

        [JsonProperty("parameters")]
        public SubmitPaymentParameter SubmitPaymentParameter { get; set; }
    }

    public partial class SubmitPaymentParameter
    {
        [JsonProperty("personId")]
        public long PersonId { get; set; }

        [JsonProperty("ExternalOrderID")]
        public long ExternalOrderId { get; set; }

        [JsonProperty("ExternalOrderLineItemID")]
        public long ExternalOrderLineItemId { get; set; }

        [JsonProperty("orderType")]
        public long OrderType { get; set; }

        [JsonProperty("credential")]
        public long Credential { get; set; }

        [JsonProperty("sku")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Sku { get; set; }
    }

    public partial class ExperienceRequestBody
    {
        [JsonProperty("workExperienceTypeEnum")]
        public string WorkExperienceTypeEnum { get; set; }

        [JsonProperty("projectTitle")]
        public string ProjectTitle { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("primaryFocusTypeEnum")]
        public string PrimaryFocusTypeEnum { get; set; }

        [JsonProperty("functionalAreaTypeEnum")]
        public string FunctionalAreaTypeEnum { get; set; }

        [JsonProperty("budgetRangeEnum")]
        public string BudgetRangeEnum { get; set; }

        [JsonProperty("methodologyEnum")]
        public long? MethodologyEnum { get; set; }

        [JsonProperty("teamSizeEnum")]
        public long? TeamSizeEnum { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class ExperienceProjectRequestBody
    {
        [JsonProperty("experienceId")]
        public long ExperienceId { get; set; }

        [JsonProperty("projectTitle")]
        public string ProjectTitle { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("projectRoleEnum")]
        public string ProjectRoleEnum { get; set; }

        [JsonProperty("contactRelationshipEnum")]
        public string ContactRelationshipEnum { get; set; }

        [JsonProperty("contactPhoneCountryCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ContactPhoneCountryCode { get; set; }

        [JsonProperty("TeamSizeEnum")]
        public string TeamSizeEnum { get; set; }

        [JsonProperty("BudgetRangeEnum")]
        public string BudgetRangeEnum { get; set; }

        [JsonProperty("MethodologyEnum")]
        public string MethodologyEnum { get; set; }
    }


    public partial class AddNewEducationRequestBody
    {
        [JsonProperty("courseEndDate")]
        public DateTimeOffset CourseEndDate { get; set; }

        [JsonProperty("courseStartDate")]
        public DateTimeOffset CourseStartDate { get; set; }

        [JsonProperty("courseTitle")]
        public string CourseTitle { get; set; }

        [JsonProperty("institution")]
        public string Institution { get; set; }

        [JsonProperty("hoursTotal")]
        public long HoursTotal { get; set; }
    }

    public partial class AuditFailRequestBody
    {
        [JsonProperty("suppressNotifications")]
        public bool SuppressNotifications { get; set; }

        [JsonProperty("parameters")]
        public AuditFailParameters AuditFailParameters { get; set; }
    }

    public partial class AuditDueDateRequestBody
    {
        [JsonProperty("suppressNotifications")]
        public bool SuppressNotifications { get; set; }

        [JsonProperty("parameters")]
        public AuditDueDateParameters AuditDueDateParameters { get; set; }
    }

    public partial class AuditDueDateParameters
    {
        [JsonProperty("AuditDueDate")]
        public string AuditDueDate { get; set; }
    }

    public partial class AuditFailParameters
    {
        [JsonProperty("AuditFailureReason")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AuditFailureReason { get; set; }
    }

    public partial class EligibilityEndDateRequestBody
    {
        [JsonProperty("suppressNotifications")]
        public bool SuppressNotifications { get; set; }

        [JsonProperty("parameters")]
        public EligibilityEndDateParameters EligibilityEndDateParameters { get; set; }
    }

    public partial class EligibilityEndDateParameters
    {
        [JsonProperty("EligibilityEndDate")]
        public string EligibilityEndDate { get; set; }
    }

    public partial class SendAuditReferenceRequestBody
    {
        [JsonProperty("auditDocumentId")]
        public long AuditDocumentId { get; set; }

        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("referenceEmail")]
        public string ReferenceEmail { get; set; }

        [JsonProperty("auditReferenceRequestStatus")]
        public long AuditReferenceRequestStatus { get; set; }

        [JsonProperty("lastUpdateDate")]
        public DateTimeOffset LastUpdateDate { get; set; }
    }

    public partial class BlobDocumentUploadRequestBody
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("documentContent")]
        public string DocumentContent { get; set; }

        [JsonProperty("documentMetadata")]
        public DocumentMetadata DocumentMetadata { get; set; }

        [JsonProperty("auditDocumentTypeEnum")]
        public long AuditDocumentTypeEnum { get; set; }
    }

    public partial class DocumentMetadata
    {
        [JsonProperty("DocumentName")]
        public string DocumentName { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }
    }

    public partial class ApplicationRequest
    {
        public static ApplicationRequest FromJson(string json) => JsonConvert.DeserializeObject<ApplicationRequest>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ApplicationRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
