using GScraper.Common.Model;
using System;
using System.Collections.Generic;

namespace GScraper.Common
{
    public interface ISearchDataProvider
    {
        SearchModel Load();
        IList<int> Search(string uri, string term, ITermParser termParser);
    }
}
