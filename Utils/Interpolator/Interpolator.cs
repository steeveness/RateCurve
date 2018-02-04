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

            double firstX = interpolatedPoints.First().Key;
            double lastX = interpolatedPoints.Last().Key;

            for(double x=firstX+step; x<lastX; x+=step)
            {
                //double y = PointLinearInterpolation(x-step,givenPoints[x-step],;
            }
            throw new NotImplementedException();
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
