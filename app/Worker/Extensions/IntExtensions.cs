using System.Linq;
using Worker.Models;

namespace Worker.Extensions
{
    public static class IntExtensions
    {
        public static string ToBase26Word(this int value)
        {
            string result = string.Empty;

            do
            {
                result = Base26Word.Alphabet.ElementAt(value % 26).Key + result;
                value = value / 26;
            }
            while (value > 0);

            return result;
        }
        public static string FromBase26(this int value)
        {
            string result = string.Empty;

            do
            {
                result = Base26Word.Alphabet.ElementAt(value % 26).Value + result;
                value = value / 26;
            }
            while (value > 0);

            return result;
        }
    }
}