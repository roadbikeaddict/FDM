using FDM.Mathematics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FDMTest
{
    
    
    /// <summary>
    ///This is a test class for RealValueTest and is intended
    ///to contain all RealValueTest Unit Tests
    ///</summary>
    [TestClass]
    public class RealValueTest
    {
        /// <summary>
        ///A test for RealValue Constructor
        ///</summary>
        [TestMethod]
        public void A_RealValue_should_be_created()
        {
            const double param = 42.0;
            var target = new RealValue(param);
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for RealValue Constructor
        ///</summary>
        [TestMethod]
        public void The_value_should_be_get_correctly()
        {
            const double param = 42.0;
            const double expected = 42.0;
            var actual = new RealValue(param);
            Assert.AreEqual(actual.Value, expected, 1E-08);
        }
       
    }
}
