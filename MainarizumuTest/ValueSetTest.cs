using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainarizumuVerifier;
using System.Linq;

namespace MainarizumuTest
{
    [TestClass]
    public class ValueSetTest
    {
        [TestMethod]
        public void ValueSetOneToFiveAsString()
        {
            ValueSet set = new ValueSet();
            set.Set(Enumerable.Range(1, 5));
            Assert.AreEqual("12345", set.ToString());
        }
        [TestMethod]
        public void ValueSetEmptyAsString()
        {
            ValueSet set = new ValueSet();
            Assert.AreEqual("Error", set.ToString());
        }
    }
}
