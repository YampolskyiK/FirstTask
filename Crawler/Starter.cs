using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawlerTask;

namespace CrawlerTask
{
    public class Starter
    {
        public static int max { get; set; }
        public static  bool IsStarted { get; set; }

        public static  void Start(string uri, int threads)
        {
            if (!IsStarted)
            {
                IsStarted = true;
                max = threads;
                CrawlerOptions options = new CrawlerOptions(uri, 3, true);
                Crawler crawler = new Crawler(options);
                crawler.Crawl();
                Wait();
            }
        }
        public static  void Stop()
        {
            max = 0;
            IsStarted = false;
        }

        private static void Wait()
        {
            while (true)
            {
                Thread.Sleep(3000);
                int free1, free2;
                ThreadPool.SetMaxThreads(max, max);
                ThreadPool.GetAvailableThreads(out free1, out free2);
                Console.WriteLine($"{free1}/{max}");

                if (free1 == max)
                {
                    Console.WriteLine("THE END");
                    break;
                }

            }
        }
    }
}
