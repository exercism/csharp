using System;

namespace Generators.Methods
{
    public class TestMethodOptions
    {
        public ExpectedFormat ExpectedFormat { get; set; } = ExpectedFormat.Formatted;
        public Type ExceptionType { get; set; } = typeof(ArgumentException);
        public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.Static;
        public Func<object, bool> ThrowExceptionWhenExpectedValueEquals { get; set; } = x => false;
    }
}