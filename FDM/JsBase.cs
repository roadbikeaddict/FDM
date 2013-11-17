using System;
using System.Collections.Generic;
using System.Globalization;

namespace FDM
{
    public class JsBase
    {
       

        public JsBase()
        {
      
        }

        /// <summary>
        /// Converts from degree Kelvin to degree Fahrenheit.
        /// </summary>
        /// <param name="kelvin">The degree in Kelvin.</param>
        /// <returns>The degree in Fahrenheit</returns>
        public static double KelvinToFahrenheit(double kelvin)
        {
            return 1.8*kelvin - 459.4;
        }

        /// <summary>
        /// Converts from degree Celsius to degree Rankine.
        /// </summary>
        /// <param name="celsius">The degree in Celsius.</param>
        /// <returns>The degree in Rankine</returns>
        public static double CelsiusToRankine(double celsius)
        {
            return celsius*1.8 + 491.67;
        }

        /// <summary>
        /// Converts from degrees Rankines to degrees Celsius.
        /// </summary>
        /// <param name="rankine">The degrees in Rankine.</param>
        /// <returns>The degrees in Celsius</returns>
        public static double RankineToCelsius(double rankine)
        {
            return (rankine - 491.67)/1.8;
        }

        /// <summary>
        /// Converts from degrees Kelvin to degrees Rankine.
        /// </summary>
        /// <param name="kelvin">The degrees in Kelvin.</param>
        /// <returns>The degrees in Rankine</returns>
        public static double KelvinToRankine(double kelvin)
        {
            return kelvin*1.8;
        }

        /// <summary> 
        /// Converts from degrees Rankine to degrees Kelvin.
        /// </summary>
        /// <param name="rankine">The degrees in Rankine.</param>
        /// <returns>The degrees in Kelvin</returns>
        public static double RankineToKelvin(double rankine)
        {
            return rankine/1.8;
        }

        /// <summary> 
        /// Converts from degrees Fahrenheit to degrees Celsius.
        /// </summary>
        /// <param name="fahrenheit">The degrees in Fahrenheit.</param>
        /// <returns>The degrees in Celsius</returns>
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32.0)/1.8;
        }

        /// <summary> 
        /// Converts from degrees Celsius to degrees Fahrenheit.
        /// </summary>
        /// <param name="celsius">The degrees in Celsius.</param>
        /// <returns>The degrees in Fahrenheit</returns>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return celsius*1.8 + 32.0;
        }

        /// <summary> 
        /// Converts from degrees Celsius to degrees Kelvin.
        /// </summary>
        /// <param name="celsius">The degrees in Celsius.</param>
        /// <returns>The degrees in Kelvin</returns>
        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        /// <summary> 
        /// Converts from degrees Kelvin to degrees Celsius.
        /// </summary>
        /// <param name="kelvin">The degrees in Kelvin.</param>
        /// <returns>The degrees in Celsius</returns>
        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        /// <summary>
        /// Gets the program version.
        /// </summary>
        /// <returns>The version string</returns>
        public string GetVersion()
        {
            return "0.1";
        }

        
        //private static double GetDblEpsilon() 
        //{
        //    double d = 1;
        //    while (1.0 + d/2 != 1.0) 
        //    {
        //        d = d/2;
        //    }
        //    return d;
        //}

        /** Finite precision comparison.
        @param a first value to compare
        @param b second value to compare
        @return if the two values can be considered equal up to roundoff */

        public static bool EqualToRoundoff(double a, double b)
        {
            const double DBL_EPSILON = 2.22045e-016;
            double eps = 2.0*DBL_EPSILON;
            return Math.Abs(a - b) <= eps*Math.Max(Math.Abs(a), Math.Abs(b));
        }

        /** Finite precision comparison.
        @param a first value to compare
        @param b second value to compare
        @return if the two values can be considered equal up to roundoff */

        public static bool EqualToRoundoff(float a, float b)
        {
            const float FLT_EPSILON = 1.192092896e-07F;
            const float eps = (float) 2.0*FLT_EPSILON;
            return Math.Abs(a - b) <= eps*Math.Max(Math.Abs(a), Math.Abs(b));
        }

        /** Finite precision comparison.
        @param a first value to compare
        @param b second value to compare
        @return if the two values can be considered equal up to roundoff */

        public static bool EqualToRoundoff(float a, double b)
        {
            return EqualToRoundoff(a, (float) b);
        }

        /** Finite precision comparison.
        @param a first value to compare
        @param b second value to compare
        @return if the two values can be considered equal up to roundoff */

        public static bool EqualToRoundoff(double a, float b)
        {
            return EqualToRoundoff((float) a, b);
        }

        /** Constrain a value between a minimum and a maximum value.
        */

        public static double Constrain(double min, double value, double max)
        {
            return value < min ? (min) : (value > max ? (max) : (value));
        }

        public static double Sign(double num)
        {
            return num >= 0.0 ? 1.0 : -1.0;
        }

        public static string CreateIndexedPropertyName(string property, int index)
        {
            return property + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
        }

        // This stuff needs to be reworked
        public static double GaussianRandomNumber()
        {
            double V1, V2, S;
            int phase = 0;
            double X;

            V1 = 0.0;
            V2 = 0.0;
            S = 0.0;
            X = 0.0;
            var rnd = new Random((int) DateTime.Now.Ticks);
            if (phase == 0)
            {
                do
                {
                    var u1 = rnd.NextDouble();
                    var u2 = rnd.NextDouble();
                    V1 = 2*u1 - 1;
                    V2 = 2*u2 - 1;
                    S = V1*V1 + V2*V2;
                } while (S >= 1 || S == 0);

                X = V1*Math.Sqrt(-2*Math.Log(S)/S);
            }
            else
            {
                X = V2*Math.Sqrt(-2*Math.Log(S)/S);
            }

            phase = 1 - phase;

            return X;
        }


      
    }
}

