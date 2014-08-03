using CreditCard_Check;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardCheckTest
{
    [TestClass]
    public class CardCheckTest
    {
        [TestMethod]
        public void NumberValid16()
        {
            string testNumber = "1234567890123452";
            bool result = CardCheck.CheckNumber(testNumber);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NumberValid15()
        {
            string testNumber = "123456789012347";
            bool result = CardCheck.CheckNumber(testNumber);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NumberValid3()
        {
            string testNumber = "125";
            bool result = CardCheck.CheckNumber(testNumber);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NumberInvalid16()
        {
            string testNumber = "123456789012345";
            bool result = CardCheck.CheckNumber(testNumber);

            Assert.IsFalse(result);

        }
    }
}
