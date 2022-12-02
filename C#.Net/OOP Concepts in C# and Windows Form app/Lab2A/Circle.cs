using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Circle Class is used to calculate area and volume of Circle.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Circle Class is used to calculate area and volume of Circle.
    /// </summary>
    internal class Circle : Ellipse
    {
        private double circleradius; // to store circle radius

        /// <summary>
        /// Constructor Circle
        /// </summary>
        public Circle()
        {
            this.Type = "2 - Dimentional"; // shape type

        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of circle.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating circle area
            return PI * circleradius * circleradius;
        }

        /// <summary>
        /// not implemeted because circle has no volume
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
                    Console.WriteLine("Enter the radius: ");
                    circleradius = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (circleradius < 0) 
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
        /// to display circle data
        /// </summary>
        /// <returns> a string which contains circle data</returns>
        public override string ToString()
        {
            return $"Circle: {"\nShape type: " + this.Type,-20} {"\nCircle Radius: " + circleradius,-20} {"\nCircle Area: " + CalculateArea(),-40}";
        }
    }
}
