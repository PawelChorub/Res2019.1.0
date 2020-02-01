using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Test
{
    public class SampleProvider
    {
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
            string[] model = new string[] { "4", "NameMock", "SurnameMock", "123456789", "mockEmail@wp.pl" };

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
        public IDate CreateSampleDate()
        {
            IDate date = new Date();
            date.Date_Id = "2";
            date.Day = "2020-02-20";
            date.Time = "18:00";
            date.Length = "0:30";
            date.Duration = "1";
            return date;
        }
        public IMyServices CreateSampleService()
        {
            IMyServices service = new MyServices();
            service.Service_Id = "1";
            service.Name = "sampleName";
            return service;
        }
    }
}
