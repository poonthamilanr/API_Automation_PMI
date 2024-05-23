#pragma warning disable 649
#pragma warning disable 169

namespace Anc.Api.Automation.Tests
{
    using Microsoft.Extensions.Configuration;
    using Pmi.Web.Ui.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class UserSettings
    {
        private readonly IEnumerable<IConfigurationSection> configSection;
        public UserSettings()
        {
            var configManager = new ConfigManager("appsettings.json");
            configSection = configManager.Configuration.GetSection("UserConfiguration").GetChildren();
        }
        public string Environment => GetValue("Environment");
        public string DataScaffoldingUrl => GetValue("DataScaffoldingUrl");
        public string AppApiUrl => GetValue("AppApiUrl");
        public string CertApiUrl => GetValue("CertApiUrl");
        public string IdpBaseUrl => GetValue("IdpBaseUrl");
        public string ClientId => GetValue("ClientId");
        public string ClientSecret => GetValue("ClientSecret");
        public string Username => GetValue("Username");
        public string Password => GetValue("Password");
        public string WebRepApiUrl => GetValue("WebRepApiUrl");
        public string PduApiUrl => GetValue("PduApiUrl");
        public string PMICoreConnectionString => GetValue("PMICoreConnectionString");
        public string CurrentExecutionDirectory => Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
        private string GetValue(string key)
        {
            return configSection.FirstOrDefault(k => k.Key.Equals(key))?.Value;
        }
    }
}
