using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorTests
    {
        public GradingCalculator gradingCalculator;

        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GetGrade_InputScore95Attendance90_ResultEqualsA()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var grade = gradingCalculator.GetGrade();

            //Assert
            Assert.That(grade, Is.EqualTo("A"));
        }

        [Test]
        public void GetGrade_InputScore85Attendance90_ResultEqualsB()
        {
            //Arrange
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var grade = gradingCalculator.GetGrade();

            //Assert
            Assert.That(grade, Is.EqualTo("B"));
        }

        [Test]
        public void GetGrade_InputScore65Attendance90_ResultEqualsC()
        {
            //Arrange
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var grade = gradingCalculator.GetGrade();

            //Assert
            Assert.That(grade, Is.EqualTo("C"));
        }

        [Test]
        public void GetGrade_InputScore95Attendance65_ResultEqualsB()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            //Act
            var grade = gradingCalculator.GetGrade();

            //Assert
            Assert.That(grade, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void GetGrade_FailureScenarios_ResultEqualsF(int score, int attendance)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            var grade = gradingCalculator.GetGrade();

            //Assert
            Assert.That(grade, Is.EqualTo("F"));
        }
    }
}
