#pragma warning disable 649
#pragma warning disable 169
#pragma warning disable CS0219


namespace Anc.Api.Automation.Tests.Utilities
{
    using System.Net;
    using Anc.Api.Automation.Tests.Hooks;
    using Anc.Api.Automation.Tests.Provider;
    using RestSharp;
    using System;
    using FluentAssertions;
    using System.Collections.Generic;
    using TechTalk.SpecFlow;
    using Microsoft.Practices.Unity;

    public class CertificationAllRequests : BaseProvider
    {
        private readonly IRequestCalls requestCalls;
        private readonly TestData _testData;
        private IRestResponse response;
        private RequestCallWithQueryString requestCallWithQueryString;
        private readonly Utility utility;
        private readonly ScenarioContext _scenarioContext;

        public CertificationAllRequests(TestData testData)
        {
            _testData = testData;
            requestCalls = Container.Resolve<IRequestCalls>();
            requestCallWithQueryString = new RequestCallWithQueryString();
            utility = new Utility(_scenarioContext, _testData);
        }

        /// <summary>
        /// GET Request.
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API Endpoint</param>
        /// <param name="firstValue">Value that needs to be add on first position based on the index in uri. Eg index: {0}</param>
        /// <param name="secondValue">Value that needs to be add on second position based on the index in uri. Eg index: {1}</param>
        /// <returns>Response details</returns>
        /// <exception cref="Exception">looks either Token or Uri is null</exception>
        public IRestResponse GetRequestCall(string token, string uri = null, string firstValue = null, string secondValue = null)
        {
            if (token != null && uri != null)
            {
                response = requestCalls.GetRequestCall(token, string.Format(uri, firstValue, secondValue));
                utility.VerifyResponseStatusCode(response);
            }
            else
                throw new Exception($"Kindly make sure token/Uri from test data looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {response.ResponseUri + uri}");
            return response;
        }

        /// <summary>
        /// GET request call runs in loop
        /// </summary>
        /// <param name="token">Access TokenAPI Endpoint</param>
        /// <param name="eventSize">Run count</param>
        /// <returns>Response details</returns>
        /// <exception cref="Exception">looks either Token or Uri is null. NOT FOUND: 404 - URI is not valid</exception>
        public IRestResponse GetRequestCallforMultipleTimesByAnIDSize(string token, string uri = null, int eventSize = 1)
        {
            if (token != null && uri != null)
            {
                bool flag = false;
                var ValidlistId = new List<string>();
                var NotValidList = new List<string>();
                for (int index = 0; index < eventSize; index++)
                {
                    response = requestCalls.GetRequestCall(token, string.Format(uri, index));
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        flag = false;
                        NotValidList.Add(index.ToString());
                        response.StatusCode.Should().Be(HttpStatusCode.NoContent, $"Expected should be: {HttpStatusCode.NoContent} but Actual Response code is: {response.StatusCode}", false);
                    }
                    else if (response.StatusCode == HttpStatusCode.OK)
                    {
                        response.StatusCode.Should().Be(HttpStatusCode.OK, "Expected should be:" + HttpStatusCode.OK + "but Actual Response code is: " + response.StatusCode, false);
                        flag = true;
                        ValidlistId.Add(index.ToString());
                        break;
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new Exception($"NOT FOUND: 404 - Looks URI is not valid. Please ensure this URI: \r{uri}");
                    else
                        throw new Exception($"Response Content Details:\n{response.ErrorMessage}\n{response.ErrorException}");
                }
                Console.WriteLine($"This list of event/rule ids are valid for this application ID: {string.Join(", ", ValidlistId)}");
                Console.WriteLine($"This list of event/rule ids are not valid for this application ID: {string.Join(", ", NotValidList)}");
            }
            else
                throw new Exception($"Kindly make sure token/Urin from test data looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {uri}");
            return response;
        }

        /// <summary>
        /// POST Request
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="requestBody">API EndPoint</param>
        /// <param name="firstValue">Value that needs to be add on first position based on the index in uri. Eg index: {0}</param>
        /// <param name="secondValue">Value that needs to be add on second position based on the index in uri. Eg index: {1}</param>
        /// <returns>Response details</returns>
        /// <exception cref="Exception">looks either Token or Uri is null</exception>
        public IRestResponse PostRequestCall(string token, string uri = null, object requestBody = null, string firstValue = null, string secondValue = null)
        {
            if (token != null && uri != null)
            {
                response = requestCalls.PostRequestCall(token, requestBody, string.Format(uri, firstValue, secondValue));
                utility.VerifyResponseStatusCode(response);
                return response;
            }
            else
                throw new Exception($"Kindly make sure token/Uri from test data looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {uri}");
        }

