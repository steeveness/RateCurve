using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UnitTests
{
    /// <summary>
    /// Description résumée pour InterpolatorTests
    /// </summary>
    [TestClass]
    public class InterpolatorTests
    {
        public InterpolatorTests()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires

        static SortedDictionary<double, double> dict;


         //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
         [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            dict = new SortedDictionary<double, double>()
            {
                {0.25, 1 },
                {0.5, 3 },
                {0.75, 4 },
                {1, 9 },
                {1.5, 16 },
                {2, 18 },
                {3, 21 }
            };
        }

        //Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
         [ClassCleanup()]
        public static void MyClassCleanup() { }

        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
         [TestInitialize()]
        public void MyTestInitialize() { }

        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        [TestCleanup()]
         public void MyTestCleanup() { }

        #endregion

        [TestMethod]
        public void should_interpolate_whole_curve_by_step()
        {
            double step = 0.25;
            SortedDictionary<double, double> interpolatedDictionary = Interpolator.CurveLinearSmoothing(dict, step);
            Assert.IsTrue(interpolatedDictionary[1.25].Equals(12.5) && interpolatedDictionary[1.75].Equals(17));
        }

        [TestMethod]
        public void should_return_abscissa_of_interpolated_regular_point_linear()
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

            double x = 0.37;
            double expectedY = 1.96;

            double x1 = 0.25;

            try
            {
                double y = Interpolator.PointLinearInterpolation(mainPoints, x);

                double y1 = Interpolator.PointLinearInterpolation(mainPoints, x1);

                Assert.IsTrue(y.Equals(expectedY));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        [TestMethod]
        public void should_return_abscissa_of_interpolated_border_point_linear()
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

            double x = 0.25;
            double expectedY = 1;

            double x1 = 2;
            double expectedY1 = 18;

            try
            {
                double y = Interpolator.PointLinearInterpolation(mainPoints, x);

                double y1 = Interpolator.PointLinearInterpolation(mainPoints, x1);

                Assert.IsTrue(y.Equals(expectedY) && y1.Equals(expectedY1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
