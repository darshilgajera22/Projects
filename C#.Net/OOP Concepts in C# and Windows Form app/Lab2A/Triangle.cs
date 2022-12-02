using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Triangle Class is used to calculate area and volume of Triangle.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Triangle Class is used to calculate area and volume of Triangle.
    /// </summary>
    internal class Triangle : Shape
    {
        private double triangleheight; // to store triangle height
        private double trianglebase; // to store triangle base

        /// <summary>
        /// Constructor Triangle
        /// </summary>
        public Triangle()
        {
            this.Type = "2 - Dimentional"; // Shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of triangle.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating triangle area
            return trianglebase * triangleheight / 2;
        }

        /// <summary>
        /// not implemeted because triangle has no volume
        /// </summary>
        /// <returns></returns>
        public override double CalculateVolume()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// to get input from user and store in class varibales
        /// </summary>
        public override void SetData()
        {
            bool flag = false; // to turminate loop
            do
            {
                try
                {
                    Console.WriteLine("Enter the base: ");
                    trianglebase = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height: ");
                    triangleheight = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (trianglebase < 0 || triangleheight < 0)
                    {
                        // print error message
                        Console.WriteLine("\t****** Please enter positive numbers ******");
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                catch (FormatException) // if input is characters
                {
                    // print error message
                    Console.WriteLine("\t****** Please enter numbers ******");
                    flag = false;
                }
            } while (flag != true); // continue loop
        }

        /// <summary>
        /// to display triangle data
        /// </summary>
        /// <returns> a string which contains triangle data</returns>
        public override string ToString()
        {
            return $"Triangle: {"\nShape type: " + this.Type,20} {"\nTriangle Base: " + trianglebase,-20} {"\nTriangle Height: " + triangleheight,-40} {"\nTriangle Area: " + CalculateArea(),-40}";
        }
    }
}
