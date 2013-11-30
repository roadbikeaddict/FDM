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
    }
}
