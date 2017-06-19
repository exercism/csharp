using System;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ExerciseConfiguration
    {
        public ExpectedFormat ExpectedFormat { get; set; } = ExpectedFormat.Formatted;
        public Type ExceptionType { get; set; } = typeof(ArgumentException);
        public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.EqualityCheck;
        public TestedMethodFormat TestedMethodFormat { get; set; } = TestedMethodFormat.Static;
        public Func<object, bool> ThrowExceptionWhenExpectedValueEquals { get; set; } = x => x is JObject;
    }
}