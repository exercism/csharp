using System.Collections.Generic;
using System.Linq;
using Humanizer;
using To = Generators.Helpers.To;

namespace Generators.Methods
{
    public abstract class TestMethodGenerator
    {
        public TestMethod Create(TestMethodData testMethodData)
        {
            TestMethodData = testMethodData;

            return new TestMethod
            {
                MethodName = MethodName,
                Body = Body,
                Index = TestMethodData.Index,
                UsingNamespaces = UsingNamespaces
            };
        }

        protected TestMethodData TestMethodData { get; private set; }

        protected abstract string Body { get; }

        protected virtual ISet<string> UsingNamespaces 
            => new HashSet<string>();

        protected virtual string MethodName
            => TestMethodData.CanonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName);    

        protected virtual string TestedClassName
            => TestMethodData.CanonicalData.Exercise.Transform(To.TestedClassName);

        protected virtual string TestedMethod
            => TestMethodData.CanonicalDataCase.Property.Transform(To.TestedMethodName);

        protected virtual object Input => 
            TestMethodData.Options.FormatInput 
                ? FormatInputValue(InputValue) 
                : InputValue;

        protected virtual object Expected => 
            TestMethodData.Options.FormatExpected 
                ? FormatValue(TestMethodData.CanonicalDataCase.Expected) 
                : TestMethodData.CanonicalDataCase.Expected;

        protected virtual object InputValue => 
            TestMethodData.Options.InputProperty == null 
                ? TestMethodData.CanonicalDataCase.Input
                : TestMethodData.CanonicalDataCase.Data[TestMethodData.Options.InputProperty];

        protected virtual object FormatValue(object val)
        {
            switch (val)
            {
                case string s:
                    return $"\"{s}\"";
                default:
                    return val;
            }
        }

        protected virtual object FormatInputValue(object val)
        {
            switch (val)
            {
                case IEnumerable<object> inputs when !(val is string):
                    return string.Join(", ", inputs.Select(FormatValue));
                default:
                    return FormatValue(val);
            }
        }
    }
}