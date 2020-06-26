using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public static class Base26Word
    {
        public static Dictionary<char, char> Map = new Dictionary<char, char>
            {
                { '0', 'a' },
                { '1', 'b' },
                { '2', 'c' },
                { '3', 'd' },
                { '4', 'e' },
                { '5', 'f' },
                { '6', 'g' },
                { '7', 'h' },
                { '8', 'i' },
                { '9', 'j' },
                { 'A', 'k' },
                { 'B', 'l' },
                { 'C', 'm' },
                { 'D', 'n' },
                { 'E', 'o' },
                { 'F', 'p' },
                { 'G', 'q' },
                { 'H', 'r' },
                { 'I', 's' },
                { 'J', 't' },
                { 'K', 'u' },
                { 'L', 'v' },
                { 'M', 'w' },
                { 'N', 'x' },
                { 'O', 'y' },
                { 'P', 'z' },
            };

        public static int WordCount(int digits)
        {
            return (int)Math.Pow(26.0, (double)digits);
        }
        public static string ToBase26Word(this int value)
        {
            string result = string.Empty;

            do
            {
                result = Map.ElementAt(value % 26).Key + result;
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
                result = Map.ElementAt(value % 26).Value + result;
                value = value / 26;
            }
            while (value > 0);

            return result;
        }
    }
}