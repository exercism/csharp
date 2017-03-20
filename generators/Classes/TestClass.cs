using System.Collections.Generic;
using Generators.Methods;

namespace Generators.Classes
{
    public class TestClass
    {
        public ISet<string> UsingNamespaces { get; set; } = new HashSet<string> { "Xunit" };
        public string ClassName { get; set; }
        public string BeforeTestMethods { get; set; }
        public TestMethod[] TestMethods { get; set; }
        public string AfterTestMethods { get; set; }
    }    
}