using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IContract> channelFactory = new ChannelFactory<IContract>(new BasicHttpBinding(),
                new EndpointAddress("http://localhost:1992/CrawlerService"));

            IContract service = channelFactory.CreateChannel();
            string uri = Console.ReadLine();
            
        }
    }
}
