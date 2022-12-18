using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        public GradingCalculator gradingCalculator;

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new ();
        }

        [Fact]
        public void GetGrade_InputScore95Attendance90_ResultEqualsA()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void GetGrade_InputScore85Attendance90_ResultEqualsB()
        {
            //Arrange
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }

        [Fact]
        public void GetGrade_InputScore65Attendance90_ResultEqualsC()
        {
            //Arrange
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("C", result);
        }

        [Fact]
        public void GetGrade_InputScore95Attendance65_ResultEqualsB()
        {
            //Arrange
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGrade_FailureScenarios_ResultEqualsF(int score, int attendance)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("F", result);

        }

        //My Result for Assignment 2, Part 2
        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_InputScoreAndAttendance_ResultGrade(int score, int attendance, string grade)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal(grade, result);
        }

        //Bhrugen's Result for Assignment 2, Part 2
        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_AllGradeLogicalScenarios_ResultGrade(int score, int attendance, string grade)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            //Act
            var result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal(grade, result);
        }

    }
}
