using System;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    internal class MultiLineString
    {
        public MultiLineString(object obj) =>
            Lines = obj switch
            {
                string[] lines => lines,
                string line => line.Split("\n"),
                JArray _ => Array.Empty<string>(),
                _ => throw new ArgumentException("Unsupported multi-line string type", nameof(obj))
            };

        public string[] Lines { get; }
    }
}
