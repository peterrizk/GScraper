﻿using GScraper.Common;
using System;
using System.Linq;

namespace GScraper.DataAccess
{
    public class TermParser : ITermParser
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
    }
}