using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Tools;

namespace RateCurveApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, double> myDictionary = new SortedDictionary<double, double>();

            for(double x = 0.25; x<=5; x+=0.25)
            {
                myDictionary.Add(x,x * x + 1);
            }

            for(int i = 0; i<myDictionary.Count(); i++)
            {
                Console.WriteLine($"Key: {myDictionary.ElementAt(i).Key}  \t  Value: {myDictionary.ElementAt(i).Value}");
            }

            double value = Tools.FindLowestAbove(myDictionary, 2.37);

            double value2 = Tools.FindIndex(myDictionary.Keys.ToArray<double>(), 5);
        }
    }
}
