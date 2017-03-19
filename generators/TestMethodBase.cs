using Humanizer;

namespace Generators
{
    public abstract class TestMethodBase : TestMethod
    {
        protected TestMethodBase(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            MethodName = GetMethodName(canonicalDataCase);
            Body = GetBody(canonicalData, canonicalDataCase);
            Index = index;
        }

        protected abstract string GetBody(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase);

        protected virtual string GetMethodName(CanonicalDataCase canonicalDataCase)
            => canonicalDataCase.Description.Replace(":", " is").Transform(To.TestMethodName);    

        protected virtual string GetTestedClassName(CanonicalData canonicalData)
            => canonicalData.Exercise.Transform(To.TestedClassName);

        protected virtual string GetTestedMethod(CanonicalDataCase canonicalDataCase)
            => canonicalDataCase.Property.Transform(To.TestedMethodName);
    }
}