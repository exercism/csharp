namespace Generators
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override string GetBody() 
            => $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethod}({Input}));";
    }
}