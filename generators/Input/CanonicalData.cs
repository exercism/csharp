using System.Collections.Generic;

namespace Exercism.CSharp.Input
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