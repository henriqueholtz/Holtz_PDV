using System.Globalization;

namespace Holtz_PDV.Models.Enums
{
    public class Moeda
    {
        public string ToString(double Value)
        {
            return Value.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
