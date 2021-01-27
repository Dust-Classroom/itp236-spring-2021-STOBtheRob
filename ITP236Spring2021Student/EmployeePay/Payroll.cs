using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePay
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get;set; }
        public abstract double Pay { get; }

        public Employee()
        {
            EmployeeId = 0;
            FirstName = "John";
            LastName = "Doe";
            HireDate = new DateTime(2000, 01, 01);
        }
    }
    public class Sales : Employee
    {
        public double Draw { get; set; }
        public double CommissionRate { get; set; }
        public double GrossSales { get; set; }
        public override double Pay
        {
            get
            {
                if (Draw < ((.01 * CommissionRate) * GrossSales))
                {
                    return (.01 * CommissionRate) * GrossSales;
                }
                else
                {
                    return Draw;
                }
            }
        }

    }
    public class Salary : Employee
    {
        public double MonthlySalaryAmount { get; set; }
        public double Bonus { get; set; }
        public override double Pay
        {
            get
            {
                return (MonthlySalaryAmount / 2) + Bonus;
            }
        }
    }
    public class Hourly : Employee
    {
        public double Hours { get; set; }
        public double HourlyRate { get; set; }
        public override double Pay
        {
            get
            {
                if (Hours < 40)
                {
                    return Hours * HourlyRate;
                }
                else
                {
                    return (HourlyRate * 40) + ((HourlyRate*1.5) * (Hours - 40));
                }
                
            }
        }
    }
}
