using System;
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

        [TestMethod]
        public void Matrix_is_invertible()
        {
            var testMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            var actual = testMatrix.IsInvertible();

            Assert.AreEqual(actual, true);
        }


        [TestMethod]
        public void Matrix_is_not_invertible()
        {
            var testMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          0.0, 0.0, 0.0);

            var actual = testMatrix.IsInvertible();

            Assert.AreEqual(actual, false);
        }

        [TestMethod]
        public void Read_access_matrix_by_index()
        {
            var testMatrix = new Matrix33(1.0, -2.0, -3.0,
                                          4.6, 3.2, -1.2,
                                          -0.9, 8.1, 3.4);

            var a11 = testMatrix[1, 1];
            var a12 = testMatrix[1, 2];
            var a13 = testMatrix[1, 3];

            var a21 = testMatrix[2, 1];
            var a22 = testMatrix[2, 2];
            var a23 = testMatrix[2, 3];

            var a31 = testMatrix[3, 1];
            var a32 = testMatrix[3, 2];
            var a33 = testMatrix[3, 3];

            Assert.AreEqual(a11, 1.0);
            Assert.AreEqual(a12, -2.0);
            Assert.AreEqual(a13, -3.0);

            Assert.AreEqual(a21, 4.6);
            Assert.AreEqual(a22, 3.2);
            Assert.AreEqual(a23, -1.2);

            Assert.AreEqual(a31, -0.9);
            Assert.AreEqual(a32, 8.1);
            Assert.AreEqual(a33, 3.4);
        }


        [TestMethod]
        public void Write_access_matrix_by_index()
        {
            var testMatrix = new Matrix33();

            testMatrix[1, 1] = 1.3;
            testMatrix[1, 2] = 3.0;
            testMatrix[1, 3] = 5.4;

            testMatrix[2, 1] = -9.8;
            testMatrix[2, 2] = -42.1;
            testMatrix[2, 3] = 4.9;

            testMatrix[3, 1] = 7.9;
            testMatrix[3, 2] = 1.2;
            testMatrix[3, 3] = 4.2;

            Assert.AreEqual(testMatrix.A11, 1.3);
            Assert.AreEqual(testMatrix.A12, 3.0);
            Assert.AreEqual(testMatrix.A13, 5.4);

            Assert.AreEqual(testMatrix.A21, -9.8);
            Assert.AreEqual(testMatrix.A22, -42.1);
            Assert.AreEqual(testMatrix.A23, 4.9);

            Assert.AreEqual(testMatrix.A31, 7.9);
            Assert.AreEqual(testMatrix.A32, 1.2);
            Assert.AreEqual(testMatrix.A33, 4.2);
        }

        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_read_access_to_matrix_element_1()
        {
            var testMatrix = new Matrix33();
            testMatrix[1, 1] = testMatrix[1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_read_access_to_matrix_element_2()
        {
            var testMatrix = new Matrix33();
            testMatrix[1, 1] = testMatrix[2, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_read_access_to_matrix_element_3()
        {
            var testMatrix = new Matrix33();
            testMatrix[1, 1] = testMatrix[3, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_read_access_to_matrix_element_4()
        {
            var testMatrix = new Matrix33();
            testMatrix[1, 1] = testMatrix[4, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_write_access_to_matrix_element_1()
        {
            var testMatrix = new Matrix33();
            testMatrix[1, 0] = testMatrix[1, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_write_access_to_matrix_element_2()
        {
            var testMatrix = new Matrix33();
            testMatrix[2, 0] = testMatrix[1, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_write_access_to_matrix_element_3()
        {
            var testMatrix = new Matrix33();
            testMatrix[3, 0] = testMatrix[1, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
            "The index of a matrix column must be between 1 and 3")]
        public void Invalid_write_access_to_matrix_element_4()
        {
            var testMatrix = new Matrix33();
            testMatrix[4, 1] = testMatrix[1, 1];
        }

        [TestMethod]
        public void Inverse_matrix_should_be_calculated_properly()
        {
            var testMatrix = new Matrix33(3, 2, 6,
                                          1, 1, 3,
                                          -3, -2, -5);

            var actual = testMatrix.CalculateInverse();

            Assert.AreEqual(actual.A11, 1, 1E-08);
            Assert.AreEqual(actual.A12, -2, 1E-08);
            Assert.AreEqual(actual.A13, 0, 1E-08);
            Assert.AreEqual(actual.A21, -4, 1E-08);
            Assert.AreEqual(actual.A22, 3, 1E-08);
            Assert.AreEqual(actual.A23, -3, 1E-08);
            Assert.AreEqual(actual.A31, 1, 1E-08);
            Assert.AreEqual(actual.A32, 0, 1E-08);
            Assert.AreEqual(actual.A33, 1, 1E-08);
        }

    }
}