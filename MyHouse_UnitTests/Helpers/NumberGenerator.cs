using System;
using System.Linq;

namespace MyHouseUnitTests.Helpers
{
    public class NumberGenerator
    {
        public static decimal RandomDecimal(int length, int decimalPlaces)
        {
            const string chars = "0123456789";
            decimal ret =
                decimal.Parse(
                    StringGenerator.RandomCharacter(chars, length)
                    + "."
                    + StringGenerator.RandomCharacter(chars, decimalPlaces)
                );
            return ret;
        }
    }
}
