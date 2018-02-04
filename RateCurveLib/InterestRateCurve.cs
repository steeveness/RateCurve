using System;
using System.Collections.Generic;

namespace RateCurveLib
{
    public abstract class InterestRateCurve
    {
        #region Constructors
        public InterestRateCurve(SortedDictionary<double, double> points)
        {
            _curvePoints = points;
        }
        #endregion

        #region attributes

        // coordinates(x,y) of the rate curve
        protected readonly SortedDictionary<double, double> _curvePoints = null;

        // yield curve coordinates
        protected SortedDictionary<double, double> _yieldCurvePoints = null;
        #endregion

        #region methods

        // returns the rate value corresponding to the given maturity
        public double GetRate(double maturity)
        {
            if (_curvePoints == null)
            {
                string errMessage = "The curve points dictionary is null";
                throw new Exception(errMessage);
            }
            return _curvePoints[maturity];
        }

        //returns the yield value corresponding to the given maturity
        public double GetYield(double maturity)
        {
            if (_yieldCurvePoints == null)
                StripYieldCurve(null);

            return _yieldCurvePoints[maturity];
        }

        public abstract SortedDictionary<double, double> StripYieldCurve(IborCurve iborCurve);

        #endregion
    }
}
