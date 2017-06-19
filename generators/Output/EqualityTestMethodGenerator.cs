using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Output
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body 
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodFormat)
                {
                    case TestedMethodFormat.Static:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return new[] { $"var expected = {FormattedExpectedVariable};", $"Assert.Equal(expected, {TestedClassName}.{TestedMethodName}({Input}));" };

                        return new[] { $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethodName}({Input}));" };
                    case TestedMethodFormat.Instance:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return new[] { $"var expected = {FormattedExpectedVariable};", $"var sut = new {TestedClassName}();", $"Assert.Equal({Expected}, sut.{TestedMethodName}({Input}));" };

                        return new[] { $"var sut = new {TestedClassName}();", $"Assert.Equal({Expected}, sut.{TestedMethodName}({Input}));" };
                    case TestedMethodFormat.Extension:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return new[] { $"var expected = {FormattedExpectedVariable};", $"Assert.Equal(expected, {Input}.{TestedMethodName}());" };

                        return new[] { $"Assert.Equal({Expected}, {Input}.{TestedMethodName}());" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected virtual string FormattedExpectedVariable
        {
            get
            {
                var lines = ExpectedToMultiLineString(Expected).Split('\n');
                if (lines.Length == 1)
                    return lines[0];

                return "\n" + string.Join("\n", lines.Select(line => $"{line}"));
            }
        }

        private string ExpectedToMultiLineString(object expected)
        {
            switch (expected)
            {
                case JArray jarray:
                    return ExpectedToMultiLineString(jarray.Values<string>());
                case IEnumerable<string> enumerable:
                    return string.Join(" + \"\\n\" +\n", enumerable.Select(FormatExpectedValue)).Replace("\" + \"\\n", "\\n");
                case string str:
                    return ExpectedToMultiLineString(str.Split('\n'));
                default:
                    throw new ArgumentException("Cannot convert expected value to multiline string.");
            }
        }
    }
}