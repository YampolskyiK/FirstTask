using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerService
{
    [RunInstaller(true)]
    class CrawlerServiceInstaller : Installer
    {
        public  CrawlerServiceInstaller()
        {
            var process = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

            var service = new ServiceInstaller
            {
                ServiceName = "===Crawler===",
                Description = "ururu",
                StartType = ServiceStartMode.Automatic
            };

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
