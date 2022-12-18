using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
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

        //My Result for Assignment 2, Part 2
        [Test]
        [TestCase(95,90,"A")]
        [TestCase(85,90,"B")]
        [TestCase(65,90,"C")]
        [TestCase(95,65,"B")]
        [TestCase(95,55,"F")]
        [TestCase(65,55,"F")]
        [TestCase(50,90,"F")]
        public void GetGrade_InputScoreAndAttendance_ResultGrade(int score, int attendance, string grade)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo(grade));
        }

        //Bhrugen's Result for Assignment 2, Part 2
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_AllGradeLogicalScenarios_ResultGrade(int score, int attendance)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            

            //Assert
            return gradingCalculator.GetGrade();
        }

    }
}
