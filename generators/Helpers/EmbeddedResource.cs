using System.IO;

namespace Exercism.CSharp.Helpers
{
    public static class EmbeddedResource
    {
        public static string Read(string name)
        {
            using (var stream = typeof(EmbeddedResource).Assembly.GetManifestResourceStream(name))
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
