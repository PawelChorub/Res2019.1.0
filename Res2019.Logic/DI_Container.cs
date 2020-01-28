using Ninject;
using Ninject.Modules;
using Res2019.Logic.Events;
using Res2019.Logic.Helpers;
using Res2019.Logic.Models;
using Res2019.Logic.Controller;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic
{
    public class DI_Container : NinjectModule
    {
        public override void Load()
        {
            Bind<IAppointment>().To<Appointment>();
            Bind<IAppointmentProcessor>().To<AppointmentProcessor>();
            Bind<ICustomer>().To<Customer>();
            Bind<IDayCounting>().To<DayCounting>();
            Bind<IDateFormatCheck>().To<DateFormatCheck>();
            Bind<IMyServices>().To<MyServices>();
            Bind<ISetNumberOfLabel>().To<SetNumberOfLabel>();
            Bind<ISetValueToLabelSize>().To<SetValueToLabelSize>();
            Bind<ITimeFromLabel>().To<TimeFromLabel>();
            Bind<IAppointmentController>().To<AppointmentController>();
            Bind<ITimeToEndOfWorkProcessor>().To<TimeToEndOfWorkProcessor>();
            Bind<IAppointmentDetails>().To<AppointmentDetails>();
            Bind<IDate>().To<Date>();
            Bind<EmailConfirmation>().ToSelf();
            Bind<SmsConfirmation>().ToSelf();
            Bind<IMyServicesController>().To<MyServicesController>();
            Bind<ICustomerController>().To<CustomerController>();
            Bind<IDateController>().To<DateController>();



            Bind<IBusinessLogic>().To<BusinessLogic>();
        }
    }
}
