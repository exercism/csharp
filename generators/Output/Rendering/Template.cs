using System.Reflection;
using DotLiquid;
using DotLiquid.FileSystems;

namespace Exercism.CSharp.Output.Rendering
{
    internal static class Template
    {
        private static readonly string EmbeddedTemplatesNamespace = $"{typeof(Template).Namespace}.Templates";

        static Template()
        {
            DotLiquid.Template.RegisterFilter(typeof(IndentFilter));
            DotLiquid.Template.FileSystem = new EmbeddedFileSystem(Assembly.GetEntryAssembly(), EmbeddedTemplatesNamespace);
        }

        public static string Render(string template, object parameters) 
            => DotLiquid.Template.Parse($"{{% include \"{template}\" %}}").Render(Hash.FromAnonymousObject(parameters));
    }
}