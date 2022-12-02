using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Sphere Class is used to calculate area and volume of Sphere.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Sphere Class is used to calculate area and volume of Sphere.
    /// </summary>
    internal class Sphere : Cylinder
    {
        private double sphereradius; // to store sphere radius

        /// <summary>
        /// Constructor Sphere
        /// </summary>
        public Sphere()
        {
            this.Type = "3 - Dimentional"; // Shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of sphere.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating sphere area
            return 4 * PI * sphereradius * sphereradius;
        }

        /// <summary>
        /// to calculate volume
        /// </summary>
        /// <returns>a double which is a volume of sphere</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating sphere volume
            return 4 * PI * sphereradius * sphereradius * sphereradius / 3;
        }

        /// <summary>
        /// to get input from user and store in class varibales
        /// </summary>
        public override void SetData()
        {
            bool flag=false; // to turminate loop
            do
            {
                try
                {
                    Console.WriteLine("Enter the radius: ");
                    sphereradius = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (sphereradius < 0)
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
        /// to display sphere data
        /// </summary>
        /// <returns> a string which contains sphere data</returns>
        public override string ToString()
        {
            return $"Sphere: {"\nShape type: " + this.Type,-20} {"\nSphere Radius: " + sphereradius,-20} {"\nSphere Area: " + CalculateArea(),-40} {"\nSphere Volume: " + CalculateVolume(),-40}";
        }
    }
}
