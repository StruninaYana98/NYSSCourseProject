using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NYSS;

namespace NYSSTests
{
    [TestClass]
    public class CryptographerTests
    {
        [TestMethod]
        public void EncryptText_РаЗнЫйРеГиСтР_ВкЦюКтЯтФуАгА()
        {
            string teststring = "РаЗнЫйРеГиСтР";
            string expected = "ВкЦюКтЯтФуАгА";
            string actual = Cryptographer.EncryptText(teststring, "скорпион");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncryptText_StringWithNumbers_SameNumbers()
        {
            string teststring = "кро62ащ9ь3лк3344";
            string expected = "ьыэ62ри9е3ъш3344";
            string actual = Cryptographer.EncryptText(teststring, "скорпион");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncryptText_StringWithSymbols_SameSymbols()
        {
            string teststring = "с.и/м:во<лы";
            string expected = "г.у/ы:тю<фй";
            string actual = Cryptographer.EncryptText(teststring, "скорпион");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptText_дпагэиянггчеачрше_тестнарасшифровку()
        {
            string teststring = "дпагэиянггчеачрше";
            string expected = "тестнарасшифровку";
            string actual = Cryptographer.DecryptText(teststring, "скорпион");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecryptText_БыэТФщэеяёшtext_ПроВЕрочныйtext()
        {
            string teststring = "БыэТФщэеяёш text";
            string expected = "ПроВЕрочный text";
            string actual = Cryptographer.DecryptText(teststring, "скорпион");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyValidator_ключw_false()
        {
            bool actual = Cryptographer.KeyValidator("ключw");
            Assert.IsTrue(actual == false);
        }
        [TestMethod]
        public void KeyValidator_КлЮч_true()
        {
            bool actual = Cryptographer.KeyValidator("КлЮч");
            Assert.IsTrue(actual);
        }

    }
}
