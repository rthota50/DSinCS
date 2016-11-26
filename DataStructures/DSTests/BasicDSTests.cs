using Xunit;
using BasicDS;

namespace DSTests
{
    public class BasicDSTests
    {
        [Fact]
        public void UF_basic_tests()
        {
            var uf = new DisjointSet(10);
            uf.Union(7, 2);
            uf.Union(2, 5);
            uf.Union(2, 1);
            uf.Union(7, 6);
            uf.Union(3, 4);
            uf.Union(4, 0);
            Assert.Equal(uf.Count, (uint)4);
            uf.Union(8, 9);
            Assert.Equal(uf.Count, (uint)3);
            uf.Union(8, 3);
            Assert.Equal(uf.Count, (uint)2);
            uf.Union(2, 3);
            Assert.Equal(uf.Count, (uint)1);
            Assert.True(uf.Connected(1, 2));
            Assert.True(uf.Connected(3, 2));
            Assert.True(uf.Connected(8, 9));
            Assert.True(uf.Connected(7, 0));
        }
    }
}
