using DotLiquid;

namespace Generators.Templates
{
    public static class TemplateRenderer
    {
        public static string Render(string templateFileName, object templateModel)
        {
            var template = Template.Parse(TemplateReader.Read(templateFileName));
            return template.Render(Hash.FromAnonymousObject(templateModel));
        }
    }
}
