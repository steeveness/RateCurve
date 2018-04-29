using Utils.Tools;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UnitTests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void should_return_first_last_and_middle_index_of_collection()
        {
            double[] collection = new double[] {1,3,4,9,10,16,18,21,27,34};

            double val1 = 1;
            double val2 = 34;
            double val3 = 16;

            int index1 = Tools.FindIndex(collection, val1);
            int index2 = Tools.FindIndex(collection, val2);
            int index3 = Tools.FindIndex(collection, val3);

            Assert.IsTrue(index1 == 0 && index2 == 9 && index3 == 5);
        }

        [TestMethod]
        public void should_return_minus_one_if_value_out_of_collection_on_index_searching()
        {
            double[] collection = new double[] { 1, 3, 4, 9, 10, 16, 18, 21, 27, 34 };

            double val1 = 40;
            double val2 = -10;

            int index1 = Tools.FindIndex(collection, val1);
            int index2 = Tools.FindIndex(collection, val2);

            Assert.IsTrue(index1 == -1 && index2 == -1);
        }

        [TestMethod]
        public void should_return_lowest_above_value_for_first_and_intermidiate_elements()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 0.26;
            double val2 = 0.37;
            double val3 = 2.12;
            double val4 = 9.25;

            double key1 = Tools.FindLowestAbove(collection, val1);
            double key2 = Tools.FindLowestAbove(collection, val2);
            double key3 = Tools.FindLowestAbove(collection, val3);
            double key4 = Tools.FindLowestAbove(collection, val4);

            Assert.IsTrue(key1.Equals(0.5) && key2.Equals(0.5) && key3.Equals(3) && key4.Equals(10));
        }

        [TestMethod]
        public void should_return_highest_below_value_for_first_and_intermidiate_elements()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 0.26;
            double val2 = 2.12;
            double val3 = 9.25;
            double val4 = 10.4;

            double key1 = -1;
            double key2 = -1;
            double key3 = -1;
            double key4 = -1;

            try
            {
                key1 = Tools.FindHighestBelow(collection, val1);
                key2 = Tools.FindHighestBelow(collection, val2);
                key3 = Tools.FindHighestBelow(collection, val3);
                key4 = Tools.FindHighestBelow(collection, val4);
            }
            catch(Exception e)
            {

            }

            Assert.IsTrue(key1.Equals(0.25) && key2.Equals(2) && key3.Equals(9) && key4.Equals(10));
        }

        [TestMethod]
        public void should_return_lowest_index_above_value_for_first_and_intermidiate_elements()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 0.26;
            double val2 = 0.37;
            double val3 = 2.12;
            double val4 = 9.25;

            double ind1 = Tools.FindLowestIndexAbove(collection, val1);
            double ind2 = Tools.FindLowestIndexAbove(collection, val2);
            double ind3 = Tools.FindLowestIndexAbove(collection, val3);
            double ind4 = Tools.FindLowestIndexAbove(collection, val4);

            Assert.IsTrue(ind1.Equals(1) && ind2.Equals(1) && ind3.Equals(7) && ind4.Equals(14));
        }

        [TestMethod]
        public void should_return_highest_index_below_value_for_first_and_intermidiate_elements()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 0.26;
            double val2 = 2.12;
            double val3 = 9.25;
            double val4 = 10.4;

            double key1 = -1;
            double key2 = -1;
            double key3 = -1;
            double key4 = -1;

            try
            {
                key1 = Tools.FindHighestIndexBelow(collection, val1);
                key2 = Tools.FindHighestIndexBelow(collection, val2);
                key3 = Tools.FindHighestIndexBelow(collection, val3);
                key4 = Tools.FindHighestIndexBelow(collection, val4);
            }
            catch (Exception e)
            {

            }

            Assert.IsTrue(key1.Equals(0) && key2.Equals(6) && key3.Equals(13) && key4.Equals(14));
        }

        [TestMethod]
        public void should_throw_exception_if_no_value_in_dictionary_above_the_key()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 10;
            double val2 = 10.01;

            int nbExceptions = 0;

            try
            {
                double key1 = Tools.FindLowestAbove(collection, val1);
            }
            catch(Exception e)
            {
                nbExceptions++;
            }

            try
            {
                double key2 = Tools.FindLowestAbove(collection, val2);
            }
            catch (Exception e)
            {
                nbExceptions++;
            }

            Assert.IsTrue(nbExceptions == 2);
        }

        [TestMethod]
        public void should_throw_exception_if_no_value_in_dictionary_below_the_key()
        {
            SortedDictionary<double, double> collection = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 },
                {4, 34},
                {5, 18 },
                {6, 21 },
                {7, 34},
                {8, 18 },
                {9, 21 },
                {10, 34}
            };

            double val1 = 0.25;
            double val2 = -1;

            int nbExceptions = 0;

            try
            {
                double key1 = Tools.FindHighestBelow(collection, val1);
            }
            catch (Exception e)
            {
                nbExceptions++;
            }

            try
            {
                double key2 = Tools.FindHighestBelow(collection, val2);
            }
            catch (Exception e)
            {
                nbExceptions++;
            }

            Assert.IsTrue(nbExceptions == 2);
        }

        [TestMethod]
        public void should_return_interval_containing_point()
        {
            SortedDictionary<double, double> mainPoints = new SortedDictionary<double, double>
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.25, 10 },
                {1.5, 16 },
                {2, 18 },
            };

            double x = 0.84;
            int expectedLower = 2;

            Tuple<int, int> interval = null;

            try
            {
                interval = Tools.FindIndexInterval(mainPoints, x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Assert.IsTrue(interval.Item1.Equals(expectedLower) && interval.Item2.Equals(expectedLower+1));
        }
    }
}
