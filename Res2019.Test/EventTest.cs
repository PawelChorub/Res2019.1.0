using Moq;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Res2019.Logic.Controller;
using Res2019.Logic.Events;
using Res2019.Logic.Models;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Res2019.Test
{
    public class EventTest
    {
        private readonly MoqMockingKernel _kernel;
        SampleProvider sampleProvider = new SampleProvider();

        public EventTest()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<IMsSqlDataAccess>().ToMock();
            _kernel.Bind<ICustomer>().ToMock();
            _kernel.Bind<IDate>().ToMock();
            _kernel.Bind<ICustomer>().ToMock();
        }
        [Fact]
        public void EventTest_ShouldBeRaisedWithoutArgs()
        {
            var controller = _kernel.GetMock<IAppointmentDetailsController>();
            var mock = _kernel.GetMock<IAppointmentDetailsController>();
            mock.Setup(a => a.SaveAppointment("2", "3", "4")).Raises(a => a.SaveToDatabaseEvent += null, EventArgs.Empty).Verifiable();
            controller.Object.SaveAppointment("2", "3", "4");
            mock.Raise(r => r.SaveToDatabaseEvent += null, EventArgs.Empty);
        }

    }
}
