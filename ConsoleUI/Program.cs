using BrownfieldLibrary;
using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSheetEntryModel> timeSheets = LoadTimesheets();
            List<CustomerModel> customers = DataAccess.GetCustomers();
            EmployeeModel currentEmployee = DataAccess.GetCurrentEmployee();

            customers.ForEach(x => BillCustomer(timeSheets, x));

            PayEmployee(timeSheets, currentEmployee);

            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void PayEmployee(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        {
            decimal totalPay = TimeSheetProcessor.CalculateEmployeePay(timeSheets, employee);
            Console.WriteLine($"You will get paid ${ totalPay } for your time.");
            Console.WriteLine();
        }

        private static void BillCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double totalHours = TimeSheetProcessor.GetHoursWorksForCompany(timeSheets, customer.CustomerName);

            Console.WriteLine($"Simulating Sending email to { customer.CustomerName }");
            Console.WriteLine("Your bill is $" + (decimal)totalHours * customer.HourlyRateToBill + " for the hours worked.");
            Console.WriteLine();
        }

        private static List<TimeSheetEntryModel> LoadTimesheets()
        {
            List<TimeSheetEntryModel> output = new List<TimeSheetEntryModel>();
            string enterMoreTimesheets = "";

            do
            {
                Console.Write("Enter what you did: ");
                string workDone = Console.ReadLine();

                Console.Write("How long did you do it for: ");
                string rawTimeWorked = Console.ReadLine();

                double hoursWorked;

                while (double.TryParse(rawTimeWorked, out hoursWorked) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }

                TimeSheetEntryModel timeSheet = new TimeSheetEntryModel();
                timeSheet.HoursWorked = hoursWorked;
                timeSheet.WorkDone = workDone;
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time (yes/no): ");
                enterMoreTimesheets = Console.ReadLine();
                
            } while (enterMoreTimesheets.ToLower() == "yes");

            Console.WriteLine();

            return output;
        }
    }
}
