using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainarizumuVerifier;

namespace MainarizumuTest
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void SizeTwoCell()
        {
            Cell cell = new Cell(2);
            Assert.AreEqual("12", cell.LegalValues.ToString());
        }

        [TestMethod]
        public void SizeTwoGreaterThan()
        {
            Cell leftCell = new Cell(2);
            Cell rightCell = new Cell(2);
            leftCell.UpdateGreaterThan(rightCell);
            rightCell.UpdateLessThan(leftCell);
            Assert.AreEqual("2", leftCell.LegalValues.ToString());
            Assert.AreEqual("1", rightCell.LegalValues.ToString());
        }

        [TestMethod]
        public void SizeTwoLessThan()
        {
            Cell leftCell = new Cell(2);
            Cell rightCell = new Cell(2);
            leftCell.UpdateLessThan(rightCell);
            rightCell.UpdateGreaterThan(leftCell);
            Assert.AreEqual("1", leftCell.LegalValues.ToString());
            Assert.AreEqual("2", rightCell.LegalValues.ToString());
        }

        [TestMethod]
        public void SizeTwoDifferenceByOne()
        {
            Cell leftCell = new Cell(2);
            Cell rightCell = new Cell(2);
            leftCell.UpdateDifference(1, rightCell);
            rightCell.UpdateDifference(1, leftCell);
            Assert.AreEqual("12", leftCell.LegalValues.ToString());
            Assert.AreEqual("12", rightCell.LegalValues.ToString());

        }
    }
}
