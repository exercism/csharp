using System.Collections.Generic;

namespace Generators.Input
{
    public class CanonicalDataCase
    {
        public CanonicalDataCase(string property, IReadOnlyDictionary<string, dynamic> properties,
            IReadOnlyDictionary<string, dynamic> input, dynamic expected,
            string description, IReadOnlyCollection<string> descriptionPath)
            => (Property, Properties, Input, Expected, Description, DescriptionPath) =
                (property, properties, input, expected, description, descriptionPath);

        public IReadOnlyDictionary<string, dynamic> Properties { get; }
        public IReadOnlyDictionary<string, dynamic> Input { get; }
        public dynamic Expected { get; }
        public string Property { get; }
        public string Description { get; }
        public IReadOnlyCollection<string> DescriptionPath { get; }
    }
}