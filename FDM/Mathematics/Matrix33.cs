using System;
using System.IO;

namespace FDM.Mathematics
{
    // Note: This class is a first attempt to get the FDM running. The math classes should be 
    // replaced by a mathematics library like Math.Net
    public class Matrix33
    {
        public double A11 { get; set; }
        public double A12 { get; set; }
        public double A13 { get; set; }
        public double A21 { get; set; }
        public double A22 { get; set; }
        public double A23 { get; set; }
        public double A31 { get; set; }
        public double A32 { get; set; }
        public double A33 { get; set; }

        public Matrix33()
        {
            A11 = 0.0;
            A12 = 0.0;
            A13 = 0.0;
            A21 = 0.0;
            A22 = 0.0;
            A23 = 0.0;
            A31 = 0.0;
            A32 = 0.0;
            A33 = 0.0;
        }

        public Matrix33(double a11, double a12, double a13, double a21, double a22, double a23, double a31, double a32, double a33 )
        {
            A11 = a11;
            A12 = a12;
            A13 = a13;
            A21 = a21;
            A22 = a22;
            A23 = a23;
            A31 = a31;
            A32 = a32;
            A33 = a33;
        }

        public Matrix33(Matrix33 orig)
        {
            A11 = orig.A11;
            A12 = orig.A12;
            A13 = orig.A13;
            A21 = orig.A21;
            A22 = orig.A22;
            A23 = orig.A23;
            A31 = orig.A31;
            A32 = orig.A32;
            A33 = orig.A33;
        }

        public static Matrix33 Transpose(Matrix33 orig)
        {
            var transposedMatrix = new Matrix33(orig);
            transposedMatrix.Transpose();
            return transposedMatrix;
        }

        public void Transpose()
        {
            var x = A21;
            A21 = A12;
            A12 = x;

            x = A31;
            A31 = A13;
            A13 = x;

            x = A32;
            A32 = A23;
            A23 = x;
        }

        public double CalculateDeterminante()
        {
            var retVal = A11*A22*A33 + A12*A23*A31 + A13*A21*A32 - A13*A22*A31 - A12*A21*A33 - A11*A23*A32;
            return retVal;
        }

        public bool IsInvertible()
        {
            return Math.Abs(CalculateDeterminante() - 0) > EqualityTolerance;
        }

        public double this[int row, int column]
        {
            get
            {
                switch (row)
                {
                    case 1:
                        switch (column)
                        {
                            case 1:
                                return A11;
                            case 2:
                                return A12;
                            case 3:
                                return A13;
                        }
                        break;
                    case 2:
                        switch (column)
                        {
                            case 1:
                                return A21;
                            case 2:
                                return A22;
                            case 3:
                                return A23;
                        }
                        break;
                    case 3:
                        switch (column)
                        {
                            case 1:
                                return A31;
                            case 2:
                                return A32;
                            case 3:
                                return A33;
                        }
                        break;
                }
                return 42; // Fix me!
            }
            set
            {
                switch (row)
                {
                    case 1:
                        switch (column)
                        {
                            case 1:
                                A11 = value;
                                break;
                            case 2:
                                A12 = value;
                                break;
                            case 3:
                                A13 = value;
                                break;
                        }
                        break;
                    case 2:
                        switch (column)
                        {
                            case 1:
                                A21 = value;
                                break;
                            case 2:
                                A22 = value;
                                break;
                            case 3:
                                A23 = value;
                                break;
                        }
                        break;
                    case 3:
                        switch (column)
                        {
                            case 1:
                                A31 = value;
                                break;
                            case 2:
                                A32 = value;
                                break;
                            case 3:
                                A33 = value;
                                break;
                        }
                        break;
                }
            }
        }

        public Matrix33 CalculateInverse()
        {
            var det = CalculateDeterminante();
            if (Math.Abs(det - 0) < EqualityTolerance)
            {
                throw new InvalidDataException();
            }

            var revDet = 1/det;

            var a = revDet * (A22 * A33 - A23 * A32);
            var b = revDet * (A23 * A31 - A21 * A33);
            var c = revDet * (A21 * A32 - A22 * A31);
            var d = revDet * (A13 * A32 - A12 * A33);
            var e = revDet * (A11 * A33 - A13 * A31);
            var f = revDet * (A12 * A31 - A11 * A32);
            var g = revDet * (A12 * A23 - A13 * A22);
            var h = revDet * (A13 * A21 - A11 * A23);
            var i = revDet * (A11 * A22 - A12 * A21);

            var result = new Matrix33(a, d, g, b, e, h, c, f, i);
            return result;
        }

