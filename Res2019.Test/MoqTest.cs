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
            _kernel.Bind<ICustomerController>().ToMock();
            _kernel.Bind<IMsSqlDataAccess>().ToMock();
        }

        [Fact]
        public void CreateCustomer_ShouldReturnCustomer()
        {
            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(moq => moq.CreateCustomer(CreateSampleListOfCustomerDetails())).Returns(CreateSampleCustomer());

            var list = CreateSampleListOfCustomerDetails();

            var obj = mock.Object.CreateCustomer(list);

            mock.Verify(d => d.CreateCustomer(list), Times.Once);
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
        public void GetCustomer_ShouldGetsCustomer_ByModel()
        {
            ICustomer customer = CreateSampleCustomer();

            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(m => m.GetCustomer(customer)).Returns(CreateSampleCustomer());

            var actual = CreateSampleCustomer("5");
            var expected = mock.Object.GetCustomer(customer);

            mock.Verify(v => v.GetCustomer(customer));

            Assert.NotEqual(expected.Customer_Id, actual.Customer_Id);
        }


        [Theory]
        [InlineData("4")]
        [InlineData("1000")]
        [InlineData("366666")]
        public void GetCustomer_ShouldGetsCustomer_ById(string customer_id)
        {
            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(m => m.GetCustomer(customer_id)).Returns(CreateSampleCustomer(customer_id));

            var obj = mock.Object.GetCustomer(customer_id);

            mock.Verify(v => v.GetCustomer(customer_id));

            Assert.Equal(customer_id, obj.Customer_Id);
            Assert.NotEqual("66", obj.Customer_Id);
            Assert.NotNull(obj.Forename);
            Assert.NotNull(obj.Surname);
            Assert.NotNull(obj.Telephone);
            Assert.NotNull(obj.Email);
        }


        public List<string> CreateSampleListOfCustomerDetails()
        {
            var output = new List<string>();
            output.Add("4");
            output.Add("NameMock");
            output.Add("SurnameMock");
            output.Add("123456789");
            output.Add("mockEmail@wp.pl");
            return output;
        }

        public ICustomer CreateSampleCustomer()
        {
            ICustomer customer = new Customer();
            string [] model = new string[] { "4", "NameMock", "SurnameMock", "123456789", "mockEmail@wp.pl" };

            customer.Customer_Id = model[0];
            customer.Forename = model[1];
            customer.Surname = model[2];
            customer.Telephone = model[3];
            customer.Email = model[4];

            return customer;
        }
        public ICustomer CreateSampleCustomer(string customer_id)
        {
            ICustomer customer = new Customer();
            string[] model = new string[] { customer_id, "NameMock", "SurnameMock", "123456789", "mockEmail@wp.pl" };

            customer.Customer_Id = model[0];
            customer.Forename = model[1];
            customer.Surname = model[2];
            customer.Telephone = model[3];
            customer.Email = model[4];

            return customer;
        }



    }
}
