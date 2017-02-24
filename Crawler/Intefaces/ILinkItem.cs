using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerTask.Intefaces
{
    interface ILinkItem
    {
        int Id { get; set; }
        string Uri { get; set; }
        List<Link> ParrentLinks { get; set; }
    }
}
