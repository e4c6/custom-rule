using System.Text.RegularExpressions;
using UiPath.Activities.Api;
using UiPath.Studio.Activities.Api.Analyzer.InspectionObjects;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace CustomRules
{
    internal static class StronglyTypedDictionaryRule
    {
        private const string RuleId = "UM-ERR-007"; // Unique identifier for the rule

        internal static Rule<IActivityModel> Get()
        {
            var rule = new Rule<IActivityModel>("Strongly Typed Dictionary Rule", RuleId, Inspect)
            {
                RecommendationMessage = "Ensure all dictionaries are strongly typed.",
                ErrorLevel = System.Diagnostics.TraceLevel.Warning
            };
            return rule;
        }

        private static InspectionResult Inspect(IActivityModel activityModel, Rule ruleInstance)
        {
            var messageList = new List<string>();

            foreach (var variable in activityModel.Variables)
            {
                string typeName = variable.Type;

                // Check if the type name represents a Dictionary type
                if (typeName.StartsWith("System.Collections.Generic.Dictionary`2"))
                {
                    // Extract the generic arguments from the type name
                    var match = Regex.Match(typeName, @"System\.Collections\.Generic\.Dictionary`2\[\[(.+?),(.+?)\]\]");
                    if (match.Success && match.Groups.Count == 3)
                    {
                        var keyType = match.Groups[1].Value.Trim();
                        var valueType = match.Groups[2].Value.Trim();

                        // Check if either the key or value types are "System.Object"
                        if (keyType.Contains("System.Object") || valueType.Contains("System.Object"))
                        {
                            messageList.Add($"The dictionary {variable.DisplayName} is not strongly typed: {variable.Type}");
                        }

                        // To Debug in UiPath Studio, add else { messageList.Add($"The dictionary {variable.DisplayName} is strongly typed: {variable.Type}"); }
                    }
                }
            }

            return messageList.Any()
                ? new InspectionResult
                {
                    ErrorLevel = ruleInstance.ErrorLevel,
                    HasErrors = true,
                    RecommendationMessage = ruleInstance.RecommendationMessage,
                    Messages = messageList
                }
                : new InspectionResult() { HasErrors = false };
        }
    }
    // This static class is not mandatory. It just helps organizining the code.
    }