using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GAS.Tests {
    [TestClass]
    public class NdncFilterTests {

        [TestMethod]
        public void Phone_is_NDNC() {
            NdncFilter filter = new NdncFilter();
            Assert.IsTrue(filter.CheckIfNumberDnc("9891410701"));
        }

        [TestMethod]
        public void Phone_is_not_NDNC() {
            NdncFilter filter = new NdncFilter();
            Assert.IsFalse(filter.CheckIfNumberDnc("9891012345"));
        }
    }
}
