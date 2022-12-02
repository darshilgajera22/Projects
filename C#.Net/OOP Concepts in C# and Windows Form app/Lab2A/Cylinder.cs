using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Cylinder Class is used to calculate area and volume of Cylinder.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Cylinder Class is used to calculate area and volume of Cylinder.
    /// </summary>
    internal class Cylinder : Shape
    {
        private double cylinderheight; //  to store cylinder height
        private double cylinderradius; // to store cylinder radius

        /// <summary>
        /// Constructor Cylinder
        /// </summary>
        public Cylinder()
        {
            this.Type = "3 - Dimentional"; // Shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of cylinder.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating cylinder area
            return 2 * PI * cylinderradius * cylinderheight + 2 * PI * cylinderradius * cylinderradius;
        }

        /// <summary>
        /// to calculate cylinder volume
        /// </summary>
        /// <returns>a double which is a volume of cylinder</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating cylinder volume
            return PI * cylinderradius * cylinderradius * cylinderheight;
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
                    cylinderradius = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height: ");
                    cylinderheight = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if (cylinderradius < 0 || cylinderheight < 0)
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
        /// to display cylinder data
        /// </summary>
        /// <returns> a string which contains cylinder data</returns>
        public override string ToString()
        {
            return $"Cylinder: {"\nShape type: " + this.Type,-20} {"\nCylinder Radius: " + cylinderradius,-20} {"\nCylinder Height: " + cylinderheight,-20} {"\nCylinder Area: " + CalculateArea(),-40} {"\nCylinder Volume: " + CalculateVolume(),-40}";
        }
    }
}
