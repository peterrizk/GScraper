using GScraper.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace GScraper.UnitTests
{
    public class HtmlParserTests
    {
        [Theory]
        [InlineData(@"<a href=""/url?q=https://www.leapconveyancer.com.au/&amp;sa=U&amp;ved=2ahUKEwjz8a3gr9v1AhWojYkEHWfZA_YQFnoECGMQAg&amp;usg=AOvVaw2vqUQZ1AwoRsQBpKrDUa_y""><div>www.leapconveyancer.com.au</div></a>", "www.smokeball.com.au", new[] { 0 })]
        [InlineData(@"<a href=""/url?q=https://www.smokeball.com.au/&amp;sa=U&amp;ved=2ahUKEwjz8a3gr9v1AhWojYkEHWfZA_YQFnoECGMQAg&amp;usg=AOvVaw2vqUQZ1AwoRsQBpKrDUa_y""><div>www.leapconveyancer.com.au</div></a>
                        <a href=""/url?q=https://www.leapconveyancer.com.au/&amp;sa=U&amp;ved=2ahUKEwjz8a3gr9v1AhWojYkEHWfZA_YQFnoECGMQAg&amp;usg=AOvVaw2vqUQZ1AwoRsQBpKrDUa_y""><div>www.leapconveyancer.com.au</div></a>
                            <a href=""/url?q=https://www.smokeball.com.au/&amp;sa=U&amp;ved=2ahUKEwjz8a3gr9v1AhWojYkEHWfZA_YQFnoECGMQAg&amp;usg=AOvVaw2vqUQZ1AwoRsQBpKrDUa_y""><div>www.leapconveyancer.com.au</div></a>", "www.smokeball.com.au", new[] { 1, 3 })]
        [InlineData(null, null, new[] { 0 })]
        [InlineData("", "", new[] { 0 })]
        public void HtmlParser_FindsPositionsOfSearchResults(string text, string term, int[] expected)
        {
            var count = new HtmlParser().Positions(text, term);
            Assert.Equal(expected, count);
        }

        [Theory]
        [InlineData("www.smokeball.com.au", "www.smokeball.com.au", 1)]
        [InlineData("www.smokeball.com.au www.smokeball.com.au/www.smokeball.com.au", "www.smokeball.com.au", 3)]
        [InlineData(null, null, 0)]
        [InlineData("", "", 0)]
        public void StringParser_CountsTermsCorrectly(string text, string term, int expected)
        {
            var count = new HtmlParser().Count(text, term);
            Assert.Equal(expected, count);
        }
    }
}
