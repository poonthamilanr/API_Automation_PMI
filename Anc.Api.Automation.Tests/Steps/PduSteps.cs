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
    using TechTalk.SpecFlow.CommonModels;

    [Binding]
    public class PduSteps
    {
        private const string TokenKey = "Token";
        public static string ExamType = "ExamType";

        private readonly IdentityToken identityToken;
        private readonly ScenarioContext scenarioContext;
        public static IRestResponse response;
        private readonly TestData testData;
        private readonly Utility utility;
        private readonly CertificationAllRequests request;

        public PduSteps(ScenarioContext scenarioCont, IdentityToken identityTok, TestData testData)
        {
            scenarioContext = scenarioCont;
            identityToken = identityTok;
            this.testData = testData;
            utility = new Utility(scenarioContext, testData);
            request = new CertificationAllRequests(testData);
        }

        [Given(@"Generate access token for PDU application")]
        public void GenerateAccessTokenForPDUApplication()
        {
            var idpToken = identityToken.GetIdpToken();
            scenarioContext[TokenKey] = idpToken;
        }

        [When(@"Get claim review rules details")]
        public void WhenGetClaimReviewRulesDetails()
        {
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }

        [Then(@"Verify claim review rule response details")]
        [Then(@"Verify that executed maxlimitpdurule claim review rule")]
        public void ThenVerifyClaimReviewRuleResponseDetails()
        {
            utility.CompareTwoObjects(response);
        }

        [When(@"Post the MaxLimitPduRule review rule for an pdu claim")]
        public void WhenPostTheMaxLimitPduRuleReviewRuleForAnPduClaim()
        {
            response = request.GetRequestCall(scenarioContext.Get<String>(TokenKey), testData.Uri);
        }
    }
}
