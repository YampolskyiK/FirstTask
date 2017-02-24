using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Crawler.Crawler
{
    public class PageGetter 
    {
        internal HtmlDocument GetPage(string uri)
        {
            try
            {
                return new HtmlWeb().Load(uri);
            }
            catch (Exception)
            {
                Console.WriteLine($"exp - {uri}");
                return null;
            }
        }

        public PageGetter()
        {
            Console.WriteLine("gettr - on");
        }
        ~PageGetter()
        {
            Console.WriteLine("getter - off");
        }

    }
}
