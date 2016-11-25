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
            p.InsertKey(5,"a");
            p.InsertKey(4,"b");
            p.InsertKey(3,"c");
            p.InsertKey(2,"d");
            p.InsertKey(1,"e");
            p.InsertKey(0,"f");
            Assert.Equal(p.DelMinKey(), "a");
            Assert.Equal(p.DelMinKey(), "b");
            Assert.Equal(p.DelMinKey(), "c");
            Assert.Equal(p.DelMinKey(), "d");
            Assert.Equal(p.DelMinKey(), "e");
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
