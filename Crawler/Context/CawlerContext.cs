using System.Data;
using Crawler.Context;

namespace CrawlerTask
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CawlerContext : DbContext
    {

        public CawlerContext()
            : base("name=CawlerContext")
        {
        }

        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<StyleSheet> StyleSheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Link>()
                .HasMany(l=>l.Requests)
                .WithRequired(r=>r.RequestedLink)
                .HasForeignKey(r=>r.RequestedLinkId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
            
        }
    }


}