#pragma warning disable 649
#pragma warning disable 169
#pragma warning disable CS0618

namespace Anc.Api.Automation.Tests
{
    using TechTalk.SpecFlow;
    using Anc.Api.Automation.Tests.Provider;
    using Pmi.Api.Framework;
    using Microsoft.Practices.Unity;

    [Binding]
    public class BaseProvider
    {
        protected UnityContainer Container;
        protected RestServiceTypeBuilder Builder;
        protected IToken TokenClient;
        protected IRequestCalls RequestClient;
        protected UserSettings UserSettings;


        protected BaseProvider()
        {
            UserSettings = new UserSettings();
            Container = new UnityContainer();
            Builder = new RestServiceTypeBuilder();
            TokenClient = Builder.GetDynamicRestClientType<IToken>(UserSettings.IdpBaseUrl);

            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("APPLICATIONAPI"))
                RequestClient = Builder.GetDynamicRestClientType<IRequestCalls>(UserSettings.AppApiUrl);
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("CERTIFICATIONAPI"))
                RequestClient = Builder.GetDynamicRestClientType<IRequestCalls>(UserSettings.CertApiUrl);
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("WEBREPORTAPI"))
                RequestClient = Builder.GetDynamicRestClientType<IRequestCalls>(UserSettings.WebRepApiUrl);
            if (FeatureContext.Current.FeatureInfo.Title.ToString().Replace(" ", "").ToUpper().Contains("PDUAPI"))
                RequestClient = Builder.GetDynamicRestClientType<IRequestCalls>(UserSettings.PduApiUrl);

            Container.RegisterInstance(TokenClient);
            Container.RegisterInstance(RequestClient);
        }
    }
}
