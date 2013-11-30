using System;

namespace FDM.Mathematics
{
    public class Quaternion
    {
        private double[] mData = new double[4];

        private Vector3 mEulerAngles;

        /// <summary>
        /// Initializes with the identity rotation
        /// </summary>
        public Quaternion()
        {
            mData[0] = 1;
            mData[1] = 0;
            mData[2] = 0;
            mData[3] = 0;
        }
 
        // Copy constructor
        public Quaternion(Quaternion other)
        {
            mData[0] = other.mData[0];
            mData[1] = other.mData[1];
            mData[2] = other.mData[2];
            mData[3] = other.mData[3];
        }

         /** Initializer by euler angles.
      Initialize the quaternion with the euler angles.
      @param phi The euler X axis (roll) angle in radians
      @param tht The euler Y axis (attitude) angle in radians
      @param psi The euler Z axis (heading) angle in radians  */
        public Quaternion(double phi, double theta, double psi)
        {
            var thtd2 = 0.5 * theta;
            var psid2 = 0.5 * psi;
            var phid2 = 0.5 * phi;
  
            var Sthtd2 = Math.Sin(thtd2);
            var Spsid2 = Math.Sin(psid2);
            var Sphid2 = Math.Sin(phid2);
  
            var Cthtd2 = Math.Cos(thtd2);
            var Cpsid2 = Math.Cos(psid2);
            var Cphid2 = Math.Cos(phid2);
  
            var Cphid2Cthtd2 = Cphid2*Cthtd2;
            var Cphid2Sthtd2 = Cphid2*Sthtd2;
            var Sphid2Sthtd2 = Sphid2*Sthtd2;
            var Sphid2Cthtd2 = Sphid2*Cthtd2;
  
            mData[0] = Cphid2Cthtd2*Cpsid2 + Sphid2Sthtd2*Spsid2;
            mData[1] = Sphid2Cthtd2*Cpsid2 - Cphid2Sthtd2*Spsid2;
            mData[2] = Cphid2Sthtd2*Cpsid2 + Sphid2Cthtd2*Spsid2;
            mData[3] = Cphid2Cthtd2*Spsid2 - Sphid2Sthtd2*Cpsid2;
        }

