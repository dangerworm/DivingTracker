using System;

namespace DivingTracker.ServiceLayer.JsonModels
{
    public class WikipediaSearchDataJdo
    {
        public WikipediaSearchQueryJdo query { get; set; }
    }

    public class WikipediaSearchQueryJdo
    {
        public SearchInfo searchinfo { get; set; }
        public Search[] search { get; set; }
    }

    public class SearchInfo
    {
        public int totalhits { get; set; }
    }

    public class Search
    {
        public int ns { get; set; }
        public string title { get; set; }
        public int pageid { get; set; }
        public int size { get; set; }
        public int wordcount { get; set; }
        public string snippet { get; set; }
        public DateTime timestamp { get; set; }
    }
}
