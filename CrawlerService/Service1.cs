using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using  System.ServiceModel;


namespace CrawlerService
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost service = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (service == null)
            {
                service = new ServiceHost(typeof(Service));
                service.Open();
            }
        }

        protected override void OnStop()
        {
            service.Close();
        }
    }
}
