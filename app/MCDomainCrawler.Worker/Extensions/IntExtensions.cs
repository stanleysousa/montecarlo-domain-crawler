using MCDomainCrawler.Core;

namespace MCDomainCrawler.Worker.Extensions
{
    public static class IntExtensions
    {
        public static string ToBase26Number(this int value)
        {
            string result = string.Empty;

            do
            {
                var number = Base26.getNumber(value);
                result = number.character + result;
                value = number.remainder / 26;
            }
            while (value > 0);

            return result;
        }

        public static string ToBase26Word(this int value)
        {
            string result = string.Empty;

            do
            {
                var letter = Base26.getLetter(value);
                result = letter.character + result;
                value = letter.remainder / 26;
            }
            while (value > 0);

            return result;
        }
    }
}
