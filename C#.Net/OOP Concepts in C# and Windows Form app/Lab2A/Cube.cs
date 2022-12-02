using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Cube Class is used to calculate area and volume of Cube.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Cube Class is used to calculate area and volume of Cube.
    /// </summary>
    internal class Cube : Box
    {
        private double cubelength; // to store cube length

        /// <summary>
        /// Constructor Cube
        /// </summary>
        public Cube()
        {
            this.Type = "3 - Dimentional"; // shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of cube.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating circle area
            return 6 * (cubelength * cubelength);
        }

        /// <summary>
        /// to calculate cube volume
        /// </summary>
        /// <returns>a double which is a volume of cube</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating circle volume
            return cubelength * cubelength * cubelength;
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
                    cubelength = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (cubelength < 0)
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
        /// to display cube data
        /// </summary>
        /// <returns> a string which contains cube data</returns>
        public override string ToString()
        {
            return $"Cube: {"\nShape type: " + this.Type,-20} {"\nCube Length: " + cubelength,-20} {"\nCube Area: " + CalculateArea(),-40} {"\nCube Volume: " + CalculateVolume(),-40}";
        }
    }
}
