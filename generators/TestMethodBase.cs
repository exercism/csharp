using Humanizer;

namespace Generators
{
    public abstract class TestMethodBase : TestMethod
    {
        protected TestMethodBase(TestMethodData testMethodData)
        {
            MethodName = GetMethodName(testMethodData);
            Body = GetBody(testMethodData);
            Index = testMethodData.Index;
        }

        protected abstract string GetBody(TestMethodData testMethodData);

        protected virtual string GetMethodName(TestMethodData testMethodData)
            => testMethodData.CanonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName);    

        protected virtual string GetTestedClassName(TestMethodData testMethodData)
            => testMethodData.CanonicalData.Exercise.Transform(To.TestedClassName);

        protected virtual string GetTestedMethod(TestMethodData testMethodData)
            => testMethodData.CanonicalDataCase.Property.Transform(To.TestedMethodName);
    }
}