using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerTask.Intefaces;

namespace CrawlerTask
{
    public class Link : ILinkItem
    {
        [Key]
        public int Id { get; set; }

        public string Uri { get; set; }


        public List<Image> Images { get; set; }
        public List<StyleSheet> StyleSheets { get; set; }

        public List<Link> ParrentLinks { get; set; }
        public List<Link> ChildLinks { get; set; }


       public List<Request> Requests { get; set; }
        public Link(string uri)
        {
            Uri = uri;
            ParrentLinks = new List<Link>();
            ChildLinks = new List<Link>();
            Requests = new List<Request>();

            Images = new List<Image>();
            StyleSheets = new List<StyleSheet>();

            Id = uri.GetHashCode();
        }

        public Link()
        {
            ParrentLinks = new List<Link>();
            ChildLinks = new List<Link>();
            Requests = new List<Request>();

            Images = new List<Image>();
            StyleSheets = new List<StyleSheet>();
        }
    }
}
