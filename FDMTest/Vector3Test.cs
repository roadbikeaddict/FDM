using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDM.Mathematics;

namespace FDMTest
{
    [TestClass]
    public class Vector3Test
    {
        [TestMethod]
        public void Another_vector_shall_be_added_to_the_current_one()
        {
            var firstOperand = new Vector3(1, 5, 6);
            var secondOperand = new Vector3(4, 9, 1);

            var actual = firstOperand + secondOperand;
            Assert.AreEqual(actual.X, 5);
            Assert.AreEqual(actual.Y, 14);
            Assert.AreEqual(actual.Z, 7);
        }

        [TestMethod]
        public void Another_vector_shall_be_subtracted_from_the_current_one()
        {
            var firstOperand = new Vector3(1, 5, 6);
            var secondOperand = new Vector3(4, 9, 1);

            var actual = firstOperand - secondOperand;
            Assert.AreEqual(actual.X, -3);
            Assert.AreEqual(actual.Y, -4);
            Assert.AreEqual(actual.Z, 5);
        }

        [TestMethod]
        public void Calculate_dot_product()
        {
            var firstOperand = new Vector3(1, 5, 6);
            var secondOperand = new Vector3(4, 9, 1);

            var actual = firstOperand.Dot(secondOperand);
            Assert.AreEqual(actual, 55);
        }

        [TestMethod]
        public void Calculate_cross_product()
        {
            var firstOperand = new Vector3(1, 5, 6);
            var secondOperand = new Vector3(4, 9, 1);

            var actual = firstOperand.Cross(secondOperand);
            Assert.AreEqual(actual.X, -49);
            Assert.AreEqual(actual.Y, 23);
            Assert.AreEqual(actual.Z, -11);
        }

        [TestMethod]
        public void The_two_vectors_should_be_equal()
        {
            var firstVector = new Vector3(42, 66, 23);
            var secondVector = new Vector3(42, 66, 23);

            var actual = firstVector.Equals(secondVector);
            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void The_two_vectors_should_not_be_equal()
        {
            var firstVector = new Vector3(66, 42, -23);
            var secondVector = new Vector3(42, 66, 23);

            var actual = firstVector.Equals(secondVector);
            Assert.AreEqual(actual, false);
        }

        [TestMethod]
        public void A_hashcode_should_be_returned()
        {
            const int expected = -1386971136;
            var testVector = new Vector3(42, 66, 23);
            var actual = testVector.GetHashCode();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void A_copied_vector_should_be_returned()
        {
            var origVector = new Vector3(42, 66, 23);
            var actual = new Vector3(origVector);
            Assert.AreEqual(actual.X, origVector.X);
            Assert.AreEqual(actual.Y, origVector.Y);
            Assert.AreEqual(actual.Z, origVector.Z);
        }

        [TestMethod]
        public void The_vector_components_should_be_assigned_correctly()
        {
            var origVector = new Vector3(42, 66, 23);
            var actual = new Vector3();
            actual.AssignFrom(origVector);
            Assert.AreEqual(actual.X, origVector.X);
            Assert.AreEqual(actual.Y, origVector.Y);
            Assert.AreEqual(actual.Z, origVector.Z);
        }

        [TestMethod]
        public void The_vector_components_should_be_returned_correctly_by_index()
        {
            const int expectedX = 42;
            const int expectedY = 66;
            const int expectedZ = 23;
            var testVector = new Vector3(42, 66, 23);
            var actualX = testVector[1];
            var actualY = testVector[2];
            var actualZ = testVector[3];
            Assert.AreEqual(actualX, expectedX);
            Assert.AreEqual(actualY, expectedY);
            Assert.AreEqual(actualZ, expectedZ);
        }

        [TestMethod]
        public void The_vector_components_should_be_set_correctly_by_index()
        {
            const int expectedX = 42;
            const int expectedY = 66;
            const int expectedZ = 23;
            var testVector = new Vector3();
            testVector[1] = 42;
            testVector[2] = 66;
            testVector[3] = 23;
            Assert.AreEqual(testVector.X, expectedX);
            Assert.AreEqual(testVector.Y, expectedY);
            Assert.AreEqual(testVector.Z, expectedZ);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
                  "The index of a vector element must be between 1 and 3")]
        public void An_exception_should_be_thrown_when_a_value_is_assigned_to_an_invalid_index()
        {
            var testVector = new Vector3();
            testVector[4] = 42;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
                  "The index of a vector element must be between 1 and 3")]
        public void An_exception_should_be_thrown_when_a_value_is_read_from_an_invalid_index()
        {
            var testVector = new Vector3(42, 66, 23);
            testVector[1] = testVector[4];
        }

