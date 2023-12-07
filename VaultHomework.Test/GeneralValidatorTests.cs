using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VaultHomework.Test
{
    public class GeneralValidatorTests
    {
        private readonly ValidatorBase unitUnderTest = new GeneralValidator();

        [Theory]
        [InlineData("alma korte!", true)]
        [InlineData("szilva.",  false)] // False because It's a single word
        [InlineData("citrom lime",  false)] // False due to missing punctuation
        [InlineData("korte korte?", false)] // False due to duplicated words
        [InlineData("dinnye, ananasz, fuge ",  false)] // False due to no comma allowed
        [InlineData("Alma Korte!", false)] // False due to capital letter  
        [InlineData("repeat repeat", false)]
        public void CheckOccurrences_ReturnsExpectedResult(string words, bool expected)
        {
            bool result = unitUnderTest.CheckValidPassphrases(words);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("all lowercase.",  true)]
        [InlineData("UpperCase!",  false)]
        [InlineData("mixed Case.",  false)]
        [InlineData("",  false)]
        public void IsAllValid_ReturnsExpectedResult(string line, bool expected)
        {
            bool result = unitUnderTest.IsAllValid(line);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("test!",  true)]
        [InlineData("example?",  true)]
        [InlineData("example.",  true)]
        [InlineData("fail",  false)] // No punctuation 
        public void IsLastCharValid_ReturnsExpectedResult(string line, bool expected)
        {
            bool result = unitUnderTest.IsLastCharValid(line);
            Assert.Equal(expected, result);
        }
    }
}
