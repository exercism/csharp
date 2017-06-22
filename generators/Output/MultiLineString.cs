using System.Collections;
using System.Collections.Generic;

namespace Generators.Output
{
    public class MultiLineString : IEnumerable<string>
    {
        private readonly IEnumerable<string> _lines;

        public MultiLineString(string str) : this(str.Split('\n'))
        {
        }

        public MultiLineString(IEnumerable<string> lines) => _lines = lines;

        public IEnumerator<string> GetEnumerator() => _lines.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}