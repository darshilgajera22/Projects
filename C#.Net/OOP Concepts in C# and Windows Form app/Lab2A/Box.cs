using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Box Class is used to calculate area and volume of Box.
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    /// Box class is used to calculate area and volume of Box.
    /// </summary>
    internal class Box : Shape
    { 
        private double boxlength;// to store box length
        private double boxwidth;// to store box width
        private double boxheight;// to store box height

        /// <summary>
        /// Constructor Box
        /// </summary>
        public Box()
        {
            this.Type = "3 - Dimentional";// shape type
        }

        /// <summary>
        /// to calculate area
        /// </summary>
        /// <returns>a double which is a area of box.</returns>
        public override double CalculateArea()
        {
            // math formula for calculating box area
            return 2 * (boxlength * boxwidth) + 2 * (boxlength * boxheight) + 2 * (boxheight * boxwidth);
        }

        /// <summary>
        /// to calculate box volume
        /// </summary>
        /// <returns>a double which is a volume of box.</returns>
        public override double CalculateVolume()
        {
            // math formula for calculating box volume
            return boxlength * boxheight * boxwidth;
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
                    boxlength = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the width: ");
                    boxwidth = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height: ");
                    boxheight = double.Parse(Console.ReadLine());
                    // if inputs is negative
                    if(boxlength < 0 || boxwidth < 0 || boxheight < 0)
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
            }while (flag != true); // continue loop
            
        }

        /// <summary>
        /// to display box data
        /// </summary>
        /// <returns> a string which contains box data</returns>
        public override string ToString()
        {
            return $"Box: {"\nShape type: " + this.Type,-20} {"\nBox Length: " + boxlength,-20} {"\nBox Width: " + boxwidth,-20} {"\nBox Height: " + boxheight,-20} {"\nBox Area: " + CalculateArea(),-40} {"\nBox Volumn: " + CalculateVolume(),-40}";

        }
    }
}
