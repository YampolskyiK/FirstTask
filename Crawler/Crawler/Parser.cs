using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HtmlAgilityPack;

namespace CrawlerTask
{
    static class Parser
    {

        public static IEnumerable<string> GetUries(HtmlDocument page, LinkItemType linkItemType, string parrentUri)
        {
            Dictionary<LinkItemType, string> getXPath = new Dictionary<LinkItemType, string>()
            {
                {LinkItemType.Css, "//link[@rel='stylesheet']"},
                {LinkItemType.Link, "//a[@href]" },
                { LinkItemType.Image, "//image[@src]"}
            };
            IEnumerable<HtmlNode> selectedNodes = page.DocumentNode.SelectNodes(getXPath[linkItemType]) ??
                                                  (IEnumerable<HtmlNode>)new List<HtmlNode>();

            foreach (HtmlNode node in selectedNodes)
            {
                if (linkItemType == LinkItemType.Image)
                    yield return GetAbsoluteUri(node.Attributes["src"].Value, parrentUri);
                else
                    yield return GetAbsoluteUri(node.Attributes["href"].Value, parrentUri);
            }
        }

        private static string GetAbsoluteUri(string uriStr, string parrentUriStr)
        {

            Uri uri = new Uri(parrentUriStr);
            Uri.TryCreate(uri, uriStr, out uri);
            if (uri!= null && (uri.Scheme == "http" || uri.Scheme == "https"))
                return uri.AbsoluteUri;
            else
                return parrentUriStr;
        }
    }

    internal enum LinkItemType
    {
        Link,
        Image,
        Css
    }
}
