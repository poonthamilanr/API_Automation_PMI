#pragma warning disable 649
#pragma warning disable 169
using TechTalk.SpecFlow;
using Anc.Api.Automation.Tests.Hooks;
using Anc.Api.Automation.Tests.Models;
using Anc.Api.Automation.Tests.Provider;
using Pmi.Api.Framework;
using RestSharp;
using System.Collections.Generic;
using FluentAssertions;
using System.Net;
using System.Linq;
using Microsoft.Practices.Unity;

namespace Anc.Api.Automation.Tests.Modules
{
    public class Experience : BaseProvider
    {
        private readonly IRequestCalls requestCalls;
        private readonly ScenarioContext scenarioContext;
        private RestResponse response;
        private AddExperienceResponse addExperienceResponse;
        public Experience(ScenarioContext scenarioCont, TestData testData)
        {
            requestCalls = Container.Resolve<IRequestCalls>();
            scenarioContext = scenarioCont;
        }

        public bool DeleteAllExperience(string token,List<string> listOfExpID, string appID)
        {
            var delExpFlag = false;
            if (listOfExpID.Count>0&& token!=null)
            {
                foreach (string expID in listOfExpID){
                    response = requestCalls.DeleteRequestCall(token, $"/applications/{appID}/Experience/{expID}");
                    response.StatusCode.Should().Be(HttpStatusCode.OK, $"Delete request has not processed for Experience ID:\r{expID} and App ID:\r{appID}");
                }
                delExpFlag= true;
            }
            return delExpFlag;
        }

        public bool VerifyAllExperienceDeleted(IRestResponse response)
        {
            var expFlag = false;
            if (response != null)
            {
                response.Content.Deserialize<AddExperienceResponse>().WorkExperienceTypeEnum.Should().Be(null, $"Experience not deleted");
                expFlag= true;
            }
            return expFlag;
        }

        public bool DeleteAllExperienceProjects(string token, List<string> listOfExpProjID, string appID, string expID)
        {
            var delExpPrjFlag = false;
            if (listOfExpProjID.Count > 0 && token != null)
            {
                foreach (string expProjID in listOfExpProjID)
                {
                    response = requestCalls.DeleteRequestCall(token, $"/applications/{appID}/experience/{expID}/ExperienceProjects/{expProjID}");
                    response.StatusCode.Should().Be(HttpStatusCode.OK, $"Delete request has not processed for Experience ID:\r{expID}");
                }
                delExpPrjFlag = true;
            }
            return delExpPrjFlag;
        }

        public bool VerifyAllExperienceProjectsDeleted(IRestResponse response)
        {
            var expProjFlag = false;
            if (response != null)
            {
                response.Content.Deserialize<AddEducationResponse>().Resources.ToArray().Length.Should().Be(0, $"Education details not deleted, found {response.Content.Deserialize<AddEducationResponse>().Resources.ToArray().Length} records");
                expProjFlag = true;
            }
            return expProjFlag;
        }
    }
}
