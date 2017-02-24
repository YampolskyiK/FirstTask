using CrawlerTask;

namespace CrawlerService
{
    internal class Service : IContract
    {
        public void Crawl(string input, int threads)
        {
            Starter.Start(input, threads);
        }

        public void StopCrawling()
        {
            Starter.Stop();
        }
    }
}