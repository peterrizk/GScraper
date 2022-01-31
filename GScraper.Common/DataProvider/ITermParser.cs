using GScraper.Common.Model;
using System;
using System.Collections.Generic;

namespace GScraper.Common
{
    public interface ITermParser
    {
        int Count(string text, string term);

        IList<int> Positions(string text, string term);
    }
}
