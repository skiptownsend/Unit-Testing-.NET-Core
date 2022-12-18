using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class FiboXUnitTests
    {
        private Fibo fibo;
        public FiboXUnitTests()
        {
            fibo = new Fibo();
        }

        //My Solution
        [Fact]
        public void GetFiboSeries_InputRangeEquals1()
        {
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(u => u), result);
            Assert.Contains(0, result);
        }

        //Bhrugen's Solution
        [Fact]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() { 0 };
            fibo.Range = 1;

            List<int> result = fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(u => u), result);
            Assert.Equal(expectedRange, result);
            Assert.True(result.SequenceEqual(expectedRange)); //Equivalent to line 41
        }

        //My Solution
        [Fact]
        public void GetFiboSeries_InputRangeEquals6()
        {
            //Arrange
            fibo.Range = 6;
            List<int> resultMatch = new[] { 0, 1, 1, 2, 3, 5 }.ToList();

            //Act
            List<int> result = fibo.GetFiboSeries();

            //Assert
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(resultMatch, result);
        }

        //Bhrugen's Solution
        [Fact]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            fibo.Range = 6;

            List<int> result = fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange, result);
        }
    }
}
