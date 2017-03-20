using System;

namespace Generators.Methods
{
    public class TestMethodOptions
    {
        public string InputProperty { get; set; }
        public bool FormatInput { get; set; } = true;
        public bool FormatExpected { get; set; } = true;
        public Type ExceptionType { get; set; } = typeof(ArgumentException);
    }
}