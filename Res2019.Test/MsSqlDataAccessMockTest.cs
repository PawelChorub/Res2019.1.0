using Moq;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Res2019.Test
{
    public class MsSqlDataAccessMockTest
    {
        private readonly MoqMockingKernel _kernel;
        SampleProvider sampleProvider = new SampleProvider();

        public MsSqlDataAccessMockTest()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<IMsSqlDataAccess>().ToMock();
            _kernel.Bind<ICustomer>().ToMock();        
        }

        [Fact]
        public void SaveData_ShouldSaveDataToDatabase()
        {
            ICustomer customer = sampleProvider.CreateSampleCustomer();
            string query = string.Format("INSERT INTO customer (forename, surname, telephone) VALUES ('{0}','{1}','{2}')",
                customer.Forename,
                customer.Surname,
                customer.Telephone);

            var mock = _kernel.GetMock<IMsSqlDataAccess>();

            mock.Setup(m => m.SaveData(query)).Verifiable();
            mock.Object.SaveData(query);
            mock.Verify(v => v.SaveData(query), Times.Exactly(1));          
        }

        [Fact]
        public void GetDataList_ShouldGetDataFromDatabaseToList()
        {
            var customer = _kernel.GetMock<ICustomer>();
            string query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer.Object.Customer_Id);

            var mock = _kernel.GetMock<IMsSqlDataAccess>();
            mock.Setup(m => m.GetDataList(query, customer)).Returns(sampleProvider.CreateSampleListOfCustomerDetails).Verifiable();

            mock.Object.GetDataList(query, customer);
            mock.Verify(v => v.GetDataList(query, customer), Times.Once);
        }

        [Fact]
        public void GetDataList_ShouldGetDataFromOneColumnFromDatabaseToList()
        {
            var customer = _kernel.GetMock<ICustomer>();
            string query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer.Object.Customer_Id);

            var mock = _kernel.GetMock<IMsSqlDataAccess>();
            mock.Setup(m => m.GetSingleColumnDataList(query, customer.Object.Customer_Id)).Returns(sampleProvider.CreateSampleListOfCustomerDetails()).Verifiable();

            var actual = mock.Object.GetSingleColumnDataList(query, customer.Object.Customer_Id);
            var expected = sampleProvider.CreateSampleListOfCustomerDetails();

            mock.Verify(v => v.GetSingleColumnDataList(query, customer.Object.Customer_Id), Times.Once);
            mock.VerifyNoOtherCalls();

            Assert.NotNull(actual);
            Assert.IsType<List<string>>(actual);
            Assert.Contains("SELECT * FROM", query);
        }
    }
}
