#pragma warning disable 649
#pragma warning disable 169

namespace Anc.Api.Automation.Tests.Models
{
    using Newtonsoft.Json;
    public class Authorization
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }
    }
}