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
    }
}
