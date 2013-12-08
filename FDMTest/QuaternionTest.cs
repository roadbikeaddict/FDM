using System;
using FDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDM.Mathematics;

namespace FDMTest
{
    [TestClass]
    public class QuaternionTest
    {
        [TestMethod]
        public void A_standard_quaternion_should_be_created()
        {
            var testQuaternion = new Quaternion();
            Assert.AreEqual(testQuaternion.Q1, 1.0, 1E-08);
            Assert.AreEqual(testQuaternion.Q2, 0.0, 1E-08);
            Assert.AreEqual(testQuaternion.Q3, 0.0, 1E-08);
            Assert.AreEqual(testQuaternion.Q4, 0.0, 1E-08);
        }

        [TestMethod]
        public void A_user_defined_quaternion_should_be_created()
        {
            var testQuaternion = new Quaternion(42.0, -66.0, 23.5, -87.2);
            Assert.AreEqual(testQuaternion.Q1, 42.0, 1E-08);
            Assert.AreEqual(testQuaternion.Q2, -66.0, 1E-08);
            Assert.AreEqual(testQuaternion.Q3, 23.5, 1E-08);
            Assert.AreEqual(testQuaternion.Q4, -87.2, 1E-08);
        }

        [TestMethod]
        public void A_quaternion_with_three_Euler_angles_as_initial_parameters_should_be_created()
        {
            var testQuaternion = new Quaternion(DegToRad(42.0), DegToRad(23.0), DegToRad(66.0));
            Assert.AreEqual(testQuaternion.Q1, 0.80616101177, 1E-10);
            Assert.AreEqual(testQuaternion.Q2, 0.19314748280, 1E-10);
            Assert.AreEqual(testQuaternion.Q3, 0.34736125366, 1E-10);
            Assert.AreEqual(testQuaternion.Q4, 0.43833620936, 1E-10);
        }

        [TestMethod]
        public void A_quaternion_with_Euler_angle_phi_as_initial_parameter_should_be_created()
        {
            var testQuaternion = new Quaternion(EulerAngles.ePhi, DegToRad(42.0));
            Assert.AreEqual(testQuaternion.Q1, 0.93358042649, 1E-10);
            Assert.AreEqual(testQuaternion.Q2, 0.35836794954, 1E-10);
            Assert.AreEqual(testQuaternion.Q3, 0.0, 1E-10);
            Assert.AreEqual(testQuaternion.Q4, 0.0, 1E-10);
        }

        [TestMethod]
        public void A_quaternion_with_Euler_angle_theta_as_initial_parameter_should_be_created()
        {
            var testQuaternion = new Quaternion(EulerAngles.eTht, DegToRad(42.0));
            Assert.AreEqual(testQuaternion.Q1, 0.93358042649, 1E-10);
            Assert.AreEqual(testQuaternion.Q2, 0.0, 1E-10);
            Assert.AreEqual(testQuaternion.Q3, 0.35836794954, 1E-10);
            Assert.AreEqual(testQuaternion.Q4, 0.0, 1E-10);
        }

        [TestMethod]
        public void A_quaternion_with_Euler_angle_psi_as_initial_parameter_should_be_created()
        {
            var testQuaternion = new Quaternion(EulerAngles.ePsi, DegToRad(42.0));
            Assert.AreEqual(testQuaternion.Q1, 0.93358042649, 1E-10);
            Assert.AreEqual(testQuaternion.Q2, 0.0, 1E-10);
            Assert.AreEqual(testQuaternion.Q3, 0.0, 1E-10);
            Assert.AreEqual(testQuaternion.Q4, 0.35836794954, 1E-10);
        }

