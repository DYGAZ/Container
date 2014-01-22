using System;
using AHM.Core;
using AHMI.Relay;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AHMI.Test
{
    [TestClass]
    public class RelayTest
    {
        [TestMethod]
        public void TestQueryServer()
        {
            var relay = new AhmiRelay();
            relay.GetData();
        }
    }
}
