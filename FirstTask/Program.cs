using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerTask;
using NLog;

namespace FirstTask
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetLogger("kokoko");
        static void Main(string[] args)
        {

            Logger.Trace("logger trace");
            Starter.Start("https://www.wikipedia.org/", 200);
        }
    }
}
