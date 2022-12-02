using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Square Class is used to calculate area and volume of Square.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Square Class is used to calculate area and volume of Square.
    /// </summary>
    internal class Square : Rectangle
    {
        private double squarelength = 0; // to store square length

        /// <summary>
        /// Constructor Square
        /// </summary>
        public Square()
        {
            this.Type = "2 - Dimentional"; // Shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of square.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating square area
            return squarelength * squarelength;
        }

        /// <summary>
        /// not implemented because square has no volume
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
                    Console.WriteLine("Enter the length: ");
                    double squarelengthuser = double.Parse(Console.ReadLine());
                    squarelength = squarelengthuser;
                    // if inputs is negative
                    if (squarelength < 0)
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
        /// to display square data
        /// </summary>
        /// <returns> a string which contains square data</returns>
        public override string ToString()
        {
            return $"Square: {"\nShape type: " + this.Type,-20} {"\nSquare Length: " + squarelength,-20} {"\nSquare Area: " + CalculateArea(),-40}";
        }
    }
}
