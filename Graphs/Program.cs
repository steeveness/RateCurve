using RateCurveLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils.Loader;

namespace Graphs
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Whole Curve
            string filePath = @"C:\Users\Steeve\source\repos\RateCurve\Utils\ratecurve1.csv";
            char sep = ';';
            SortedDictionary<double, double> myDictionary = CurveLoader.LoadFromFile(filePath, sep, true);
            #endregion

            #region Euribor Rates
            string euriborRatesPath = @"C:\Users\Steeve\source\repos\RateCurve\Input\Euribor_Rates.csv";
            SortedDictionary<double, double> euriborRates = CurveLoader.LoadFromFile(euriborRatesPath, sep, true);
            #endregion

            #region Swap Rates
            string swapRatesPath = @"C:\Users\Steeve\source\repos\RateCurve\Input\ICESwapRateHistoricalRates.csv";
            SortedDictionary<double, double> swapRates = CurveLoader.LoadFromFile(swapRatesPath, sep, true);
            #endregion

            #region building custom path
            CustomCurve customCurve=null;
            try
            {
                customCurve = new CustomCurve(euriborRates, swapRates);
            }
            catch(Exception ex)
            {
                string errMessage = "Error: unable to build custom curve.\n"+ex.Message;
                MessageBox.Show(errMessage);
            }
            #endregion

            //Application.Run(new RateCurvePlots(myDictionary));
            SortedDictionary<double, double> points = customCurve.GetCurvePoints();

            Application.Run(new RateCurvePlots(points));
        }
    }
}
