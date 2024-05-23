using Anc.Api.Automation.Tests.Models;

namespace Anc.Api.Automation.Tests.Hooks
{
    public class TestData
    {
        public string ScenarioName { get; set; }
        public string Uri { get; set; }
        public string QueryString { get; set; }
        public string ExpectedResponseData { get; set; }
        public string ExpectedResponseBodyJsonFileName { get; set; }
        public string DataScaffoldingApplicationType { get; set; }
        public string DataScaffoldingApplicationStatusType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string ExpectedWebReportName { get; set; }
        public string APIType { get; set; }
        public DS_UserDetails User { get; set; }

    }
}
