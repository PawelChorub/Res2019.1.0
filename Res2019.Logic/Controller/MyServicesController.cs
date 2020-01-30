using Ninject;
using Res2019.Logic.Models;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Controller
{
    public class MyServicesController : IMyServicesController
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public IMyServices CreateService(params string[] model)
        {
            IMyServices service = kernel.Get<IMyServices>();
            
            service.Service_Id = model[0];
            service.Name = model[1];

            return service;
        }
        public IMyServices GetService(IMyServices _service)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesController myServicesProcessor = kernel.Get<IMyServicesController>();

            query = string.Format("SELECT * FROM service WHERE name = '{0}'", _service.Name);
            var receivedData = msSqlDataAccess.GetDataList(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }

        public IMyServices GetService(string service_id)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesController myServicesProcessor = kernel.Get<IMyServicesController>();

            query = string.Format("SELECT * FROM service WHERE service_id = '{0}'", service_id);
            var receivedData = msSqlDataAccess.GetDataList(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }
    }
}
