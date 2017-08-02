using DotLiquid;

namespace Generators.Output
{
    public class UnescapedValue : ILiquidizable
    {
        private readonly string _value;

        public UnescapedValue(string value) => _value = value;

        public override string ToString() => _value;

        public object ToLiquid() => _value;
    }
}