        public Vector3 MultiplyVectorByMatrix(Vector3 vector)
        {
            var a = vector.X * A11 + vector.Y * A21 + vector.Z * A31;
            var b = vector.X * A12 + vector.Y * A22 + vector.Z * A32;
            var c = vector.X * A13 + vector.Y * A23 + vector.Z * A33;
            var retVal = new Vector3(a, b, c);
            return retVal;
        }

        public Vector3 MultiplyMatrixByVector(Vector3 vector)
        {
            var a = vector.X * A11 + vector.Y * A12 + vector.Z * A13;
            var b = vector.X * A21 + vector.Y * A22 + vector.Z * A23;
            var c = vector.X * A31 + vector.Y * A32 + vector.Z * A33;
            var retVal = new Vector3(a, b, c);
            return retVal;
        }

        public Matrix33 MultiplyBy(double scalar)
        {
            var retVal = new Matrix33(A11*scalar, A12*scalar, A13*scalar,
                                      A21*scalar, A22*scalar, A23*scalar,
                                      A31*scalar, A32*scalar, A33*scalar);
            return retVal;
        }

        public static Matrix33 operator +(Matrix33 summand)
        {
            var retVal = new Matrix33(+summand.A11, +summand.A12, +summand.A13,
                                      +summand.A21, +summand.A22, +summand.A23,
                                      +summand.A31, +summand.A32, +summand.A33);
            return retVal;
        }

        public static Matrix33 operator -(Matrix33 subtrahend)
        {
            var retVal = new Matrix33(+subtrahend.A11, +subtrahend.A12, +subtrahend.A13,
                                      +subtrahend.A21, +subtrahend.A22, +subtrahend.A23,
                                      +subtrahend.A31, +subtrahend.A32, +subtrahend.A33);
            return retVal;
        }

        public Matrix33 MultiplyThisByOther(Matrix33 factor)
        {
            var a11 = A11*factor.A11 + A12*factor.A21 + A13*factor.A31;
            var a12 = A11*factor.A12 + A12*factor.A22 + A13*factor.A32;
            var a13 = A11*factor.A13 + A12*factor.A23 + A13*factor.A33;
            var a21 = A21*factor.A11 + A22*factor.A21 + A23*factor.A31;
            var a22 = A21*factor.A12 + A22*factor.A22 + A23*factor.A32;
            var a23 = A21*factor.A13 + A22*factor.A23 + A23*factor.A33;
            var a31 = A31*factor.A11 + A32*factor.A21 + A33*factor.A31;
            var a32 = A31*factor.A12 + A32*factor.A22 + A33*factor.A32;
            var a33 = A31*factor.A13 + A32*factor.A23 + A33*factor.A33;
            var retVal = new Matrix33(a11, a12, a13, a21, a22, a23, a31, a32, a33);
            return retVal;
        }

        public Matrix33 MultiplyOtherByThis(Matrix33 factor)
        {
            var a11 = factor.A11 * A11 + factor.A12 * A21 + factor.A13 * A31;
            var a12 = factor.A11 * A12 + factor.A12 * A22 + factor.A13 * A32;
            var a13 = factor.A11 * A13 + factor.A12 * A23 + factor.A13 * A33;
            var a21 = factor.A21 * A11 + factor.A22 * A21 + factor.A23 * A31;
            var a22 = factor.A21 * A12 + factor.A22 * A22 + factor.A23 * A32;
            var a23 = factor.A21 * A13 + factor.A22 * A23 + factor.A23 * A33;
            var a31 = factor.A31 * A11 + factor.A32 * A21 + factor.A33 * A31;
            var a32 = factor.A31 * A12 + factor.A32 * A22 + factor.A13 * A32;
            var a33 = factor.A31 * A13 + factor.A32 * A23 + factor.A33 * A33;
            var retVal = new Matrix33(a11, a12, a13, a21, a22, a23, a31, a32, a33);
            return retVal;
        }

        public const double EqualityTolerance = Double.Epsilon;
    }
}




