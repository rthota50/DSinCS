using Sorting;
using Xunit;

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

        [Fact]
        public void Min_priority_queue()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            Assert.Equal("5", string.Join(",", p.CurrentPQ()));

            p.Insert(4);
            Assert.Equal("4,5", string.Join(",", p.CurrentPQ()));

            p.Insert(99);
            Assert.Equal("4,5,99", string.Join(",", p.CurrentPQ()));

            p.Insert(14);
            Assert.Equal("4,5,99,14", string.Join(",", p.CurrentPQ()));

            p.Insert(0);
            Assert.Equal("0,4,99,14,5", string.Join(",", p.CurrentPQ()));
        }


        [Fact]
        public void Min_pq_delete_tests()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            p.Insert(4);
            p.Insert(99);
            p.Insert(14);
            p.Insert(0);
            Assert.Equal(0, p.DelMin());
            Assert.Equal(4, p.DelMin());
            Assert.Equal(5, p.DelMin());
            Assert.Equal(14, p.DelMin());
            Assert.Equal(99, p.DelMin());
        }
    }
}
