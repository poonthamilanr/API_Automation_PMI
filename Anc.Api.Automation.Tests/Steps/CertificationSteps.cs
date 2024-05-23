#pragma warning disable 649
#pragma warning disable 169
namespace Anc.Api.Automation.Tests.Steps
{
    using Anc.Api.Automation.Tests.Hooks;
    using Anc.Api.Automation.Tests.Modules;
    using Anc.Api.Automation.Tests.Utilities;
    using RestSharp;
    using System;
    using TechTalk.SpecFlow;
    using CertificationAllRequests = Anc.Api.Automation.Tests.Utilities.CertificationAllRequests;
    using FluentAssertions;
    using Newtonsoft.Json;
    using CertificationRequest = Models.CertificationRequest;
    using static Anc.Api.Automation.Tests.CertificationTypesEnum;
    using Org.BouncyCastle.Utilities;
    using Pmi.Api.Framework.Attributes;
    using Anc.Api.Automation.Tests.Models;

    [Binding]
    public class CertificationSteps
    {
        private const string TokenKey = "Token";
        public static string ExamType = "ExamType";

        private readonly CertificationAllRequests request;
        private readonly Experience experience;
        private readonly IdentityToken identityToken;
        private readonly ScenarioContext scenarioContext;
        public static IRestResponse response;
        private readonly TestData testData;
        private readonly Utility utility;
        public List<string> expectedListValue;
        public CertificationRequest requestBodyObject = JsonConvert.DeserializeObject<CertificationRequest>(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/RequestBody/Certification.Json"));
        public object requestBody = null;
        public readonly CertificationTypesEnum certTypeEnum;
        private Dictionary<string, string> dbDicValues;
        private readonly UserSettings userSettings = new UserSettings();

        public CertificationSteps(ScenarioContext scenarioCont, IdentityToken identityTok, TestData testData, Experience exper)
        {
            scenarioContext = scenarioCont;
            identityToken = identityTok;
            experience = exper;
            this.testData = testData;
            utility = new Utility(scenarioContext, testData);
            request = new CertificationAllRequests(testData);
            certTypeEnum = new CertificationTypesEnum();
        }

        [Given(@"Generate access token for certification service")]
        public void GenerateAccessTokenForCertificationService()
        {
            var idpToken = identityToken.GetIdpToken();
            scenarioContext[TokenKey] = idpToken;
        }

        [When(@"Get CCR cycle details by id")]
        [When(@"Get cycle for given certification id")]
        [When(@"Get cycle by CCR cycle id and certification id")]
        [When(@"Get certification details by ID")]
        [When(@"Get valid transition event for certification by id")]
        [When(@"Get valid re-certification transition event for certification by id")]
        [When(@"Get business rule settings")]
        [When(@"Get ccr settings")]
        [When(@"Get certification configurations settings")]
        [When(@"Get certification configurations settings by certification type")]
        [When(@"Get raw certification configurations settings")]
        [When(@"Get raw certification configurations settings by id")]
        [When(@"Get raw certification configurations settings by certification type")]
        [When(@"Get certification general settings")]
        [When(@"Get enterprise settings")]
        [When(@"Get field validation settings")]
        [When(@"Get prerequisites to eligible for a specified certification type")]
        [When(@"Get prerequisites to apply for a specified certification type")]
        [When(@"Get exam details")]
        [When(@"Get exam vendor inbound transactions by date range")]
        [When(@"Get exam vendor inbound transactions by id")]
        [When(@"Get exam vendor inbound transactions by person id")]
        [When(@"Get exam vendor outbound message events by date range")]
        [When(@"Get exam vendor outbound message events by id")]
        [When(@"Get exam vendor outbound message events by person id")]
        [When(@"Get the member type by given person id")]
        [When(@"Get exam details by eligibility id")]
        [When(@"Get exam form details for an exam")]
        [When(@"Get exam results for an exam id")]
        [When(@"Get vendor availability")]
        [When(@"Get all active vendor availability")]
        [When(@"Get exams for given person")]
        [When(@"Get exams for given person and certification type")]
        [When(@"Get active exams for given person and certification type")]
        [When(@"Get all exam security details by flaggedOnly")]
        [When(@"Get exam security result by examId")]
        [When(@"Get exam security summary result by personId")]
        [When(@"Get exam vendor message events by exam id")]
        [When(@"Get certification events for given person id")]
        [When(@"Get exams for given group exam id")]
        [When(@"Get given person is an active provider representative")]
        [When(@"Get status of certifications for given person id and certification type")]
        [When(@"Get exam processing results by id")]
        [When(@"Get pmi and nonpmi certification profile for a given person id")]
        [When(@"Get nonpmi certification profile for a given person id")]
        [When(@"Get profile education for a given person id")]
        [When(@"Get exam processing results for a given person")]
        [When(@"Get the token for an given email template")]
        [When(@"Get the personalization details for an given email template id")]
        [When(@"Get the attribute details for an given email template id")]
        [When(@"Get the request queue for a given id")]
        [When(@"Get the request queue for a given batch number")]
        [When(@"Get the status of user can apply for a certification for a given person id")]
        [When(@"Get the eligible to pay status of certification for a given person id")]
        [When(@"Get Certification credential status for a given person id")]
        [When(@"Get the status for a given person has a credential that is expired")]
        public void CertificationGetCall()
        {
            if (testData.Uri.Contains("{0}"))
            {
                testData.User = DataScaffolding.PullCertifiedUser("PMP");
                testData.Uri = testData.Uri.Replace("{0}", testData.User.PersonId.ToString()).Replace("{1}", testData.User.ApplicationType);
                expectedListValue = new List<string> { testData.User.PersonId.ToString() };
            }
                response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Post rten modify appointment to reschedule an event")]
        [When(@"Post rten modify appointment to schedule an event")]
        [When(@"Post add new ccr cycle for given certification id")]
        [When(@"Submit certify and establish certification event for the given application")]
        [When(@"Post eligibility get extended for given non application based exam")]
        [When(@"Post indicate that given person has completed lms course")]
        [When(@"Send eligible for exam email for a person")]
        public void CertificationPostCall()
        {
            var scenarioTitle = scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper();
            if (scenarioTitle.Contains("NEWCCRCYCLEADDED"))
                requestBody = requestBodyObject.NewCcrCycle;
            if (scenarioTitle.Contains("EXAMSCHEDULED"))
                requestBody = requestBodyObject.Scheduled;
            if (scenarioTitle.Contains("EXAMRESCHEDULED"))
                requestBody = requestBodyObject.ReScheduled;
            if (scenarioTitle.Contains("ELIGIBILITYGETEXTENDED"))
                requestBody = requestBodyObject.ExtEligibilityForNonAppBased;
            if (scenarioTitle.Contains("LMSCOURSECOMPLETED"))
                requestBody = requestBodyObject.LmsCourseCompletion;
            if (scenarioTitle.Contains("SENDEMAILFORELIGIBLEFOREXAM"))
            {
                testData.User = DataScaffolding.PullEligibleForExamUser("PMP");
                requestBodyObject.PostEmailRequestBody.PersonId = testData.User.PersonId;
                requestBodyObject.PostEmailRequestBody.TokenObjectIds.ApplicationId = long.Parse(testData.User.ApplicationId);
                dbDicValues =  utility.ReadValuesFromDataBase($"SELECT * FROM cert.CW_Exams where PersonID = '{testData.User.PersonId}'");
                requestBodyObject.PostEmailRequestBody.TokenObjectIds.ExamId = long.Parse(dbDicValues.GetValueOrDefault("ID"));
                requestBody = requestBodyObject.PostEmailRequestBody;
            }
               
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBody);
        }

        [When(@"Get the person certification details for given user")]
        public void WhenGetThePersonCertificationDetailsForGivenUserSpecificAccessToken()
        {
            testData.User = DataScaffolding.PullCertifiedUser(testData.DataScaffoldingApplicationType);
            scenarioContext[TokenKey] = identityToken.GetIdpToken(testData.User.UserName, testData.User.Password);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, testData.User.PersonId.ToString());
        }

