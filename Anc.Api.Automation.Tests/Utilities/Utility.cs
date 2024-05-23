using Anc.Api.Automation.Tests.Hooks;
using Anc.Api.Automation.Tests.Models;
using FluentAssertions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using JsonDiffer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pmi.Api.Framework;
using RestSharp;
using System.Data;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace Anc.Api.Automation.Tests.Utilities
{
    public class Utility
    {
        private readonly TestData _testData;
        private readonly ScenarioContext scenarioContext;
        private readonly UserSettings userSettings;

        public Utility(ScenarioContext context, TestData testData)
        {
            scenarioContext = context;
            _testData = testData;
            userSettings = new UserSettings();
        }

        /// <summary>
        /// Verifies response body details based on expected data
        /// </summary>
        /// <param name="response">RestResponce from executed GET/POST request.</param>
        /// <param name="extraExpectedValues">Expected data of list during the run time.</param>
        /// <returns>True for success and False if its failed</returns>
        /// <exception cref="Exception">Actual responce status code is <paramref name="response"/> not met with Expected. list of expected result value are not available in actual result</exception>
        public bool VerifyResponseBodyDetails(IRestResponse response, List<string> extraExpectedValues = null)
        {
            bool flag = false;
            if (response.Content != "" && (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created))
            {
                List<string> expectedtResponceList;
                expectedtResponceList = _testData.ExpectedResponseData.Split('|').ToList<string>();
                if (extraExpectedValues != null && extraExpectedValues.Count != 0)
                    expectedtResponceList.AddRange(extraExpectedValues);
                var missingExpli = new List<string>();
                if (expectedtResponceList.Count > 0 && _testData.ExpectedResponseData != null && response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    foreach (var expectedResponseData in expectedtResponceList)
                    {
                        if (expectedResponseData != "")
                            try
                            {
                                response.Content.Should().Contain(expectedResponseData, $"{expectedResponseData} is not listed in actual request response body. \nActual Responce content: \r{response.Content}", false);
                                flag = true;
                            }
                            catch (ArgumentException)
                            {
                                missingExpli.Add(expectedResponseData);
                                flag = false;
                            }
                        else if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                        {
                            flag = true;
                            return flag;
                        }
                    }
                    if (flag == false || missingExpli.Count > 0)
                       throw new Exception($"This list of expected result value are not available in actual result. \n Expected list values: \r {missingExpli}");
                    else
                        Console.WriteLine($"Successfully actual result content has met with expected results. \n Actual result Content: \r{response.Content} \n Expected list values: \r{String.Join(", ", expectedtResponceList)}");
                }
                else
                    throw new Exception($"Please ensure that response status: {response.StatusCode} & Expected data : {_testData.ExpectedResponseData}");
                return flag;
            }
            else if (response.Content == "" && (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created))
            {
                flag = true;
                VerifyResponseStatusCode(response);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception($"Looks URI is not valid. Please ensure this URI: \r{_testData.Uri}");
            else
                throw new Exception($"Please ensure that response status: {response.StatusCode} & Expected data : {_testData.ExpectedResponseData}");
            return flag;
        }

        /// <summary>
        /// Verifies Actual result json object with Expected result of json object
        /// </summary>
        /// <param name="actualResponse">RestResponce from GET/POST call</param>
        /// <returns>the values that are not match with expected data</returns>
        /// <exception cref="Exception">Expected responce body file is missing</exception>
        public JToken CompareTwoObjects(IRestResponse actualResponse)
        {
            if (actualResponse.StatusCode != HttpStatusCode.OK)
            {
                var response = $"Actual response Status not OK. : {actualResponse.StatusCode} Expected status code : 200";
                throw new Exception(response);
            }

            if (_testData.ExpectedResponseBodyJsonFileName != null && actualResponse.StatusCode == HttpStatusCode.OK)
            {
                var actual = JToken.Parse(actualResponse.Content);
                var expected = JToken.Parse(File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/ResponseBodyQA/{_testData.ExpectedResponseBodyJsonFileName}.json"));
                JsonDifferentiator jsonDifferentiator = new JsonDifferentiator(OutputMode.Symbol, true);
                JsonDifferentiator jsonDifferentiator2 = new JsonDifferentiator(OutputMode.Symbol, true);
                var verifiedActualDifferentValues = jsonDifferentiator.Differentiate(expected, actual);
                var verifiedExpectedValues = jsonDifferentiator2.Differentiate(actual, expected);
                if (verifiedActualDifferentValues != null)
                    Console.WriteLine($"Actual response is not completely met with expected Responce. \n Expected result: \r{verifiedExpectedValues} \n Actual Result:  \r{verifiedActualDifferentValues}");
                return verifiedActualDifferentValues;
            }
            else
                throw new Exception($"Expected response body file is missing: {_testData.ExpectedResponseBodyJsonFileName}");
        }

        /// <summary>
        /// Reading a value from sesponce content based on content attribute name
        /// </summary>
        /// <param name="response">RestResponce from GET/POST call</param>
        /// <param name="attributename">AN attribute name from response content</param>
        /// <param name="module"></param>
        /// <returns>Attribute value</returns>
        /// <exception cref="Exception">Not able to fine this <paramref name="attributename"/> name. </exception>
        public string ReadAValueFromResponseContentHref(IRestResponse response, string attributename = null, string module = null)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(response.Content));
            var attributeValue = "";
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.Value.Equals(attributename))
                        {
                            if (attributename == "href")
                            {
                                var hrefLink = reader.ReadAsString().ToUpper().Substring(5);
                                if (hrefLink.Contains($"{module.ToUpper()}"))
                                {
                                    var arrayofLinkValue = hrefLink.Split('/');
                                    for (int index = 0; index < arrayofLinkValue.Length; index++)
                                    {
                                        if (arrayofLinkValue[index].ToUpper().Equals(module.ToUpper().Replace("/", "")))
                                            return arrayofLinkValue[index + 1];
                                    }
                                }
                            }
                            else if (attributename == reader.Value.ToString())
                                return reader.ReadAsString().ToString();
                            else
                                throw new Exception($"No match found for the Attribute:{attributename}");
                        }
                        else
                            throw new Exception($"Value not equal to {attributename}");
                    }
                    else
                       throw new Exception("Value is null");
                }
            else
                throw new Exception($"Response status/attribute name is null. \n\nResponse Status: \r{response.StatusCode} \n\nAttribute Name: \r{attributename} \n\nResponse Content:\r{response.Content}");

            return attributeValue;
        }

        /// <summary>
        /// Downloading response content to PDF format if content type is pdf
        /// </summary>
        /// <param name="response">RestResponce from GET/POST call</param>
        /// <param name="fileName">File name of PDF document</param>
        /// <returns>Downloaded file name</returns>
        public string[] DownloadPDFFileFromResponceContent(IRestResponse response, string fileName)
        {
            DeleteAllOldDocumentBaseOnNameStartsWith(fileName).Should().BeTrue("Existing Files has not deleted successfully", false);
            string rootFolderPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\TestResultWebReports\";
            fileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMMMdd_hhmmss")}_{userSettings.Environment}";
            using (BinaryWriter writer = new BinaryWriter(File.Open($@"{rootFolderPath}\{fileName}.pdf", FileMode.Create))) { writer.Write(response.RawBytes); writer.Close(); }
            string[] fileList = Directory.GetFiles(@rootFolderPath, fileName + ".pdf");
            fileList.Length.Should().BeGreaterThan(0, $"This file && {fileName} && has not created in this folder. Folder Path: {rootFolderPath}", false);
            return fileList;
        }

        /// <summary>
        /// Deleting all existing documents based on prefix name and return True or False
        /// </summary>
        /// <param name="fileName">Name of the file starts-with</param>
        /// <returns>TRUE if all files are deleted</returns>
        /// <exception cref="FileNotFoundException"></exception>
        private bool DeleteAllOldDocumentBaseOnNameStartsWith(string fileName)
        {
            fileName = fileName.IsNullOrEmpty() ? fileName : throw new Exception("File name should not be null or empty");
            string rootFolderPath = $@"{AppDomain.CurrentDomain.BaseDirectory}\TestResultWebReports\";
            string filesToDelete = $@"*{fileName}*.pdf";
            string[] fileList = Directory.GetFiles(@rootFolderPath, filesToDelete);
            bool flag = false;
            if (fileList.Length > 0)
                foreach (string file in fileList)
                {
                    File.Delete(file);
                    if (Directory.GetFiles(@rootFolderPath, filesToDelete).Length == 0)
                    {
                        flag = true;
                        break;
                    }
                }
            else if (fileList.Length == 0)
                flag = true;
            else
                throw new FileNotFoundException();
            return flag;
        }

        /// <summary>
        /// Verifies response status codes
        /// </summary>
        /// <param name="response">ResrResponse from GET/POST call</param>
        /// <exception cref="Exception">NotFound:404. Unathorized:401. InternalServerError:500. NoContent:204. UnprocessableEntity:422. BadRequest:400</exception>
        public void VerifyResponseStatusCode(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                        response.StatusCode.Should().Be(HttpStatusCode.OK, "Expected should be:" + HttpStatusCode.OK + "but Actual Response code is: " + response.Content, false);
                    break;
                case HttpStatusCode.Created:
                        response.StatusCode.Should().Be(HttpStatusCode.Created, "Expected should be:" + HttpStatusCode.OK + "but Actual Response code is: " + response.Content, false);
                    break;
                case HttpStatusCode.NotFound:
                    throw new Exception($"Getting NotFount response. Please ensure the *URI: {response.ResponseUri} \nResponse status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.Unauthorized:
                    throw new Exception($"Getting Unauthorized error looks token is not valid response\nToken:\r{string.Join(response.Headers.ToString(), ',')}. Response status: \r{response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.InternalServerError:
                    throw new Exception($"Getting Internal Server Error response. Response status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.NoContent:
                    throw new Exception($"Response status is NO Content. Response status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.UnprocessableEntity:
                    throw new Exception($"Response status is UnprocessableEntity. Response status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.BadRequest:
                    throw new Exception($"Response status is BadRequest. Response status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
                case HttpStatusCode.Forbidden:
                    throw new Exception($"Response status is Forbidden. Response status: {response.StatusCode}\nError Exception details: \r{response.ErrorException}\nError message details:\r{response.ErrorMessage}");
            }
        }

        /// <summary>
        /// Verifies PDF content
        /// </summary>
        /// <param name="fileName">Actual file name which id getting during the execution</param>
        /// <returns>TRUE if Actualfile contents are met with Expected contents.</returns>
        /// <exception cref="Exception">Actual PDF page size is not met with expected. Actual PDF content is not met with Expected Content. Not able to file the expected pdf file</exception>
        public bool PDFValidation(string fileName)
        {
            if (fileName != null && _testData.ExpectedWebReportName != "")
            {
                PdfReader expectedReader = new($@"{AppDomain.CurrentDomain.BaseDirectory}TestResultWebReports\{userSettings.Environment}WebReports\{_testData.ExpectedWebReportName}.pdf");
                PdfReader actualReader = new(fileName);
                StringBuilder expBuilder = new();
                StringBuilder actBuilder = new();
                PdfDocument expPdfDoc = new(expectedReader);
                PdfDocument actPdfDoc = new(actualReader);

                if (expPdfDoc.GetNumberOfPages() != actPdfDoc.GetNumberOfPages())
                    throw new Exception($"The number of pages in the expected PDF does not match the actual PDF.\nExpected Pdf Page size: \r {expPdfDoc.GetNumberOfPages()}\nActual Pdf page size:\r{actPdfDoc.GetNumberOfPages()}");

                for (int page = 1; page <= expPdfDoc.GetNumberOfPages(); page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    expBuilder.Append(PdfTextExtractor.GetTextFromPage(expPdfDoc.GetPage(page), strategy));
                }
                expPdfDoc.Close();
                expectedReader.Close();
                
                for (int page = 1; page <= actPdfDoc.GetNumberOfPages(); page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    actBuilder.Append(PdfTextExtractor.GetTextFromPage(actPdfDoc.GetPage(page), strategy));
                }
                actPdfDoc.Close();
                actualReader.Close();

                actBuilder.Replace("\u0016", "R");
                expBuilder.Replace("\u0016", "R");
                bool flag = false;
                //Changing dates on expected report based on actual report generation date
                if (actBuilder.ToString().Contains("Name for correspondence") || actBuilder.ToString().Contains("Experience Audit Report") || actBuilder.ToString().Contains("Batch Claims Summary")||
                    actBuilder.ToString().Contains("Cycle Summary:") || actBuilder.ToString().Contains("Your Overall Performance") || actBuilder.ToString().Contains("Transcript as of") || actBuilder.ToString().Contains("A pproved PDUs:"))
                {
                    string actTemp = "", exptTemp = "";
                    int index = 0, genIndex = 0;
                    if (fileName.ToString().ToLower().Contains("transcriptreport"))
                    {
                        index = 50;
                        genIndex = actBuilder.ToString().IndexOf("PM I ID:") - 60;
                    }
                    if (fileName.ToString().ToLower().Contains("ecoreport") || fileName.ToString().ToLower().Contains("auditreport"))
                    {
                        index = 31;
                        genIndex = actBuilder.ToString().IndexOf("Generated");
                    }
                    if (fileName.ToString().ToLower().Contains("cyclesummaryreport"))
                    {
                        index = 35;
                        genIndex = actBuilder.ToString().IndexOf("PMI ID:") + 8;
                    }
                    if (fileName.ToString().ToLower().Contains("applicationreport"))
                    {
                        index = 30;
                        genIndex = actBuilder.ToString().IndexOf("PMI ID:") + 13;
                    }
                    for (int i = 0; i <= index; i++)
                    {
                        actTemp = actTemp + actBuilder.ToString().ElementAt(genIndex + i);
                        exptTemp = exptTemp + expBuilder.ToString().ElementAt(genIndex + i);
                    }
                    expBuilder.Replace(exptTemp, actTemp);
                }

                //Comparing actual report text and expected report text
                if (fileName.ToString().ToLower().Contains("batchclaimdetailreport"))
                {
                    List<string> expArray = expBuilder.ToString().Split(' ').ToList();
                    expArray.Sort();
                    List<string> aclArray = actBuilder.ToString().Split(' ').ToList();
                    aclArray.Sort();
                    aclArray.Count.Should().BeCloseTo(expArray.Count, 1, $"Actual Batch claim details count is not met with Expected claim count.\r\n\n***Actul Claim detail count***\n{aclArray.Count}\r\n\n***Expected Claim detail count***\n{expArray.Count}");
                    flag = true;
                }
                else
                {
                    actBuilder.ToString().Should().Be(expBuilder.ToString(), $"Actual report details is not met with Expected reports.\r\n\n***Actul Report Content***\n{actBuilder}\r\n\n***Expected Report Content***\n{expBuilder}");
                    flag = true;
                }

                return flag;
            }
            else
                throw new Exception($"Actual report details is not met with Expected reports.\r\n\n***Actul file name ***\n {fileName} \r\n\n***Expected file name***\n{AppDomain.CurrentDomain.BaseDirectory}//TestResultWebReports//Expected{userSettings.Environment}WebReports//{_testData.ExpectedWebReportName}.pdf");
        }

        /// <summary>
        /// Reading the data from DataBasse based on query.
        /// </summary>
        /// <param name="query">String of SQL query. INSERT, UPDATE & DELETE query will not be executed</param>
        /// <returns>Dictionary of Column header and value as string</returns>
        /// <exception cref="Exception">Given SQL is null. DB connection has not established</exception>
        public Dictionary<string, string> ReadValuesFromDataBase(string query)
        {
            var dic = new Dictionary<string, string>();
            using (SqlConnection connection = new SqlConnection(userSettings.PMICoreConnectionString))
            {
                if (query != null && !query.ToUpper().Contains("INSERT") && !query.ToUpper().Contains("DELETE") && !query.ToUpper().Contains("UPDATE") && !query.ToUpper().Contains("SET"))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.CommandType = CommandType.Text;
                        command.CommandTimeout = 30;
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            for (int index = 0; index < reader.FieldCount; index++)
                            {
                                dic.Add(reader.GetName(index).ToString(), reader.GetValue(index).ToString());
                            }
                        }
                        return dic;
                    }
                    catch (SqlException exception)
                    {
                        throw new Exception($"Exception Details: {exception}");
                    }
                }
                else
                    throw new Exception(query == null ? $"SQL query is null: {query}" : "No permission to Update/Delete/Set/Insert");
            }
        }

        public bool VerifyResourceDeleted(IRestResponse response)
        {
            var resoFlag = false;
            if (response != null)
            {
                response.Content.Should().Be("", "Resource not deleted");
                resoFlag = true;
            }
            return resoFlag;
        }
    }
}