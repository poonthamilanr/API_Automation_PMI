using Anc.Api.Automation.Tests.Hooks;
using Anc.Api.Automation.Tests.Modules;
using Anc.Api.Automation.Tests.Utilities;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using CertificationAllRequests = Anc.Api.Automation.Tests.Utilities.CertificationAllRequests;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;
using Anc.Api.Automation.Tests.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Anc.Api.Automation.Tests.Steps
{
    [Binding]
    public class WebReportSteps
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
        public List<string> expectedListValue;
        public string[] fileListString;
        private IRestResponse response;
        private readonly Utility utility;
        private readonly TestData testData;
        public static Dictionary<string, string> expectedResultFromDB;
        public ApplicationRequest requestBodyObject = JsonConvert.DeserializeObject<ApplicationRequest>(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/RequestBody/Application.Json"));

        public WebReportSteps(ScenarioContext scenarioContext, IdentityToken identityToken, CertificationAllRequests request, RestResponse response, TestData testData)
        {
            this.scenarioContext = scenarioContext;
            this.identityToken = identityToken;
            this.request = request;
            this.response = response;
            this.testData = testData;
            utility = new Utility(scenarioContext, testData);
        }

        [Given(@"Generate access token for Webreport service")]
        public void GenerateAccessTokenForApplicationService()
        {
            scenarioContext[TokenKey] = identityToken.GetIdpToken();
        }

        [When(@"Get certificate for a certified user by person id and certification type")]
        [When(@"Get eco report details by providing person id and exam id")]
        [When(@"Get cycle summary report by providing person id")]
        [When(@"Get candidate batch details")]
        [When(@"Get application report based on person id and application id")]
        [When(@"Get transcript by passing person id")]
        [When(@"Get audit report details by providing application id and experience id")]
        [When(@"Get cover letter report details")]
        public void WhenGetCertificateForACertifiedUserByPersonIdAndCertificationType()
        {
            var fileName = "";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("ECOREPORT"))
                fileName = "EcoReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("TRANSCRIPT"))
                fileName = "TranscriptReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("CYCLESUMMARY"))
                fileName = "CycleSummaryReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("BATCHDETAILS"))
                fileName = "BatchClaimDetailReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("AUDITREPORT"))
                fileName = "AuditReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("APPLICATIONREPORT"))
                fileName = "ApplicationReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("CREDENTIALCERTIFICATE"))
                fileName = "CertificateReport";
            if (scenarioContext.ScenarioInfo.Title.Replace(" ", "").ToUpper().Contains("COVERLETTER"))
                fileName = "CoverLetter";
            response = request.GetRequestCallWithQueryString(scenarioContext.Get<String>(TokenKey), testData.Uri);
            fileListString = utility.DownloadPDFFileFromResponceContent(response, fileName);
        }

        [When(@"Get packing list details")]
        public void GettingGetRequestForWebReportService()
        {
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
            Console.WriteLine("WebReport service get call request has completed");
        }

        [Then(@"Verify the certificate details")]
        [Then(@"Verify the generated eco report")]
        [Then(@"Verify the generated audit report")]
        [Then(@"Verify the generated cycle summary report")]
        [Then(@"Verify the batch details")]
        [Then(@"Verify the application report")]
        [Then(@"Verify the transcript details")]
        public void VerifyWebReportResponseDetails()
        {
            utility.VerifyResponseBodyDetails(response, expectedListValue).Should().BeTrue("Actual and Expected values are not met", false);
            utility.VerifyResponseStatusCode(response);
            utility.PDFValidation(fileListString[0]); 
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }

        [Then(@"Verify the generated cover letter")]
        [Then(@"Verify the generated packing list details")]
        public void VerifyWebReportResponseDetailsWithStatusCode()
        {
            utility.VerifyResponseStatusCode(response);
            Console.WriteLine("Response content verification has been completed successfully. Responce Status Code: " + response.StatusCode);
        }
    }
}
