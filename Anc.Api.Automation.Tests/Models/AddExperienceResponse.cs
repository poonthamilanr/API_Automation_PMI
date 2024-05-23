using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anc.Api.Automation.Tests.Models
{
        public partial class AddExperienceResponse
        {
            [JsonProperty("applicationId")]
            public long ApplicationId { get; set; }

            [JsonProperty("workExperienceTypeEnum")]
            public string WorkExperienceTypeEnum { get; set; }

            [JsonProperty("projectTitle")]
            public string ProjectTitle { get; set; }

            [JsonProperty("company")]
            public string Company { get; set; }

            [JsonProperty("jobTitle")]
            public string JobTitle { get; set; }

            [JsonProperty("startDate")]
            public DateTimeOffset StartDate { get; set; }

            [JsonProperty("endDate")]
            public DateTimeOffset EndDate { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("primaryFocusTypeEnum")]
            public string PrimaryFocusTypeEnum { get; set; }

            [JsonProperty("primaryFocusTypeOther")]
            public string PrimaryFocusTypeOther { get; set; }

            [JsonProperty("functionalAreaTypeEnum")]
            public string FunctionalAreaTypeEnum { get; set; }

            [JsonProperty("functionalAreaTypeOther")]
            public string FunctionalAreaTypeOther { get; set; }

            [JsonProperty("methodologyEnum")]
            public object MethodologyEnum { get; set; }

            [JsonProperty("agileMethodologyEnum")]
            public object AgileMethodologyEnum { get; set; }

            [JsonProperty("agileMethodologyOther")]
            public object AgileMethodologyOther { get; set; }

            [JsonProperty("teamSizeEnum")]
            public object TeamSizeEnum { get; set; }

            [JsonProperty("budgetRangeEnum")]
            public string BudgetRangeEnum { get; set; }

            [JsonProperty("portfolioCount")]
            public long PortfolioCount { get; set; }

            [JsonProperty("directReports")]
            public long DirectReports { get; set; }

            [JsonProperty("pmReports")]
            public long PmReports { get; set; }

            [JsonProperty("primaryIndustryText")]
            public string PrimaryIndustryText { get; set; }

            [JsonProperty("projectRoleText")]
            public string ProjectRoleText { get; set; }

            [JsonProperty("_links")]
            public ExpLinks ExpLinks { get; set; }
        }

        public partial class ExpLinks
        {
            [JsonProperty("self")]
            public ExpSelf ExpSelf { get; set; }
        }

        public partial class ExpSelf
        {
            [JsonProperty("href")]
            public string ExperienceID { get; set; }

            [JsonProperty("allowed")]
            public System.Collections.Generic.List<string> ExpAllowed { get; set; }
        }

        public partial class AddExperienceResponse
        {
            public static AddExperienceResponse FromJson(string json) => JsonConvert.DeserializeObject<AddExperienceResponse>(json, Converter.Settings);
        }
    }
