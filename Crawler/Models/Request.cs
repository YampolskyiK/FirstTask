using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerTask
{
    public class Request
    {
        
        public int Id { get; set; }

        public int RequestedLinkId { get; set; }

        public Link RequestedLink { get; set; }


 

        public int Size { get; set; }
        public int Time { get; set; }


        public Request(Link link)
        {
            RequestedLink = link;

        }

        public Request()
        {
            
        }

    }
}
