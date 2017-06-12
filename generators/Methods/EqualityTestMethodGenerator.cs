using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Methods
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        private const string Tab = "    ";

        protected override string Body 
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return $"var expected = {FormattedExpectedVariable};\nAssert.Equal(expected, {TestedClassName}.{TestedMethod}({Input}));";

                        return $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethod}({Input}));";
                    case TestedMethodType.Instance:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return $"var expected = {FormattedExpectedVariable};\nvar sut = new {TestedClassName}();\n    Assert.Equal({Expected}, sut.{TestedMethod}({Input}));";

                        return $"var sut = new {TestedClassName}();\n    Assert.Equal({Expected}, sut.{TestedMethod}({Input}));";
                    case TestedMethodType.Extension:
                        if (TestMethodData.Options.ExpectedFormat == ExpectedFormat.FormattedAsMultilineString)
                            return $"var expected = {FormattedExpectedVariable};\nAssert.Equal(expected, {Input}.{TestedMethod}());";

                        return $"Assert.Equal({Expected}, {Input}.{TestedMethod}());";
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

                return "\n" + string.Join("\n", lines.Select(line => $"{Tab}{line}"));
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