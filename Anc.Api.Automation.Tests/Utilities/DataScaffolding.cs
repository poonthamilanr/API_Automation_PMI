namespace Anc.Api.Automation.Tests
{
    using FluentAssertions;
    using Newtonsoft.Json.Linq;
    using Anc.Api.Automation.Tests.Models;
    using System.Net;
    using System.Net.Http;

    public static class DataScaffolding
    {
        private static readonly UserSettings userSettings = new();

        private const string REGISTERED_RESOURCE_URL = "Registered";
        private const string MEMBER_RESOURCE_URL = "Member";
        private const string CHAPTER_MEMBER_RESOURCE_URL = "ChapterMember";
        private const string CAPM_ETP_RESOURCE_URL = "CAPM/EligibleToPay";
        private const string PfMP_ETP_RESOURCE_URL = "PfMP/EligibleToPay";
        private const string PgMP_ETP_RESOURCE_URL = "PgMP/EligibleToPay";
        private const string PMI_ACP_ETP_RESOURCE_URL = "PMI-ACP/EligibleToPay";
        private const string PMI_PBA_ETP_RESOURCE_URL = "PMI-PBA/EligibleToPay";
        private const string PMI_SP_ETP_RESOURCE_URL = "PMI-SP/EligibleToPay";
        private const string PMI_RMP_ETP_RESOURCE_URL = "PMI-RMP/EligibleToPay";
        private const string PMP_ETP_RESOURCE_URL = "PMP/EligibleToPay";
        private const string PMP_SUBMITTED_RESOURCE_URL = "PMP/CertSubmitted";
        private const string PMP_EFE_RESOURCE_URL = "PMP/EligibleForExam";
        private const string PMP_CERTIFIED_RESOURCE_URL = "PMP/Certified";
        private const string PMP_PENDING_RESOURCE_URL = "PMP/Pending";

        private static DataScaffoldingUser RetrieveUserFromResource(string relativeResourceUrl)
        {
            var dataScaffoldingUser = new DataScaffoldingUser();

            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var request = new HttpRequestMessage(HttpMethod.Get, $"{userSettings.DataScaffoldingUrl}/{relativeResourceUrl}");

                var response = client.SendAsync(request).Result;
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var task = response.Content.ReadAsStringAsync();
                var json = JObject.Parse(task.Result);
                dataScaffoldingUser = json.ToObject<DataScaffoldingUser>();
            }

            return dataScaffoldingUser;
        }

        public static DS_UserDetails PullUserByResource(string relativeResourceUrl, string countryCode = null)
        {
            relativeResourceUrl = countryCode == null ?
                relativeResourceUrl : $"{relativeResourceUrl}?CountryCode={countryCode}";

            var dataScaffoldingUser = RetrieveUserFromResource(relativeResourceUrl);
            return ConvertToTestUser(dataScaffoldingUser);
        }

        /// <summary>
        /// Getting Submitted status user from DataScaffolding
        /// </summary>
        /// <param name="appType">ApplicationType(PMP). Right now its working for PMP application</param>
        /// <param name="country">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, ApplicationID, ApplicationType, Username, Password, etc.,</returns>
        public static DS_UserDetails PullCertSubmittedUser(string appType, string country = null)
        {
            var user = new DS_UserDetails();
            switch (appType)
            {
                case "PMP":
                    user = PullUserByResource(PMP_SUBMITTED_RESOURCE_URL, country);
                    break;
            }
            return user;
        }

        /// <summary>
        /// Getting Eligible To Pay status user from DataScaffolding
        /// </summary>
        /// <param name="appType">ApplicationType: Supported Applications: PMP, PgMP, PfMP, PMI-ACP, PMI-SP, PMI-PBA, CAPM & PMI-RMP</param>
        /// <param name="country">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, ApplicationID, ApplicationType, Username, Password, etc.,</returns>
        public static DS_UserDetails PullEligibleToPayUser(string appType, string country = null)
        {
            var user = new DS_UserDetails();
            switch (appType)
            {
                case "PMP":
                    user = PullUserByResource(PMP_ETP_RESOURCE_URL, country);
                    break;
                case "PgMP":
                    user = PullUserByResource(PgMP_ETP_RESOURCE_URL, country);
                    break;
                case "PfMP":
                    user = PullUserByResource(PfMP_ETP_RESOURCE_URL, country);
                    break;
                case "PMI-ACP":
                    user = PullUserByResource(PMI_ACP_ETP_RESOURCE_URL, country);
                    break;
                case "PMI-SP":
                    user = PullUserByResource(PMI_SP_ETP_RESOURCE_URL, country);
                    break;
                case "PMI-PBA":
                    user = PullUserByResource(PMI_PBA_ETP_RESOURCE_URL, country);
                    break;
                case "PMI-RMP":
                    user = PullUserByResource(PMI_RMP_ETP_RESOURCE_URL, country);
                    break;
                case "CAPM":
                    user = PullUserByResource(CAPM_ETP_RESOURCE_URL, country);
                    break;
            }
            return user;
        }

        /// <summary>
        /// Getting Eligible For Exam status user from DataScaffolding
        /// </summary>
        /// <param name="appType">ApplicationType(PMP). Right now its working for PMP application</param>
        /// <param name="country">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, ApplicationID, ApplicationType, Username, Password, etc.,</returns>
        public static DS_UserDetails PullEligibleForExamUser(string appType, string country = null)
        {
            var user = new DS_UserDetails();
            switch (appType)
            {
                case "PMP":
                    user = PullUserByResource(PMP_EFE_RESOURCE_URL, country);
                    break;
            }
            return user;
        }

        /// <summary>
        /// Getting Certified status user from DataScaffolding
        /// </summary>
        /// <param name="appType">ApplicationType(PMP). Right now its working for PMP application</param>
        /// <param name="country">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, ApplicationID, ApplicationType, Username, Password, etc.,</returns>
        public static DS_UserDetails PullCertifiedUser(string appType, string country = null)
        {
            var user = new DS_UserDetails();
            switch (appType)
            {
                case "PMP":
                    user = PullUserByResource(PMP_CERTIFIED_RESOURCE_URL, country);
                    break;
            }
            return user;
        }

        /// <summary>
        /// Getting Pending status user from DataScaffolding
        /// </summary>
        /// <param name="appType">ApplicationType(PMP). Right now its working for PMP application</param>
        /// <param name="country">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, ApplicationID, ApplicationType, Username, Password, etc.,</returns>
        public static DS_UserDetails PullPendingUser(string appType, string country = null)
        {
            var user = new DS_UserDetails();
            switch (appType)
            {
                case "PMP":
                    user = PullUserByResource(PMP_PENDING_RESOURCE_URL, country);
                    break;
            }
            return user;
        }

        /// <summary>
        /// Getting Registered status user from DataScaffolding
        /// </summary>
        /// <param name="countryCode">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, Username, Password, etc.,</returns>
        public static DS_UserDetails PullRegisteredUser(string countryCode = null) =>
           PullUserByResource(REGISTERED_RESOURCE_URL, countryCode);

        /// <summary>
        ///  Getting Membership user from DataScaffolding
        /// </summary>
        /// <param name="countryCode">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, Username, Password, etc.,</returns>
        public static DS_UserDetails PullMemberUser(string countryCode = null) =>
            PullUserByResource(MEMBER_RESOURCE_URL, countryCode);

        /// <summary>
        ///  Getting Chapter Member user from DataScaffolding
        /// </summary>
        /// <param name="countryCode">Provide country code if user is required from particular country.
        /// Supported Countries : "USA", "JPN", "KOR", "CHN", "BRA", "IND", "PHL", "UKR", "MEX", "ZAF", "CAN"</param>
        /// <returns>Userdetails of PersonID, Username, Password, etc.,</returns>
        public static DS_UserDetails PullChapterMemberUser(string countryCode = null) =>
            PullUserByResource(CHAPTER_MEMBER_RESOURCE_URL, countryCode);

        private static DS_UserDetails ConvertToTestUser(DataScaffoldingUser dataScaffoldingUser)
        {
            var user = new DS_UserDetails()
            {
                Email = dataScaffoldingUser.Email,
                Password = dataScaffoldingUser.Password,
                UserName = dataScaffoldingUser.UserName,
                Id = dataScaffoldingUser.Id,
                FirstName = dataScaffoldingUser.FirstName,
                LastName = dataScaffoldingUser.LastName,
                Country = dataScaffoldingUser.Country,
                PersonId = dataScaffoldingUser.PersonId,
                ApplicationId = dataScaffoldingUser.ApplicationId,
                ApplicationType = dataScaffoldingUser.ApplicationType,
                OrderId = dataScaffoldingUser.OrderId,
                CreatedDateTime = dataScaffoldingUser.CreatedDateTime
            };
            return user;
        }

        internal class DataScaffoldingUser
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Country { get; set; }
            public long PersonId { get; set; }
            public string ApplicationType { get; set; }
            public string ApplicationId { get; set; }
            public string OrderId { get; set; }
            public string CreatedDateTime { get; set; }

        }
    }
}

