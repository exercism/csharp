using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class BookStore : Exercise
    {
        public BookStore()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Input = ((JArray)canonicalDataCase.Properties["basket"]).Values<int>();
                canonicalDataCase.UseInputParameters = true;
            }
        }
    }
}