//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sparky
//{
//    [TestFixture]
//    public class FiboXUnitTests
//    {
//        private Fibo fibo;

//        [SetUp]
//        public void Setup()
//        {
//            fibo = new Fibo();
//        }

//        //My Solution
//        [Test]
//        public void GetFiboSeries_InputRangeEquals1()
//        {
//            fibo.Range = 1;
//            var result = fibo.GetFiboSeries();

//            Assert.That(result, Is.Not.Empty);
//            Assert.That(result, Is.Ordered);
//            Assert.That(result, Does.Contain(0));
//        }

//        //Bhrugen's Solution
//        [Test]
//        public void FiboChecker_Input1_ReturnsFiboSeries()
//        {
//            List<int> expectedRange = new() { 0 };
//            fibo.Range = 1;

//            List<int> result = fibo.GetFiboSeries();

//            Assert.That(result, Is.Not.Empty);
//            Assert.That(result, Is.Ordered);
//            Assert.That(result, Is.EquivalentTo(expectedRange));
//        }

//        //My Solution
//        [Test]
//        public void GetFiboSeries_InputRangeEquals6()
//        {
//            //Arrange
//            fibo.Range = 6;
//            List<int> resultMatch = new[] { 0, 1, 1, 2, 3, 5 }.ToList();

//            //Act
//            List<int> result = fibo.GetFiboSeries();

//            //Assert
//            Assert.That(result, Does.Contain(3));
//            Assert.That(result.Count, Is.EqualTo(6));
//            Assert.That(result, Does.Not.Contain(4));
//            Assert.That(result, Is.EqualTo(resultMatch));
//        }

//        //Bhrugen's Solution
//        [Test]
//        public void FiboChecker_Input6_ReturnsFiboSeries()
//        {
//            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
//            fibo.Range = 6;

//            List<int> result = fibo.GetFiboSeries();

//            Assert.That(result, Does.Contain(3));
//            Assert.That(result.Count, Is.EqualTo(6));
//            Assert.That(result, Has.No.Member(4));
//            Assert.That(result, Is.EquivalentTo(expectedRange));
//        }
//    }
//}
