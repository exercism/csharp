using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Output
{
    public class MultiLineString : IEnumerable<string>
    {
        private readonly IEnumerable<string> _lines;

        public MultiLineString(string str) => _lines = str.Split('\n');
        public MultiLineString(JToken jToken) => _lines = jToken.Values<string>();
        public MultiLineString(IEnumerable<string> lines) => _lines = lines;

        public IEnumerator<string> GetEnumerator() => _lines.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}