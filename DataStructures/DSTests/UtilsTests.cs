using Xunit;
using DS.Utils;
using System;

namespace DSTests
{
    public class UtilsTests
    {
        [Fact]
        public void Create_bi_directional_dictionary()
        {
            var m = new Map<string, int>(3);
            m.Add("rajiv",1);
            m.Add("thota", 2);
            m.Add("fullname",3);
            Assert.Equal(m.Reverse[1], "rajiv");
            Assert.Equal(m.Reverse[2], "thota");
            Assert.Equal(m.Forward["fullname"], 3);
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => m.Reverse[5]);
        }
    }
}
