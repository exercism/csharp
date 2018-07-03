using System;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public class MultiLineString
    {
        public MultiLineString(object obj)
        {
            switch (obj)
            {
                case string[] lines:
                    Lines = lines;
                    break;
                case string line:
                    Lines = line.Split("\n");
                    break;
                case JArray _:
                    Lines = Array.Empty<string>();
                    break;
                default:
                    throw new ArgumentException("Unsupported multi-line string type", nameof(obj));
            }
        }
        
        public string[] Lines { get; }
    }
}
