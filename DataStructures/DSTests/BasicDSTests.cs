using Xunit;
using BasicDS;

namespace DSTests
{
    public class BasicDSTests
    {
        [Fact]
        public void UF_basic_tests()
        {
            var uf = new UF(5);
            uf.Union(1, 2);
            uf.Union(3, 4);
            uf.Union(1, 5);
            Assert.Equal(uf.Count(), (uint)2);
            Assert.Equal(uf.Find(1), 1);
        }
    }
}
