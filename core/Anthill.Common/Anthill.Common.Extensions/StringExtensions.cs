using System;
using System.Linq;

namespace Anthill.Common.Extensions
{
    public static class StringExtensions
    {
        public static void AddLine(this String source, String line)
        {
            source += Environment.NewLine + line;
        }

        public static string Truncate(this String source, Int32 maxLength)
        {
            return source.Length <= maxLength ? source : source.Remove(maxLength);
        }

        public static string Join(string separator, params string[] parts)
        {
            return string.Join(separator , parts.Where(s => !string.IsNullOrEmpty(s)));
        }

        public static string CapitalFirst(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            return char.ToUpper(source[0]) + source.Substring(1).ToLower();
        }
    }
}
