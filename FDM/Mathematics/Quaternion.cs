using System;


/**  Models the Quaternion representation of rotations.
    FGQuaternion is a representation of an arbitrary rotation through a
    quaternion. It has vector properties. This class also contains access
    functions to the euler angle representation of rotations and access to
    transformation matrices for 3D vectors. Transformations and euler angles are
    therefore computed once they are requested for the first time. Then they are
    cached for later usage as long as the class is not accessed trough
    a nonconst member function.

    Note: The order of rotations used in this class corresponds to a 3-2-1 sequence,
    or Y-P-R, or Z-Y-X, if you prefer.


*/

namespace FDM.Mathematics
{
    public class Quaternion
    {
        public double Q1 { get; set; }
        public double Q2 { get; set; }
        public double Q3 { get; set; }
        public double Q4 { get; set; }

        // Indexer to easily access the data elements. ATTENTION: We start counting with 1!
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return Q1;
                    case 2:
                        return Q2;
                    case 3:
                        return Q3;
                    case 4:
                        return Q4;
                    default:
                        throw new IndexOutOfRangeException("The index of a quaternion element must be between 1 and 4");
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        Q1 = value;
                        break;
                    case 2:
                        Q2 = value;
                        break;
                    case 3:
                        Q3 = value;
                        break;
                    case 4:
                        Q4 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("The index of a quaternion element must be between 1 and 4");
                }
            }
        }

        public Quaternion()
        {
            Q1 = 1.0;
            Q2 = 0.0;
            Q3 = 0.0;
            Q4 = 0.0;
        }


        public Quaternion(double q1, double q2, double q3, double q4)
        {
            Q1 = q1;
            Q2 = q2;
            Q3 = q3;
            Q4 = q4;
        }

        public Quaternion(double phi, double theta, double psi)
        {
            Q1 = Math.Cos(0.5 * phi) * Math.Cos(0.5 * theta) * Math.Cos(0.5 * psi) + Math.Sin(0.5 * phi) * Math.Sin(0.5 * theta) * Math.Sin(0.5 * psi);
            Q2 = Math.Sin(0.5 * phi) * Math.Cos(0.5 * theta) * Math.Cos(0.5 * psi) - Math.Cos(0.5 * phi) * Math.Sin(0.5 * theta) * Math.Sin(0.5 * psi);
            Q3 = Math.Cos(0.5 * phi) * Math.Sin(0.5 * theta) * Math.Cos(0.5 * psi) + Math.Sin(0.5 * phi) * Math.Cos(0.5 * theta) * Math.Sin(0.5 * psi);
            Q4 = Math.Cos(0.5 * phi) * Math.Cos(0.5 * theta) * Math.Sin(0.5 * psi) - Math.Sin(0.5 * phi) * Math.Sin(0.5 * theta) * Math.Cos(0.5 * psi);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Quaternion) obj);
        }

        protected bool Equals(Quaternion other)
        {
            return Q1.Equals(other.Q1) && Q2.Equals(other.Q2) && Q3.Equals(other.Q3) && Q4.Equals(other.Q4);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Q1.GetHashCode();
                hashCode = (hashCode*397) ^ Q2.GetHashCode();
                hashCode = (hashCode*397) ^ Q3.GetHashCode();
                hashCode = (hashCode*397) ^ Q4.GetHashCode();
                return hashCode;
            }
        }

        /** Initializer by one euler angle.
        Initialize the quaternion with the single euler angle where its index
        is given in the first argument.
        @param idx Index of the euler angle to initialize
        @param angle The euler angle in radians  */

        public Quaternion(EulerAngles index, double angle)
        {
            var sinAngle2 = Math.Sin(0.5 * angle);
            var cosAngle2 = Math.Cos(0.5 * angle);

            if (index == EulerAngles.ePhi)
            {
                Q1 = cosAngle2;
                Q2 = sinAngle2;
                Q3 = 0.0;
                Q4 = 0.0;
            }
            else
            {
                if (index == EulerAngles.eTht)
                {
                    Q1 = cosAngle2;
                    Q2 = 0.0;
                    Q3 = sinAngle2;
                    Q4 = 0.0;

                }
                else
                {
                    Q1 = cosAngle2;
                    Q2 = 0.0;
                    Q3 = 0.0;
                    Q4 = sinAngle2;
                }
            }
        }

        /** Quaternion derivative for given angular rates.
        Computes the quaternion derivative which results from the given
        angular velocities
        @param PQR a constant reference to the body rate vector
        @return the quaternion derivative
        @see Stevens and Lewis, "Aircraft Control and Simulation", Second Edition,
           Equation 1.3-36. */

        public Quaternion GetQDot(Vector3 pqr)
        {
            var norm = Magnitude();
            if (Math.Abs(norm) < EqualityTolerance)
            {
                return Zero();
            }
            var rnorm = 1.0/norm;

            var qDot = new Quaternion();
            qDot[1] = -0.5*(Q2*pqr[(int) Rates.eP] + Q3*pqr[(int) Rates.eQ] + Q4*pqr[(int) Rates.eR]);
            qDot[2] = 0.5*(Q1*pqr[(int) Rates.eP] + Q3*pqr[(int) Rates.eR] - Q4*pqr[(int) Rates.eQ]);
            qDot[3] = 0.5*(Q1*pqr[(int) Rates.eQ] + Q4*pqr[(int) Rates.eP] - Q2*pqr[(int) Rates.eR]);
            qDot[4] = 0.5*(Q1*pqr[(int) Rates.eR] + Q2*pqr[(int) Rates.eQ] - Q3*pqr[(int) Rates.eP]);
            return rnorm*qDot;
        }

        /** Transformation matrix.
        @return a reference to the transformation/rotation matrix
        corresponding to this quaternion rotation.  */

        private Matrix33 GetT()
        {
            ComputeDerived();
            return mT;
        }

        /** Backward transformation matrix.
        @return a reference to the inverse transformation/rotation matrix
        corresponding to this quaternion rotation.  */

        private Matrix33 GetTInv()
        {
            ComputeDerived();
            return mTInv;
        }

        /** Retrieves the Euler angles.
        @return a reference to the triad of euler angles corresponding
        to this quaternion rotation.
        units radians  */

        private Vector3 GetEuler()
        {
            ComputeDerived();
            return mEulerAngles;
        }

        /** Retrieves the Euler angles.
        @param i the euler angle index.
        units radians.
        @return a reference to the i-th euler angles corresponding
        to this quaternion rotation.
        */

        private double GetEuler(int i)
        {
            ComputeDerived();
            return mEulerAngles[i];
        }

        /** Retrieves the Euler angles.
        @param i the euler angle index.
        @return a reference to the i-th euler angles corresponding
        to this quaternion rotation.
        units degrees */

        private double GetEulerDeg(int i)
        {
            ComputeDerived();
            return FdmConstants.RadToDeg*mEulerAngles[i];
        }

        /** Retrieves sine of the given euler angle.
        @return the sine of the Euler angle theta (pitch attitude) corresponding
        to this quaternion rotation.  */

        private double GetSinEuler(int i)
        {
            ComputeDerived();
            return mEulerSines[i];
        }

        /** Retrieves cosine of the given euler angle.
        @return the sine of the Euler angle theta (pitch attitude) corresponding
        to this quaternion rotation.  */

        private double GetCosEuler(int i)
        {
            ComputeDerived();
            return mEulerCosines[i];
        }

        public static bool operator ==(Quaternion first, Quaternion second)
        {
            var result = (Math.Abs(first[1] - second[1]) < EqualityTolerance)
                         && (Math.Abs(first[2] - second[2]) < EqualityTolerance)
                         && (Math.Abs(first[3] - second[3]) < EqualityTolerance)
                         && (Math.Abs(first[4] - second[4]) < EqualityTolerance);
            return result;
        }

        public static bool operator !=(Quaternion first, Quaternion second)
        {
            var result = !(first == second);
            return result;
        }

        public const double EqualityTolerance = Double.Epsilon;

        public static Quaternion operator +(Quaternion first, Quaternion second)
        {
            var result = new Quaternion
                (
                first[1] + second[1],
                first[2] + second[2],
                first[3] + second[3],
                first[4] + second[4]
                );
            return result;
        }

        public static Quaternion operator -(Quaternion first, Quaternion second)
        {
            var result = new Quaternion
                (
                first[1] - second[1],
                first[2] - second[2],
                first[3] - second[3],
                first[4] - second[4]
                );
            return result;
        }

        public static Quaternion operator *(Quaternion first, double scalar)
        {
            var result = new Quaternion
                (
                first[1]*scalar,
                first[2]*scalar,
                first[3]*scalar,
                first[4]*scalar
                );
            return result;
        }

        public static Quaternion operator *(double scalar, Quaternion q)
        {
            return q*scalar;
        }

        public static Quaternion operator /(Quaternion first, double scalar)
        {
            var result = new Quaternion
                (
                first[1]/scalar,
                first[2]/scalar,
                first[3]/scalar,
                first[4]/scalar
                );
            return result;
        }

        public static Quaternion operator *(Quaternion first, Quaternion second)
        {
            var result = new Quaternion
                (
                first.Q1*second.Q1 - first.Q2*second.Q2 - first.Q3*second.Q3 - first.Q4*second.Q4,
                first.Q1*second.Q2 + first.Q2*second.Q1 + first.Q3*second.Q4 - first.Q4*second.Q3,
                first.Q1*second.Q3 - first.Q2*second.Q4 + first.Q3*second.Q1 + first.Q4*second.Q2,
                first.Q1*second.Q4 + first.Q2*second.Q3 - first.Q3*second.Q2 + first.Q4*second.Q1
                );
            return result;
        }

        public void Normalize()
        {
            var norm = Magnitude();
            if (Math.Abs(norm) < EqualityTolerance)
            {
                return;
            }

            var rnorm = 1.0/norm;
            Q1 *= rnorm;
            Q2 *= rnorm;
            Q3 *= rnorm;
            Q4 *= rnorm;
        }

        /** Inverse of the quaternion.

      Compute and return the inverse of the quaternion so that the orientation
      represented with *this multiplied with the returned value is equal to
      the identity orientation.
  */

        public Quaternion Inverse()
        {
            var norm = Magnitude();
            if (Math.Abs(norm) < EqualityTolerance)
            {
                throw new ArgumentException("Magnitude of given quaternion is 0");
            }
            var rNorm = 1.0/norm;
            return new Quaternion(Q1*rNorm, -Q2*rNorm, -Q3*rNorm, -Q4*rNorm);
        }

        /** Conjugate of the quaternion.

      Compute and return the conjugate of the quaternion. This one is equal
      to the inverse iff the quaternion is normalized.
  */

        public Quaternion Conjugate()
        {
            return new Quaternion(Q1, -Q2, -Q3, -Q4);
        }



        /** Length of the vector.

      Compute and return the euclidean norm of this vector.
  */

        public double Magnitude()
        {
            return Math.Sqrt(SqrMagnitude());
        }

        /** Square of the length of the vector.

        Compute and return the square of the euclidean norm of this vector.
        */

        public double SqrMagnitude()
        {
            return Q1*Q1 + Q2*Q2 + Q3*Q3 + Q4*Q4;
        }


        /** Zero quaternion vector. Does not represent any orientation.
      Useful for initialization of increments */

        public static Quaternion Zero()
        {
            return new Quaternion(0.0, 0.0, 0.0, 0.0);
        }



        /** Computation of derived values.
      This function checks if the derived values like euler angles and
      transformation matrices are already computed. If so, it
      returns. If they need to be computed the real worker routine
      \ref FGQuaternion::ComputeDerivedUnconditional(void) const
      is called.
      This function is inlined to avoid function calls in the fast path. */

        private void ComputeDerived()
        {

            ComputeDerivedUnconditional();
        }



        /** This stores the transformation matrices.  */
        private Matrix33 mT;
        private Matrix33 mTInv;

        /** The cached euler angles.  */
        private Vector3 mEulerAngles;

        /** The cached sines and cosines of the euler angles.  */
        private Vector3 mEulerSines;
        private Vector3 mEulerCosines;



        // Compute the derived values if required ...
        private void ComputeDerivedUnconditional()
        {


            // First normalize the 4-vector
            double norm = Magnitude();
            if (Math.Abs(norm) < EqualityTolerance)
            {
                return;
            }
            double rnorm = 1.0/norm;
            double q1 = rnorm*Q1;
            double q2 = rnorm*Q2;
            double q3 = rnorm*Q3;
            double q4 = rnorm*Q4;

            // Now compute the transformation matrix.
            double q1Q1 = q1*q1;
            double q2Q2 = q2*q2;
            double q3Q3 = q3*q3;
            double q4Q4 = q4*q4;
            double q1Q2 = q1*q2;
            double q1Q3 = q1*q3;
            double q1Q4 = q1*q4;
            double q2Q3 = q2*q3;
            double q2Q4 = q2*q4;
            double q3Q4 = q3*q4;

            mT[1, 1] = q1Q1 + q2Q2 - q3Q3 - q4Q4;
            mT[1, 2] = 2.0*(q2Q3 + q1Q4);
            mT[1, 3] = 2.0*(q2Q4 - q1Q3);
            mT[2, 1] = 2.0*(q2Q3 - q1Q4);
            mT[2, 2] = q1Q1 - q2Q2 + q3Q3 - q4Q4;
            mT[2, 3] = 2.0*(q3Q4 + q1Q2);
            mT[3, 1] = 2.0*(q2Q4 + q1Q3);
            mT[3, 2] = 2.0*(q3Q4 - q1Q2);
            mT[3, 3] = q1Q1 - q2Q2 - q3Q3 + q4Q4;
            // Since this is an orthogonal matrix, the inverse is simply
            // the transpose.
            mTInv = mT;
            mTInv.Transpose();

            // Compute the Euler-angles
            if (Math.Abs(mT[3, 3]) < EqualityTolerance)
                mEulerAngles[(int) EulerAngles.ePhi] = 0.5*Math.PI;
            else
                mEulerAngles[(int) EulerAngles.ePhi] = Math.Atan2(mT[2, 3], mT[3, 3]);

            if (mT[1, 3] < -1.0)
                mEulerAngles[(int) EulerAngles.eTht] = 0.5*Math.PI;
            else if (1.0 < mT[1, 3])
                mEulerAngles[(int) EulerAngles.eTht] = -0.5*Math.PI;
            else
                mEulerAngles[(int) EulerAngles.eTht] = Math.Asin(-mT[1, 3]);

            if (Math.Abs(mT[1, 1]) < EqualityTolerance)
                mEulerAngles[(int) EulerAngles.ePsi] = 0.5*Math.PI;
            else
            {
                double psi = Math.Atan2(mT[1, 2], mT[1, 1]);
                if (psi < 0.0)
                    psi += 2*Math.PI;
                mEulerAngles[(int) EulerAngles.ePsi] = psi;
            }

            // FIXME: may be one can compute those values easier ???
            mEulerSines[(int) EulerAngles.ePhi] = Math.Sin(mEulerAngles[(int) EulerAngles.ePhi]);
            // mEulerSines(eTht) = sin(mEulerAngles(eTht));
            mEulerSines[(int) EulerAngles.eTht] = -mT[1, 3];
            mEulerSines[(int) EulerAngles.ePsi] = Math.Sin(mEulerAngles[(int) EulerAngles.ePsi]);
            mEulerCosines[(int) EulerAngles.ePhi] = Math.Cos(mEulerAngles[(int) EulerAngles.ePhi]);
            mEulerCosines[(int) EulerAngles.eTht] = Math.Cos(mEulerAngles[(int) EulerAngles.eTht]);
            mEulerCosines[(int) EulerAngles.ePsi] = Math.Cos(mEulerAngles[(int) EulerAngles.ePsi]);
        }
    }
}

