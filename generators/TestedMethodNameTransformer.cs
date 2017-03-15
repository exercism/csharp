using Humanizer;

namespace Generators
{
    public class TestedMethodNameTransformer : IStringTransformer
    {
        public string Transform(string input) => input.Dehumanize();
    }
}