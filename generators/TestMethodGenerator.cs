using Humanizer;

namespace Generators
{
    public abstract class TestMethodGenerator
    {
        public TestMethod Create(TestMethodData testMethodData)
        {
            TestMethodData = testMethodData;

            return new TestMethod
            {
                MethodName = MethodName,
                Body = GetBody(),
                Index = TestMethodData.Index
            };
        }

        protected TestMethodData TestMethodData { get; private set; }

        protected abstract string GetBody();

        protected virtual string MethodName
            => TestMethodData.CanonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName);    

        protected virtual string TestedClassName
            => TestMethodData.CanonicalData.Exercise.Transform(To.TestedClassName);

        protected virtual string TestedMethod
            => TestMethodData.CanonicalDataCase.Property.Transform(To.TestedMethodName);

        protected virtual object Input => FormatValue(InputValue);

        protected virtual object Expected => FormatValue(TestMethodData.CanonicalDataCase.Expected);

        protected virtual object InputValue 
            => TestMethodData.InputProperty == null 
                ? TestMethodData.CanonicalDataCase.Input 
                : TestMethodData.CanonicalDataCase.Data[TestMethodData.InputProperty];

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
    }
}