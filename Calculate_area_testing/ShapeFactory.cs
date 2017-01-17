using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_area_testing
{


    public class InvalidParameterException : System.Exception
    {
        public InvalidParameterException(string s) : base(s)
        {
        }

    }
    public class ShapeFactory {
        
        enum choices { circle = 1, rectangle, triangle }

        public static  Shape GetShape(int choice) {
            
            switch (choice) {
                case (int)choices.circle:
                    return new Circle();

                case (int)choices.rectangle:
                    return new Rectangle();

                case (int)choices.triangle:
                    return new Triangle();
                default:
                    throw (new InvalidParameterException("Invalid choice"));
            }            
        }
    }
   
    public abstract class Shape
    {
        public abstract Shape CalculateArea();
        public abstract void AssignParameters(params double[] parameters);
        public abstract double Display();
    }
    public class Circle : Shape
    {
        
        private double areaOfCircle;
        const double pi = 3.14159;
        private double radiusOfCircle;

        public override void AssignParameters(params double[] parameters)
        {
            if (parameters.Length != 1) {
                throw (new InvalidParameterException("Invalid parameter"));
            }
            
            radiusOfCircle = parameters[0];
            if (radiusOfCircle <= 0) {
                throw (new InvalidParameterException("Radius of circle should be positive"));
            }
        }
        public override Shape CalculateArea()
        {
            areaOfCircle = pi * radiusOfCircle * radiusOfCircle;
            return this;
        }

        public override double Display()
        {
            return areaOfCircle;
            
        }
    }
    public class Rectangle : Shape
    {
        private double lengthOfRectangle;
     

        private double breadthOfCircle;


        private double areaOfRectangle;
        public override void AssignParameters(params double[] parameters)
        {

            if (parameters.Length != 2)
            {
                throw (new InvalidParameterException("Invalid parameter"));
            }
            if(parameters[0]<=0 || parameters[1]<=0)
                throw (new InvalidParameterException("parameters should not be negative"));

            lengthOfRectangle = parameters[0];
            breadthOfCircle = parameters[1];
        }
        public override Shape CalculateArea()
        {
            areaOfRectangle = lengthOfRectangle * breadthOfCircle;
            return this;
        }

        public override double Display()
        {
            return areaOfRectangle;
        }
    }

    public class Triangle : Shape
    {


       
        private double areaOfTriangle;
        private double baseOfTriangle;

        private double hieghtOfTriangle;

        public override void AssignParameters(params double[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw (new InvalidParameterException("Invalid parameter"));
            }
            if (parameters[0] <=0 || parameters[1] <= 0)
                throw (new InvalidParameterException("parameters should not be negative"));

            baseOfTriangle = parameters[0];
            hieghtOfTriangle = parameters[1];
        }


        public override Shape CalculateArea()
        {
            areaOfTriangle = (0.5) * baseOfTriangle * hieghtOfTriangle;
            return this;
        }
        public override double Display()
        {
            return areaOfTriangle;
        }
    }
}
