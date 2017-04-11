using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntToRomain;

namespace TestIntToRomain
{
    // class de test pour valider le fonctionnement de la convertion d'un entier en nombre Romain
    [TestClass]
    public class TestRomainConverter
    {

        public TestContext TestContext { get; set; }

        // lecture d'un  fichier xml contenant l'ensemble des tests a passé
        [TestMethod]
        [DeploymentItem("TestIntToromain\\RomainTest.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\RomainTest.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestconvertToRomain()
        {
            int aNumber = Int32.Parse((string)TestContext.DataRow["aNumber"]);
            string res = (string)TestContext.DataRow["expected"];
            ExecTestConvertToRomain(aNumber, res);
        }

        public void ExecTestConvertToRomain(int aNumber, string resultAWait)
        {
            string result = RomainConverter.ConvertToRomain(aNumber);
            // verifie que le resultat attendu est egal au resultat obtenu
            Assert.AreEqual(result, resultAWait);
        }

        
    }
}
