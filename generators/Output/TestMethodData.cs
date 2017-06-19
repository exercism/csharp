using Generators.Input;

namespace Generators.Output
{
    public class TestMethodData
    {
        public CanonicalData CanonicalData { get; set; }
        public CanonicalDataCase CanonicalDataCase { get; set;}
        public int Index { get; set; }
        public TestMethodOptions Options { get; set; } = new TestMethodOptions();
    }
}