using Humanizer;

namespace Generators.Methods
{
    public class TestedMethodNameTransformer : IStringTransformer
    {
        public string Transform(string input) => input.Dehumanize();
    }
}