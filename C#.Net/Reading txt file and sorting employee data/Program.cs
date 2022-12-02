using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/// <summary>
/// Purpose:  Main View class for interacting with user
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab1
{
    /// <summary>
    /// Main Program to sort employee data on the basis of Employee name, Employee Number, rate, hours, gross.
    /// </summary>
    internal class Program
    {
        // Employee class array to store Employee Data
        static Employee[] employee;
        // To store Employee information on specific index of array
        static int EmployeeIndex=0;
        // Employee data file
        const string DATAFILE = "employees.txt";
        
        /// <summary>
        /// Main method to run program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            employee = new Employee[100];
            // To read file content
            StreamReader reader = new StreamReader(DATAFILE);
            string[] line;
            
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(',');
                    employee[EmployeeIndex] = new Employee(line[0], int.Parse(line[1]), decimal.Parse(line[2]), double.Parse(line[3]));
                    EmployeeIndex++;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Error reading file " + ex.Message);
            }

            // menu to display sorting option
            int choice;
            
            do
            {
                Console.WriteLine("\n\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                Console.WriteLine("\n\t Enter Your Choice \n");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
                Console.WriteLine("1) Sort By Employee Name (Ascending)");
                Console.WriteLine("2) Sort By Employee Number (Ascending)");
                Console.WriteLine("3) Sort By Employee Pay Rate (Descending)");
                Console.WriteLine("4) Sort By Employee Hours (Descending)");
                Console.WriteLine("5) Sort By Employee Gross Pay (Descending)");
                Console.WriteLine("6) Exit");

                Console.WriteLine("Enter choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SortByName(employee);
                        DisplayEmployees();          
                        break;
                    case 2:
                        SortByNumber(employee);
                        DisplayEmployees();
                        break;
                    case 3:
                        SortByRate(employee);
                        DisplayEmployees();
                        break;
                    case 4:
                        SortByHours(employee);
                        DisplayEmployees();
                        break;
                    case 5:
                        SortByGross(employee);
                        DisplayEmployees();
                        break;
                    case 6:
                    default:
                        Environment.Exit(0);
                        break;
                }
                
            } while (choice < 6);

        }

        /// <summary>
        /// To sort employee data asceding using selection sort by employee name
        /// Reference: https://www.javatpoint.com/selection-sort
        /// </summary>
        /// <param name="employee">employee array</param>
        private static void SortByName(Employee[] employee)
        {
            int n = EmployeeIndex; // to iterate loop to last index of employee
            Employee temp; // temporary variable to store employee
            int smallest; // to store smallest value of employee
            for(int i =0; i < n - 1; i++)
            {
                smallest = i;
                for(int j = i +1; j<n; j++)
                {
                    // comparing two index of employee
                    if(employee[j].GetName().CompareTo(employee[smallest].GetName()) < 0)
                    {
                        smallest = j; // assigning smallest index
                    }

                }
                // exchanging two index through temp
                temp = employee[smallest]; 
                employee[smallest] = employee[i];
                employee[i] = temp;
            }
        }

        /// <summary>
        /// To sort employee data ascending using selection sort by employee number
        /// Reference: https://www.javatpoint.com/selection-sort
        /// </summary>
        /// <param name="employee">Employee array</param>
        private static void SortByNumber(Employee[] employee)
        {
            int n = EmployeeIndex; // to iterate loop to last index of employee
            Employee temp; // temporary variable to store employee
            int smallest; // to store smallest value of employee
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    // comparing two index of employee
                    if (employee[j].GetNumber().CompareTo(employee[smallest].GetNumber()) < 0)
                    {
                        smallest = j;
                    }
                }
                // exchanging two index through temp
                temp = employee[smallest];
                employee[smallest] = employee[i];
                employee[i] = temp;
            }
        }


        /// <summary>
        /// To sort employee data descending using selection sort by employee rate
        /// Reference: https://www.javatpoint.com/selection-sort
        /// </summary>
        /// <param name="employee">Employee array</param>
        private static void SortByRate(Employee[] employee)
        {
            int n = EmployeeIndex; // to iterate loop to last index of employee
            Employee temp; // temporary variable to store employee
            int smallest; // to store smallest value of employee
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    // comparing two index of employee
                    if (employee[j].GetRate().CompareTo(employee[smallest].GetRate()) > 0)
                    {
                        smallest = j;
                    }
                }
                // exchanging two index through temp
                temp = employee[smallest];
                employee[smallest] = employee[i];
                employee[i] = temp;
            }
        }

        /// <summary>
        /// To sort employee data descending using selection sort by employee hours
        /// Reference: https://www.javatpoint.com/selection-sort
        /// </summary>
        /// <param name="employee">Employee array</param>
        private static void SortByHours(Employee[] employee)
        {
            int n = EmployeeIndex; // to iterate loop to last index of employee
            Employee temp; // temporary variable to store employee
            int smallest; // to store smallest value of employee
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    // comparing two index of employee
                    if (employee[j].GetHours().CompareTo(employee[smallest].GetHours()) > 0)
                    {
                        smallest = j;
                    }
                }
                // exchanging two index through temp
                temp = employee[smallest];
                employee[smallest] = employee[i];
                employee[i] = temp;
            }
        }



        /// <summary>
        /// To sort employee data descending using selection sort by employee gross
        /// Reference: https://www.javatpoint.com/selection-sort
        /// </summary>
        /// <param name="employee">Employee array</param>
        private static void SortByGross(Employee[] employee)
        {
            int n = EmployeeIndex; // to iterate loop to last index of employee
            Employee temp; // temporary variable to store employee
            int smallest; // to store smallest value of employee
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    // comparing two index of employee
                    if (employee[j].GetGross().CompareTo(employee[smallest].GetGross()) > 0)
                    {
                        smallest = j;
                    }
                }
                // exchanging two index through temp
                temp = employee[smallest];
                employee[smallest] = employee[i];
                employee[i] = temp;
            }
        }

        /// <summary>
        /// To display Sorted Employee information
        /// </summary>
        private static void DisplayEmployees()
        {
            // heading of employee information data
            Console.WriteLine("Employee Name \t\tEmployee Number \tEmployee rate \tEmployee Hours \tEmployee Gross");
            // to display every employee
            for (int i = 0; i < EmployeeIndex; i++)
            {
                Console.WriteLine(employee[i]);
            }
        }


    }
}
