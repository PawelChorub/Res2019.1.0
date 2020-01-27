using Res2019.Logic.Models;

namespace Res2019.Logic.Processors
{
    public interface IDateProcessor
    {
        IDate CreateDate(params string[] model);
    }
}