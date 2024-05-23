#pragma warning disable 649
#pragma warning disable 169

namespace Anc.Api.Automation.Tests.Modules
{
    using Anc.Api.Automation.Tests;
    using Anc.Api.Automation.Tests.Provider;
    using Authorization = Anc.Api.Automation.Tests.Models.Authorization;
    using Pmi.Api.Framework;
    using System;
    using System.Net;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Microsoft.IdentityModel.Tokens;

    public class IdentityToken : BaseProvider
    {
        private readonly IToken tokenProvider;

        public IdentityToken()
        {
            tokenProvider = Container.Resolve<IToken>();
            
        }

        public string GetIdpToken(string userName = null, string password = null)
        {
            if (password.IsNullOrEmpty())
                password = UserSettings.Password;
            if (userName.IsNullOrEmpty())
                userName = UserSettings.Username;
            var response = tokenProvider.GenerateToken(
                userName,
                password,
                UserSettings.ClientId,
                UserSettings.ClientSecret
            );

            Console.WriteLine(response.StatusCode);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var authorization = response.Content.Deserialize<Authorization>();

            authorization.AccessToken.Should().NotBeNullOrEmpty();

            String acces_token = authorization.AccessToken.Replace("\"", "").Replace("{", "").Replace("}", "");

            var Token = "Bearer "+ acces_token+"";

            return Token;
        }
    }
}
