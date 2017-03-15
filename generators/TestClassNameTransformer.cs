using Humanizer;

namespace Generators
{
    public class TestClassNameTransformer : IStringTransformer
    {
        public string Transform(string input) => $"{input.Dehumanize()}Test";
    }
}