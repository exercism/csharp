using System.Collections.Generic;

namespace Generators.Output
{
    public class TestMethod
    {
        public string MethodName { get; set; }
        public IEnumerable<string> Body { get; set; }
    }
}