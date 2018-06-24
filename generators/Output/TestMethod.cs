using Generators.Output.Templates;

namespace Generators.Output
{
    public class TestMethod
    {
        public bool Skip { get; set; }
        public string Name { get; set; }
        public TestMethodBody Body { get; set; }
        public string TemplateName { get; set; } = "TestMethod";

        public string Render() => TemplateRenderer.RenderPartial(TemplateName, new { Name, Body = Body.Render(), Skip });
    }
}