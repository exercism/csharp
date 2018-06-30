using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Tuple(Tuple<string, object> tuple) =>
            $"Tuple.Create({tuple.Item1}, {tuple.Item2})";
    }
}