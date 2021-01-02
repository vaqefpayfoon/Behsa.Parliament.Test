using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behsa.Parliament.Test.Utilities
{
    public static class FakeData
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static Int64 RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
