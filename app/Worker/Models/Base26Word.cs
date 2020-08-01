using System;
using System.Collections.Generic;

namespace Worker.Models
{
    public static class Base26Word
    {
        public static Dictionary<char, char> Alphabet = new Dictionary<char, char>
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

    }
}