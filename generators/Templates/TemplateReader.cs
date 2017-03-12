using System.IO;
using System.Reflection;

namespace Generators.Templates
{
    public static class TemplateReader
    {
        private static readonly Assembly assembly = Assembly.GetEntryAssembly();

        public static string Read(string templateFileName)
        {
            using (var stream = assembly.GetManifestResourceStream(GetTemplateFileResourceName(templateFileName)))
            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }

        private static string GetTemplateFileResourceName(string templateFileName)
            => $"{typeof(TemplateReader).Namespace}.{templateFileName}.liquid";
    }
}
