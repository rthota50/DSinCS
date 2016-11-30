using DS.Utils;
using NUnit.Framework;

namespace DSTests
{
	[TestFixture]
    public class UtilsTests
    {
        [TestCase]
        public void Create_bi_directional_dictionary()
        {
            var m = new Map<string, int>(3);
            m.Add("rajiv",1);
            m.Add("thota", 2);
            m.Add("fullname",3);
            Assert.AreEqual(m.Reverse[1], "rajiv");
            Assert.AreEqual(m.Reverse[2], "thota");
            Assert.AreEqual(m.Forward["fullname"], 3);
            //Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => m.Reverse[5]);
        }
    }
}
