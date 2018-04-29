using System;
using System.Collections.Generic;
using System.Linq;

namespace RateCurveLib
{
    public class CustomCurve: InterestRateCurve
    {
        // TODO: create a Custom Rate curve. It will be able to combine
        // Libor, Future, and SwapCurve (or other combinations)

        #region Constructors

        public CustomCurve(): base()
        {
           
        }

        public CustomCurve(SortedDictionary<double, double> shortTermRates, SortedDictionary<double, double> longTermRates): base()
        {
            // check maturities consistency
            if (shortTermRates.Keys.Last() > longTermRates.Keys.First())
            {
                throw new Exception("The maturities of the rates are not consistent.");
            }

            _curvePoints = new SortedDictionary<double, double>();
            // add short term points to the curve
            foreach (var p in shortTermRates)
            {
                _curvePoints.Add(p.Key, p.Value);
            }

            // add long term points to the curve
            foreach (var p in longTermRates)
            {
                if(!_curvePoints.Keys.Contains(p.Key))
                    _curvePoints.Add(p.Key, p.Value);
            }
        }

        public CustomCurve(InterestRateCurve ShortTermCurve, InterestRateCurve MediumTermCurve, InterestRateCurve LongTermCurve): base()
        {
            // check maturities consistency
            if(ShortTermCurve.GetUpperMaturity() > MediumTermCurve.GetLowerMaturity() || MediumTermCurve.GetUpperMaturity() > LongTermCurve.GetLowerMaturity())
            {
                throw new Exception("The maturities of the curve are not consistent.");
            }

            _curvePoints = new SortedDictionary<double, double>();

            // add short term points to the curve
            foreach(var p in ShortTermCurve.GetCurvePoints())
            {
                _curvePoints.Add(p.Key, p.Value);
            }

            // add medium term points to the curve
            foreach (var p in MediumTermCurve.GetCurvePoints())
            {
                _curvePoints.Add(p.Key, p.Value);
            }

            // add long term points to the curve
            foreach (var p in LongTermCurve.GetCurvePoints())
            {
                _curvePoints.Add(p.Key, p.Value);
            }
        }

        public override string CurveType()
        {
            return "Custom";
        }

        #endregion


        public override SortedDictionary<double, double> StripYieldCurve(IborCurve iborCurve)
        {
            throw new NotImplementedException();
        }
    }
}
