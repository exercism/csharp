using System.Collections.Generic;

namespace Exercism.CSharp.Input
{
    public class CanonicalDataCase
    {
        public CanonicalDataCase(int index, string property, IReadOnlyDictionary<string, dynamic> properties,
            IReadOnlyDictionary<string, dynamic> input, dynamic expected,
            string description, IReadOnlyCollection<string> descriptionPath)
            => (Index, Property, Properties, Input, Expected, Description, DescriptionPath) =
                (index, property, properties, input, expected, description, descriptionPath);

        public int Index { get; }
        public IReadOnlyDictionary<string, dynamic> Properties { get; }
        public IReadOnlyDictionary<string, dynamic> Input { get; }
        public dynamic Expected { get; }
        public string Property { get; }
        public string Description { get; }
        public IReadOnlyCollection<string> DescriptionPath { get; }
    }
}