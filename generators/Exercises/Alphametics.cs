using System;
using System.Collections.Generic;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Alphametics : Exercise
    {
        public Alphametics()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;

                if (canonicalDataCase.Expected == null)
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
                else
                    canonicalDataCase.Expected = ((JObject)canonicalDataCase.Expected).ToObject<Dictionary<char, int>>();
            }
        }

        protected override TestClass CreateTestClass()
        {
            var testClass = base.CreateTestClass();
            testClass.UsingNamespaces.Add(typeof(ArgumentException).Namespace);
            testClass.UsingNamespaces.Add(typeof(Dictionary<char, int>).Namespace);

            return testClass;
        }
    }
}