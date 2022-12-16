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
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void Is_Input_Odd_IsOddNumber()
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(3);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Is_Input_Even_IsOddNumber()
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(2);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
