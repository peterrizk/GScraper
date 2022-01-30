using GScraper.DataAccess;
using System;
using Xunit;

namespace GScraper.UnitTests
{
    public class TermParserTests
    {
        [Theory]
        [InlineData("www.smokeball.com.au", "www.smokeball.com.au", 1)]
        [InlineData("www.smokeball.com.au www.smokeball.com.au/www.smokeball.com.au", "www.smokeball.com.au", 3)]
        [InlineData(null, null,0)]
        [InlineData("", "",0)]
        public void StringParser_CountsTermsCorrectly(string text, string term, int expected)
        {
            var count = new TermParser().Count(text, term);
            Assert.Equal(expected, count);
        }
    }
}
