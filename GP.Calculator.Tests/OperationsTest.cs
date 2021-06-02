using System;
using System.Collections.Generic;
using GP.Calculator.Interfaces;
using Xunit;

namespace GP.Calculator.Tests
{
    public class OperationsTest
    {
        private readonly ICalculations _operations;
        public OperationsTest()
        {
            _operations = new Calculations();
        }
        [Fact]
        public void Test_adding_two_numbers()
        {
            // arrange
            var lines = new List<string> {"add 2", "apply 10"};

            // act
            var firstArgument = _operations.GetFirstArgument(lines);
            var result = _operations.Calculate(lines[0], firstArgument);

            // assert
            result.Equals(12);
        }

        [Fact]
        public void Test_adding_and_multiply()
        {
            // arrange
            var lines = new List<string> {"add 2", "multiply 3", "apply 10"};

            // act
            var firstArgument = _operations.GetFirstArgument(lines);
            var result = _operations.Calculate(lines[0], firstArgument);

            // assert
            result.Equals(36);
        }

        [Fact]
        public void Test_multiply_and_adding()
        {
            // arrange
            var lines = new List<string> {"multiply 3", "add 2", "apply 10"};

            // act
            var firstArgument = _operations.GetFirstArgument(lines);
            var result = _operations.Calculate(lines[0], firstArgument);

            // assert
            result.Equals(32);
        }

        [Fact]
        public void Test_start_operation()
        {
            // arrange
            var lines = new List<string> {"apply 10"};

            // act
            var result = _operations.GetFirstArgument(lines);
           

            // assert
            result.Equals(10);
        }
        [Fact]
        public void Test_divide_two_number()
        {
            // arrange
            var lines = new List<string> { "divide 3", "apply 9" };

            // act
            var firstArgument = _operations.GetFirstArgument(lines);
            var result = _operations.Calculate(lines[0], firstArgument);

            // assert
            result.Equals(3);
        }

        [Fact]
        public void Test_subtraction_two_number()
        {
            // arrange
            var lines = new List<string> { "subtract 2", "apply 12" };

            // act
            var firstArgument = _operations.GetFirstArgument(lines);
            var result = _operations.Calculate(lines[0], firstArgument);

            // assert
            result.Equals(10);
        }
    }
}
