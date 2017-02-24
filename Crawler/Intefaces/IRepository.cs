using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerTask.Intefaces
{
    public interface IRepository
    {
        Link GetLink(string uri, Link parrentLink);
        Image AddImage(string uri, Request request);
        StyleSheet AddCss(string uri, Request request);

        void AddRequest(Request request);
    }
}
