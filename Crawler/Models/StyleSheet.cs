using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrawlerTask
{
    public class StyleSheet : Intefaces.ILinkItem
    {

        public int Id { get; set; }
        public string Uri { get; set; }
        public List<Link> ParrentLinks { get; set; }

        public StyleSheet(string uri)
        {
            Uri = uri;
            ParrentLinks = new List<Link>();
        }

        public StyleSheet()
        {

        }
    }
}