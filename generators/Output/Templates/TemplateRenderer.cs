using System.Reflection;
using DotLiquid;
using DotLiquid.FileSystems;

namespace Exercism.CSharp.Output.Templates
{
    public static class TemplateRenderer
    {
        private static readonly string EmbeddedTemplatesNamespace = typeof(TemplateRenderer).Namespace;

        static TemplateRenderer()
        {
            Template.RegisterFilter(typeof(IndentFilter));
            Template.FileSystem = new EmbeddedFileSystem(Assembly.GetEntryAssembly(), EmbeddedTemplatesNamespace);
        }

        public static string RenderInline(string template, object parameters)
            => Template.Parse(template).Render(Hash.FromAnonymousObject(parameters));

        public static string RenderPartial(string template, object parameters) 
            => Template.Parse($"{{% include \"{template}\" %}}").Render(Hash.FromAnonymousObject(parameters));
    }
}