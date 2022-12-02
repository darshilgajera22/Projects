using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Tetrahedron Class is used to calculate area and volume of Tetrahedron.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Tetrahedron Class is used to calculate area and volume of Tetrahedron.
    /// </summary>
    internal class Tetrahedron : Triangle
    {
        private double tetrahedronlength; // to store tetrahedron length

        /// <summary>
        /// Constructor Tetrahedron
        /// </summary>
        public Tetrahedron()
        {
            this.Type = "3 - Dimentional"; // Shape type

        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of trtrahedron.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating tetrahedron area
            return Math.Sqrt(3) * (tetrahedronlength * tetrahedronlength);
        }

        /// <summary>
        /// to calculate volume
        /// </summary>
        /// <returns>a double which is a volume of tetrahedron</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating tetrahedron volume
            return Math.Pow(tetrahedronlength, 3) / 6 * Math.Sqrt(2);
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
                    tetrahedronlength = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (tetrahedronlength < 0)
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
                catch (FormatException)  // if input is characters
                {
                    // print error message
                    Console.WriteLine("\t****** Please enter numbers ******");
                    flag = false;
                }
            } while (flag != true); // continue loop
        }

        /// <summary>
        /// to display tetrahedron data
        /// </summary>
        /// <returns> a string which contains tetrahedron data</returns>
        public override string ToString()
        {
            return $"Tetrahedron: {"\nShape type: " + this.Type,-20} {"\nTetrahedron Length: " + tetrahedronlength,-20} {"\nTetrahedron Area: " + CalculateArea(),-40} {"\nTetrahedron Volume: " + CalculateVolume(),-40}";    
        }
    }
}
