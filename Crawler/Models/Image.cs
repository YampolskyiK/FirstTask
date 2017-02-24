using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CrawlerTask
{
    public class Image : Intefaces.ILinkItem
    {
        [Key]
        public int Id { get; set; }
        public string Uri { get; set; }
        public List<Link> ParrentLinks { get; set; }

        public Image(string uri)
        {
            Uri = uri;
            ParrentLinks = new List<Link>();
        }

        public Image()
        {
            
        }
    }
}