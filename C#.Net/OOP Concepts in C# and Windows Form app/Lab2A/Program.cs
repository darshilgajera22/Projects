using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Purpose:    Main method to interact with user
/// Authorship: I, Darshil Gajera, 000867069 certify that this material is my original work.
///             No other person's work has been used without due acknowledgement.            
/// </summary>
namespace Lab2A
{
    /// <summary>
    ///   Repromt the options menu to user         
    /// </summary>
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Shape> shapelist = new List<Shape>(); // to store every shape 
            char choice = 'z'; // to get user choice
            // repromt window until user want exit
            do
            {
                Console.Clear(); // clearing console
                // menu
                Console.WriteLine("Nick's Geometry Class");
                Console.WriteLine("A - Rectangle \t E - Ellipse \t I - Triangle");
                Console.WriteLine("B - Square \t F - Circle \t J - Tetrahedron");
                Console.WriteLine("C - Box \t G - Cylinder");
                Console.WriteLine("D - Cube \t H - Sphere");

                Console.WriteLine("\n0 - List all shapes and Exit .............");
                bool flag = false; // turminating loop
                do
                {
                    try
                    {
                        Console.Write("\nEnter Your Choice: ");
                        choice = char.Parse(Console.ReadLine());
                        flag = true;
                    }
                    catch (Exception) // if user enter number
                    {
                        // error message
                        Console.WriteLine("\n\t ***** Please enter only Character *******");
                        flag = false;
                    }
                } while (flag != true); // continuing loop
                
                // displaying total number of shapes entered by user
                Console.WriteLine("\n"+Shape.GetCount() + "(shapes enter so far) \n");

                try
                {
                    // to create & call perticular class method
                    switch (char.ToUpper(choice))
                    {
                        case 'A':
                            Shape rectangle = new Rectangle(); 
                            rectangle.SetData(); 
                            shapelist.Add(rectangle); 
                            break;
                        case 'B':
                            Shape square = new Square(); 
                            square.SetData(); 
                            shapelist.Add(square); 
                            break;
                        case 'C':
                            Shape box = new Box(); 
                            box.SetData(); 
                            shapelist.Add(box); 
                            break;
                        case 'D':
                            Shape cube = new Cube();
                            cube.SetData(); 
                            shapelist.Add(cube);
                            break;
                        case 'E':
                            Shape ellipse = new Ellipse();
                            ellipse.SetData();
                            shapelist.Add(ellipse);
                            break;
                        case 'F':
                            Shape circle = new Circle();
                            circle.SetData();
                            shapelist.Add(circle);
                            break;
                        case 'G':
                            Shape cylinder = new Cylinder();
                            cylinder.SetData();
                            shapelist.Add(cylinder);
                            break;
                        case 'H':
                            Shape sphere = new Sphere();
                            sphere.SetData();
                            shapelist.Add(sphere);
                            break;
                        case 'I':
                            Shape triangle = new Triangle();
                            triangle.SetData();
                            shapelist.Add(triangle);
                            break;
                        case 'J':
                            Shape tetrahedron = new Tetrahedron();
                            tetrahedron.SetData();
                            shapelist.Add(tetrahedron);
                            break;
                        case '0':
                            Console.WriteLine("\n\n------------------------------------------------------------------------------\n\n");
                            Console.WriteLine("\t\t\tList of all Shapes \n");
                            foreach (var i in shapelist)
                            {
                                Console.WriteLine(i.ToString() + "\n");
                            }
                            Thread.Sleep(30000);
                            break;
                    }
                }
                catch (FormatException) // if user enter numbers or string
                {
                    Console.WriteLine("\t****** Please Enter Only Characters ******");
                }
            } while (choice != '0'); // turminating loop if user enter 0

        }
    }
}
