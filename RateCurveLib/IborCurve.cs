using System;
using System.Collections.Generic;

namespace RateCurveLib
{
    public class IborCurve : InterestRateCurve
    {
        #region constructors
        public IborCurve(SortedDictionary<double, double> initialPoints): base(initialPoints)
        {

        }

        public override string CurveType()
        {
            return "Ibor";
        }
        #endregion

        #region methods
        public override SortedDictionary<double, double> StripYieldCurve(IborCurve iborCurve)
        {
            if (_yieldCurvePoints != null)
                return _yieldCurvePoints;

            _yieldCurvePoints = new SortedDictionary<double, double>();

            double rate;

            foreach (var item in _curvePoints)
            {
                rate = Math.Log(1 + item.Value * item.Key) / item.Key;
                _yieldCurvePoints.Add(item.Key, rate);
            }

            return _yieldCurvePoints;
        }

        #endregion
    }
}