using Ninject;
using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Processors
{
    public class MyServicesProcessor : IMyServicesProcessor
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());

        public IMyServices CreateService(params string[] model)
        {
            IMyServices service = kernel.Get<IMyServices>();
            
            service.Service_Id = model[0];
            service.Name = model[1];

            return service;
        }
    }
}
