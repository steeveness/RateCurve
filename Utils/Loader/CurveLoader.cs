using System;
using System.Collections.Generic;
using System.IO;

namespace Utils.Loader
{
    public class CurveLoader
    {
        public static SortedDictionary<double,double> LoadFromFile(string filepath, char separator, bool header=false)
        {
            SortedDictionary<double, double> rateCurve = new SortedDictionary<double, double>();

            using (var reader = new StreamReader(filepath))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    var line = reader.ReadLine();
                    var values = line.Split(separator);

                    double maturity;
                    double ratevalue;

                    if(Double.TryParse(values[0], out  maturity))
                    {
                        ratevalue = percentageToDouble(values[1]);
                        rateCurve.Add(maturity, ratevalue);
                    }
                }
            }
            return rateCurve;
        }


        private static bool IsPercentage(string value)
        {
            return value.Contains("%");
        }

        private static double percentageToDouble(string value)
        {
            double converted = Double.NaN;

            string trimmed = value.Replace("%", string.Empty);

            Double.TryParse(trimmed, out converted);

            return converted.Equals(Double.NaN)? converted : converted/100 ;
        }
    }
}
