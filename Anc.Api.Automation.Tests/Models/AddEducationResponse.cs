using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anc.Api.Automation.Tests.Models
{
    public partial class AddEducationResponse
    {
        [JsonProperty("resources")]
        public object[] Resources { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Self eduSelf { get; set; }
    }

    public partial class Self
    {
        [JsonProperty("href")]
        public string eduHref { get; set; }

        [JsonProperty("allowed")]
        public string[] eduAllowed { get; set; }
    }

    public partial class AddEducationResponse
    {
        public static AddEducationResponse FromJson(string json) => JsonConvert.DeserializeObject<AddEducationResponse>(json, Converter.Settings);
    }
}
