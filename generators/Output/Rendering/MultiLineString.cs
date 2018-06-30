using System;
using DotLiquid;

namespace Exercism.CSharp.Output.Rendering
{
    public class MultiLineString : ILiquidizable
    {
        private readonly string _value;

        public MultiLineString(object obj) 
            => _value = string.Join("\n", obj as object[] ?? Array.Empty<object>());

        public override string ToString() => _value;

        public object ToLiquid() => _value;
    }
}
