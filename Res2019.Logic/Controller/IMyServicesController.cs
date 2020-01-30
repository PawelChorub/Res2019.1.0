using Res2019.Logic.Models;

namespace Res2019.Logic.Controller
{
    public interface IMyServicesController
    {
        IMyServices CreateService(params string[] model);
        IMyServices GetService(IMyServices _service);
        IMyServices GetService(string service_id);
    }
}