using System.Collections.Generic;

namespace Exercism.CSharp.Input
{
    // TODO: use records
    internal class CanonicalData
    {
        public CanonicalData(string exercise, IReadOnlyCollection<CanonicalDataCase> cases) =>
            (Exercise, Cases) = (exercise, cases);

        public string Exercise { get; }
        public IReadOnlyCollection<CanonicalDataCase> Cases { get; }
    }
}