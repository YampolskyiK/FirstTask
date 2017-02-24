using System.Data.Entity.ModelConfiguration;
using CrawlerTask;

namespace Crawler.Context
{
    class RequestConfig : EntityTypeConfiguration<Request>
    {
        public RequestConfig()
        {
            HasKey(r => r.Id);
            HasRequired(r => r.RequestedLink);
        }
    }
}
