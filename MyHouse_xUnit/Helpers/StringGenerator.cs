using System;
using System.Linq;

namespace MyHouseXunit.ValidationHelpers
{
    public class StringGenerator
    {
        private readonly static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'@!$%^&*()/.,;:#~[]{}";
            string ret = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return ret;
        }
    }
}
