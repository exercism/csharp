using System.Globalization;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Double(double dbl) => dbl.ToString(CultureInfo.InvariantCulture);

        public string Float(float flt) => flt.ToString(CultureInfo.InvariantCulture);

        public string Int(int i) => i.ToString(CultureInfo.InvariantCulture);

        public string Ulong(ulong ulng) => $"{ulng}UL";
    }
}