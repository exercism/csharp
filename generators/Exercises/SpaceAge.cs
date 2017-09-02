using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class SpaceAge : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["seconds"] = canonicalDataCase.Properties["seconds"]
                };

                canonicalDataCase.Property = $"On_{canonicalDataCase.Input["planet"]}";
                canonicalDataCase.Input.Remove("planet");
            }
        }
    }
}