        [TestMethod]
        public void The_vector_magnitude_should_be_calculated_correctly()
        {
            const double expected = 81.54140052758475891788908552927;
            var testVector = new Vector3(42, 66, -23);
            var actual = testVector.Magnitude();
            Assert.AreEqual(actual, expected, 1E-08);
        }

        [TestMethod]
        public void Another_vector_should_be_added_correctly_to_the_current_one()
        {
            const int expectedX = 60;
            const int expectedY = 86;
            const int expectedZ = -1;

            var testVector = new Vector3(42, 66, -23);
            var otherVector = new Vector3(18, 20, 22);
            var actual = testVector + otherVector;
            Assert.AreEqual(actual.X, expectedX);
            Assert.AreEqual(actual.Y, expectedY);
            Assert.AreEqual(actual.Z, expectedZ);
        }

        [TestMethod]
        public void Another_vector_should_be_subtracted_correctly_to_the_current_one()
        {
            const int expectedX = 24;
            const int expectedY = 46;
            const int expectedZ = -45;

            var testVector = new Vector3(42, 66, -23);
            var otherVector = new Vector3(18, 20, 22);
            var actual = testVector - otherVector;
            Assert.AreEqual(actual.X, expectedX);
            Assert.AreEqual(actual.Y, expectedY);
            Assert.AreEqual(actual.Z, expectedZ);
        }

        [TestMethod]
        public void Another_vector_should_be_added_correctly_to_the_current_one_by_direct_assignment()
        {
            const int expectedX = 60;
            const int expectedY = 86;
            const int expectedZ = -1;

            var testVector = new Vector3(42, 66, -23);
            var otherVector = new Vector3(18, 20, 22);
            testVector += otherVector;
            Assert.AreEqual(testVector.X, expectedX);
            Assert.AreEqual(testVector.Y, expectedY);
            Assert.AreEqual(testVector.Z, expectedZ);
        }

        [TestMethod]
        public void Another_vector_should_be_subtracted_correctly_to_the_current_one_by_direct_assignment()
        {
            const int expectedX = 24;
            const int expectedY = 46;
            const int expectedZ = -45;

            var testVector = new Vector3(42, 66, -23);
            var otherVector = new Vector3(18, 20, 22);
            testVector -= otherVector;
            Assert.AreEqual(testVector.X, expectedX);
            Assert.AreEqual(testVector.Y, expectedY);
            Assert.AreEqual(testVector.Z, expectedZ);
        }

