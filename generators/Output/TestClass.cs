using System.Collections.Generic;

namespace Generators.Output
{
    public class TestClass
    {
        public ISet<string> UsingNamespaces { get; set; } = new HashSet<string> { "Xunit" };
        public string ClassName { get; set; }
        public TestMethod[] TestMethods { get; set; }
        public string CanonicalDataVersion { get; set; }
    }    
}