using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerClient
{
    [ServiceContract]
    internal interface IContract
    {
        [OperationContract]
        void Crawl(string input, int threads);

        [OperationContract]
        void StopCrawling();

    }
}
