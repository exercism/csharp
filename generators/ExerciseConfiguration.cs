using System;
using Newtonsoft.Json.Linq;

namespace Generators
{
    public class ExerciseConfiguration
    {
        public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.Static;
        public Type ExceptionType { get; set; } = typeof(ArgumentException);
        public Func<object, bool> ThrowExceptionWhenExpectedValueEquals { get; set; } = x => x is JObject;
    }
}