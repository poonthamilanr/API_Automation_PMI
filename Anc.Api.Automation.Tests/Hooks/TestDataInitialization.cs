using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Anc.Api.Automation.Tests.Hooks
{
    [Binding]
    public class TestDataInitialization
    {
        private readonly ScenarioContext _context;
        private readonly TestData _testData;
        private readonly UserSettings _userSettings;

        public TestDataInitialization(ScenarioContext context, TestData testData)
        {
            _context = context;
            _testData = testData;
            _userSettings = new UserSettings();
        }

        [Before]
        public void ReadTestDataBeforeTestRun()
        {
            //Should remove this code when reading it from shared location..
            var currentDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader($@"{currentDirectory}\Hooks\TestData_{_userSettings.Environment}.csv"))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    if (!csv.GetField("ScenarioName").Equals(_context.ScenarioInfo.Title)) continue;

                    _testData.ScenarioName = csv.GetField("ScenarioName");
                    _testData.Uri = csv.GetField("Uri");
                    _testData.QueryString = csv.GetField("QueryString");
                    _testData.ExpectedResponseData = csv.GetField("ExpectedResponseData");
                    _testData.ExpectedResponseBodyJsonFileName = csv.GetField("ExpectedResponseBodyJsonFileName");
                    _testData.DataScaffoldingApplicationType = csv.GetField("DataScaffoldingApplicationType");
                    _testData.DataScaffoldingApplicationStatusType = csv.GetField("DataScaffoldingApplicationStatusType");
                    _testData.UserName = csv.GetField("UserName");
                    _testData.Password = csv.GetField("Password");
                    _testData.Country = csv.GetField("Country");
                    _testData.ExpectedWebReportName = csv.GetField("ExpectedWebReportName");
                    _testData.APIType = csv.GetField("APIType");
                    break;
                }
            }
        }
    }
}

