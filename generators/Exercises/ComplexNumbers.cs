using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ComplexNumbers : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            canonicalData.Cases = canonicalData.Cases.Where(c => c.Property != "exp").ToArray();

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Expected = ConvertToTuple(canonicalDataCase.Expected) ?? canonicalDataCase.Expected;

                var keys = canonicalDataCase.Input.Keys.ToArray();

                foreach (var key in keys)
                {
                   canonicalDataCase.Input[key] = ConvertToTuple(canonicalDataCase.Input[key]) ?? canonicalDataCase.Input[key];
                }
            }
        }

        protected override HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = base.GetUsingNamespaces();
            usingNamespaces.Add(typeof(Tuple<int, int>).Namespace);

            return usingNamespaces;
        }

        private Tuple<int, int> ConvertToTuple(object rawValue)
        {
            if (rawValue is JArray)
            {
                var array = rawValue.ConvertToEnumerable<int>().ToArray();
                return new Tuple<int, int>(array[0], array[1]);
            }
            else
            {
                return null;
            }
        }
    }
}