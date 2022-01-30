using GScraper.Common.Model;
using System;

namespace GScraper.Common
{
    public interface ISearchDataProvider
    {
        SearchModel Load();
        int Search(string uri, string term, ITermParser termParser);
    }
}
