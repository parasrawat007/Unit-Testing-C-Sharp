﻿using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;
        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrade() 
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            var result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;
            var result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;
            var result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;
            var result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailureScenarios_GetFGrade(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;
            var result = gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
    }
}
