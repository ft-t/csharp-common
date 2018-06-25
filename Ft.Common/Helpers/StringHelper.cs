using System;

namespace Ft.Common.Helpers
{
    public static class StringHelper
    {
        public static string GetRandomString()
        {
            var id = Guid.NewGuid();

            return id.ToString();
        }

        /// <summary>
        /// Trims the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string TrimLength(this string str, int length = 100)
        {
            string result = str;

            if (str.Length > length)
            {
                result = $"{str.Substring(0, length)}...";
            }

            return result;
        }
    }
}