using Generators.Input;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Generators.Exercises
{
    class WordCount : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.Expected = ((JObject)canonicalDataCase.Expected).ToObject<Dictionary<string, int>>();
            }
        }

        protected override HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = base.GetUsingNamespaces();
            usingNamespaces.Add(typeof(Dictionary<string, int>).Namespace);

            return usingNamespaces;
        }
    }
}
