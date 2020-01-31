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
        [Fact]
        public void SaveCustomer_ShouldSaveCustomer()
        {
            var customer = CreateSampleCustomer();
            string query = string.Format("INSERT INTO customer (forename, surname, telephone) VALUES ('{0}','{1}','{2}')",
                                        customer.Forename, customer.Surname, customer.Telephone);
            var mock = _kernel.GetMock<IMsSqlDataAccess>();
            mock.Setup(m => m.SaveData(query));

            var ctrl = _kernel.GetMock<ICustomerController>();
            ctrl.Object.SaveCustomer(customer);
            ctrl.Verify(c => c.SaveCustomer(customer), Times.Exactly(1));

            mock.Object.SaveData(query);
            mock.Verify(x => x.SaveData(query), Times.Exactly(1));
        }
        [Fact]
        public void GetCustomer_ShouldGetsCustomer()
        {
            ICustomer customer = new Customer();
            var customer_id = "4";

            string query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer_id);

            var mock = _kernel.GetMock<IMsSqlDataAccess>();
            mock.Setup(m => m.GetDataList(query, customer)).Returns(CreateSampleListOfCustomer());

            //dalej dla następnych składowych metody

            //var mock_2 = _kernel.GetMock<ICustomerController>();
            //mock_2.Object.CreateCustomer(CreateSampleListOfCustomer().ToArray());

            //mock_2.Object.GetCustomer(customer_id);
            //var expected = CreateSampleListOfCustomer();
            var actual = mock.Object.GetDataList(query, customer);
            mock.VerifyAll();
     



        }
        public List<string> CreateSampleListOfCustomer()
        {
            var output = new List<string>();
            output.Add("4");
            output.Add("Justyna");
            output.Add("Ceha");
            output.Add("721721721");
            output.Add("email222@wp.pl");
            return output;
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
