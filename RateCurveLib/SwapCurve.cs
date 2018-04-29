using System.Collections.Generic;

namespace RateCurveLib
{
    class SwapCurve : InterestRateCurve
    {

        #region attributes
        private double _Tenor;
        #endregion

        public SwapCurve(SortedDictionary<double, double> points, double tenor=0.25) : base(points)
        {
            _Tenor = tenor;
        }

        public override string CurveType()
        {
            return "Swap";
        }

        public override SortedDictionary<double, double> StripYieldCurve(IborCurve iborCurve)
        {
            _yieldCurvePoints = new SortedDictionary<double, double>();

            double P_t_TN;
            double sum = 0;
            double level;
            double swapRate;

            foreach(var item in _curvePoints)
            {
                level = item.Key;
                swapRate = item.Value;

                //sum += _Tenor * iborCurve.GetRate(x) * swapRate;

                double yield = (1 - sum) / (1 + swapRate * _Tenor);

                _yieldCurvePoints.Add(level, yield);
            }

            return _yieldCurvePoints;
        }
    }
}
