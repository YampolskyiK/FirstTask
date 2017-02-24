using System.Threading;
using Crawler.Crawler;
using CrawlerTask.Intefaces;

namespace CrawlerTask
{
    public class CrawlerOptions
    {
        public CrawlerOptions(string rootString, int maxDepth, bool isParseExternalSites)
        {
            RootString = rootString;
            MaxDepth = maxDepth;
            IsParseExternalSites = isParseExternalSites;
            Semaphore = new SemaphoreSlim(1);
            Repository = new Repository(new CawlerContext());
            PageGetter  = new PageGetter();
        }

        public PageGetter PageGetter { get; set; }

        public string RootString { get; set; }

        public bool IsParseExternalSites { get; set; }

        public int MaxDepth { get; set; }

        public  IRepository Repository { get; set; }
        public SemaphoreSlim Semaphore { get; set; }
    }
}