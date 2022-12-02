using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Ellipse Class is used to calculate area and volume of Ellipse.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Ellipse Class is used to calculate area and volume of Ellipse.
    /// </summary>
    internal class Ellipse : Shape
    {
        private double ellipsemajor; // to store ellipse major
        private double ellipseminor; // to store ellipse minor

        /// <summary>
        /// Constructor Ellipse
        /// </summary>
        public Ellipse()
        {
            this.Type = "3 - Dimentional"; // shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of Ellipse.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating circle area
            return PI * ellipsemajor * ellipseminor;
        }

        /// <summary>
        /// to calculate ellipse volume
        /// </summary>
        /// <returns>a double which is a volume of ellipse</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating circle volume
            return 4 * PI * ellipsemajor * ellipseminor / 3;
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
                    Console.WriteLine("Enter the semi-major axis length: ");
                    ellipsemajor = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the semi-minor axis length: ");
                    ellipseminor = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (ellipsemajor < 0 || ellipseminor < 0)
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
        /// to display ellipse data
        /// </summary>
        /// <returns> a string which contains ellipse data</returns>
        public override string ToString()
        {
            return $"Ellipse: {"\nShape type: " + this.Type,-20} {"\nEllipse semi-major axis: " + ellipsemajor,-20} {"\nEllipse semi-minor axis: " + ellipseminor,-20} {"\nEllipse Area: " + CalculateArea(),-40} {"\nEllipse Volume: " + CalculateVolume(),-40}";
          
        }
    }
}
