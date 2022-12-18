using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            Calculator calc = new Calculator();

            int result = calc.AddNumbers(10, 20);

            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)] //15.9
        //[InlineData(5.43, 10.53)] //15.96
        //[InlineData(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calc = new Calculator();

            double result = calc.AddNumbersDouble(a, b);

            Assert.Equal(15.9, result, 1); //The "1" signifies that all results should be +/- 0.2 of the first value (15.9) 

        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new Calculator();

            bool result = calc.IsOddNumber(a);

            Assert.True(result);
        }

        [Fact]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new Calculator();

            bool result = calc.IsOddNumber(2);   
            
            Assert.False(result);
        }

        //The following format is recommended when multiple test cases have similiar logic (in this case true/false)
        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddNumber_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calc = new Calculator();

            var result = calc.IsOddNumber(a);

            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GetOddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //Range = 5-10

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }
    }
}
