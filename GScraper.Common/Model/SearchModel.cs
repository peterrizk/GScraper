using System;

namespace GScraper.Common.Model
{
    public class SearchModel
    {
        public string Terms { get; set; }

        public Uri Uri { get; set; }

        public string Path { get; set; }

        public int PageSize { get; set; }
        public string PageSizeQs { get; set; }
        public string TermsQs { get; set; }
        public string CountTerm { get; set; }
    }
}
