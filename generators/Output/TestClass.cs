using System.Collections.Generic;

namespace Generators.Output
{
    public class TestClass
    {   
        public string ClassName { get; set; }
        public string CanonicalDataVersion { get; set; }
        public IEnumerable<string> Methods { get; set; }
        public IEnumerable<string> Namespaces { get; set; }
        public string TemplateName { get; set; } = "TestClass";

        public string Render() => TemplateRenderer.RenderPartial(TemplateName, new { ClassName, CanonicalDataVersion, Methods, UsingNamespaces = Namespaces });
    }
}