﻿using FluentAssertions.Analyzers.Tips;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class NullConditionalAssertionTests
    {
        [AssertionDataTestMethod]
        [AssertionDiagnostic("actual?.Should().Be(expected{0});")]
        [Implemented]
        public void TestAnalyzer(string assertion) => VerifyCSharpDiagnostic(assertion);

        private void VerifyCSharpDiagnostic(string assertion)
        {
            var code = new StringBuilder()
                .AppendLine("using System;")
                .AppendLine("using FluentAssertions;")
                .AppendLine("namespace TestNamespace")
                .AppendLine("{")
                .AppendLine("    class TestClass")
                .AppendLine("    {")
                .AppendLine("        void TestMethod(int? actual, int expected)")
                .AppendLine("        {")
                .AppendLine($"            {assertion}")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("    class Program")
                .AppendLine("    {")
                .AppendLine("        public static void Main()")
                .AppendLine("        {")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("}")
                .ToString();

            DiagnosticVerifier.VerifyCSharpDiagnostic<NullConditionalAssertionAnalyzer>(code, new DiagnosticResult
            {
                Id = NullConditionalAssertionAnalyzer.DiagnosticId,
                Message = NullConditionalAssertionAnalyzer.Message,
                Severity = Microsoft.CodeAnalysis.DiagnosticSeverity.Warning,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 9, 13)
                }
            });
        }
    }
}
