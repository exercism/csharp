using Humanizer;

namespace Generators.Classes
{
    public class TestClassNameTransformer : IStringTransformer
    {
        public string Transform(string input) => $"{input.Dehumanize()}Test";
    }
}