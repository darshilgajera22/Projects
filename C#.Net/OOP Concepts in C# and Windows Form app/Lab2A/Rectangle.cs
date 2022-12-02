using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Rectangle Class is used to calculate area and volume of Rectangle.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Rectangle Class is used to calculate area and volume of Rectangle.
    /// </summary>
    internal class Rectangle : Shape
    {
        private double rectanglelength; // to store rectangle length
        private double rectanglewidth; // to store rectangle width

        /// <summary>
        /// Constructor rectangle
        /// </summary>
        public Rectangle()
        {
            this.Type = "2 - Dimentional"; // Shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of Rectangle.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating rectangle area
            return rectanglelength * rectanglewidth;

        }

        /// <summary>
        /// to calculate volume
        /// </summary>
        /// <returns>a double which is a volume of rectangle</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating circle volume
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
                    Console.WriteLine("Enter the length: ");
                    rectanglelength = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the width: ");
                    rectanglewidth = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (rectanglelength < 0 || rectanglewidth < 0)
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
            } while(flag != true); // continue loop
            
        }

        /// <summary>
        /// to display rectangle data
        /// </summary>
        /// <returns> a string which contains rectangle data</returns>
        public override string ToString()
        {
            return $"Rectangle: {"\nShape type: " + this.Type,-20} {"\nRectangle Length: " + rectanglelength,-20} {"\nRectangle Width: " + rectanglewidth,-20} {"\nRectangle Area: " + CalculateArea(),-40}";
        }
    }
}
