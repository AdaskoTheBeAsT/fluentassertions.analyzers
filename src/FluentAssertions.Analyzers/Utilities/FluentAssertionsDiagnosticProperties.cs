﻿using System.Collections.Immutable;

namespace FluentAssertions.Analyzers
{

    public class FluentAssertionsDiagnosticProperties
    {
        public ImmutableDictionary<string, string> Properties { get; }

        public FluentAssertionsDiagnosticProperties(ImmutableDictionary<string, string> properties)
        {
            Properties = properties;
        }

        public string Title => GetPropertyOrDefault(Constants.DiagnosticProperties.Title);
        public string VariableName => GetPropertyOrDefault(Constants.DiagnosticProperties.VariableName);
        public string BecauseArgumentsString => GetPropertyOrDefault(Constants.DiagnosticProperties.BecauseArgumentsString);
        public string ExpectedItemString => GetPropertyOrDefault(Constants.DiagnosticProperties.ExpectedItemString);
        public string UnexpectedItemString => GetPropertyOrDefault(Constants.DiagnosticProperties.UnexpectedItemString);
        public string ArgumentString => GetPropertyOrDefault(Constants.DiagnosticProperties.ArgumentString);

        public string VisitorName => GetPropertyOrDefault(Constants.DiagnosticProperties.VisitorName);

        public string CombineWithBecauseArgumentsString(string validArgument)
        {
            if (!string.IsNullOrWhiteSpace(BecauseArgumentsString) && !string.IsNullOrWhiteSpace(validArgument))
            {
                return $"{validArgument}, {BecauseArgumentsString}";
            }
            return validArgument + BecauseArgumentsString;
        }

        private string GetPropertyOrDefault(string key) => Properties.TryGetValue(key, out var value) ? value : string.Empty;
    }
}
