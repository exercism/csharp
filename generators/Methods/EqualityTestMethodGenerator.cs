using System;
using System.Linq;

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
                        if (TestMethodData.Options.UseVariableForExpected)
                            return $"var expected = {FormattedExpectedVariable};\nAssert.Equal(expected, {TestedClassName}.{TestedMethod}({Input}));";

                        return $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethod}({Input}));";
                    case TestedMethodType.Instance:
                        if (TestMethodData.Options.UseVariableForExpected)
                            return $"var expected = {FormattedExpectedVariable};\nvar sut = new {TestedClassName}();\n    Assert.Equal({Expected}, sut.{TestedMethod}({Input}));";

                        return $"var sut = new {TestedClassName}();\n    Assert.Equal({Expected}, sut.{TestedMethod}({Input}));";
                    case TestedMethodType.Extension:
                        if (TestMethodData.Options.UseVariableForExpected)
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
                var lines = Expected.ToString().Split('\n');
                if (lines.Length == 1)
                    return lines[0];

                return "\n" + string.Join("\n", lines.Select(line => $"{Tab}{line}"));
            }
        }
    }
}