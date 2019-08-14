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

using System;
using System.Linq;
using Xunit;

namespace GlitchedPolygons.Utilities.RandomStringGenerator.UnitTests
{
    public class RandomStringGeneratorTests
    {
        private static readonly char[] DEFAULT_LEGAL_CHARS =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        };

        [Fact]
        public void GetDefaultLegalChars_ReturnsCorrectArray()
        {
            Assert.Equal(DEFAULT_LEGAL_CHARS, RandomStringGenerator.GetDefaultLegalChars());
        }

        [Fact]
        public void GetDefaultLegalChars_ReturnsOnlyCopy()
        {
            char[] copy = RandomStringGenerator.GetDefaultLegalChars();
            copy[0] = copy[1] = copy[2] = copy[3] = '_';
            Assert.NotEqual(copy, DEFAULT_LEGAL_CHARS);
            Assert.NotEqual(copy, RandomStringGenerator.GetDefaultLegalChars());
            Assert.Equal(DEFAULT_LEGAL_CHARS, RandomStringGenerator.GetDefaultLegalChars());
        }

        [Fact]
        public void GenerateRandomString_ZeroSize_ReturnsStringEmpty()
        {
            Assert.Equal(string.Empty, RandomStringGenerator.GenerateRandomString(0));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(new char[0])]
        public void GenerateRandomString_NullOrEmptyLegalChars_ReturnsEmptyString(char[] legalChars)
        {
            Assert.Empty(RandomStringGenerator.GenerateRandomString(legalChars));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GenerateRandomString_NullOrEmptyLegalChars_StringVariant_ReturnsEmptyString(string legalChars)
        {
            Assert.Empty(RandomStringGenerator.GenerateRandomString(legalChars));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(64)]
        [InlineData(-32)]
        [InlineData(-159)]
        [InlineData(1996)]
        [InlineData(1337420)]
        public void GenerateRandomString_GeneratedStringHasPassedDesiredLength(int size)
        {
            Assert.Equal(Math.Abs(size), RandomStringGenerator.GenerateRandomString(size).Length);
        }
       
        [Theory]
        [InlineData("ABC")]
        [InlineData("AAAAABC")]
        [InlineData("ABCDEFabcdef")]
        [InlineData("öäü*ç%&/+¦|¢(=§5234¨__[")]
        public void GenerateRandomString_GeneratedStringOnlyContainsLegalCharacters(string legalChars)
        {
            bool fail = false;
            string str = RandomStringGenerator.GenerateRandomString(legalChars);
            foreach (char c in str)
            {
                if (!legalChars.Contains(c))
                {
                    fail = true;
                    break;
                }
            }
            Assert.False(fail);
        }

        [Fact]
        public void GenerateRandomString_TwoGeneratedStringsAreNotIdentical()
        {
            Assert.NotEqual(RandomStringGenerator.GenerateRandomString(), RandomStringGenerator.GenerateRandomString());
        }
    }
}