        /// <summary>
        /// POST Request with query parameters
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API EndPoint</param>
        /// <param name="requestBody">Request body in Json object</param>
        /// <param name="firstValue">Value that needs to be add on first position based on the index in uri. Eg index: {0}</param>
        /// <param name="secondValue">Value that needs to be add on second position based on the index in uri. Eg index: {1}</param>
        /// <param name="querystring">Query string Parameter</param>
        /// <returns>Response Details</returns>
        /// <exception cref="Exception">Either Token or Uri is null</exception>
        public IRestResponse PostRequestCallWithQueryString(string token, string uri = null, object requestBody = null, string firstValue = null, string secondValue = null, string querystring = null)
        {
            if (token != null && uri != null)
            {
                if (querystring == null && _testData.QueryString != null)
                    querystring = _testData.QueryString;
                if (querystring == null && _testData.QueryString == null)
                    querystring = null;
                response = requestCallWithQueryString.PostRequestCallWithQueryString(token, string.Format(uri, firstValue, secondValue), requestBody, querystring);
                utility.VerifyResponseStatusCode(response);
                Console.WriteLine($"Response Content Details:\n{response.Content.ToString()}");
                return response;
            }
            else
                throw new Exception($"Kindly make sure token/Uri from test data and Query strings, looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {uri} \nQuery String: {querystring}");
        }

        /// <summary>
        /// PUT Request
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API EndPoint</param>
        /// <param name="requestBody">Request body in Json object</param>
        /// <param name="firstValue">Value that needs to be add on first position based on the index in uri. Eg index: {0}</param>
        /// <param name="secondValue">Value that needs to be add on second position based on the index in uri. Eg index: {1}</param>
        /// <param name="querystring">Query string Parameter</param>
        /// <returns>Response Details</returns>
        /// <exception cref="Exception">Either Token or Uri is null</exception>
        public IRestResponse PutRequestCall(string token, string uri = null, object requestBody = null, string firstValue = null, string secondValue = null, string querystring = null)
        {
            if (token != null && uri != null)
            {
                if (querystring == null && _testData.QueryString != null)
                    querystring = _testData.QueryString;
                if (querystring == null && _testData.QueryString == null)
                    querystring = null;
                response = requestCallWithQueryString.PutRequestCallWithQueryString(token, string.Format(uri, firstValue, secondValue), requestBody, querystring);
                utility.VerifyResponseStatusCode(response);
                return response;
            }
            else
                throw new Exception($"Kindly make sure token/Uri from test data and Query strings, looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {uri} \nQuery String: {querystring}");
        }

        /// <summary>
        /// GET Request with QueryString
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API EndPoint</param>
        /// <param name="requestBody">Request Body in JSON object</param>
        /// <param name="firstValue">Value that needs to be add on first position based on the index in uri. Eg index: {0}</param>
        /// <param name="secondValue">Value that needs to be add on second position based on the index in uri. Eg index: {1}</param>
        /// <param name="querystring">Query string Parameter</param>
        /// <returns>Response Details</returns>
        /// <exception cref="Exception">Either Token or Uri is null</exception>
        public IRestResponse GetRequestCallWithQueryString(string token, string uri = null, object requestBody = null, string firstValue = null, string secondValue = null, string querystring = null)
        {
            if (token != null && uri != null)
            {
                if (querystring == null && _testData.QueryString != null)
                    querystring = _testData.QueryString;
                if (querystring == null && _testData.QueryString == null)
                    querystring = null;
                response = requestCallWithQueryString.GetRequestCallWithQueryString(token, string.Format(uri, firstValue, secondValue), requestBody, querystring);
                utility.VerifyResponseStatusCode(response);
                return response;
            }
            else
                throw new Exception($"Kindly make sure token/Uri from test data and Query strings, looks either Token or Uri is null.\nToken Detail: \r{token} \nUri: {uri} \nQuery String: {querystring}");
        }
    }
}