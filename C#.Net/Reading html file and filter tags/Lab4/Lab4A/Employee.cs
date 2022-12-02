using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4A
{
    /// <summary>
    /// Employee Class
    /// </summary>
    internal class Employee
    {
        private string name;    // employee name
        private int number;     // employee ID
        private decimal rate;   // hourly rate
        private double hours;   // weekly hours
        private decimal gross;  // gross pay

        public string Name { get { return name; } set { name = value; } }
        public int Number { get { return number; } set { number = value; } }
        public decimal Rate { get { return rate; } set { rate = value; } }
        public double Hours { get { return hours; } set { hours = value; } }
        public decimal Gross { get { return (hours < 40) ? (decimal)hours * rate : (40.0m * rate) + (((decimal)hours - 40.0m) * rate * 1.5m); } }
        
        /// <summary>
        /// Default constructor for Employee class
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        /// constructor for Employee class
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <param name="number">Employee number</param>
        /// <param name="rate">Hourly rate of pay</param>
        /// <param name="hours">Hours worked in a week</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            gross = Gross;
        }

        /// <summary>
        /// Employee display method - in the future, we'll override the ToString method of Object
        /// </summary>
        public override String ToString() => $"{Name,-20}  {Number:D5}  {Rate,6:C}  {Hours:#0.00}  {Gross,9:C}";

    }

    // The following Set methods allow for private data modification - in the future we'll use properties
}
