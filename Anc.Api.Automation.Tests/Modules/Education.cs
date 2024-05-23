#pragma warning disable 649
#pragma warning disable 169
using Anc.Api.Automation.Tests.Hooks;
using Anc.Api.Automation.Tests.Models;
using Anc.Api.Automation.Tests.Provider;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Pmi.Api.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace Anc.Api.Automation.Tests.Modules
{
    public class Education : BaseProvider
    {
        private readonly IRequestCalls requestCalls;
        private RestResponse response;
        public Education(ScenarioContext scenarioCont, TestData testData)
        {
            requestCalls = Container.Resolve<IRequestCalls>();
        }

        public bool DeleteEducation(string token,string educationID, string appID)
        {
            var delExpFlag = false;
            if (educationID!=null && token != null)
            {
                response = requestCalls.DeleteRequestCall(token, $"/applications/{appID}/Education/{educationID}");
                response.StatusCode.Should().Be(HttpStatusCode.OK, $"Delete request has not processed for Experience ID:\r{educationID} and App ID:\r{appID}");
                delExpFlag = true;
            }
            return delExpFlag;
        }

        public bool VerifyEducationDeleted(IRestResponse response)
        {
            var eduFlag = false;
            if (response != null)
            {
                response.Content.Deserialize<AddEducationResponse>().Resources.ToArray().Length.Should().Be(0,$"Education details not deleted, found {response.Content.Deserialize<AddEducationResponse>().Resources.ToArray().Length} records");
                eduFlag=true;
            }
            return eduFlag;
        }
    }
}
