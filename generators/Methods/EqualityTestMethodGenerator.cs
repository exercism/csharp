namespace Generators.Methods
{
    public class EqualityTestMethodGenerator : TestMethodGenerator
    {
        protected override string Body => $"Assert.Equal({Expected}, {TestedClassName}.{TestedMethod}({Input}));";
    }
}