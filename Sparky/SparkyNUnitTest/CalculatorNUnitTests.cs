using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            //Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.96
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            //Calculator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, 0.2); //The "1" signifies that all results should be +/- 0.2 of the first value (15.9) 
            
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            //Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            //Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(2);

            //Assert
            Assert.IsFalse(result);
        }

        //The following format is recommended when multiple test cases have similiar logic (in this case true/false)
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
        {
            //Arrange
            //Calculator calc = new();

            //Act
            return calc.IsOddNumber(a);

            //Assert - No assert in this type of test method because the assert is done by returning a value and checking
            //it against the Expected Results in lines 55 and 56

        }

        [Test]
        public void GetOddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            List<int> expectedOddRange = new() { 5, 7, 9 }; //Range = 5-10

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual(expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Ordered.Descending);
            Assert.That(result, Is.Unique); //Checks that all values in the list are unique
        }
    }
}
