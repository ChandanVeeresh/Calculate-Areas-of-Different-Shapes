using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_area_testing
{
    class Program
    {
        enum choices { circle = 1, rectangle, triangle }

        static void Main(string[] args)
        {
            string parameters;
            double[] arguments;

        Console.WriteLine("Enter: \n 1 for Circle\n 2 for Rectangle \n 3 for Triangle");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case (int)choices.circle:
                        Console.WriteLine("Enter the radius of circle");
                        parameters = Console.ReadLine();
                        arguments = Array.ConvertAll(parameters.Split(' '), Double.Parse);
                        CalculateArea(choice, arguments);
                        break;
                    case (int)choices.rectangle:
                        Console.WriteLine("Enter the length and breadth of rectangle by giving spaces like length breadth");
                        parameters = Console.ReadLine();
                        arguments = Array.ConvertAll(parameters.Split(' '), Double.Parse);
                        CalculateArea(choice, arguments);
                        break;
                    case (int)choices.triangle:
                        Console.WriteLine("Enter the base and height of triangle by giving spaces like base  hieght");
                        parameters = Console.ReadLine();
                        arguments = Array.ConvertAll(parameters.Split(' '), Double.Parse);
                        CalculateArea(choice, arguments);
                        break;
                    default:
                        CalculateArea(choice);
                        break;
                }

            }
            catch (Exception e) {
                Console.WriteLine("Error : \n " + e.Message);
            }

            Console.ReadKey();
        }

        static void CalculateArea(int choice,params double[] parameters) {
            Shape s;
            try
            {
                s = ShapeFactory.GetShape(choice);
                s.AssignParameters(parameters);
                Console.WriteLine(s.CalculateArea().Display().ToString());

            }
            catch (InvalidParameterException e) {
                Console.WriteLine("Error : \n" + e.Message);
            }
        }
    }
}