        [TestMethod]
        public void First_vector_is_greater_than_the_second_one()
        {
            var firstVector = new Vector3(42, 66, -23);
            var secondVector = new Vector3(2, -1, 3.5);
            var actual = firstVector > secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_smaller_than_the_second_one()
        {
            var firstVector = new Vector3(1, -3, 5);
            var secondVector = new Vector3(-42, -66, -23);
            var actual = firstVector < secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_not_greater_than_the_second_one()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(42, 66, 23);
            var actual = firstVector > secondVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void First_vector_is_not_smaller_than_the_second_one()
        {
            var firstVector = new Vector3(-42, -66, -23);
            var secondVector = new Vector3(1, 3, -5);
            var actual = firstVector < secondVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void First_vector_is_greater_than_or_equal_to_the_second_one_case_greater()
        {
            var firstVector = new Vector3(42, 66, -23);
            var secondVector = new Vector3(2, -1, 3.5);
            var actual = firstVector >= secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_greater_than_or_equal_to_the_second_one_case_equal()
        {
            var firstVector = new Vector3(-42, 66, -23);
            var secondVector = new Vector3(42, -66, 23);
            var actual = firstVector >= secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_smaller_than_or_equal_to_the_second_one_case_smaller()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(42, 66, -23);
            var actual = firstVector <= secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_smaller_than_or_equal_to_the_second_one_case_equal()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(-2, 1, -3.5);
            var actual = firstVector <= secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_not_greater_than_or_equal_to_the_second_one_case_greater()
        {
            var firstVector = new Vector3(2, 1, 4);
            var secondVector = new Vector3(42, 66, -23);
            var actual = firstVector >= secondVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void First_vector_is_not_smaller_than_or_equal_to_the_second_one_case_smaller()
        {
            var firstVector = new Vector3(42, 66, 23);
            var secondVector = new Vector3(2, -1, 3.5);
            var actual = firstVector <= secondVector;
            Assert.IsFalse(actual);
        }

     
        [TestMethod]
        public void First_vector_is_equal_to_the_second_one()
        {
            var firstVector = new Vector3(-2, -1, 3.5);
            var secondVector = new Vector3(-2, -1, 3.5);
            var actual = firstVector == secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void First_vector_is_not_equal_to_the_second_one()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(42, -1, 3.5);
            var actual = firstVector == secondVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void First_vector_is_equal_to_the_second_one_using_unequal_operator()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(-2, -1, 3.5);
            var actual = firstVector == secondVector;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void First_vector_is_not_equal_to_the_second_one_using_unequal_operator()
        {
            var firstVector = new Vector3(2, -1, 3.5);
            var secondVector = new Vector3(42, -1, 3.5);
            var actual = firstVector != secondVector;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Multiply_vector_by_scalar()
        {
            const double expectedX = 147.0;
            const double expectedY = 80.5;
            const double expectedZ = 231.0;
            var testVector = new Vector3(42, 23, 66);
            const double scalar = 3.5;
            var actual = testVector*scalar;
            Assert.AreEqual(actual.X, expectedX, 1E-08);
            Assert.AreEqual(actual.Y, expectedY, 1E-08);
            Assert.AreEqual(actual.Z, expectedZ, 1E-08);
        }

        [TestMethod]
        public void Multiply_scalar_by_vector()
        {
            const double expectedX = 147.0;
            const double expectedY = 80.5;
            const double expectedZ = 231.0;
            var testVector = new Vector3(42, 23, 66);
            const double scalar = 3.5;
            var actual = scalar * testVector;
            Assert.AreEqual(actual.X, expectedX, 1E-08);
            Assert.AreEqual(actual.Y, expectedY, 1E-08);
            Assert.AreEqual(actual.Z, expectedZ, 1E-08);
        }
        
        [TestMethod]
        public void Divide_vector_by_scalar()
        {
            const double expectedX = 12.0;
            const double expectedY = 6.5714285714285714285714285714286;
            const double expectedZ = 18.857142857142857142857142857143;
            
            var testVector = new Vector3(42, 23, 66);
            const double scalar = 3.5;
            var actual = testVector / scalar;
            Assert.AreEqual(actual.X, expectedX, 1E-08);
            Assert.AreEqual(actual.Y, expectedY, 1E-08);
            Assert.AreEqual(actual.Z, expectedZ, 1E-08);
        }

        [TestMethod]
        public void Calculate_static_cross_product()
        {
            const double expectedX = 12.0;
            const double expectedY = 46.0;
            const double expectedZ = -44.0;

            var firstVector = new Vector3(3, 4, 5);
            var secondVector = new Vector3(8, -4, -2);

            var actual = Vector3.Cross(firstVector, secondVector);
            Assert.AreEqual(actual.X, expectedX, 1E-08);
            Assert.AreEqual(actual.Y, expectedY, 1E-08);
            Assert.AreEqual(actual.Z, expectedZ, 1E-08);
        }

        [TestMethod]
        public void Calculate_static_dot_product()
        {
            const double expected = -2.0;
        
            var firstVector = new Vector3(3, 4, 5);
            var secondVector = new Vector3(8, -4, -2);

            var actual = Vector3.Dot(firstVector, secondVector);
            Assert.AreEqual(actual, expected, 1E-08);
        }

        [TestMethod]
        public void Calculate_normalized_vector()
        {
            const double expectedX = 0.85078833316749163833243067806701;
            const double expectedY = 0.24308238090499761095212305087629;
            const double expectedZ = -0.46590789673457875432490251417956;

            var testVector = new Vector3(42, 12, -23);
            var actual = testVector.Normalize();
            Assert.AreEqual(actual.X, expectedX, 1E-08);
            Assert.AreEqual(actual.Y, expectedY, 1E-08);
            Assert.AreEqual(actual.Z, expectedZ, 1E-08);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),
                  "Magnitude is zero")]
        public void Calculate_normalized_vector_for_null_vector()
        {
            var testVector = new Vector3(0, 0, 0);
            testVector.Normalize();
        }
    }
}
