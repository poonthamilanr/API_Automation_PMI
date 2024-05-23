#pragma warning disable 649
#pragma warning disable 169
namespace Anc.Api.Automation.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CertificationRequest
    {
        [JsonProperty("Scheduled")]
        public Scheduled Scheduled { get; set; }

        [JsonProperty("ReScheduled")]
        public Scheduled ReScheduled { get; set; }

        [JsonProperty("NewCcrCycle")]
        public NewCcrCycle NewCcrCycle { get; set; }

        [JsonProperty("SBApplicationETPAndPR")]
        public SbApplicationETPAndPR SbApplicationETPAndPR { get; set; }

        [JsonProperty("SBNewCertification")]
        public SbNewCertification SbNewCertification { get; set; }
        
        [JsonProperty("SBExamTaken")] 
        public SbExamTaken SbExamTaken { get; set; }

        [JsonProperty("SBExamScheduled")]
        public SbExamScheduled SbExamScheduled { get; set; }

        [JsonProperty("SBExamPurchased")]
        public SbExamPurchased SbExamPurchased { get; set; }

        [JsonProperty("SBExamDetailsCompletedAndAccomm")]
        public SbExamDetailsCompletedAndAccomm SbExamDetailsCompletedAndAccomm { get; set; }

        [JsonProperty("SBEligibilityExpired")]
        public SbEligibilityExpired SbEligibilityExpired { get; set; }

        [JsonProperty("SBCourseCompleted")]
        public SbCourseCompleted SbCourseCompleted { get; set; }

        [JsonProperty("ExtEligibilityForNonAppBased")]
        public ExtEligibilityForNonAppBased ExtEligibilityForNonAppBased { get; set; }

        [JsonProperty("LmsCourseCompletion")]
        public LmsCourseCompletion LmsCourseCompletion { get; set; }

        [JsonProperty("QueueExamProcessingResult")]
        public QueueExamProcessingResult QueueExamProcessingResult { get; set; }

        [JsonProperty("DequeueExamProcessingResult")]
        public DequeueExamProcessingResult DequeueExamProcessingResult { get; set; }

        [JsonProperty("ProcessOrderPayment")]
        public ProcessOrderPayment ProcessOrderPayment { get; set; }

        [JsonProperty("PostEmailRequestBody")]
        public PostEmailRequestBody PostEmailRequestBody { get; set; }

        [JsonProperty("ProcesssBatch")]
        public List<long> ProcesssBatch { get; set; }

        [JsonProperty("CandidateUpload")]
        public List<CandidateUpload> CandidateUpload { get; set; }
    }

    public partial class Scheduled
    {
        [JsonProperty("Accomodations")]
        public List<dynamic> Accomodations { get; set; }

        [JsonProperty("VendorAppointmentID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? VendorAppointmentId { get; set; }

        [JsonProperty("VendorCandidateID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? VendorCandidateId { get; set; }

        [JsonProperty("CandidateID")]
        public string CandidateId { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("EventType")]
        public string EventType { get; set; }

        [JsonProperty("EventTime")]
        public DateTimeOffset? EventTime { get; set; }

        [JsonProperty("AppointmentStartDateTime")]
        public string AppointmentStartDateTime { get; set; }

        [JsonProperty("FirstName")]
        public dynamic FirstName { get; set; }

        [JsonProperty("MiddleName")]
        public dynamic MiddleName { get; set; }

        [JsonProperty("LastName")]
        public dynamic LastName { get; set; }

        [JsonProperty("TestingCenter")]
        public TestingCenter TestingCenter { get; set; }

        [JsonProperty("Exam")]
        public Exam Exam { get; set; }
    }

    public partial class NewCcrCycle
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("certificationId")] public long CertificationId { get; set; }
        [JsonProperty("effectiveStartDate")] public DateTimeOffset EffectiveStartDate { get; set; }
        [JsonProperty("effectiveEndDate")] public DateTimeOffset EffectiveEndDate { get; set; }
        [JsonProperty("originalStartDate")] public DateTimeOffset OriginalStartDate { get; set; }
        [JsonProperty("originalEndDate")] public DateTimeOffset OriginalEndDate { get; set; }
        [JsonProperty("totalPDUsRequired")] public long TotalPdUsRequired { get; set; }
        [JsonProperty("exemptFlag")] public bool ExemptFlag { get; set; }
    }

    public partial class Exam
    {
        [JsonProperty("Definition")] public Definition Definition { get; set; }
    }

    public partial class Definition
    {
        [JsonProperty("DeliveryMethod")] public string DeliveryMethod { get; set; }
    }

    public partial class TestingCenter
    {
        [JsonProperty("Identifier")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Identifier { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class SbApplicationETPAndPR
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("personId")] public long PersonId { get; set; }
        [JsonProperty("certificationTypeEnum")] public long CertificationTypeEnum { get; set; }
        [JsonProperty("applicationStatusEnum")] public long ApplicationStatusEnum { get; set; }
        [JsonProperty("dateStartEffectiveEligibility")] public DateTimeOffset DateStartEffectiveEligibility { get; set; }
        [JsonProperty("dateEndEffectiveEligibility")] public DateTimeOffset DateEndEffectiveEligibility { get; set; }
        [JsonProperty("closeReason")] public string CloseReason { get; set; }
        [JsonProperty("examVendorCountry")] public string ExamVendorCountry { get; set; }
    }

    public partial class SbNewCertification
    {
        [JsonProperty("personId")] public long PersonId { get; set; }
        [JsonProperty("certificationType")] public string CertificationType { get; set; }
    }

    public partial class SbExamTaken
    {
        [JsonProperty("examId")] public long ExamId { get; set; }
        [JsonProperty("certificationId")] public long CertificationId { get; set; }
    }

    public partial class SbExamScheduled
    {
        [JsonProperty("examId")] public long ExamId { get; set; }
        [JsonProperty("isRescheduled")] public bool IsRescheduled { get; set; }
    }

    public partial class SbExamPurchased
    {
        [JsonProperty("examId")] public long ExamId { get; set; }
        [JsonProperty("dateEndEffectiveEligibility")] public DateTimeOffset DateEndEffectiveEligibility { get; set; }
    }

    public partial class SbExamDetailsCompletedAndAccomm
    {
        [JsonProperty("examId")] public long ExamId { get; set; }
        [JsonProperty("currentDate")] public DateTimeOffset CurrentDate { get; set; }
    }

    public partial class SbEligibilityExpired
    {
        [JsonProperty("examId")] public long ExamId { get; set; }
    }

    public partial class SbCourseCompleted
    {
        [JsonProperty("personId")] public long PersonId { get; set; }
        [JsonProperty("courseId")] public string CourseId { get; set; }
    }
    public partial class ExtEligibilityForNonAppBased
    {
        [JsonProperty("dateEndEffectiveEligibility")]
        public DateTimeOffset DateEndEffectiveEligibility { get; set; }
    }
    public partial class LmsCourseCompletion
    {
        [JsonProperty("courseId")]
        public string CourseId { get; set; }

        [JsonProperty("courseTitle")]
        public string CourseTitle { get; set; }

        [JsonProperty("institution")]
        public string Institution { get; set; }

        [JsonProperty("courseEndDate")]
        public DateTimeOffset CourseEndDate { get; set; }

        [JsonProperty("courseStartDate")]
        public DateTimeOffset CourseStartDate { get; set; }

        [JsonProperty("hoursTotal")]
        public long HoursTotal { get; set; }
    }
    public partial class CertificationRequest
    {
        public static CertificationRequest FromJson(string json) => JsonConvert.DeserializeObject<CertificationRequest>(json, Converter.Settings);
    }
    public partial class DequeueExamProcessingResult
    {
        [JsonProperty("examProcessingResultIds")]
        public List<long> ExamProcessingResultIds { get; set; }

        [JsonProperty("adminPersonId")]
        public long AdminPersonId { get; set; }
    }
    public partial class QueueExamProcessingResult
    {
        [JsonProperty("examProcessingResultIds")]
        public List<long> ExamProcessingResultIds { get; set; }

        [JsonProperty("adminPersonId")]
        public long AdminPersonId { get; set; }

        [JsonProperty("queueParameters")]
        public QueueParameters QueueParameters { get; set; }
    }

    public partial class QueueParameters
    {
        [JsonProperty("queueMode")]
        public string QueueMode { get; set; }

        [JsonProperty("alternateEligibilityId")]
        public object AlternateEligibilityId { get; set; }

        [JsonProperty("alternateExamFormCode")]
        public object AlternateExamFormCode { get; set; }
    }

    public partial class ProcessOrderPayment
    {
        [JsonProperty("personId")] public long PersonId { get; set; }
        [JsonProperty("ExternalOrderID")] public long ExternalOrderId { get; set; }
        [JsonProperty("ExternalOrderLineItemID")] public long ExternalOrderLineItemId { get; set; }
        [JsonProperty("orderType")] public long OrderType { get; set; }
        [JsonProperty("credential")] public long Credential { get; set; }
        [JsonProperty("sku")] public string Sku { get; set; }
    }

    public partial class PostEmailRequestBody
    {
        [JsonProperty("PersonId")]
        public long PersonId { get; set; }

        [JsonProperty("UserName")]
        public object UserName { get; set; }

        [JsonProperty("From")]
        public object From { get; set; }

        [JsonProperty("To")]
        public object To { get; set; }

        [JsonProperty("Bcc")]
        public object Bcc { get; set; }

        [JsonProperty("CC")]
        public object Cc { get; set; }

        [JsonProperty("Subject")]
        public object Subject { get; set; }

        [JsonProperty("HtmlContent")]
        public object HtmlContent { get; set; }

        [JsonProperty("TemplateId")]
        public string TemplateId { get; set; }

        [JsonProperty("Country")]
        public object Country { get; set; }

        [JsonProperty("TokenObjectIds")]
        public TokenObjectIds TokenObjectIds { get; set; }

        [JsonProperty("ExtendedAttributes")]
        public ExtendedAttributes ExtendedAttributes { get; set; }

        [JsonProperty("ContactHistoryType")]
        public object ContactHistoryType { get; set; }

        [JsonProperty("PreferredAddressId")]
        public object PreferredAddressId { get; set; }

        [JsonProperty("SkipLocalization")]
        public bool SkipLocalization { get; set; }
    }

    public partial class ExtendedAttributes
    {
        [JsonProperty("ApplicationID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ApplicationId { get; set; }
    }

    public partial class TokenObjectIds
    {
        [JsonProperty("APPLICATION_ID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ApplicationId { get; set; }

        [JsonProperty("EXAM_ID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExamId { get; set; }

        [JsonProperty("CERTIFICATION_TYPE_ID")]
        public string CertificationTypeId { get; set; }
    }

    public partial class CandidateUpload
    {
        [JsonProperty("courseTitle")]
        public string CourseTitle { get; set; }

        [JsonProperty("institution")]
        public string Institution { get; set; }

        [JsonProperty("courseEndDate")]
        public DateTimeOffset CourseEndDate { get; set; }

        [JsonProperty("courseStartDate")]
        public DateTimeOffset CourseStartDate { get; set; }

        [JsonProperty("hoursTotal")]
        public long HoursTotal { get; set; }

        [JsonProperty("courseId")]
        public string CourseId { get; set; }

        [JsonProperty("pmiId")]
        public long PmiId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("credential")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Credential { get; set; }

        [JsonProperty("examStatus")]
        public string ExamStatus { get; set; }
    }
}
