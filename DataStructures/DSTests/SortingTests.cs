using Xunit;
using Sorting;

namespace DSTests
{
    public class SortingTests
    {
        [Fact]
        public void Min_index_priority_queue()
        {
            var p = new MinIndexPQ<string>(10);
            p.Insert("a");
            p.Insert("b");
            p.Insert("c");
            p.Insert("d");
            p.Insert("e");
            p.Insert("f");
            Assert.Equal(p.DelMin(), "a");
            Assert.Equal(p.DelMin(), "b");
            Assert.Equal(p.DelMin(), "c");
            Assert.Equal(p.DelMin(), "d");
            Assert.Equal(p.DelMin(), "e");
        }
    }
}
