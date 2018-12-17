using System.Globalization;
using System.Numerics;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Decimal(decimal dec) => $"{dec.ToString(CultureInfo.InvariantCulture)}m";

        public string Double(double dbl) => dbl.ToString(CultureInfo.InvariantCulture);

        public string Float(float flt) => flt.ToString(CultureInfo.InvariantCulture);

        public string Int(int i) => i.ToString(CultureInfo.InvariantCulture);

        public string Ulong(ulong ulng) => $"{ulng}UL";

        public string Uint(uint ui) => string.Format("0x{0:X}u", ui);

        public string BigInteger(BigInteger bigInt) => $"new BigInteger({bigInt.ToString()})";
    }
}