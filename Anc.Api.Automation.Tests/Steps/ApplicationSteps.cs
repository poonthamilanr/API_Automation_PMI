using Anc.Api.Automation.Tests.Hooks;
using Anc.Api.Automation.Tests.Modules;
using Anc.Api.Automation.Tests.Utilities;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using CertificationAllRequests = Anc.Api.Automation.Tests.Utilities.CertificationAllRequests;
using FluentAssertions;
using System.Net;
using Anc.Api.Automation.Tests.Models;
using Newtonsoft.Json;

namespace Anc.Api.Automation.Tests.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        private const string TokenKey = "Token";
        public static string ExamType = "ExamType";
        public static string AppID = "AppID";
        public static string ExpID = "ExpID";
        public static string EducationID = "EducationID";
        List<string> experienceList = new List<string>();
        List<string> experienceProjectList = new List<string>();
        private readonly IdentityToken identityToken;
        private readonly ScenarioContext scenarioContext;
        private readonly CertificationAllRequests request;
        private readonly Experience experience;
        private readonly Education education;
        public List<string> expectedListValue;

        //private UserDetails userDetails;
        private IRestResponse response;
        private readonly Utility utility;
        private readonly TestData testData;
        public static Dictionary<string, string> expectedResultFromDB;
        public ApplicationRequest requestBodyObject = JsonConvert.DeserializeObject<ApplicationRequest>(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/RequestBody/Application.Json"));



        public ApplicationSteps(ScenarioContext scenarioContext, IdentityToken identityToken, RestResponse response, TestData testData, Experience experience, Education education)
        {
            this.experience = experience;
            this.education = education;
            this.scenarioContext = scenarioContext;
            this.identityToken = identityToken;
            request = new CertificationAllRequests(testData);
            this.response = response;
            this.testData = testData;
            utility = new Utility(scenarioContext, testData);
        }

        [Given(@"Generate access token for application service")]
        public void GenerateAccessTokenForApplicationService()
        {
            scenarioContext[TokenKey] = identityToken.GetIdpToken();
        }

        [Then(@"Verify audit details for an application")]
        [Then(@"Verify that Submit reset audit event for an applicat")]
        [Then(@"Verify application details")]
        [Then(@"Verify the response of executed appreview rulr for that application")]
        [Then(@"Verify experience details")]
        [Then(@"Verify application review rule by id")]
        [Then(@"Verify application review rule types")]
        [Then(@"Verify that application reviewed by all application review rules")]
        [Then(@"Verify academic details by application id")]
        [Then(@"Verify application requirement settings by credentials")]
        [Then(@"Verify applications business rule settings")]
        [Then(@"Verify certifications general settings")]
        [Then(@"Verify applications enterprise settings")]
        [Then(@"Verify experience details by Experience ID")]
        [Then(@"Verify name on certificate by application ID")]
        [Then(@"Verify experience requirenment for pmp application by worktype")]
        [Then(@"Verify education requirenment for pmp application")]
        [Then(@"Verify requirenment status for an application")]
        [Then(@"Verify valid transition event details for an application by ID")]
        [Then(@"Verify Experience summary comment details for an application by ID")]
        [Then(@"Verify application details response by person ID")]
        [Then(@"Verify exams identification address")]
        [Then(@"Verify exams by exam id")]
        [Then(@"Verify exams by application id")]
        [Then(@"Verify exams identification name")]
        [Then(@"Verify active exam record for given application")]
        [Then(@"Verify experience for a given application")]
        [Then(@"Verify experience by experience id")]
        [Then(@"Verify experience hours for a given application")]
        [Then(@"Verify experience projects for a given application")]
        [Then(@"Verify experience summery for a given application")]
        [Then(@"Verify open experience summery for a given application")]
        [Then(@"Verify active application details for a given person and credential type and create if none exists")]
        [Then(@"Verify a list of audit documents by application id")]
        [Then(@"Verify audit summary by certification type")]
        [Then(@"Verify blob storage document details")]
        [Then(@"Verify docusign documents details")]
        [Then(@"Verify reponse of education for aplication id")]
        [Then(@"Verify reponse for education by id")]
        [Then(@"Verify response for education history that can be applied the given application id")]
        [Then(@"Verify experience summary questions for application id and experience summary id")]
        [Then(@"Verify experience summary questions by id")]
        [Then(@"Verify experience summary answers for application id and experience summary id")]
        [Then(@"Verify experience summary answers by question id")]
        [Then(@"Verify group exam details by id")]
        [Then(@"Verify groups exam details by identifier")]
        [Then(@"Verify created application details for a given person")]
        [Then(@"Verify payment information for open application details for a given person")]
        [Then(@"Verify all application details for a given person for mypmi")]
        [Then(@"Verify the application details with a specific user access token")]
        [Then(@"Verify response details of specific user that eligible or not to apply for an application")]
        [Then(@"Verify application creation eligibility details for a specific user access token")]
        [Then(@"Verify the details opened application details for a given credential type using specific user access token")]
        [Then(@"Verify payment information for open application details for a specific user access token")]
        [Then(@"Verify education")]
        [Then(@"Verify applied application review rule against a specified application")]
        [Then(@"Verify application review against a specified application")]
        [Then(@"Verify application review against a specified application in preview mode")]
        [Then(@"Verify experience hours details")]
        [Then(@"Verify experience project details")]
        [Then(@"Verify experience summery details")]
        [Then(@"Verify created application details of specific user that eligible or not to apply for an application")]
        [Then(@"Verify created docusign envelope details")]
        [Then(@"Verify experience")]
        [Then(@"Verify other experience")]
        [Then(@"Verify audit reference request sent")]
        [Then(@"Verify the response for audit expiration date updated for given application")]
        [Then(@"Verify that blob document is updated for an application")]
        [Then(@"Verify open application details for a given person")]
        [Then(@"Verify added new application details for a given person and credential type")]
        [Then(@"Verify the response of reopen event for given application")]
        [Then(@"Verify the response of close expire event for given application")]
        [Then(@"Verify the response of close event for given application")]
        [Then(@"Verify group number is set for given application")]
        [Then(@"Verify application approved event details for a given application")]
        [Then(@"Verify application audit event details for a given application")]
        [Then(@"Verify submitted payment details")]
        [Then(@"Verify extended eligibility details")]
        [Then(@"Verify rejected application detail")]
        [Then(@"Verify all values in an application for a given person")]
        [Then(@"Verify response for given panel reviewer")]
        [Then(@"Verify experience project")]
        [Then(@"Verify other experience project")]
        public void ThenVerifyResponseDetails()
        {
            utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue("Actual and Expected values are not met", false);
            utility.VerifyResponseStatusCode(response);
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }

        [Then(@"Verify application review rules details")]
        public void ThenVerifyResponseDetailsByComparingTwoObjects()
        {
            ThenVerifyResponseDetails();
            //utility.CompareTwoObjects(response).Should().BeNullOrEmpty("There is difference between expected result and actual result");
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }

        #region Application module
        [When(@"Get academic details by application id")]
        [When(@"Get application details by id")]
        [When(@"Get experience details")]
        [When(@"Get experience details by Experience ID")]
        [When(@"Get name on certificate by application ID")]
        [When(@"Get experience requirenment for pmp application by worktype")]
        [When(@"Get education requirenment for pmp application")]
        [When(@"Get requirenment status for an application")]
        [When(@"Get valid transition event details for an application by ID")]
        [When(@"Get and verify assignment score for an application by ID")]
        [When(@"Get Experience summary comment for an application by ID")]
        [When(@"Get application details by person ID")]
        [When(@"Get exams identification address")]
        [When(@"Get exams by exam id")]
        [When(@"Get exams by application id")]
        [When(@"Get exams identification name")]
        [When(@"Get active exam record for given application")]
        [When(@"Get experience for a given application")]
        [When(@"Get experience by experience id")]
        [When(@"Get experience hours for a given application")]
        [When(@"Get experience projects for a given application")]
        [When(@"Get experience summery for a given application")]
        [When(@"Get open experience summery for a given application")]
        [When(@"Get a list of audit documents by application id")]
        [When(@"Download blob storage document by Audit document id")]
        [When(@"Download multiple docusign docuemnts for given application id")]
        [When(@"Get eductaion for a given application id")]
        [When(@"Get eductaion by id")]
        [When(@"Get education history that can be applied the given application id")]
        [When(@"Get experience summary questions for application id and experience summary id")]
        [When(@"Get experience summary questions by providing id")]
        [When(@"Get experience summary answers for application id and experience summary id")]
        [When(@"Get experience summary answers by question id")]
        [When(@"Get group exam details by id")]
        [When(@"Get groups exam details by identifier")]
        [When(@"Get payment information for open application for a given person and credential type")]
        [When(@"Get application details for a given person and credential type")]
        [When(@"Get application details for a given person for mypmi")]
        [When(@"Get experience hours details")]
        [When(@"Get experience project details")]
        [When(@"Get experience summery details")]
        [When(@"Get application requirement settings by credentials")]
        [When(@"Get applications business rule settings")]
        [When(@"Get certifications general settings")]
        [When(@"Get applications enterprise settings")]
        [When(@"Get panel reviwer assignments and status by person id")]
        [When(@"Get audit details by id for an application")]
        [When(@"Get application review rule by rule id")]
        [When(@"Get application review rule types")]
        [When(@"Get application review by application id")]
        public void GettingGetRequestForApllicationService()
        {
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
            Console.WriteLine("Appplication service get call request has completed");
        }


        [When(@"Get create application for a given person and credential type")]
        [When(@"Get active application for a given person and credential type and create if none exists")]
        public void WhenGetCreateApplicationForAGivenPersonAndCredentialType_Registered()
        {
            testData.User = DataScaffolding.PullRegisteredUser(testData.Country);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, testData.User.PersonId.ToString(), testData.DataScaffoldingApplicationType);
            expectedListValue = new List<string>() { testData.User.PersonId.ToString() };
        }
        [When(@"Get open application details for a given person and credential type")]
        public void WhenGetCreateApplicationForAGivenPersonAndCredentialType_ETP()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, testData.User.PersonId.ToString(), testData.User.ApplicationType);
            expectedListValue = new List<string>() { testData.User.PersonId.ToString() };
        }


        [When(@"Get and Verify the all valid transitions for a given application")]
        public void WhenGetTheValidTransitionForAGivenApplication()
        {
            response = request.GetRequestCallforMultipleTimesByAnIDSize(scenarioContext.Get<String>(TokenKey), testData.Uri, 34);
            Console.WriteLine("Get request and response are verified successfully");
        }
        #endregion

        [When(@"Get a list of audit documents by application id using specific user access token")]
        [When(@"Get audit summary by certification type using specific user access token")]
        [When(@"Get an application details with a specific user access token")]
        [When(@"Get the status os user whether thay are eligible or not to apply with a specific user access token")]
        [When(@"Get payment information for open application for a specific user access token")]
        public void WhenGetAListOfAuditDocumentsByApplicationIdUsingSpecificUserAccessToken()
        {
            scenarioContext[TokenKey] = identityToken.GetIdpToken(testData.UserName);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Submit new application for a given person and credential type")]
        public void PostCallBasedOnPersonIdWithDataScaffoldingUser()
        {
            testData.User = DataScaffolding.PullRegisteredUser();
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, testData.User.PersonId.ToString());
            expectedListValue = new List<string>() { testData.User.PersonId.ToString(), "PMP" };
        }

        [When(@"Get an user eligible to create application for a credential type")]
        [When(@"Get active application for a credential type and create if none exists for a specific user access token")]
        public void RequestingGetCallWithUserSpecificTokened_Registered()
        {
            testData.User = DataScaffolding.PullRegisteredUser();
            scenarioContext[TokenKey] = identityToken.GetIdpToken(testData.User.UserName, testData.User.Password);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Get opened application details for a given credential type using specific user access token")]
        public void RequestingGetCallWithUserSpecificTokened_ETP()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            scenarioContext[TokenKey] = identityToken.GetIdpToken(testData.User.UserName, testData.User.Password);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Submit the reopen event for given application")]
        [When(@"Submit the close expire event for given application")]
        [When(@"Submit the close event for given application")]
        public object PostingACallBasedOnApplicationIDByUsingDataScaffolding_ETP()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, testData.User.ApplicationId);
            expectedListValue = new List<string> { testData.User.ApplicationId, testData.User.PersonId.ToString(), testData.User.ApplicationType };
            return testData.User;
        }

        [When(@"Submit approve event for a given application")]
        [When(@"Submit audit event for a given application")]
        [When(@"Reject an application for a given application id")]
        public object PostingACallBasedOnApplicationIDByUsingDataScaffolding_CertSubmitted()
        {
            var userData = utility.ReadValuesFromDataBase("SELECT\r\nTOP 1\r\nc.PersonID as PersonID\r\n, p.FirstName + ' ' + p.LastName as Name\r\n, s.UserName, c.ID as ApplicationID, c.CertificationTypeID\r\nFROM\r\ncert.CW_Applications c\r\nJOIN Persons p ON p.ID = c.PersonID\r\nJOIN SecurityUsers s ON s.UserID = c.PersonID\r\nJOIN Addresses a on a.personid = c.personid\r\nWHERE\r\nc.CertificationTypeID = 1\r\nand\r\nc.statusid = 1 --Submitted --8 = audit\r\nORDER BY NEWID()");
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, userData.GetValueOrDefault("ApplicationID"));
            expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP" };
            return testData.User;
        }

        [When(@"Submit the group number for given application")]
        [When(@"Provide application id of specified application")]
        [When(@"Provide application id and rule id")]
        [When(@"Provide application id of specified application for preview")]
        [When(@"Submit an application review rule for an application")]
        public void WhenPostTheGroupNumberForGivenApplication()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
            Console.WriteLine("Successfully When step got completed");
        }

        [When(@"Add education")]
        public void Postthegroupnumberforgivenapplication()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.AddNewEducationRequestBody);
            scenarioContext[EducationID] = utility.ReadAValueFromResponseContentHref(response, "href", "Education");
            scenarioContext[AppID] = utility.ReadAValueFromResponseContentHref(response, "applicationId");
            Console.WriteLine("Successfully When step got completed");
        }

        [When(@"Education details deleted")]
        public void WhenEducationDetailsDeleted()
        {
            education.DeleteEducation(scenarioContext.Get<String>(TokenKey), scenarioContext.Get<String>(EducationID), scenarioContext.Get<String>(AppID)).Should().BeTrue();
        }

        [Then(@"Education should be deleted")]
        public void ThenEducationShouldBeDeleted()
        {
            education.VerifyEducationDeleted(response).Should().BeTrue();
        }

        //Audit scenarios are required submitted user generation
        [When(@"Submit and verify audit document received event for a given application followed by audit event")]
        [When(@"Submit and verify audit fail event for a given application followed by audit event")]
        [When(@"Submit and verify audit grant extension event for a given application followed by audit event")]
        [When(@"Submit and verify audit reset event for a given application followed by audit event")]
        [When(@"Submit and verify audit reset docs not received event for a given application followed by audit event")]
        public void WhenPostAuditDocumentReceivedEventForAGivenApplicationFollowedByAuditEvent()
        {
            var userData = utility.ReadValuesFromDataBase("SELECT\r\nTOP 1\r\nc.PersonID as PersonID\r\n, p.FirstName + ' ' + p.LastName as Name\r\n, s.UserName, c.ID as ApplicationID, c.CertificationTypeID\r\nFROM\r\ncert.CW_Applications c\r\nJOIN Persons p ON p.ID = c.PersonID\r\nJOIN SecurityUsers s ON s.UserID = c.PersonID\r\nJOIN Addresses a on a.personid = c.personid\r\nWHERE\r\nc.CertificationTypeID = 1\r\nand\r\nc.statusid = 1 --Submitted --8 = audit\r\nORDER BY NEWID()");
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, userData.GetValueOrDefault("ApplicationID"), "audit");
            expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "AuditInProgress", "Pending", "CBT", "English", "PearsonVUE" };
            Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r moved to audit state");
            utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);

            var secondUriValue = "";
            if (scenarioContext.ScenarioInfo.Title.ToUpper().Replace(" ", "").Contains("AUDITDOCUMENTRECEIVED"))
            {
                secondUriValue = "audit-documentation-received";
                expectedListValue.Clear();
                expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "AuditDocumentationReceived", "Pending", "CBT", "English", "PearsonVUE" };
                response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, userData.GetValueOrDefault("ApplicationID"), secondUriValue);
                Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r moved to audit-documentation-received state");
                utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);
            }
            else if (scenarioContext.ScenarioInfo.Title.ToUpper().Replace(" ", "").Contains("AUDITFAIL"))
            {
                secondUriValue = "audit-fail";
                expectedListValue.Clear();
                expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "ClosedFailAudit", "AuditedAndFailed", "Pending", "CBT", "English", "PearsonVUE" };
                response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.AuditFailRequestBody, userData.GetValueOrDefault("ApplicationID"), secondUriValue);
                Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r moved to audit-fail state");
                utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);
            }
            else if (scenarioContext.ScenarioInfo.Title.ToUpper().Replace(" ", "").Contains("AUDITRESETDOCSNOTRECEIVED"))
            {
                secondUriValue = "audit-documentation-received";
                expectedListValue.Clear();
                expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "AuditDocumentationReceived", "Pending", "CBT", "English", "PearsonVUE" };
                response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, userData.GetValueOrDefault("ApplicationID"), secondUriValue);
                Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r moved to audit-documentation-received state");
                utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);

                secondUriValue = "audit-reset-docs-not-received";
                expectedListValue.Clear();
                expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "AuditInProgress", "Pending", "CBT", "English", "PearsonVUE" };
                response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, null, userData.GetValueOrDefault("ApplicationID"), secondUriValue);
                Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r moved to audit-reset-docs-not-received state");
                utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);
            }
            else
            {
                if (scenarioContext.ScenarioInfo.Title.ToUpper().Replace(" ", "").Contains("AUDITGRANTEXTENSION"))
                    secondUriValue = "audit-grant-extension";
                if (scenarioContext.ScenarioInfo.Title.ToUpper().Replace(" ", "").Contains("AUDITRESET"))
                    secondUriValue = "audit-reset";

                string currentDate = DateTime.Now.AddDays(250).ToString("yyyy-MM-ddT00:00:00");
                expectedListValue.Clear();
                expectedListValue = new List<string> { userData.GetValueOrDefault("ApplicationID"), userData.GetValueOrDefault("PersonID"), "PMP", "Audit", "AuditInProgress", "Pending", "CBT", "English", "PearsonVUE" };
                requestBodyObject.AuditDueDateRequestBody.AuditDueDateParameters.AuditDueDate = currentDate;
                response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.AuditDueDateRequestBody, userData.GetValueOrDefault("ApplicationID"), secondUriValue);
                Console.WriteLine($"Successfully this Application:\r {userData.GetValueOrDefault("ApplicationID")}\r due date extended due to this: \r{secondUriValue} \nevent & the extended dateis:\r{currentDate}");
                utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);
            }
        }

        [When(@"Submit create a docusign envelope manually")]
        [When(@"Update audit expiration date for given application")]
        public void PostRequestCallWithQueryString()
        {
            response = request.PostRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey), testData.Uri);
            Console.WriteLine($"Successfully docusign envelope has been created for an user");
        }

        [When(@"Submit extend eligibility event for a given application")]
        public void WhenPostExtendEligibilityEventForAGivenApplication()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            string currentDate = DateTime.Now.AddYears(1).ToString("yyyy-MM-ddT00:00:00");
            expectedListValue = new List<string> { testData.User.ApplicationId, testData.User.PersonId.ToString(), testData.User.ApplicationType, "Audit", "Pending", "CBT", "English", "PearsonVUE" };
            requestBodyObject.EligibilityEndDateRequestBody.EligibilityEndDateParameters.EligibilityEndDate = currentDate;
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.EligibilityEndDateRequestBody, testData.User.ApplicationId);
            Console.WriteLine($"Successfully this Application:\r {testData.User.ApplicationId}\r eligiblity date extended upto: \r{currentDate}");
        }

        [When(@"Submit payment event for a given application '([^']*)'")]
        public IRestResponse WhenPostSubmitPaymentEventForAGivenApplication(string uri = null)
        {
            if (testData.User == null)
                testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            if (uri == null || uri == "uri")
                uri = testData.Uri;
            //requestBodyObject.SubmitPaymentRequestBody.SubmitPaymentParameter.PersonId = testData.User.PersonId;
            if (testData.DataScaffoldingApplicationType == "PMI-SP")
                requestBodyObject.SubmitPaymentRequestBody.SubmitPaymentParameter.Sku = 6700038;
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), uri, requestBodyObject.SubmitPaymentRequestBody, testData.User.ApplicationId);
            expectedListValue = new List<string> { testData.User.ApplicationId, testData.User.PersonId.ToString(), testData.User.ApplicationType };
            Console.WriteLine($"Successfully payment has been submitted for this application ID & Person ID:\r {testData.User.ApplicationId} & {testData.User.PersonId}\r and this application momved to Eligible for exam state");
            return response;
        }

        #region
        [When(@"Add experience")]
        [Then(@"Add other experience")]
        public void WhenAddExperienceAndGetExperienceID()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.ExperienceRequestBody);
            experienceList.Add(utility.ReadAValueFromResponseContentHref(response, "href", "Experience"));
            scenarioContext[AppID] = utility.ReadAValueFromResponseContentHref(response, "applicationId");
            Console.WriteLine($"Successfully experience added and able to get Experience ID:\r{utility.ReadAValueFromResponseContentHref(response, "Experience")} and Application ID:\r{scenarioContext.Get<String>(AppID)}");
        }

        [Then(@"Delete all experience")]
        public void ThenDeleteAllExperienceAndVerify()
        {
            experience.DeleteAllExperience(scenarioContext.Get<String>(TokenKey), experienceList, scenarioContext.Get<String>(AppID)).Should().BeTrue();
        }

        [Then(@"Verify experience deleted")]
        public void ThenVerifyExperienceDeleted()
        {
            experience.VerifyAllExperienceDeleted(response);
            Console.WriteLine($"Successfully able to delete all experience");
        }
        [When(@"Provide and send audit refernce request")]
        public void WhenPostAuditRefernceRequest()
        {
            requestBodyObject.SendAuditReferenceRequestBody.AuditDocumentId = Convert.ToInt64(testData.ExpectedResponseData.Split('|').ToList().First()); ;
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.SendAuditReferenceRequestBody);
            Console.WriteLine($"Successfully the reference email has sent to this email id:\r{requestBodyObject.SendAuditReferenceRequestBody.ReferenceEmail}");
        }

        [When(@"Update the blob document for an application by audiy document Id")]
        public void WhenUpdateTheBlobDocumentForAnApplicationByAudiyDocumentId()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.BlobDocumentUploadRequestBody);
            Console.WriteLine($"Successfully the blob document has updated for this document id:\r{requestBodyObject.BlobDocumentUploadRequestBody.Id}");
        }
        #endregion

        [When(@"Request special accommodation for an exam")]
        public void WhenRequestSpecialAccommodationForAnExam()
        {
            testData.User = DataScaffolding.PullEligibleToPayUser(testData.DataScaffoldingApplicationType, testData.Country);
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), "/applications/{0}/Exams", testData.User.ApplicationId);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var examId = utility.ReadAValueFromResponseContentHref(response, "href", "Exams/");
            response = request.PutRequestCall(scenarioContext.Get<String>(TokenKey), "/applications/{0}/Exams/{1}/exam-accommodation", null
                , testData.User.ApplicationId, examId, "isAccommodationsRequired:true");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            WhenPostSubmitPaymentEventForAGivenApplication("/Applications/{0}/submit-payment");
        }

        [Then(@"Verify special accommodation requested details")]
        public void ThenVerifySpecialAccommodationRequestedDetails()
        {
            expectedListValue = new List<string> { testData.User.ApplicationId, testData.User.PersonId.ToString(), testData.User.ApplicationType, "SpecialAccomPending", "requested", "true" };
            utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue($"Actual and Expected values are not met: {response.Content}", false);
        }

        [Then(@"Approve special accommodation request for a given application and exam id")]
        public void ThenApproveSpecialAccommodationRequestForAGivenApplicationAndExamId()
        {
            response = request.PostRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey),
                testData.Uri, requestBodyObject.SpecialAccommodationRequestBody, testData.User.ApplicationId, null, $"personId:{testData.User.PersonId}");
        }

        [Then(@"Verify that special accommodation are approved")]
        public void ThenVerifyThatSpecialAccommodationAreApproved()
        {
            expectedListValue.Clear();
            expectedListValue = new List<string> { testData.User.ApplicationId, testData.User.PersonId.ToString(), testData.User.ApplicationType, "EligibleForExam" };
            utility.VerifyResponseBodyDetails(response, expectedListValue);
        }

        [When(@"Provide Panel reviewer person id details")]
        public void WhenProvidePanelReveiwerPersonIdDetails()
        {
            scenarioContext[TokenKey] = identityToken.GetIdpToken();
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [When(@"Add experience project")]
        [Then(@"Add other experience project")]
        public void WhenAddExperienceProject()
        {
            response = request.PostRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri, requestBodyObject.ExperienceProjectRequestBody);
            experienceProjectList.Add(utility.ReadAValueFromResponseContentHref(response, "href", "ExperienceProjects"));
            scenarioContext[AppID] = utility.ReadAValueFromResponseContentHref(response, "href", "applications");
            scenarioContext[ExpID] = utility.ReadAValueFromResponseContentHref(response, "experienceId");
            Console.WriteLine($"Successfully experience added and able to get Experience Project ID:\r{utility.ReadAValueFromResponseContentHref(response, "ExperienceProjects")}");
        }

        [Then(@"Delete all experience project")]
        public void ThenDeleteAllExperienceProject()
        {
            experience.DeleteAllExperienceProjects(scenarioContext.Get<String>(TokenKey), experienceProjectList, scenarioContext.Get<String>(AppID), scenarioContext.Get<String>(ExpID)).Should().BeTrue();
        }

        [Then(@"Verify experience project deleted")]
        public void ThenVerifyExperienceProjectDeleted()
        {
            experience.VerifyAllExperienceProjectsDeleted(response);
        }
        [When(@"Get application review rules")]
        public void GetRequestCallWithQueryString()
        {
            response = request.GetRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }
    }
}
