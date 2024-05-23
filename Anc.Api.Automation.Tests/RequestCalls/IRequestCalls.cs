#pragma warning disable 649
#pragma warning disable 169

namespace Anc.Api.Automation.Tests.Provider
{
    using Pmi.Api.Framework.Attributes;
    using RestSharp;
    using Pmi.Api.Framework;
    using RequestBody = Pmi.Api.Framework.Attributes.RequestBody;
    using System;
    using TechTalk.SpecFlow;

    public interface IRequestCalls
    {
        /// <summary>
        /// GET request
        /// </summary>
        /// <param name="customerToken">Authorizes access token</param>
        /// <param name="uri">API endpoint or url</param>
        /// <param name="contentType">Default content Type: application/problem+json</param>
        /// <returns>RestResponce details</returns>
        [RestOperation(Resource = "{uri}", Verb = Method.GET)]
        RestResponse GetRequestCall([Header(Name = "Authorization")] string customerToken,
            [UrlParameter(Name = "uri")] string uri = null,
            [Header(Name = "Content-Type")] string contentType = "application/problem+json");

        /// <summary>
        /// POST Request
        /// </summary>
        /// <param name="customerToken">Authorizes access token</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="uri">API endpoint or url</param>
        /// <param name="contentType">Default content Type: application/problem+json</param>
        /// <returns>Responce details</returns>
        [RestOperation(Resource = "{uri}", Verb = Method.POST)]
        RestResponse PostRequestCall([Header(Name = "Authorization")] string customerToken,
            [RequestBody] object requestBody, [UrlParameter(Name = "uri")] string uri = null,
            [Header(Name = "Content-Type")] string contentType = "application/problem+json");

        /// <summary>
        /// DELETE Request
        /// </summary>
        /// <param name="customerToken">Authorizes access token</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="uri">API endpoint or url</param>
        /// <param name="contentType">Default content Type: application/problem+json</param>
        /// <returns>Responce details</returns>
        [RestOperation(Resource = "{uri}", Verb = Method.DELETE)]
        RestResponse DeleteRequestCall([Header(Name = "Authorization")] string customerToken,
            [UrlParameter(Name = "uri")] string uri = null, [RequestBody] object requestBody = null,
            [Header(Name = "Content-Type")] string contentType = "application/problem+json");

        /// <summary>
        /// PUT Request
        /// </summary>
        /// <param name="customerToken">Authorizes access token</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="uri">API endpoint or url</param>
        /// <param name="contentType">Default content Type: application/problem+json</param>
        /// <returns>Responce details</returns>
        [RestOperation(Resource = "{uri}", Verb = Method.PUT)]
        RestResponse PutRequestCall([Header(Name = "Authorization")] string customerToken,
            [UrlParameter(Name = "uri")] string uri = null, [RequestBody] object requestBody = null,
            [Header(Name = "Content-Type")] string contentType = "application/problem+json");
    }

#pragma warning disable CS0618 // Type or member is obsolete
    public class RequestCallWithQueryString
    {

        static UserSettings _userSettings;
        private IRestResponse response;
        public RequestCallWithQueryString()
        {
            _userSettings = new UserSettings();
        }

