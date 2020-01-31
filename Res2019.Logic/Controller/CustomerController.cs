using Ninject;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Controller
{
    public class CustomerController : ICustomerController
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public ICustomer CreateCustomer(params string[] model)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            if (model.Length > 0)
            {
                customer.Customer_Id = model[0];
                customer.Forename = model[1];
                customer.Surname = model[2];
                customer.Telephone = model[3];
                customer.Email = model[4];
            }

            return customer;
        }
        public void SaveCustomer(ICustomer customer)
        {
            query = string.Format("INSERT INTO customer (forename, surname, telephone) VALUES ('{0}','{1}','{2}')",
                  customer.Forename,
                  customer.Surname,
                  customer.Telephone);
            msSqlDataAccess.SaveData(query);
        }

        public ICustomer GetCustomer(string customer_id)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerController customerController = kernel.Get<ICustomerController>();

            query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer_id);
            var receivedData = msSqlDataAccess.GetDataList(query, customer).ToArray();

            customer = customerController.CreateCustomer(receivedData);
            return customer;
        }

        public ICustomer GetCustomer(ICustomer _customer)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerController customerProcessor = kernel.Get<ICustomerController>();

            query = string.Format("SELECT * FROM customer WHERE forename = '{0}' AND surname = '{1}' AND telephone = '{2}'", _customer.Forename, _customer.Surname, _customer.Telephone);
            var receivedData = msSqlDataAccess.GetDataList(query, customer).ToArray();

            customer = customerProcessor.CreateCustomer(receivedData);
            return customer;
        }


    }
}
