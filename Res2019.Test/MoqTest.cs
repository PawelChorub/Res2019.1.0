using Moq;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Res2019.Logic.Controller;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Res2019.Test
{
    public class MoqTest
    {
        private readonly MoqMockingKernel _kernel;

        public MoqTest()
        {            
            _kernel = new MoqMockingKernel();
            _kernel.Bind<ICustomerController>().ToMock();//.To<Customer>();
            _kernel.Bind<IMsSqlDataAccess>().ToMock();
        }

        [Fact]
        public void CreateCustomer_ShouldReturnCustomer()
        {
            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(moq => moq.CreateCustomer()).Returns(CreateSampleCustomer());

            var expected = CreateSampleCustomer();
            var actual = mock.Object.CreateCustomer();

            mock.VerifyAll();
        }

        public ICustomer CreateSampleCustomer()
        {
            ICustomer customer = new Customer();
            string [] model = new string[] {"3", "Paweł", "Ceha", "721721721","email@wp.pl" };

            customer.Customer_Id = model[0];
            customer.Forename = model[1];
            customer.Surname = model[2];
            customer.Telephone = model[3];
            customer.Email = model[4];

            return customer;
        }
    }
}
