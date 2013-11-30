using System;

namespace FDM.Mathematics
{
    // This class implements a 3 element column vector.
    public class Vector3
    {
        protected bool Equals(Vector3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
       
        public Vector3()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
        }

        public Vector3(double xValue, double yValue, double zValue)
        {
            X = xValue;
            Y = yValue;
            Z = zValue;
        }

        // Copy constructor.
        public Vector3(Vector3 orig)
        {
            X = orig.X;
            Y = orig.Y;
            Z = orig.Z;
        }

        public void AssignFrom(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        // Indexer to easily access the data elements. ATTENTION: We start counting with 1!
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return X;
                    case 2:
                        return Y;
                    case 3:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException("The index of a vector element must be between 1 and 3");
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        X = value;
                        break;
                    case 2:
                        Y = value;
                        break;
                    case 3:
                        Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("The index of a vector element must be between 1 and 3");
                }
            }
        }
 
        #region Operators for compositions of this vector with another one
        public static Vector3 operator +(Vector3 other)
        {
            var result = new Vector3
            (
                + other.X,
                + other.Y,
                + other.Z
            );
            return result; 
        }

        public static Vector3 operator -(Vector3 other)
        {
            var result = new Vector3
            (
                -other.X,
                -other.Y,
                -other.Z
            );
            return result;
        }

        #endregion
        #region Operators for two given vectors
        public static Vector3 operator +(Vector3 first, Vector3 second)
        {
            var result = new Vector3
            {
                X = first.X + second.X,
                Y = first.Y + second.Y,
                Z = first.Z + second.Z
            };
            return result;
        }

        public static Vector3 operator -(Vector3 first, Vector3 second)
        {
            var result = new Vector3
            {
                X = first.X - second.X,
                Y = first.Y - second.Y,
                Z = first.Z - second.Z
            };
            return result;
        }
        #endregion

        public static bool operator <(Vector3 v1, Vector3 v2)
        {
            return v1.Magnitude() < v2.Magnitude();
        }

        public static bool operator >(Vector3 v1, Vector3 v2)
        {
            return v1.Magnitude() > v2.Magnitude();
        }

        public static bool operator <=(Vector3 v1, Vector3 v2)
        {
            return v1.Magnitude() <= v2.Magnitude();
        }

        public static bool operator >=(Vector3 v1, Vector3 v2)
        {
            return v1.Magnitude() >= v2.Magnitude();
        }

        public static bool operator ==(Vector3 first, Vector3 second)
        {
            var result =    (Math.Abs(first.X - second.X) < EqualityTolerance)
                         && (Math.Abs(first.Y - second.Y) < EqualityTolerance)
                         && (Math.Abs(first.Z - second.Z) < EqualityTolerance);
            return result;
        }
        
        public static bool operator !=(Vector3 first, Vector3 second)
        {
            var result = !( (Math.Abs(first.X - second.X) < EqualityTolerance)
                         && (Math.Abs(first.Y - second.Y) < EqualityTolerance)
                         && (Math.Abs(first.Z - second.Z) < EqualityTolerance));
            return result;
        }

        public static Vector3 operator *(Vector3 vector, double scalar)
        {
            var result = new Vector3 {X = vector.X*scalar, Y = vector.Y*scalar, Z = vector.Z*scalar};
            return result;
        }

        public static Vector3 operator *(double scalar, Vector3 vector)
        {
            var result = vector*scalar;
            return result;
        }

        public static Vector3 operator /(double scalar, Vector3 vector)
        {
            var result = vector/scalar;
            return result;
        }

        public static Vector3 operator /(Vector3 vector, double scalar)
        {
            var result = new Vector3 {X = vector.X/scalar, Y = vector.Y/scalar, Z = vector.Z/scalar};
            return result;
        }

        public static Vector3 Cross(Vector3 first, Vector3 second)
        {
            var result = new Vector3
                {
                    X = first.Y*second.Z - first.Z*second.Y,
                    Y = first.Z*second.X - first.X*second.Z,
                    Z = first.X*second.Y - first.Y*second.X
                };
            return result;
        }

        public Vector3 Cross(Vector3 other)
        {
            var result = new Vector3
            {
                X = Y * other.Z - Z * other.Y,
                Y = Z * other.X - X * other.Z,
                Z = X * other.Y - Y * other.X
            };
            return result;
        }

        public static double Dot(Vector3 first, Vector3 second)
        {
            var result = first.X*second.X + first.Y*second.Y + first.Z*second.Z;
            return result;
        }

        public double Dot(Vector3 other)
        {
            var result = X * other.X + Y * other.Y + Z * other.Z;
            return result;
 }
  
        // Length of the vector
        public double Magnitude()
        {
            var result = Math.Sqrt(X*X + Y*Y + Z*Z);
            return result;
        }

        public Vector3 Normalize()
        {
            var magnitude = Magnitude();
            if (Math.Abs(magnitude - 0.0) < EqualityTolerance)
            {
                throw new DivideByZeroException();
            }
            var result = this / magnitude;
            return result;
        }

        public const double EqualityTolerance = Double.Epsilon;
    }
}