        [TestMethod]
        public void Two_quaternions_should_be_equal()
        {
            var firstQuaternion = new Quaternion(1,2,3,4);
            var secondQuaternion = new Quaternion(1, 2, 3, 4);
            var actual = firstQuaternion == secondQuaternion;
            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void Two_quaternions_should_be_unequal()
        {
            var firstQuaternion = new Quaternion(1, 2, 3, 4);
            var secondQuaternion = new Quaternion(1, 3, 2, 4);
            var actual = firstQuaternion != secondQuaternion;
            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void Two_quaternions_should_be_equal_using_equals()
        {
            var firstQuaternion = new Quaternion(1, 2, 3, 4);
            var secondQuaternion = new Quaternion(1, 2, 3, 4);
            var actual = firstQuaternion.Equals(secondQuaternion);
            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void Two_quaternions_should_be_added_correctly()
        {
            var firstQuaternion = new Quaternion(1, 2, 3, 4);
            var secondQuaternion = new Quaternion(5, -2, 9, 3);
            var actual = firstQuaternion + secondQuaternion;
            Assert.AreEqual(actual[1], 6);
            Assert.AreEqual(actual[2], 0);
            Assert.AreEqual(actual[3], 12);
            Assert.AreEqual(actual[4], 7);
        }

        [TestMethod]
        public void Two_quaternions_should_be_subtracted_correctly()
        {
            var firstQuaternion = new Quaternion(1, 2, 3, 4);
            var secondQuaternion = new Quaternion(5, -2, 9, 3);
            var actual = firstQuaternion - secondQuaternion;
            Assert.AreEqual(actual[1], -4);
            Assert.AreEqual(actual[2], 4);
            Assert.AreEqual(actual[3], -6);
            Assert.AreEqual(actual[4], 1);
        }

        [TestMethod]
        public void A_quaternion_should_be_multiplied_with_a_scalar_correctly()
        {
            var testQuaternion = new Quaternion(1, 2, 3, 4);
            const double scalar = 1.5;
            var actual = testQuaternion * scalar;
            Assert.AreEqual(actual[1], 1.5);
            Assert.AreEqual(actual[2], 3);
            Assert.AreEqual(actual[3], 4.5);
            Assert.AreEqual(actual[4], 6);
        }

        [TestMethod]
        public void A_scalar_should_be_multiplied_with_a_quaternion_correctly()
        {
            var testQuaternion = new Quaternion(1, 2, 3, 4);
            const double scalar = 1.5;
            var actual = scalar * testQuaternion;
            Assert.AreEqual(actual[1], 1.5);
            Assert.AreEqual(actual[2], 3);
            Assert.AreEqual(actual[3], 4.5);
            Assert.AreEqual(actual[4], 6);
        }

        [TestMethod]
        public void A_quaternion_should_be_divided_by_a_scalar_correctly()
        {
            var testQuaternion = new Quaternion(1.5, 3, 4.5, 6);
            const double scalar = 1.5;
            var actual = testQuaternion / scalar;
            Assert.AreEqual(actual[1], 1, 1E-08);
            Assert.AreEqual(actual[2], 2, 1E-08);
            Assert.AreEqual(actual[3], 3, 1E-08);
            Assert.AreEqual(actual[4], 4, 1E-08);
        }

        [TestMethod]
        public void A_quaternion_should_be_multiplied_with_a_quaternion_correctly()
        {
            var firstQuaternion = new Quaternion(1, 2, 3, 4);
            var secondQuaternion = new Quaternion(-3, 5, 1, 8);
            var actual = firstQuaternion * secondQuaternion;
            Assert.AreEqual(actual[1], -48, 1E-08);
            Assert.AreEqual(actual[2], 19, 1E-08);
            Assert.AreEqual(actual[3], -4, 1E-08);
            Assert.AreEqual(actual[4], -17, 1E-08);
        }

        [TestMethod]
        public void Calculate_square_magnitude_of_a_quaternion()
        {
            var testQuaternion = new Quaternion(-4, 8, 1, 9);
            var actual = testQuaternion.SqrMagnitude();
            Assert.AreEqual(actual, 162, 1E-08);
        }

        [TestMethod]
        public void Calculate_magnitude_of_a_quaternion()
        {
            var testQuaternion = new Quaternion(-4, 8, 1, 9);
            var actual = testQuaternion.Magnitude();
            Assert.AreEqual(actual, 12.72792206135, 1E-10);
        }

        [TestMethod]
        public void Normalize_a_quaternion()
        {
            var testQuaternion = new Quaternion(-4, 8, 1, 9);
            testQuaternion.Normalize();
            Assert.AreEqual(testQuaternion.Q1, -0.31426968052, 1E-10);
            Assert.AreEqual(testQuaternion.Q2,  0.62853936105, 1E-10);
            Assert.AreEqual(testQuaternion.Q3,  0.07856742013, 1E-10);
            Assert.AreEqual(testQuaternion.Q4,  0.70710678118, 1E-10);
        }

        [TestMethod]
        public void Conjugate_a_quaternion()
        {
            var testQuaternion = new Quaternion(-4, 8, 1, 9);
            var actual = testQuaternion.Conjugate();
            Assert.AreEqual(actual.Q1, -4, 1E-10);
            Assert.AreEqual(actual.Q2, -8, 1E-10);
            Assert.AreEqual(actual.Q3, -1, 1E-10);
            Assert.AreEqual(actual.Q4, -9, 1E-10);
        }

        [TestMethod]
        public void Get_zero_quaternion()
        {
            var actual = Quaternion.Zero();
            Assert.AreEqual(actual.Q1, 0, 1E-10);
            Assert.AreEqual(actual.Q2, 0, 1E-10);
            Assert.AreEqual(actual.Q3, 0, 1E-10);
            Assert.AreEqual(actual.Q4, 0, 1E-10);
        }

        [TestMethod]
        public void Calculate_Qdot()
        {
            var expectedQ1 = -23 / Math.Sqrt(46);
            var expectedQ2 = -15 / Math.Sqrt(46);
            var expectedQ3 = 4 / Math.Sqrt(46);
            var expectedQ4 = 9 / Math.Sqrt(46);

            var testVector = new Vector3(-1, 8, 3);
            var testQuaternion = new Quaternion(2, 1, 4, 5);
            var actual = testQuaternion.GetQDot(testVector);
            Assert.AreEqual(actual.Q1, expectedQ1, 1E-10);
            Assert.AreEqual(actual.Q2, expectedQ2, 1E-10);
            Assert.AreEqual(actual.Q3, expectedQ3, 1E-10);
            Assert.AreEqual(actual.Q4, expectedQ4, 1E-10);
        }

        [TestMethod]
        public void Invert_a_quaternion()
        {
            var testQuaternion = new Quaternion(-4, 8, 1, 9);
            var actual = testQuaternion.Inverse();
            Assert.AreEqual(actual.Q1, -0.31426968052, 1E-10);
            Assert.AreEqual(actual.Q2, -0.62853936105, 1E-10);
            Assert.AreEqual(actual.Q3, -0.07856742013, 1E-10);
            Assert.AreEqual(actual.Q4, -0.70710678118, 1E-10);
        }
        [TestMethod]
        public void A_hashcode_should_be_returned()
        {
            const int expected = -2119088742;
            var testQuaternion = new Quaternion(42, 66, 23);
            var actual = testQuaternion.GetHashCode();
            Assert.AreEqual(actual, expected);
        }

        private double DegToRad(double degree)
        {
            return degree*Math.PI/180;
        }
    }
}