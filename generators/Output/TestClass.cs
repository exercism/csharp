using System.Collections.Generic;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Output
{
    public class TestClass
    {   
        public string Exercise { get; set; }
        public string ClassName { get; set; }
        public string CanonicalDataVersion { get; set; }
        public IList<string> Methods { get; set; }
        public ISet<string> Namespaces { get; set; }
        public string TemplateName { get; set; } = "TestClass";

        public string Render() => TemplateRenderer.RenderPartial(TemplateName, new { ClassName, CanonicalDataVersion, Methods, UsingNamespaces = Namespaces });
    }
}