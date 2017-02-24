using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Crawler.Crawler;
using HtmlAgilityPack;
using NLog;

namespace CrawlerTask
{
    public class Crawler
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public Crawler(CrawlerOptions options)
        {
            Options = options;
        }
        public CrawlerOptions Options { get; set; }
        void Crawl(string linkStr, Link parrentLink, int depth)
        {
            depth++;

            Link link = Options.Repository.GetLink(linkStr, parrentLink);

            HtmlDocument page = Options.PageGetter.GetPage(linkStr);

            if (page == null)
                return;
            Request request = new Request(link)
            {
                Size = 150,
                Time = 250
            };

            Options.Repository.AddRequest(request);
            if (depth <= Options.MaxDepth)
            {
                foreach (var recievedLink in Parser.GetUries(page, LinkItemType.Link, link.Uri))
                    //Crawl(recievedLink, request, depth);
                    ThreadPool.QueueUserWorkItem(Crawl, new Bundle(recievedLink, depth, link));
            }

        }

        private void Crawl(object bundleObj)
        {
            Bundle bundle = (Bundle)bundleObj;
            Crawl(bundle.Link, bundle.ParrentLink, bundle.Depth);
        }



        public void Crawl()
        {
            //Link link = Options.Repository.GetLink(Options.RootString, null);
            Crawl(Options.RootString, null, 0);
        }

        //private IEnumerable<Link> GetRecievedLinks(Request parrentRequest, HtmlDocument page)
        //{
        //    foreach (string uri in Parser.GetUries(page, LinkItemType.Link, parrentRequest.RequestedLink.Uri))
        //        yield return Options.Repository.GetLink(uri, parrentRequest);
        //}

        IEnumerable<Image> GetImages(Request parrentRequest, HtmlDocument page)
        {
            foreach (string uri in Parser.GetUries(page, LinkItemType.Image, parrentRequest.RequestedLink.Uri))
                yield return Options.Repository.AddImage(uri, parrentRequest);
        }

        IEnumerable<StyleSheet> GetStyleSheets(Request parrentRequest, HtmlDocument page)
        {
            foreach (string uri in Parser.GetUries(page, LinkItemType.Css, parrentRequest.RequestedLink.Uri))
                yield return Options.Repository.AddCss(uri, parrentRequest);
        }

    }
    internal class Bundle
    {
        internal string Link { get; set; }
        internal int Depth { get; set; }
        internal Link ParrentLink { get; set; }

        public Bundle(string link, int depth, Link parrentLink)
        {
            Link = link;
            Depth = depth;
            ParrentLink = parrentLink;
        }
    }
}