        // Indexer to easily access the data elements. ATTENTION: We start counting with 1
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return mData[0];
                    case 2:
                        return mData[1];
                    case 3:
                        return mData[2];
                    case 4:
                        return mData[3];
                    default:
                        return 42;  // Fix that!
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        mData[0] = value;
                        break;
                    case 2:
                        mData[1] = value;
                        break;
                    case 3:
                        mData[2] = value;
                        break;
                    case 4:
                        mData[3] = value;
                        break;
                }
            }
        }
 
  /** Initializer by one euler angle.
      Initialize the quaternion with the single euler angle where its index
      is given in the first argument.
      @param idx Index of the euler angle to initialize
      @param angle The euler angle in radians  */
        public Quaternion(int idx, double angle)
        {
            var angle2 = 0.5*angle;

            var Sangle2 = Math.Sin(angle2);
            var Cangle2 = Math.Cos(angle2);

            if (idx == 1)
            {
                mData[0] = Cangle2;
                mData[1] = Sangle2;
                mData[2] = 0.0;
                mData[3] = 0.0;
            }
            else
            {
                if (idx == 2)
                {
                    mData[0] = Cangle2;
                    mData[1] = 0.0;
                    mData[2] = Sangle2;
                    mData[3] = 0.0;

                }
                else
                {
                    mData[0] = Cangle2;
                    mData[1] = 0.0;
                    mData[2] = 0.0;
                    mData[3] = Sangle2;
                }
            }
        }


        // Compute and return the euclidean norm of this vector.
        public double Magnitude() 
        {
            return Math.Sqrt(SqrMagnitude());
        }

  /** Square of the length of the vector.

      Compute and return the square of the euclidean norm of this vector.
  */
        public double SqrMagnitude()
        {
            return mData[0] * mData[0] + mData[1] * mData[1] + mData[2] * mData[2] + mData[3] * mData[3];
        }

        void Normalize()
        {
            // Note: this does not touch the cache
            // since it does not change the orientation ...
  
            double norm = Magnitude();
            if (norm == 0.0)
                return;
  
            double rnorm = 1.0/norm;
            mData[0] *= rnorm;
            mData[1] *= rnorm;
            mData[2] *= rnorm;
            mData[3] *= rnorm;
        }
        /** Returns the derivative of the quaternion corresponding to the
    angular velocities PQR.
    See Stevens and Lewis, "Aircraft Control and Simulation", Second Edition,
    Equation 1.3-36. 
           Quaternion derivative for given angular rates.
      Computes the quaternion derivative which results from the given
      angular velocities
      @param PQR a constant reference to the body rate vector
      @return the quaternion derivative
      @see Stevens and Lewis, "Aircraft Control and Simulation", Second Edition,
           Equation 1.3-36. 
*/
        public Quaternion GetQDot(Vector3 PQR)
        {
            double norm = Magnitude();
            if (norm == 0.0)
                return Zero();
            double rnorm = 1.0/norm;

            Quaternion QDot = new Quaternion();
            QDot[1] = -0.5*(this[2]*PQR[1] + this[3]*PQR[2] + this[4]*PQR[3]);
            QDot[2] =  0.5*(this[1]*PQR[1] + this[3]*PQR[3] - this[4]*PQR[2]);
            QDot[3] =  0.5*(this[1]*PQR[2] + this[4]*PQR[1] - this[2]*PQR[3]);
            QDot[4] =  0.5*(this[1]*PQR[3] + this[2]*PQR[2] - this[3]*PQR[1]);
            return rnorm*QDot;
        }

        /** Scalar multiplication.

    @param scalar scalar value to multiply with.
    @param q Vector to multiply.

    Multiply the Vector with a scalar value.
*/
        public static Quaternion operator *(double scalar, Quaternion q)
        {
            return new Quaternion(scalar * q[1], scalar * q[2], scalar * q[3], scalar * q[4]);
        }
  

  /** Transformation matrix.
      @return a reference to the transformation/rotation matrix
      corresponding to this quaternion rotation.  */
    public Matrix33 GetT()
    {
        ComputeDerived(); 
        return mT;
    }

  /** Backward transformation matrix.
      @return a reference to the inverse transformation/rotation matrix
      corresponding to this quaternion rotation.  */
  public Matrix33 GetTInv()
  {
      ComputeDerived(); 
      return mTInv;
  }

  /** Retrieves the Euler angles.
      @return a reference to the triad of euler angles corresponding
      to this quaternion rotation.
      units radians  */
  public Vector3 GetEuler()
  {
    ComputeDerived();
    return mEulerAngles;
  }

    // Compute the derived values
    public void ComputeDerived()
    {
        // First normalize the 4-vector
        double norm = Magnitude();
        if (norm == 0.0)
            return;

        double rnorm = 1.0/norm;
        double q1 = rnorm * mData[0];
        double q2 = rnorm * mData[1];
        double q3 = rnorm * mData[2];
        double q4 = rnorm * mData[3];

        // Now compute the transformation matrix.
        double q1q1 = q1*q1;
        double q2q2 = q2*q2;
        double q3q3 = q3*q3;
        double q4q4 = q4*q4;
        double q1q2 = q1*q2;
        double q1q3 = q1*q3;
        double q1q4 = q1*q4;
        double q2q3 = q2*q3;
        double q2q4 = q2*q4;
        double q3q4 = q3*q4;
  
  mT[1,1] = q1q1 + q2q2 - q3q3 - q4q4;
  mT[1,2] = 2.0*(q2q3 + q1q4);
  mT[1,3] = 2.0*(q2q4 - q1q3);
  mT[2,1] = 2.0*(q2q3 - q1q4);
  mT[2,2] = q1q1 - q2q2 + q3q3 - q4q4;
  mT[2,3] = 2.0*(q3q4 + q1q2);
  mT[3,1] = 2.0*(q2q4 + q1q3);
  mT[3,2] = 2.0*(q3q4 - q1q2);
  mT[3,3] = q1q1 - q2q2 - q3q3 + q4q4;
  // Since this is an orthogonal matrix, the inverse is simply
  // the transpose.
  mTInv = mT;
        mTInv.Transpose();
  
  // Compute the Euler-angles
  if (mT[3,3] == 0.0)
    mEulerAngles[1] = 0.5 * Math.PI;
  else
    mEulerAngles[1] = Math.Atan2(mT[2,3], mT[3,3]);
  
  if (mT[1,3] < -1.0)
    mEulerAngles[2] = 0.5*Math.PI;
  else if (1.0 < mT[1,3])
    mEulerAngles[2] = -0.5*Math.PI;
  else
    mEulerAngles[2] = Math.Asin(-mT[1,3]);
  
  if (mT[1,1] == 0.0)
    mEulerAngles[3] = 0.5*Math.PI;
  else {
    double psi = Math.Atan2(mT[1,2], mT[1,1]);
    if (psi < 0.0)
      psi += 2*Math.PI;
    mEulerAngles[3] = psi;
  }
  
  // FIXME: may be one can compute those values easier ???
  mEulerSines[1] = Math.Sin(mEulerAngles[1]);
  // mEulerSines(eTht) = sin(mEulerAngles(eTht));
  mEulerSines[2] = -mT[1,3];
  mEulerSines[3] = Math.Sin(mEulerAngles[3]);
  mEulerCosines[1] = Math.Cos(mEulerAngles[1]);
  mEulerCosines[2] = Math.Cos(mEulerAngles[2]);
  mEulerCosines[3] = Math.Cos(mEulerAngles[3]);
}
  /** Retrieves the Euler angles.
      @param i the euler angle index.
      units radians.
      @return a reference to the i-th euler angles corresponding
      to this quaternion rotation.
   */
  double GetEuler(int i)
  {
    ComputeDerived();
    return mEulerAngles[i];
  }

  /** Retrieves the Euler angles.
      @param i the euler angle index.
      @return a reference to the i-th euler angles corresponding
      to this quaternion rotation.
      units degrees */
  double GetEulerDeg(int i) 
  {
    ComputeDerived();
    return (Math.PI / 180) * mEulerAngles[i];
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
        double GetCosEuler(int i) 
        {
            ComputeDerived();
            return mEulerCosines[i];
        }

 
 

  /** Comparison operator "==".
      @param q a quaternion reference
      @return true if both quaternions represent the same rotation.  */
  public static bool operator ==(Quaternion p, Quaternion q)
  {
      return p[1] == q[1] && p[2] == q[2] && p[3] == q[3] && p[4] == q[4];
  }
 
  /** Comparison operator "==".
      @param q a quaternion reference
      @return true if both quaternions represent the same rotation.  */
  public static bool operator !=(Quaternion p, Quaternion q)
  {
      return !(p == q);
  }
  
 
  
/** Arithmetic operator "+".
      @param q a quaternion to be summed.
      @return a quaternion representing Q, where Q = Q + q. */
     public static Quaternion operator +(Quaternion p, Quaternion q)
     {
         return new Quaternion(p[1] + q[1], p[2] + q[2], p[3] + q[3], p[4] + q[4]);
     }
  /** Arithmetic operator "-".
      @param q a quaternion to be subtracted.
      @return a quaternion representing Q, where Q = Q - q. */
     public static Quaternion operator -(Quaternion p, Quaternion q)
     {
         return new Quaternion(p[1] - q[1], p[2] - q[2], p[3] - q[3], p[4] - q[4]);
     }

  /** Arithmetic operator "*".
      Multiplication of two quaternions is like performing successive rotations.
      @param q a quaternion to be multiplied.
      @return a quaternion representing Q, where Q = Q * q. */
  public static Quaternion operator *(Quaternion p, Quaternion q)
  {
    return new Quaternion(p[1]*q[1]-p[2]*q[2]-p[3]*q[3]-p[4]*q[4],
                          p[1]*q[2]+p[2]*q[1]+p[3]*q[4]-p[4]*q[3],
                          p[1]*q[3]-p[2]*q[4]+p[3]*q[1]+p[4]*q[2],
                          p[1]*q[4]+p[2]*q[3]-p[3]*q[2]+p[4]*q[1]);
  }

  
  /** Inverse of the quaternion.

      Compute and return the inverse of the quaternion so that the orientation
      represented with *this multiplied with the returned value is equal to
      the identity orientation.
  */
  public Quaternion Inverse() 
  {
    double norm = Magnitude();
    if (norm == 0.0)
      return this;  // or new one with the same values?
    double rNorm = 1.0/norm;
    return new Quaternion( mData[0]*rNorm, -mData[1]*rNorm,
                         -mData[2]*rNorm, -mData[3]*rNorm );
  }

  /** Conjugate of the quaternion.

      Compute and return the conjugate of the quaternion. This one is equal
      to the inverse iff the quaternion is normalized.
  */
  Quaternion Conjugate()
  {
    return new Quaternion( mData[0], -mData[1], -mData[2], -mData[3] );
  }


  /** Zero quaternion vector. Does not represent any orientation.
      Useful for initialization of increments */
  public static Quaternion Zero()
  {
      return new Quaternion( 0.0, 0.0, 0.0, 0.0 );
  }


  /** Copying by assigning the vector valued components.  */
  Quaternion(double q1, double q2, double q3, double q4)
  {
      this[1] = q1; 
      this[2] = q2; 
      this[3] = q3; 
      this[4] = q4;
  }

  

 /** This stores the transformation matrices.  */
  private Matrix33 mT;
  private Matrix33 mTInv;
 

  /** The cached sines and cosines of the euler angles.  */
  private Vector3 mEulerSines;
  private Vector3 mEulerCosines;
};



}

