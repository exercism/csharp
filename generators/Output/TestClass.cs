using System.Collections.Generic;

namespace Generators.Output
{
    public class TestClass
    {
        public string ClassName { get; set; }
        public string CanonicalDataVersion { get; set; }
        public IList<string> Methods { get; set; }
        public ISet<string> UsingNamespaces { get; set; } = new HashSet<string> { "Xunit" };
        public string TemplateName { get; set; } = "TestClass";
        
        public string Render() => TemplateRenderer.RenderPartial(TemplateName, new { ClassName, CanonicalDataVersion, Methods, UsingNamespaces });
    }    
}