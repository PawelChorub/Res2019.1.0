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
        }
        [Fact]
        public void EventTest_ShouldBeRaisedWithoutArgs()
        {
            var mock = _kernel.GetMock<IAppointmentDetailsController>();
            mock.Setup(a => a.SaveAppointment("2", "3", "4")).Raises(a => a.SaveToDatabaseEvent += null, EventArgs.Empty).Verifiable();
            mock.Object.SaveAppointment("2", "3", "4");
            mock.Raise(r => r.SaveToDatabaseEvent += null, EventArgs.Empty);
        }
        [Fact]
        public void EventTest_ShouldBeRaisedWithArgs()
        {
            var mock = _kernel.GetMock<IAppointmentDetailsController>();
            var customer = sampleProvider.CreateSampleCustomer();
            var date = sampleProvider.CreateSampleDate();
            var service = sampleProvider.CreateSampleService();

            var args = new AppointmentEventArgs();

            mock.Setup(a => a.UpdateAppointment(date, customer, service, "1"))
                //.Raises(a => a.UpdatedToDatabase += null, new AppointmentEventArgs() { Date = date, Customer = customer, Service = service })
                .Raises(a => a.UpdatedToDatabase += null, args.Date = date, args.Customer = customer, args.Service = service)
                .Verifiable();

            mock.Object.UpdateAppointment(date, customer, service, "1");

            //mock.Raise(r => r.UpdatedToDatabase += null, new AppointmentEventArgs() { Date = date, Customer = customer, Service = service });
            mock.Raise(r => r.UpdatedToDatabase += null, args.Date = date, args.Customer = customer, args.Service = service);
            Assert.Equal(args.Date.Date_Id, date.Date_Id);
            Assert.Equal(args.Customer.Customer_Id, customer.Customer_Id);
            Assert.Equal(args.Service.Service_Id, service.Service_Id);
            Assert.IsType<string>(args.Customer.Surname);
            Assert.IsAssignableFrom<IDate>(args.Date);
        }

    }
}
