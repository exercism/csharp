using Humanizer;

namespace Generators
{
    public class TestedClassNameTransformer : IStringTransformer
    {
        public string Transform(string input) => input.Dehumanize();
    }
}