using System;

namespace Generators.Methods
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body 
        {
            get
            {
                switch (TestMethodData.Options.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethod}({Input}));";
                    case TestedMethodType.Instance:
                        return $"var sut = new {TestedClassName}();\n    Assert.Equal({Expected}, sut.{TestedMethod}({Input}));";
                    case TestedMethodType.Extension:
                        return $"Assert.Equal({Expected}, {Input}.{TestedMethod}());";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        } 
    }
}