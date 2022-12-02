using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Purpose:    Employee Class is used as a starting class to model Employee in an application
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab1
{
    /// <summary>
    /// Employee Class is used as a starting class to model Employee in an application
    /// </summary>
    internal class Employee
    {
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        /// <summary>
        /// Constructor Employee, used as the model for an application
        /// </summary>
        /// <param name="name">Employee Name</param>
        /// <param name="number">Employee Number</param>
        /// <param name="rate">Employee Rate Per Hours</param>
        /// <param name="hours">Employee Hours</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            
            // Calculating Gross Salary of Employee
            if (this.hours > 40)
            {
                // calculating 40 hours with rate and calculating overtime with rate + 1.5 rate
                this.gross = 40 * rate + (decimal)(hours - 40) * (decimal)1.5 * rate;
            }
            else
            {
                // calculating 40 hours with rate
                this.gross = rate * (decimal)hours;
            }
        }

        /// <summary>
        /// Used to read Gross property of class
        /// </summary>
        /// <returns>a decimal which is a gross salary of employee</returns>
        public decimal GetGross()
        {
            return gross;
        }

        /// <summary>
        /// Used to read Hours property of class
        /// </summary>
        /// <returns>a double which is a total hours of employee</returns>
        public double GetHours()
        {
            return hours;
        }

        /// <summary>
        /// Used to read Name property of class
        /// </summary>
        /// <returns>a string which is a name of employee</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Used to read Employee Number of class
        /// </summary>
        /// <returns>a integer which is a Employee Number of Employee</returns>
        public int GetNumber()
        {
            return number;
        }
        
        /// <summary>
        /// Used to read Employee Rate of class
        /// </summary>
        /// <returns>a decimal which is a Employee Rate of Employee</returns>
        public decimal GetRate()
        {
            return rate;
        }
        
        /// <summary>
        /// Used to set Employee Hours of Employee
        /// </summary>
        /// <param name="hours">Employee Hours</param>
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        /// <summary>
        /// Used to set Employee Name of Employee
        /// </summary>
        /// <param name="name">Employee Name</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Used to set Hours of Employee
        /// </summary>
        /// <param name="number">Employee Number</param>
        public void SetNumber(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Used to set rate of Employee
        /// </summary>
        /// <param name="rate">Employee Rate</param>
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }

        /// <summary>
        /// To Display Employee Data
        /// </summary>
        /// <returns> a string which containes employee information</returns>
        public override string ToString()
        {
            return $"{name, -23} {number, -23} {rate, -15} {hours, -16} {gross, -20}";
        }

    }
}
