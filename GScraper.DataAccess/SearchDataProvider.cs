using GScraper.Common;
using GScraper.Common.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace GScraper.DataAccess
{
    public class SearchDataProvider : ISearchDataProvider
    {
        public SearchModel Load()
        {
            return new SearchModel()
            {
                Terms = "conveyancing software",
                TermsQs = "q",
                Uri = new Uri("https://www.google.com.au"),
                Path = "search",
                PageSize = 100,
                PageSizeQs = "num",
                CountTerm = "www.smokeball.com.au"
            };
        }

        public IList<int> Search(string uri, string term, ITermParser termParser)
        {
            var text = string.Empty;
            using (var response = new HttpClient().GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).Result)
            {
                response.EnsureSuccessStatusCode();
                text = response.Content.ReadAsStringAsync().Result;
            }
            return termParser.Positions(text,term);
        }
    }
}