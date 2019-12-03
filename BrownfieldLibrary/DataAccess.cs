using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public static class DataAccess
    {
        public static List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> output = new List<CustomerModel>();

            output.Add(new CustomerModel { CustomerName = "Acme", HourlyRateToBill = 150 });
            output.Add(new CustomerModel { CustomerName = "ABC", HourlyRateToBill = 125 });

            return output;
        }

        public static EmployeeModel GetCurrentEmployee()
        {
            EmployeeModel output = new EmployeeModel
            {
                FirstName = "Sue",
                LastName = "Smith",
                HourlyRate = 15
            };

            return output;
        }
    }
}
