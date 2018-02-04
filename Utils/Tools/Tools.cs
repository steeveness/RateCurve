using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Tools
{
    public class Tools
    {
        private static int FindNearestIndex(SortedDictionary<double, double> dict, double key)
        {
            if (dict == null)
            {
                throw new System.ArgumentNullException(nameof(dict));
            }        

            List<double> myArray = new List<double>(dict.Keys);

            int n = myArray.Count;
            int pos = 0;
            int upper = n - 1;
            int lower = 0;
            bool stop = false;


            // dichotomy
            while (!stop)
            {
                pos = (upper + lower) / 2;

                if (myArray[pos].Equals(key))
                    return pos;
                else
                {
                    if (key < myArray[pos])
                    {
                        upper = pos;
                    }
                    else //(key > myArray[pos])
                    {
                        if (lower == pos)
                            return upper;
                        lower = pos;
                    }
                }
            }
            return pos;
        }

        public static double FindLowestAbove(SortedDictionary<double, double> myList, double myKey)
        {
            if (myKey >= myList.Last().Key)
                throw new Exception("No values above key inside the sorted dictionary");

            int pos = FindNearestIndex(myList, myKey);

            if(myKey < myList.ElementAt(pos).Key)
            {
                return myList.ElementAt(pos).Key;
            }
            else
            {
                if (pos < myList.Count - 1)
                {
                    return myList.ElementAt(pos + 1).Key;
                }
                else
                    throw new Exception("No values above key inside the sorted dictionary");
            }
        }

        public static double FindHighestBelow(SortedDictionary<double, double> dict, double key)
        {
            if(key <= dict.First().Key)
                throw new Exception("No values below key inside the sorted dictionary");

            int pos = FindNearestIndex(dict, key);

            if(key > dict.ElementAt(pos).Key)
            {
                return dict.ElementAt(pos).Key;
            }
            else
            {
                if (pos > 0)
                    return dict.ElementAt(pos - 1).Key;
                else
                    throw new Exception("No values below key inside the sorted dictionary");
            }
        }

        public static int FindIndex(double[] vector, double value)
        {
            int n = vector.Length;

            int lower = 0;
            int upper = n-1;
            int pos = -1; ;

            while(value >= vector[lower] && value <= vector[upper])
            {
                if(upper-lower == 1)
                {
                    if (vector[upper].Equals(value))
                        return upper;
                    else if (vector[lower].Equals(value))
                        return lower;
                }
                else
                {
                    pos = (lower + upper) / 2;
                }

                if (vector[pos].Equals(value))
                    return pos;
                
                else if(vector[pos] < value)
                {
                    if (lower == pos)
                    {
                        break;
                    }
                    lower = pos;
                }
                else
                {
                    if (upper == pos)
                    {
                        break;
                    }
                    upper = pos;
                }
            }

            pos = (pos == -1)? pos : vector[pos].Equals(value) ? pos : -1;

            return pos;
        }

        public static int FindInterval(SortedDictionary<double, double> dict, double key)
        {
            if (key <= dict.First().Key || key >= dict.Last().Key )
                throw new Exception("The key is not ");
        }
    }
}
