using System.Collections.Generic;
using Generators.Input;

namespace Generators.Output
{
    public class TestMethod
    {
        public string MethodName { get; set; }
        public IEnumerable<string> Body { get; set; }
        public CanonicalDataCase GeneratedFrom { get; set; }
    }
}