using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Loader;
using System.IO;
using System.Linq;

namespace UnitTests
{
    /// <summary>
    /// Description résumée pour CurveLoader
    /// </summary>
    [TestClass]
    public class CurveLoaderTests
    {
        public CurveLoaderTests()
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
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void should_load_data_from_correct_rate_curve_file()
        {
            string filePath = @"C:\Users\Steeve\source\repos\RateCurve\Utils\ratecurve.csv";
            char separator = ';';

            // First create the file
            SortedDictionary<double, double> originalRateCurve = new SortedDictionary<double, double>()
            {
                {0.0833333333333333,0.00465},
                {0.166666666666667,0.00473},
                {0.25,0.0048},
                {0.5,0.007},
                {0.75,0.0073},
                {1,0.00893},
                {2,0.00899},
                {3,0.0115},
                {4,0.01457},
                {5,0.01714},
                {6,0.01953},
                {7,0.02166},
                {8,0.02355},
                {9,0.02518},
                {10,0.02656},
                {11,0.02768},
                {12,0.02859},
                {13,0.02935},
                {14,0.02999},
                {15,0.03054},
                {16,0.03102},
                {17,0.03143},
                {18,0.03179},
                {19,0.0321},
                {20,0.03236},
                {21,0.03258},
                {22,0.03275},
                {23,0.0329},
                {24,0.03302},
                {25,0.03311},
                {26,0.03319},
                {27,0.03325},
                {28,0.03331},
                {29,0.03335},
                {30,0.03339},
                {31,0.03343},
                {32,0.03346},
                {33,0.03349},
                {34,0.03353},
                {35,0.03355},
                {36,0.03358},
                {37,0.0336},
                {38,0.03362},
                {39,0.03364},
                {40,0.03366},
                {41,0.03367},
                {42,0.03368},
                {43,0.03368},
                {44,0.03369},
                {45,0.03369},
                {46,0.03369},
                {47,0.03369},
                {48,0.03369},
                {49,0.03369},
                {50,0.03369}
            };

            // create file
            using (StreamWriter writetext = new StreamWriter(filePath))
            {
                foreach(var pair in originalRateCurve)
                {
                    writetext.WriteLine($"{pair.Key}{separator}{pair.Value}");
                }
            }

            SortedDictionary<double, double> rateCurve = CurveLoader.LoadFromFile(filePath, separator, true);

            // delete file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            bool check = true;

            double[] rateCurveKeys = rateCurve.Keys.ToArray();
            double[] originalRateCurveKeys = originalRateCurve.Keys.ToArray();

            for (int i = 0; i<rateCurve.Count; i++)
            {
                var y = rateCurve[0.25];
                check = check && rateCurve[rateCurveKeys[i]].Equals(rateCurve[rateCurveKeys[i]]);
                if (!check)
                    break;
            }

            Assert.IsTrue(rateCurve != null);
        }
    }
}
