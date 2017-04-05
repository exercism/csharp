using System;

namespace Generators.Methods
{
    public class TestMethodOptions
    {
        public string InputProperty { get; set; }
        public bool FormatInput { get; set; } = true;
        public bool FormatExpected { get; set; } = true;
        public bool UseVariableForExpected { get; set; } = false;
        public Type ExceptionType { get; set; } = typeof(ArgumentException);
        public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.Static;
        public Func<object, bool> ThrowExceptionWhenExpectedValueEquals { get; set; } = (x) => false;
    }
}