/*
   Copyright 2019 Raphael Beck

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Linq;
using System.Security.Cryptography;

namespace GlitchedPolygons.Utilities.RandomStringGenerator
{
    /// <summary>
    /// Simple utility class for generating random <c>string</c>s of any arbitrary size.
    /// </summary>
    public static class RandomStringGenerator
    {
        private static readonly char[] DEFAULT_LEGAL_CHARS =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
        };

        /// <summary>
        /// Gets the default legal characters for <c>string</c> generation that is used
        /// when no specific legal <c>char[]</c> array is passed as an argument to the <see cref="GenerateRandomString(int)"/> method.
        /// </summary>
        /// <returns>Returns a copy of <see cref="DEFAULT_LEGAL_CHARS"/>.</returns>
        public static char[] GetDefaultLegalChars()
        {
            int n = DEFAULT_LEGAL_CHARS.Length;
            char[] copy = new char[n];
            for (int i = 0; i < n; i++)
            {
                copy[i] = DEFAULT_LEGAL_CHARS[i];
            }
            return copy;
        }

        /// <summary>
        /// Generates a random <c>string</c> using only alpha-numeric characters.<para> </para>
        /// If the passed <paramref name="size"/> argument is 0, <c>string.Empty</c> is returned.<para> </para>
        /// If <paramref name="size"/> is &lt;0, the absolute value of that number will be used.<para> </para>
        /// A random <c>string</c> is returned.
        /// </summary>
        /// <param name="size">How long should the generated <c>string</c> be?</param>
        /// <returns>If the passed <paramref name="size"/> argument is 0, <c>string.Empty</c> is returned. If <paramref name="size"/> is &lt;0, the absolute value of that number will be used. A random <c>string</c> is returned.</returns>
        public static string GenerateRandomString(int size = 32)
        {
            return GenerateRandomString(DEFAULT_LEGAL_CHARS, size);
        }

        /// <summary>
        /// Generates a random <c>string</c> from a specific set of legal characters.<para> </para>
        /// If the passed <paramref name="size"/> argument is 0, or if <paramref name="legalChars"/> is <c>null</c> or empty, <c>string.Empty</c> is returned.<para> </para>
        /// If <paramref name="size"/> is &lt;0, the absolute value of that number will be used.<para> </para>
        /// On success, a random <c>string</c> is returned.
        /// </summary>
        /// <param name="legalChars">The legal characters to be used for the <c>string</c> generation.</param>
        /// <param name="size">The desired output <c>string</c>'s length.</param>
        /// <returns>If the passed <paramref name="size"/> argument is 0, or if <paramref name="legalChars"/> is <c>null</c> or empty, <c>string.Empty</c> is returned. If <paramref name="size"/> is &lt;0, the absolute value of that number will be used. On success, a random <c>string</c> is returned.</returns>
        public static string GenerateRandomString(char[] legalChars, int size = 32)
        {
            if (size == 0 || legalChars is null || legalChars.Length == 0)
                return string.Empty;
            
            if (size < 0) 
                size *= -1;
            
            byte[] data = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }
            
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = legalChars[data[i] % legalChars.Length];
            }

            return new string(chars);
        }

        /// <summary>
        /// Generates a random <c>string</c> from a specific set of legal characters.<para> </para>
        /// If the passed <paramref name="size"/> argument is 0, or if <paramref name="legalChars"/> is <c>null</c> or empty, <c>string.Empty</c> is returned.<para> </para>
        /// If <paramref name="size"/> is &lt;0, the absolute value of that number will be used.<para> </para>
        /// On success, a random <c>string</c> is returned.
        /// </summary>
        /// <param name="legalChars">The legal chars to be used for the <c>string</c> generation.</param>
        /// <param name="size">The desired output <c>string</c>'s length.</param>
        /// <returns>If the passed <paramref name="size"/> argument is 0, or if <paramref name="legalChars"/> is <c>null</c> or empty, <c>string.Empty</c> is returned. If <paramref name="size"/> is &lt;0, the absolute value of that number will be used. On success, a random <c>string</c> is returned.</returns>
        public static string GenerateRandomString(string legalChars, int size = 32)
        {
            return GenerateRandomString(legalChars?.Distinct().ToArray(), size);
        }
    }
}
