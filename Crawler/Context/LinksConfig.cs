using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerTask;

namespace Crawler.Context
{
    class LinksConfig : EntityTypeConfiguration<Link>
    {
        public LinksConfig()
        {
            HasKey(l => l.Id)
                .HasMany(l => l.ChildLinks)
                .WithMany(l => l.ParrentLinks)
                .Map(m => m.MapLeftKey("Child"))
                .Map(m => m.MapRightKey("Parrent"));

            HasMany(l => l.Requests)
                .WithRequired(r => r.RequestedLink)
                .HasForeignKey(r => r.Id);
        }
    }
}
