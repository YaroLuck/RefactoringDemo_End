using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public static class TimeSheetProcessor
    {
        public static double GetHoursWorksForCompany(List<TimeSheetEntryModel> timeSheets, string companyName)
        {
            double output = 0;

            for (int i = 0; i < timeSheets.Count; i++)
            {
                if (timeSheets[i].WorkDone.ToLower().Contains(companyName.ToLower()))
                {
                    output += timeSheets[i].HoursWorked;
                }
            }

            return output;
        }

        public static decimal CalculateEmployeePay(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        {
            decimal output = 0;
            double totalHours = 0;

            for (int i = 0; i < timeSheets.Count; i++)
            {
                totalHours += timeSheets[i].HoursWorked;
            }
            if (totalHours > 40)
            {
                output = (((decimal)(totalHours - 40) * (employee.HourlyRate * 1.5M)) + (40M * employee.HourlyRate));
            }
            else
            {
                output = (decimal)totalHours * employee.HourlyRate;
            }

            return output;
        }
    }
}
