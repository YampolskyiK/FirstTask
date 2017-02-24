using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawlerTask.Intefaces;
using System.Data.Entity.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace CrawlerTask
{
    class Repository : IRepository
    {

        private readonly SemaphoreSlim Semaphore;

        public Repository(CawlerContext db)
        {
            Semaphore = new SemaphoreSlim(1);
        }

        public Link GetLink(string uri, Link parrentLink)
        {
            Semaphore.Wait();
            Link link;
            using (CawlerContext db = new CawlerContext())
            {
                link = db.Links.FirstOrDefault(l => l.Uri == uri);
                if (link == null)
                {
                    link = new Link(uri);
                    db.Links.Add(link);
                }
                if (parrentLink != null)
                    link.ParrentLinks.Add(parrentLink);
                db.SaveChanges();
            }

            Semaphore.Release();
            return link;
        }

        public Image AddImage(string uri, Request request)
        {
            Semaphore.Wait();
            Image image;
            using (CawlerContext db = new CawlerContext())
            {
                image = db.Images.FirstOrDefault(l => l.Uri == uri);
                if (image == null)
                {
                    image = new Image(uri);
                    db.Images.Add(image);
                }
                request.RequestedLink.Images.Add(image);
                db.SaveChanges();
            }
            Semaphore.Release();
            return image;
        }
        public StyleSheet AddCss(string uri, Request request)
        {
            StyleSheet styleSheet;
            using (CawlerContext db = new CawlerContext())
            {

                Semaphore.Wait();
                styleSheet = db.StyleSheets.FirstOrDefault(l => l.Uri == uri);
                if (styleSheet == null)
                {
                    styleSheet = new StyleSheet(uri);
                    db.StyleSheets.Add(styleSheet);
                }
                request.RequestedLink.StyleSheets.Add(styleSheet);
                db.SaveChanges();
            }
            Semaphore.Release();
            return styleSheet;
        }

        public void AddRequest(Request request)
        {
            Semaphore.Wait();
            using (CawlerContext db = new CawlerContext())
            {
                db.Requests.Add(request);
                db.SaveChanges();
            }
            Semaphore.Release();
        }
    }
}
