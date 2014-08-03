using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCard_Check;

namespace CardCheckTest
{
    [TestClass]
    public class CardDataTest
    {

        [TestMethod]
        public void CardIsVisa()
        {
            string testNumber = "465943";
            string result = CardData.BankInfo(testNumber);

            Assert.IsTrue(result.StartsWith("(VISA) "));

        }
        [TestMethod]
        public void CardIsMastercard()
        {
            string testNumber = "512299";
            string result = CardData.BankInfo(testNumber);

            Assert.IsTrue(result.StartsWith("(Mastercard) "));
        }

        [TestMethod]
        public void CardIsUnknown()
        {
            string testNumber = "999999";
            string result = CardData.BankInfo(testNumber);

            Assert.IsTrue(result.StartsWith("(Unknown) "));
        }

        [TestMethod]
        public void CardDataCorrect6Digits()
        {
            var init = new CardData(@"CardData.txt");
            string testNumber = "465943";
            string expected = "(VISA) HSBC Bank (UK) Visa Debit, NO Cheque Guarantee";
            string result = CardData.BankInfo(testNumber);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CardDataCorrect4Digits()
        {
            var init = new CardData(@"CardData.txt");
            string testNumber = "512299";
            string expected = "(Mastercard) First Gulf Bank";
            string result = CardData.BankInfo(testNumber);

            Assert.AreEqual(result, expected);
        }
    }
}
