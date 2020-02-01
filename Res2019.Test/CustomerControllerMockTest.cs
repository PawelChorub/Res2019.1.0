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
    public class CustomerControllerMockTest
    {
        private readonly MoqMockingKernel _kernel;
        SampleProvider sampleProvider = new SampleProvider();
        public CustomerControllerMockTest()
        {            
            _kernel = new MoqMockingKernel();
            _kernel.Bind<ICustomerController>().ToMock();
            _kernel.Bind<IMsSqlDataAccess>().ToMock();
        }

        [Fact]
        public void CreateCustomer_ShouldReturnCustomer()
        {
            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(moq => moq.CreateCustomer(sampleProvider.CreateSampleListOfCustomerDetails())).Returns(sampleProvider.CreateSampleCustomer()).Verifiable();

            var list = sampleProvider.CreateSampleListOfCustomerDetails();

            var obj = mock.Object.CreateCustomer(list);

            mock.Verify(d => d.CreateCustomer(list), Times.Once);
        }
        [Fact]
        public void SaveCustomer_ShouldSaveCustomer()
        {
            var customer = sampleProvider.CreateSampleCustomer();
            string query = string.Format("INSERT INTO customer (forename, surname, telephone) VALUES ('{0}','{1}','{2}')",
                                        customer.Forename, customer.Surname, customer.Telephone);
            var mock = _kernel.GetMock<IMsSqlDataAccess>();
            mock.Setup(m => m.SaveData(query)).Verifiable();

            var controller = _kernel.GetMock<ICustomerController>();
            controller.Object.SaveCustomer(customer);
            controller.Verify(c => c.SaveCustomer(customer), Times.Exactly(1));

            mock.Object.SaveData(query);
            mock.Verify(x => x.SaveData(query), Times.Exactly(1));
        }

        [Fact]
        public void GetCustomer_ShouldGetsCustomer_ByModel()
        {
            ICustomer customer = sampleProvider.CreateSampleCustomer();

            var mock = _kernel.GetMock<ICustomerController>();
            mock.Setup(m => m.GetCustomer(customer)).Returns(sampleProvider.CreateSampleCustomer()).Verifiable();

            var actual = sampleProvider.CreateSampleCustomer("5");
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
            mock.Setup(m => m.GetCustomer(customer_id)).Returns(sampleProvider.CreateSampleCustomer(customer_id)).Verifiable();

            var obj = mock.Object.GetCustomer(customer_id);

            mock.Verify(v => v.GetCustomer(customer_id));

            Assert.Equal(customer_id, obj.Customer_Id);
            Assert.NotEqual("66", obj.Customer_Id);
            Assert.NotNull(obj.Forename);
            Assert.NotNull(obj.Surname);
            Assert.NotNull(obj.Telephone);
            Assert.NotNull(obj.Email);
        }

    }
}