        [When(@"Get prerequisites needed for a given person to apply for a specified certification type")]
        [When(@"Get prerequisites needed for a given person for eligibility for a specified certification type")]
        [When(@"Get the eligible to purchase status for a given person id and sku")]
        public void WhenGetPrerequisitesDetails()
        {
            string secondString = null;
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType);
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").Contains("eligibletopurchasethespecifiedsku"))
            {
                secondString = GetSkuCodes(testData.User.ApplicationType.Replace("_", "-"), "Exam");
                expectedListValue = new List<string> { testData.User.PersonId.ToString(), testData.User.ApplicationType, secondString };
            }
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, testData.User.PersonId.ToString(), secondString);
        }

        [When(@"Get certification details by using specific user access token")]
        [When(@"Get the certification details for given user")]
        [When(@"Get exam security details by ID")]
        [When(@"Get exam security result to CRM by examId")]
        [When(@"Get the certification status for given user")]
        public void WhenGetCertificationDetailsByUsingSpecificUserAccessToken()
        {
            scenarioContext[TokenKey] = identityToken.GetIdpToken(testData.UserName, testData.Password);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Get valid re-certification transition event for given certification")]
        [When(@"Get the panel reviewer details for given user")]
        [When(@"Search for person")]
        [When(@"Get PMI certification profile for a given person id")]
        [When(@"Get credential holder cert registry details")]
        [When(@"Get the status of certification for given person")]
        [When(@"Get the certification status for given certfication type")]
        public void WhenGetValidRe_CertificationTransitionEventForGivenCertification()
        {
            if (testData.Uri.Contains("{0}"))
            {
                testData.User = DataScaffolding.PullCertifiedUser("PMP");
                testData.Uri = testData.Uri.Replace("{0}", testData.User.PersonId.ToString());
                expectedListValue = new List<string> { testData.User.PersonId.ToString() };
                if(testData.Uri.Contains("can-purchase"))
                    expectedListValue.Add(GetSkuCodes(testData.User.ApplicationType, "Exam"));
            }
            response = request.GetRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey), testData.Uri) ;
        }

        [Then(@"Verify raw certification configurations sttings response")]
        [Then(@"Verify all active vendor availability details")]
        public void VerifyingCertificationDetailsByObjectComparing()
        {
            utility.CompareTwoObjects(response);
        }

        [Then(@"Verify CCR cycle details")]
        [Then(@"Verify cycle details for given certification id")]
        [Then(@"Verify cycle details for given CCR cycle id and certification id")]
        [Then(@"Verify certification details by using specific user access token")]
        [Then(@"Verify certification details")]
        [Then(@"Verify business rule sttings response")]
        [Then(@"Verify ccr sttings response")]
        [Then(@"Verify certification configurations sttings response")]
        [Then(@"Verify certification configurations sttings by certification type response")]
        [Then(@"Verify raw certification configurations sttings by id response")]
        [Then(@"Verify raw certification configurations sttings by certification type response")]
        [Then(@"Verify certification general sttings response")]
        [Then(@"Verify enterprise sttings response")]
        [Then(@"Verify field validation sttings response")]
        [Then(@"Verify prerequisites to eligible for a specified certification type response")]
        [Then(@"Verify prerequisites to apply for a specified certification type response")]
        [Then(@"Verify exam details")]
        [Then(@"Verify exam vendor inbound transactions details by date range")]
        [Then(@"Verify exam vendor inbound transactions details from id")]
        [Then(@"Verify exam vendor inbound transactions details from person id")]
        [Then(@"Verify exam vendor outbound message events details by date range")]
        [Then(@"Verify exam vendor outbound message events details from id")]
        [Then(@"Verify exam vendor outbound message events details from person id")]
        [Then(@"Verify member type details by given person id")]
        [Then(@"Verify the details for given user")]
        [Then(@"Verify the established certification details for given application")]
        [Then(@"Verify new ccr cycle added for given certification id")]
        [Then(@"Verify respone details for exam by eligibility id")]
        [Then(@"Verify exam form respone details for an exam")]
        [Then(@"Verify exam results respone details for an exam id")]
        [Then(@"Verify respone details for vendor availability")]
        [Then(@"Verify exams response for given person")]
        [Then(@"Verify exams response for given person and certification type")]
        [Then(@"Verify active exams response for given person and certification type")]
        [Then(@"Verify an exam security result by examId")]
        [Then(@"Verify all exam security details")]
        [Then(@"Verify exam security details")]
        [Then(@"Verify an exam security summary result by personId")]
        [Then(@"Verify the panel reviewr details for given user")]
        [Then(@"Verify certification status details for given user")]
        [Then(@"Verify the person is eligible for given sku")]
        [Then(@"Verify apply prerequisites details for a given person")]
        [Then(@"Verify eligibility prerequisites details for a given person")]
        [Then(@"Verify waiting period details for a given person")]
        [Then(@"Verify eligibility get extended for given non application based exam response")]
        [Then(@"Verify exam vendor message events response by exam id")]
        [Then(@"Verify certification events response for given person id")]
        [Then(@"Verify exams response for given group exam id")]
        [Then(@"Verify response details for given person")]
        [Then(@"Verify response details for status of certifications")]
        [Then(@"Verify exam processing result")]
        [Then(@"verify result queued")]
        [Then(@"Verify person details")]
        [Then(@"Verify the profile details of PMI certification")]
        [Then(@"Verify the profile details of pmi and nonpmi certification")]
        [Then(@"Verify the profile education details")]
        [Then(@"Verify cert registry details for credential holder")]
        [Then(@"Verify exam processing result details")]
        [Then(@"Verify order payment successfull response details")]
        [Then(@"Verify the token details for an email template")]
        [Then(@"Verify the personalization details for an email template id")]
        [Then(@"Verify the attribute details for an email template id")]
        [Then(@"Verify request queue details for a given id")]
        [Then(@"Verify request queue batch details for a given batch number")]
        [Then(@"Verify the candidated uploaded details")]
        [Then(@"Verify status of certification details")]
        [Then(@"Verify apply status of certification for a given person id")]
        [Then(@"Verify eligible to pay status of certification for a given person id")]
        [Then(@"Verify the details of scheduled for an exam for a given person")]
        [Then(@"Verify the status of eligible to purchase for agiven person")]
        [Then(@"Verify the status details for a certification")]
        public void ThenVerifyCertificationResponseDetails()
        {
            utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue("Actual and Expected values are not met", false);
            utility.VerifyResponseStatusCode(response);
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }

        [When(@"Get and verify all valid transition for given certification")]
        public void WhenGetAndVerifyAllValidTransitionForGivenCertification()
        {
            response = request.GetRequestCallforMultipleTimesByAnIDSize(scenarioContext.Get<String>(TokenKey), testData.Uri, 3);
            Console.WriteLine("Get request and response are verified successfully");
        }

        [Then(@"Verify re-certification transition event details")]
        [Then(@"Verify valid transition event response")]
        [Then(@"Verify valid re-certification transition event response")]
        [Then(@"Verify that reschedule event should be created successfully")]
        [Then(@"Verify that schedule event should be created successfully")]
        [Then(@"Verify an exam security result to CRM by examId")]
        [Then(@"Verify the details of the person certification")]
        [Then(@"Verify suspended details for a given person")]
        [Then(@"Verify can renew details for a given person")]
        [Then(@"Verify lms course completed response details")]
        [Then(@"Verify the profile details of nonpmi certification")]
        [Then(@"Verify the email sent details")]
        [Then(@"Verify the processed batch details")]
        [Then(@"Verify request queue item details")]
        [Then(@"Verify the suspended status for certified credential")]
        [Then(@"Verify the status of person has a credential that is expired")]
        public void VerifyCertificationServiceResponseStatus()
        {
            utility.VerifyResponseStatusCode(response);
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }

        [When(@"Test and verify to read a value from db via ado")]
        public void WhenTestAndVerifyToReadAValueFromDbViaAdo()
        {
            var dic = utility.ReadValuesFromDataBase("Select top 10 * from Cert.CW_AuditStatus order by ID desc");
            dic.Should().NotBeNull();
        }

        #region Publish events to Service Bus
        [When(@"Publish and verify application eligible to pay event sent to servicebus")]
        [When(@"Publish and verify panel review failure event sent to servicebus")]
        [When(@"Publish and verify course completed event sent to servicebus")]
        [When(@"Publish and verify eligibility expired event sent to servicebus")]
        [When(@"Publish and verify exam accommodation rejected event sent to servicebus")]
        [When(@"Publish and verify exam accommodation requested event sent to servicebus")]
        [When(@"Publish and verify exam purchased event sent to servicebus")]
        [When(@"Publish and verify exam details completed event sent to servicebus")]
        [When(@"Publish and verify exam taken event sent to servicebus")]
        [When(@"Publish and verify exam scheduled event sent to servicebus")]
        [When(@"Publish and verify new certification event sent to servicebus")]
        public void PublishAndVerifyServiceBusEvents()
        {
            var scenarioTitle = scenarioContext.ScenarioInfo.Title.ToLower();
            if (scenarioTitle.Contains("eligible to pay event sent"))
                requestBody = requestBodyObject.SbApplicationETPAndPR;
            if (scenarioTitle.Contains("panel review failure event sent"))
                requestBody = requestBodyObject.SbApplicationETPAndPR;
            if (scenarioTitle.Contains("course completed event sent"))
                requestBody = requestBodyObject.SbCourseCompleted;
            if (scenarioTitle.Contains("eligibility expired event sent"))
                requestBody = requestBodyObject.SbEligibilityExpired;

            if (scenarioTitle.Contains("accommodation approved event sent") || scenarioTitle.Contains("accommodation rejected event sent") ||
                scenarioTitle.Contains("accommodation requested event sent") || scenarioTitle.Contains("exam details completed event sent"))
                requestBody = requestBodyObject.SbExamDetailsCompletedAndAccomm;

            if (scenarioTitle.Contains("purchased event sent"))
                requestBody = requestBodyObject.SbExamPurchased;
            if (scenarioTitle.Contains("exam taken event sent"))
                requestBody = requestBodyObject.SbExamTaken;
            if (scenarioTitle.Contains("exam scheduled event sent"))
                requestBody = requestBodyObject.SbExamScheduled;
            if (scenarioTitle.Contains("new certification event sent"))
                requestBody = requestBodyObject.SbNewCertification;
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBody);
            utility.VerifyResponseStatusCode(response);
        }
        #endregion

        [When(@"Get the can purchase for given person and sku")]
        public void WhenGetTheCanPurchaseForGivenPersonAndSku()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, testData.User.PersonId.ToString());
            expectedListValue = new List<string>() { testData.User.PersonId.ToString(), testData.User.ApplicationType };
        }

        [When(@"Get is waiting for a given person and certification type")]
        [When(@"Get is suspended for a given person and certification type")]
        [When(@"Get is can renew for a given person and certification type")]
        public void GetCertificationDetailsByPersonId()
        {
            string dbQuery = "";
            string certificationType = "";
            string scenarioTitle = scenarioContext.ScenarioInfo.Title.ToLower().Replace(" ", "");
            //string canDb = userSettings.Environment.ToString().Equals("CAN") ? "cert." : "";
            if (scenarioTitle.Contains("issuspended"))
                dbQuery = $"SELECT TOP 1 * FROM cert.CW_Certifications WHERE StatusID = 7 ORDER BY 1 DESC";
            if (scenarioTitle.Contains("iswaiting"))
            {
                dbQuery = "SELECT TOP 1 * FROM cert.CW_Applications WHERE StatusID = 5 ORDER BY 1 DESC";
                dbDicValues = utility.ReadValuesFromDataBase(dbQuery);
                certificationType = Enum.GetName(typeof(CertificationTypes), Convert.ToUInt16(dbDicValues.GetValueOrDefault("CertificationTypeID"))).Replace('_', '-');
                expectedListValue = new List<string> { dbDicValues.GetValueOrDefault("PersonID"), certificationType };
            }
            if (scenarioTitle.Contains("canrenew"))
            {
                dbQuery = $"SELECT TOP 1 * FROM cert.CW_Certifications WHERE StatusID = 1 and ReCertStatusID = 2 ORDER BY 1 DESC";
                dbDicValues = utility.ReadValuesFromDataBase(dbQuery);
                certificationType = Enum.GetName(typeof(CertificationTypes), Convert.ToUInt16(dbDicValues.GetValueOrDefault("CertificationTypeID"))).Replace('_', '-');
                expectedListValue = new List<string> { dbDicValues.GetValueOrDefault("PersonID"), certificationType, GetSkuCodes(certificationType, "Renewal").ToString() };
            }
            else { 
                dbDicValues = utility.ReadValuesFromDataBase(dbQuery);
            }
            certificationType = Enum.GetName(typeof(CertificationTypes), Convert.ToUInt16(dbDicValues.GetValueOrDefault("CertificationTypeID"))).Replace('_', '-');
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, dbDicValues.GetValueOrDefault("PersonID"), certificationType);
        }

        [When(@"Exam processing result queued")]
        public void WhenExamProcessingResultQueued()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri+"/queue", requestBodyObject.QueueExamProcessingResult);
        }

        [Then(@"Get queued exam processing result by id")]
        public void ThenGetQueuedExamProcessingResultById()
        {
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri+"/queued");
        }

        [When(@"Exam processing result dequeued")]
        public void WhenExamProcessingResultDequeued()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri + "/dequeue", requestBodyObject.QueueExamProcessingResult);
        }

        [Then(@"Verify result dequeued")]
        public void ThenVerifyResultDequeued()
        {
            utility.VerifyResourceDeleted(response);
        }

        [When(@"Post process order payment for all cert exams")]
        public object PostingACallBasedOnPersonIDByUsingDataScaffolding_ETP()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType);
            var scenarioTitle = scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper();
            if (scenarioTitle.Contains("PROCESSORDERPAYMENT"))
            {
                requestBodyObject.ProcessOrderPayment.PersonId = testData.User.PersonId;
                requestBody = requestBodyObject.ProcessOrderPayment;
            }
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBody);
            expectedListValue = new List<string> { testData.User.PersonId.ToString() };
            return testData.User;
        }

        [When(@"Process the batch and generate certificates for given batch number")]
        [When(@"Process the batch and generate certificates")]
        [When(@"Get the request queue item by request queue id")]
        [When(@"Process a candidate upload for an application")]
        public void WhenProcessTheBatchAndGenerateCertificatesForGivenBatchNumber()
        {
            requestBody = null;
            if (scenarioContext.StepContext.StepInfo.Text.Replace(" ", "").Equals("Processthebatchandgeneratecertificates"))
                requestBody = userSettings.Environment.ToUpper().Equals("QA") ? requestBodyObject.ProcesssBatch = new List<long> { 1 } : requestBodyObject.ProcesssBatch;
            if (scenarioContext.StepContext.StepInfo.Text.Replace(" ", "").ToUpper().Contains("CANDIDATEUPLOAD"))
            {
                testData.User = DataScaffolding.PullCertifiedUser("PMP");
                requestBodyObject.CandidateUpload.ForEach(x => { 
                    x.PmiId = testData.User.PersonId;
                    x.FirstName = testData.User.FirstName; 
                    x.LastName = testData.User.LastName;
                    });
                requestBody = requestBodyObject.CandidateUpload;

                expectedListValue = new List<string> { testData.User.PersonId.ToString(), testData.User.FirstName, testData.User.LastName };
            }

            response = request.PostRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBody);
        }

        [When(@"Get the status of given person has a credential that is scheduled for an exam")]
        public void WhenGetTheStatusOfGivenPersonHasACredentialThatIsScheduledForAnExam()
        {
            dbDicValues = utility.ReadValuesFromDataBase("SELECT TOP 1 * FROM cert.CW_Exams WHERE ExamStatus=2 and CertificationTypeID = 1 and DateScheduled is not null and Scheduled = 1 ORDER BY DateScheduled DESC");
            var date = DateTime.Parse(dbDicValues.GetValueOrDefault("DateScheduled")).ToString("yyyy-MM-ddThh:mm:ss");
            expectedListValue = new List<string> { dbDicValues.GetValueOrDefault("PersonID"), date };
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, dbDicValues.GetValueOrDefault("PersonID"));
        }
    }
}
