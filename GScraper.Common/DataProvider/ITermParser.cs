using GScraper.Common.Model;
using System;

namespace GScraper.Common
{
    public interface ITermParser
    {
        int Count(string text, string term);
    }
}
