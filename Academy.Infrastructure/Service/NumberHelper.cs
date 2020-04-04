using System.Linq;

namespace Academy.Infrastructure.Service
{
    public static class NumberHelper
    {
        public static string ConvertToProperNumber(int number)
        {
            string no = number.ToString();
            if (no.Count() == 1)
            {
                return $"00000{number}";
            }
            if (no.Count() == 2)
            {
                return $"0000{number}";
            }
            if (no.Count() == 3)
            {
                return $"000{number}";
            }
            if (no.Count() == 4)
            {
                return $"00{number}";
            }
            if (no.Count() == 5)
            {
                return $"0{number}";
            }
            return number.ToString();
        }
    }
}
