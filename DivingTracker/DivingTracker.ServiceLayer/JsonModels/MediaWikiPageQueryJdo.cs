using System;
using System.Collections.Generic;

namespace DivingTracker.ServiceLayer.JsonModels
{
    public class MediaWikiPageDataJdo
    {
        public MediaWikiPageQueryJdo query { get; set; }
    }

    public class MediaWikiPageQueryJdo
    {
        public Dictionary<string, MediaWikiPageJdo> pages { get; set; }
    }

    public class MediaWikiPageJdo
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string contentmodel { get; set; }
        public string pagelanguage { get; set; }
        public string pagelanguagehtmlcode { get; set; }
        public string pagelanguagedir { get; set; }
        public DateTime touched { get; set; }
        public int lastrevid { get; set; }
        public int length { get; set; }
        public string fullurl { get; set; }
        public string editurl { get; set; }
        public string canonicalurl { get; set; }
    }
}
