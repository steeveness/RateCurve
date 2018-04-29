using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Tools;

namespace Utils
{
    public class Interpolator
    {
        public delegate SortedDictionary<double, double> SmoothCurve(SortedDictionary<double, double> givenPoints, double step);

        public delegate double GetIntermediatePoint(SortedDictionary<double, double> givenPoints, double x);

        public static SortedDictionary<double, double>  CurveLinearSmoothing(SortedDictionary<double, double> givenPoints, double step)
        { 
            SortedDictionary<double, double> interpolatedPoints = new SortedDictionary<double, double>(givenPoints);

            double firstX = givenPoints.First().Key;
            double lastX = givenPoints.Last().Key;
             
            double lower = 0;
            double upper = firstX;

            foreach(var pair in givenPoints)
            {
                if (pair.Key.Equals(firstX))
                    continue;

                lower = upper;
                upper = pair.Key;

                for(double x = lower+step; x < upper; x+=step)
                {
                    double xInf = Math.Max(lower, x - step);
                    double yInf = interpolatedPoints[xInf];
                    
                    if(!interpolatedPoints.ContainsKey(x))
                        interpolatedPoints.Add(x, PointLinearInterpolation(xInf, yInf, upper, givenPoints[upper], x));
                }
            }

            return interpolatedPoints;
        }

        public static double PointLinearInterpolation(SortedDictionary<double, double> mainPoints, double x)
        {
            try
            {
                double x_sup = Tools.Tools.FindLowestAbove(mainPoints, x);

                double x_inf = Tools.Tools.FindHighestBelow(mainPoints, x);

                double y_inf = mainPoints[x_inf];
                double y_sup = mainPoints[x_sup];

                double y = PointLinearInterpolation(x_inf, y_inf, x_sup, y_sup, x);

                return y;
            }
            catch(Exception e)
            {
                throw;
            }

        }

        private static double PointLinearInterpolation(double xInf, double yInf, double xSup, double ySup, double x)
        {
            return (ySup-yInf) * (x-xInf) / (xSup-xInf) + yInf;
        }
    }
}
