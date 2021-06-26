using System.Collections.Generic;

namespace Exercism.CSharp.Input
{
    internal record CanonicalData(string Exercise, IReadOnlyCollection<CanonicalDataCase> Cases);
    
    internal record CanonicalDataCase(int Index, string Property, IReadOnlyDictionary<string, dynamic> Input,
        dynamic Expected, string Description, IReadOnlyCollection<string> DescriptionPath);
}