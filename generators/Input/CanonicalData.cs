using System.Collections.Generic;

namespace Generators.Input
{
    public class CanonicalData
    {
        public CanonicalData(string exercise, string version, IReadOnlyCollection<CanonicalDataCase> cases)
            => (Exercise, Version, Cases) = (exercise, version, cases);

        public string Exercise { get; }
        public string Version { get; }
        public IReadOnlyCollection<CanonicalDataCase> Cases { get; }
    }
}