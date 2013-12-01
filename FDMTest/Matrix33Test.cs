using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDM.Mathematics;

namespace FDMTest
{
    [TestClass]
    public class Matrix33Test
    {
        [TestMethod]
        public void A_zero_matrix_should_be_created()
        {
            var testMatrix = new Matrix33();
            Assert.AreEqual(testMatrix.A11, 0.0);
            Assert.AreEqual(testMatrix.A12, 0.0);
            Assert.AreEqual(testMatrix.A13, 0.0);
            Assert.AreEqual(testMatrix.A21, 0.0);
            Assert.AreEqual(testMatrix.A22, 0.0);
            Assert.AreEqual(testMatrix.A23, 0.0);
            Assert.AreEqual(testMatrix.A31, 0.0);
            Assert.AreEqual(testMatrix.A32, 0.0);
            Assert.AreEqual(testMatrix.A33, 0.0);
        }

        [TestMethod]
        public void A_filled_matrix_should_be_created()
        {
            var testMatrix = new Matrix33(1.0, -2.0, -3.0, 
                                          4.6,  3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            Assert.AreEqual(testMatrix.A11, 1.0);
            Assert.AreEqual(testMatrix.A12, -2.0);
            Assert.AreEqual(testMatrix.A13, -3.0);
            Assert.AreEqual(testMatrix.A21, 4.6);
            Assert.AreEqual(testMatrix.A22, 3.2);
            Assert.AreEqual(testMatrix.A23, -1.2);
            Assert.AreEqual(testMatrix.A31, -0.9);
            Assert.AreEqual(testMatrix.A32, 8.1);
            Assert.AreEqual(testMatrix.A33, 3.4);
        }


        [TestMethod]
        public void A_new_matrix_should_be_created_from_another_one()
        {
            var copyMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            var testMatrix = new Matrix33(copyMatrix);
            Assert.AreEqual(testMatrix.A11, 1.0);
            Assert.AreEqual(testMatrix.A12, -2.0);
            Assert.AreEqual(testMatrix.A13, -3.0);
            Assert.AreEqual(testMatrix.A21, 4.6);
            Assert.AreEqual(testMatrix.A22, 3.2);
            Assert.AreEqual(testMatrix.A23, -1.2);
            Assert.AreEqual(testMatrix.A31, -0.9);
            Assert.AreEqual(testMatrix.A32, 8.1);
            Assert.AreEqual(testMatrix.A33, 3.4);
        }

        [TestMethod]
        public void The_given_matrix_should_be_transposed()
        {
            var origMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            var actual = Matrix33.Transpose(origMatrix);

            Assert.AreEqual(actual.A11, 1.0);
            Assert.AreEqual(actual.A12, 4.6);
            Assert.AreEqual(actual.A13, -0.9);
            Assert.AreEqual(actual.A21, -2.0);
            Assert.AreEqual(actual.A22, 3.2);
            Assert.AreEqual(actual.A23, 8.1);
            Assert.AreEqual(actual.A31, -3.0);
            Assert.AreEqual(actual.A32, -1.2);
            Assert.AreEqual(actual.A33, 3.4);
        }

        [TestMethod]
        public void The_current_matrix_should_be_transposed()
        {
            var actual = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            actual.Transpose();

            Assert.AreEqual(actual.A11, 1.0);
            Assert.AreEqual(actual.A12, 4.6);
            Assert.AreEqual(actual.A13, -0.9);
            Assert.AreEqual(actual.A21, -2.0);
            Assert.AreEqual(actual.A22, 3.2);
            Assert.AreEqual(actual.A23, 8.1);
            Assert.AreEqual(actual.A31, -3.0);
            Assert.AreEqual(actual.A32, -1.2);
            Assert.AreEqual(actual.A33, 3.4);
        }

        [TestMethod]
        public void Calculate_determinante_of_given_matrix()
        {
            const double expected = -70.7;

            var testMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            var actual = testMatrix.CalculateDeterminante();

            Assert.AreEqual(actual, expected, 1E-08);
        }
    }
}