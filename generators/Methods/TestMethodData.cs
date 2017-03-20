using Generators.Data;

namespace Generators.Methods
{
    public class TestMethodData
    {
        public CanonicalData CanonicalData { get; set; }
        public CanonicalDataCase CanonicalDataCase { get; set;}
        public int Index { get; set; }
        public TestMethodOptions Options { get; } = new TestMethodOptions();
    }
}