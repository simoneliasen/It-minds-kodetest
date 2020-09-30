using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using Xunit.Sdk;

namespace StolenTests
{
    public class NumberHelperTests {

        /// <param name="needle">Number that is searched for</param>
        /// <param name="haystack">Collection of numbers that are searched through</param>
        /// <param name="n">The amount of numbers close to needle that should be returned</param>

        // Original specification: Exact needle pick
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 3, 1)]
        [InlineData(5, 5, 1)]
        public void NumberHelper_ShouldFindTheSingleExactNeedleSpecified(int needleExample, int expected, int returnSize)
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            IEnumerable<int> actual = helper.FindClosestNumbers(needleExample, haystackExample, returnSize);

            // Assert
            Assert.Equal(expected, actual.First());

        }

        // Original specification: Close needle pick
        [Theory]
        [InlineData(5, 3, 1)]
        [InlineData(0, 1, 1)]
        public void NumberHelper_ShouldFindTheSingleClosestNeedle(int needleExample, int expected, int returnSize)
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 2, 3 };

            // Act
            IEnumerable<int> actual = helper.FindClosestNumbers(needleExample, haystackExample, returnSize);

            // Assert
            Assert.Equal(expected, actual.First());

        }

        // Issues on the Testing methods below from here, couldn't manage to get lists as input to work for Inlinedata to test multiple input values, with more time this should be implemented, for more tests

        // Original specification: Exactly between needle return size of one
        [Fact]
        public void NumberHelper_ShouldFindLowestClosestNeedleWhenEquallyCloseToTwoNumbers()
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 3, 5, 7, 9, 12, 15, 20, 25 };
            List<int> expected = new List<int> { 1, 3 };

            // Act
            IEnumerable<int> actual = helper.FindClosestNumbers(2, haystackExample, 1).ToList();

            // Assert
            Assert.Equal(expected, actual);

        }

        // Original specification: Exactly between needle return size of two
        [Fact]
        public void NumberHelper_ShouldFindMultipleClosestNeedleWhenEquallyCLoseToTwoNumbers()
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 3, 5, 7, 9, 12, 15, 20, 25 };
            List<int> expected = new List<int> { 1, 3 };

            // Act
            IEnumerable<int> actual = helper.FindClosestNumbers(2, haystackExample, 2).ToList();

            // Assert
            Assert.Equal(expected, actual);
        }

        // Edge Case: Positive integer should work
        [Fact]
        public void NumberHelper_PositiveIntegerShouldWork()
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 2, 3 };

            // Act
            var actual = helper.FindClosestNumbers(2, haystackExample, 1).ToList();

            // Assert
            Assert.True(actual.First() > 0);
        }


        // Edge case: Non-Positive integers should fail
        [Fact]
        public void NumberHelper_NegativeIntegerShoulFail()
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 2, 3 };

            // Act and Assert
            Assert.Throws<ArgumentException>("needle", () => helper.FindClosestNumbers(-200, haystackExample, 1));

        }

        // Edge case: N bigger than list count
        [Fact]
        public void NumberHelper_NBiggerThanHaystackCountShouldFail()
        {
            // Arrange
            NumberHelper helper = new NumberHelper();
            List<int> haystackExample = new List<int> { 1, 2, 3 };

            // Act
            helper.FindClosestNumbers(2, haystackExample, 5);

            //Assert
            Assert.Throws<ArgumentException>(() => "N is greater than amount of elements in the haystack");

        }

        // Additional tests which was thought about at time of handing in the coding-test
        // Edge case: Two or more needles in haystack
        // Edge case: Empty list 
        // Edge case: Non Ordered list
        // Edge case: response on max values

    }
}








