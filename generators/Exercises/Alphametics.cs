using System;
using System.Collections.Generic;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Alphametics : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;

                if (canonicalDataCase.Expected == null)
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
                else
                    canonicalDataCase.Expected = ((JObject)canonicalDataCase.Expected).ToObject<Dictionary<char, int>>();
            }
        }

        protected override HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = base.GetUsingNamespaces();
            usingNamespaces.Add(typeof(Dictionary<char, int>).Namespace);

            return usingNamespaces;
        }
    }
}