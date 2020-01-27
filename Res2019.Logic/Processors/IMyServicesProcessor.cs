using Res2019.Logic.Models;

namespace Res2019.Logic.Processors
{
    public interface IMyServicesProcessor
    {
        IMyServices CreateService(params string[] model);
    }
}