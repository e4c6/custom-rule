using UiPath.Studio.Activities.Api;
using UiPath.Studio.Activities.Api.Analyzer;


namespace CustomRules
{
    public class RegisterAnalyzerConfiguration : IRegisterAnalyzerConfiguration
    {
        public void Initialize(IAnalyzerConfigurationService workflowAnalyzerConfigService)
        {
            // Add rule configuration
            workflowAnalyzerConfigService.AddRule(StronglyTypedDictionaryRule.Get());
        }
    }
}