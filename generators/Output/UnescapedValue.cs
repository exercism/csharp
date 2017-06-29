namespace Generators.Output
{
    public class UnescapedValue
    {
        private readonly string _value;

        public UnescapedValue(string value) => _value = value;

        public override string ToString() => _value;
    }
}
