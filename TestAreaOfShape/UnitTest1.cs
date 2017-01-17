using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculate_area_testing;
namespace TestAreaOfShape
{
    
    [TestClass]
    public class UnitTest1

    {
        enum choices {circle=1,rectangle,triangle}
       
        public static double CalculateArea(int choice, params double[] s) {
            Shape p;
            p = ShapeFactory.GetShape(choice);
            p.AssignParameters(s);
            return p.CalculateArea().Display();

        }

        [TestMethod]
        public void ValidChoiceValidInputForCircle_OnAreaCalculation_ReturnsCorrectResult()
        {
            double area = (3.14159 * 5 * 5);
            Assert.AreEqual(area, CalculateArea((int)choices.circle, 5), "Incorrect area");
        }

        [TestMethod]
        public void ValidChoiceValidInputForRectangle_OnAreaCalculation_ReturnsCorrectResult() {
            double area = 5 * 4;

            Assert.AreEqual(area, CalculateArea((int)choices.rectangle,5,4), "Incorrect area");

        }

        [TestMethod]
        public void ValidChoiceValidInputForTriangle_OnAreaCalculation_ReturnsCorrectResult()
        {
            double area = 5 * 4*0.5;

            Assert.AreEqual(area, CalculateArea((int)choices.triangle, 5, 4), "Incorrect area");

        }
        [TestMethod,ExpectedException(typeof(InvalidParameterException))]
        public void InvalidChoiceValidInput_OnAreaCalculation_ThrowsException()
        {
            CalculateArea(4, 5);
        }
        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void InvalidParamCircleValidInput_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.circle);
        }

        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceInvalidCircleParameters_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.circle,-5);
        }

        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceInvalidRectangleParameters_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.rectangle, -5,-6);
        }

        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceInvalidTriangleParameters_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.triangle, -5,-8);
        }

        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void InvalidParamRectangleValidInput_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.rectangle);
        }
        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void InvalidParamTriangleValidInput_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.triangle,-8,0);
        }
        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceCircleBoundaryZero_OnAreaCalculation_ThrowsException() {
            CalculateArea((int)choices.circle, 0);
        }

        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceRectangleBoundaryZero_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.rectangle, 0);
        }
        [TestMethod, ExpectedException(typeof(InvalidParameterException))]
        public void ValidChoiceTriangleBoundaryZero_OnAreaCalculation_ThrowsException()
        {
            CalculateArea((int)choices.triangle, 0,0);
        }
    }
}
