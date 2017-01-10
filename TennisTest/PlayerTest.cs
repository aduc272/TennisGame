using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis;

namespace TennisTest
{
    [TestClass]
    public class PlayerTest
    {
        Player fexEx;

        [TestInitialize]
        public void Init()
        {
            fexEx = new Player("FedEx");
        }

        [TestMethod]
        public void EqualsPoint_Nominal()
        {
            Player nole = new Player("Nole");

            fexEx.WinsPoint();
            fexEx.WinsPoint();
            nole.WinsPoint();
            Assert.IsFalse(fexEx.EqualsPoint(nole));

            nole.WinsPoint();
            Assert.IsTrue(fexEx.EqualsPoint(nole));
        }

        [TestMethod]
        public void EqualsPoint_NullInput()
        {
            Player nole = null;            
            Assert.IsFalse(fexEx.EqualsPoint(nole));
        }

        [TestMethod]
        public void WinPoint_Nominal()
        {
            Assert.AreEqual(0, fexEx.Point);

            fexEx.WinsPoint();
            Assert.AreEqual(1, fexEx.Point);

            fexEx.WinsPoint();
            Assert.AreEqual(2, fexEx.Point);
        }

        [TestMethod]
        public void IsLeadingPoint_Nominal()
        {
            Player nole = new Player("Nole");

            fexEx.WinsPoint();
            fexEx.WinsPoint();
            nole.WinsPoint();
            Assert.IsTrue(fexEx.IsLeadingPoint(nole));

            nole.WinsPoint();
            Assert.IsFalse(fexEx.IsLeadingPoint(nole));
        }

        [TestMethod]
        public void IsLeadingPoint_NullInput()
        {
            Player nole = null;
            Assert.IsFalse(fexEx.IsLeadingPoint(nole));
        }
    }
}