        private string BaseUrl() 
        {
            var baseUrl = "";
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("APPLICATIONAPI"))
                baseUrl = _userSettings.AppApiUrl;
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("CERTIFICATIONAPI"))
                baseUrl = _userSettings.CertApiUrl;
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("WEBREPORTAPI"))
                baseUrl = _userSettings.WebRepApiUrl;
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("PDUAPI"))
                baseUrl = _userSettings.PduApiUrl;
            return baseUrl;
        }

        /// <summary>
        /// POST request with parameterized query string
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API Endpoint</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="queryString">Query string. Queery string should be seperated by '=' for one pair. Incase of multiple querystring the add it by using '&'. Each pair should be seperated by '&'</param>
        /// <returns>Responce details</returns>
        /// <exception cref="Exception">Either <paramref name="token"/> or <paramref name="uri"/> is null</exception>
        public IRestResponse PostRequestCallWithQueryString(string token, string uri, object requestBody = null, string queryString = null)
        {
            if (token != null && uri != null)
            {
                var client = new RestSharp.RestClient(BaseUrl());
                var request = new RestRequest(uri, Method.POST);
                AddingParametersHeddersAndRequestBody(token, request, requestBody, queryString);
                response = client.Execute(request);
                return response;
            }
            else
                throw new Exception($"Either Token/uri is null. \nToken: \r{token} \nUri: \r{uri}");
        }

        /// <summary>
        /// PUT request with parameterized query string
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API Endpoint</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="queryString">Query string. Queery string should be seperated by '=' for one pair. Incase of multiple querystring the add it by using '&'. Each pair should be seperated by '&'</param>
        /// <returns>Responce details</returns>
        /// <exception cref="Exception">Either <paramref name="token"/> or <paramref name="uri"/> is null</exception>
        public IRestResponse PutRequestCallWithQueryString(string token, string uri, object requestBody = null, string queryString = null)
        {
            if (token != null && uri != null)
            {
                var client = new RestSharp.RestClient(BaseUrl());
                var request = new RestRequest(uri, Method.PUT);
                AddingParametersHeddersAndRequestBody(token, request, requestBody, queryString);
                response = client.Execute(request);
                return response;
            }
            else
                throw new Exception($"Either Token/uri is null. \nToken: \r{token} \nUri: \r{uri}");
        }

        /// <summary>
        /// PUT request with parameterized query string
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="uri">API Endpoint</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="queryString">Queery string should be seperated by '=' for one pair. Incase of multiple querystring the add it by using '&'. Each pair should be seperated by '&'</param>
        /// <returns>Responce details</returns>
        /// <exception cref="Exception">Either <paramref name="token"/> or <paramref name="uri"/> is null</exception>
        public IRestResponse GetRequestCallWithQueryString(string token, string uri, object requestBody = null, string queryString = null)
        {
            if (token != null && uri != null)
            {
                var client = new RestSharp.RestClient(BaseUrl());
                var request = new RestRequest(uri, Method.GET);
                AddingParametersHeddersAndRequestBody(token, request, requestBody, queryString);
                response = client.Execute(request);
                return response;
            }
            else
                throw new Exception($"Either Token/uri is null. \nToken: \r{token} \nUri: \r{uri}");
        }

        /// <summary>
        /// Adding Query parameters and  request body the request call
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="requestBody">Request body in Json format</param>
        /// <param name="queryString">Queery string should be seperated by '=' for one pair. Incase of multiple querystring the add it by using '&'. Each pair should be seperated by '&' EG: attributeName1=AttributeValue1&AttributeName2=AttributeValue2</param>
        /// <returns>Request with request body and query string of parameter</returns>
        /// <exception cref="Exception">Given queryString <paramref name="queryString"/> is not valid</exception>
        internal RestRequest AddingParametersHeddersAndRequestBody(string token, RestRequest request, object requestBody = null, string queryString = null) 
        {
            request.AddHeader("Authorization", token);
            request.AddHeader("Content-Type", "application/problem+json");
            if (queryString != null)
            {
                var querystringArray = queryString.Split('&');
                foreach (var item in querystringArray)
                {
                    var arrayValue = item.Split('=');
                    request.AddParameter(arrayValue[0], arrayValue[1], ParameterType.QueryString);
                    Console.WriteLine($"This Name: \r{arrayValue[0]} & Value: \r{arrayValue[1]} has added to the request parameters");
                }
            }
            else
                throw new Exception($"Passed query string is not valid.\nQuery string:\r{queryString}");
            if (requestBody != null)
                request.AddJsonBody(requestBody);
            return request;
        }
    }
}
