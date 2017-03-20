using Humanizer;

namespace Generators.Classes
{
    public class TestedClassNameTransformer : IStringTransformer
    {
        public string Transform(string input) => input.Dehumanize();
    }
}