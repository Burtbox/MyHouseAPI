using System;
using System.Linq;

namespace MyHouseUnitTests.Helpers
{
    public class StringGenerator
    {
        private readonly static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'@!$%^&*()/.,;:#~[]{}";
            string ret = RandomCharacter(chars, length);
            return ret;
        }

        public static string RandomCharacter(string chars, int length)
        {
            string ret = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return ret;
        }
    }
}
