using GScraper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace GScraper.DataAccess
{
    public class HtmlParser : ITermParser
    {
        public int Count(string text, string term)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            if (string.IsNullOrEmpty(term))
                return 0;

            //Convert the string into an array of words  
            string[] source = text.Split(new char[] { ' ', '/', '"' }, StringSplitOptions.RemoveEmptyEntries);

            // Create the query.  Use ToLowerInvariant to match "data" and "Data"
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == term.ToLowerInvariant()
                             select word;

            return matchQuery.Count();
        }


        public IList<int> Positions(string text, string term)
        {
            if (string.IsNullOrEmpty(text))
                return new List<int>() { 0};
            if (string.IsNullOrEmpty(term))
                return new List<int>() { 0 };

            var matches = Regex.Matches(text, @"<a href=""\/url\?q\=https\:\/\/(.+?)<\/a>");

            var count = 0;
            var pos = new List<int>();
            foreach (var item in matches.ToList())
            {
                count++;
                if(item.Value.Contains(term))
                    pos.Add(count);
            }

            return pos.Any() ? pos : new List<int>() { 0 };
        }
    }
}