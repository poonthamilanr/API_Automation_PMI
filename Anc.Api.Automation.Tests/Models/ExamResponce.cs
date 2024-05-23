#pragma warning disable 649
#pragma warning disable 169
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anc.Api.Automation.Tests.Models
{
    //    var examDetails = ExamDetails.FromJson(jsonString);
    public partial class ExamResponce
    {
        [JsonProperty("personId")]
        public long? PersonId { get; set; }

        [JsonProperty("certificationTypeEnum")]
        public string CertificationTypeEnum { get; set; }

        [JsonProperty("applicationId")]
        public long? ApplicationId { get; set; }

        [JsonProperty("examStatusEnum")]
        public string ExamStatusEnum { get; set; }

        [JsonProperty("examResolutionStatusEnum")]
        public string ExamResolutionStatusEnum { get; set; }

        [JsonProperty("examTypeEnum")]
        public string ExamTypeEnum { get; set; }

        [JsonProperty("examLanguageEnum")]
        public string ExamLanguageEnum { get; set; }

        [JsonProperty("examRescoringStatus")]
        public long? ExamRescoringStatus { get; set; }

        [JsonProperty("groupExamId")]
        public dynamic GroupExamId { get; set; }

        [JsonProperty("groupExam")]
        public dynamic GroupExam { get; set; }

        [JsonProperty("examNotTakenReasonEnum")]
        public string ExamNotTakenReasonEnum { get; set; }

        [JsonProperty("passed")]
        public bool? Passed { get; set; }

        [JsonProperty("specialAccommodations")]
        public SpecialAccommodations SpecialAccommodations { get; set; }

        [JsonProperty("dateStartEffectiveEligibility")]
        public dynamic DateStartEffectiveEligibility { get; set; }

        [JsonProperty("dateEndEffectiveEligibility")]
        public dynamic DateEndEffectiveEligibility { get; set; }

        [JsonProperty("dateOfExam")]
        public dynamic DateOfExam { get; set; }

        [JsonProperty("datePaid")]
        public dynamic DatePaid { get; set; }

        [JsonProperty("dateScheduled")]
        public dynamic DateScheduled { get; set; }

        [JsonProperty("scheduled")]
        public dynamic Scheduled { get; set; }

        [JsonProperty("identification")]
        public Identification Identification { get; set; }

        [JsonProperty("eligibilityQueue")]
        public EligibilityQueue EligibilityQueue { get; set; }

        [JsonProperty("selectedFormId")]
        public dynamic SelectedFormId { get; set; }

        [JsonProperty("adminIgnoreExam")]
        public bool? AdminIgnoreExam { get; set; }

        [JsonProperty("examVendorEnum")]
        public string ExamVendorEnum { get; set; }

        [JsonProperty("referenceOrderId")]
        public long? ReferenceOrderId { get; set; }

        [JsonProperty("externalOrderId")]
        public dynamic ExternalOrderId { get; set; }

        [JsonProperty("externalOrderLineItemId")]
        public dynamic ExternalOrderLineItemId { get; set; }

        [JsonProperty("examVendorCountry")]
        public string ExamVendorCountry { get; set; }

        [JsonProperty("systemCreateDate")]
        public DateTimeOffset? SystemCreateDate { get; set; }

        [JsonProperty("isPilotExam")]
        public bool? IsPilotExam { get; set; }

        [JsonProperty("examLanguageAsText")]
        public string ExamLanguageAsText { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("isOpen")]
        public bool? IsOpen { get; set; }

        [JsonProperty("isFailed")]
        public bool? IsFailed { get; set; }

        [JsonProperty("isScheduled")]
        public bool? IsScheduled { get; set; }

        [JsonProperty("isEligible")]
        public bool? IsEligible { get; set; }

        [JsonProperty("examVendorAsText")]
        public string ExamVendorAsText { get; set; }

        [JsonProperty("dateEndEffectiveEligibilityAsText")]
        public string DateEndEffectiveEligibilityAsText { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public partial class EligibilityQueue
    {
        [JsonProperty("sentCandidateId")]
        public dynamic SentCandidateId { get; set; }

        [JsonProperty("confirmationNumber")]
        public dynamic ConfirmationNumber { get; set; }

        [JsonProperty("examId")]
        public dynamic ExamId { get; set; }

        [JsonProperty("examFormId")]
        public dynamic ExamFormId { get; set; }

        [JsonProperty("examFormCode")]
        public dynamic ExamFormCode { get; set; }

        [JsonProperty("examSequence")]
        public long? ExamSequence { get; set; }

        [JsonProperty("examQueueStatusEnum")]
        public string ExamQueueStatusEnum { get; set; }

        [JsonProperty("returnSiteId")]
        public dynamic ReturnSiteId { get; set; }

        [JsonProperty("numberAttempts")]
        public long? NumberAttempts { get; set; }

        [JsonProperty("suspended")]
        public bool? Suspended { get; set; }

        [JsonProperty("suspendedReason")]
        public string SuspendedReason { get; set; }

        [JsonProperty("examResultReceived")]
        public dynamic ExamResultReceived { get; set; }

        [JsonProperty("suspendedDate")]
        public dynamic SuspendedDate { get; set; }
    }

    public partial class Identification
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("id", Required = Required.Always)]
        public long? Id { get; set; }

        [JsonProperty("attention")]
        public dynamic Attention { get; set; }

        [JsonProperty("organizationName")]
        public dynamic OrganizationName { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public dynamic Address2 { get; set; }

        [JsonProperty("address3")]
        public dynamic Address3 { get; set; }

        [JsonProperty("city", Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty("state", Required = Required.Always)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? State { get; set; }

        [JsonProperty("postalCode", Required = Required.Always)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? PostalCode { get; set; }

        [JsonProperty("countryCode", Required = Required.Always)]
        public string CountryCode { get; set; }

        [JsonProperty("addressTypeEnum", Required = Required.Always)]
        public string AddressTypeEnum { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("id", Required = Required.Always)]
        public long? Id { get; set; }

        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("middleName", Required = Required.AllowNull)]
        public dynamic MiddleName { get; set; }

        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("fullName", Required = Required.Always)]
        public string FullName { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self", Required = Required.Always)]
        public Self Self { get; set; }
    }

    public partial class Self
    {
        [JsonProperty("href", Required = Required.Always)]
        public string Href { get; set; }

        [JsonProperty("allowed", Required = Required.AllowNull)]
        public List<string> Allowed { get; set; }
    }

    public partial class SpecialAccommodations
    {
        [JsonProperty("requested", Required = Required.Always)]
        public bool? Requested { get; set; }

        [JsonProperty("approved", Required = Required.AllowNull)]
        public dynamic Approved { get; set; }

        [JsonProperty("previousRequested", Required = Required.AllowNull)]
        public dynamic PreviousRequested { get; set; }

        [JsonProperty("limitDescription", Required = Required.AllowNull)]
        public dynamic LimitDescription { get; set; }

        [JsonProperty("requireTestAccommodation", Required = Required.AllowNull)]
        public dynamic RequireTestAccommodation { get; set; }

        [JsonProperty("testAccommodationDescription", Required = Required.AllowNull)]
        public dynamic TestAccommodationDescription { get; set; }

        [JsonProperty("conditions", Required = Required.AllowNull)]
        public dynamic Conditions { get; set; }

        [JsonProperty("conditionsList", Required = Required.AllowNull)]
        public dynamic ConditionsList { get; set; }

        [JsonProperty("conditionsEnumList")]
        public List<dynamic> ConditionsEnumList { get; set; }
    }

    public class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
