using Sorting;
using NUnit.Framework;

namespace DSTests
{
	[TestFixture]
    public class SortingTests
    {
		[TestCase]
        public void Min_index_priority_queue()
        {
            var p = new MinIndexPQ<string>(10);
            p.InsertKey(5,"a");
            p.InsertKey(4,"b");
            p.InsertKey(3,"c");
            p.InsertKey(2,"d");
            p.InsertKey(1,"e");
            p.InsertKey(0,"f");

            Assert.AreEqual(p.DelMinKey(), "a");
            Assert.AreEqual(p.DelMinKey(), "b");
            Assert.AreEqual(p.DelMinKey(), "c");
            Assert.AreEqual(p.DelMinKey(), "d");
            Assert.AreEqual(p.DelMinKey(), "e");
        }

        [TestCase]
        public void Min_priority_queue()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            Assert.AreEqual("5", string.Join(",", p.CurrentPQ()));

            p.Insert(4);
            Assert.AreEqual("4,5", string.Join(",", p.CurrentPQ()));

            p.Insert(99);
            Assert.AreEqual("4,5,99", string.Join(",", p.CurrentPQ()));

            p.Insert(14);
            Assert.AreEqual("4,5,99,14", string.Join(",", p.CurrentPQ()));

            p.Insert(0);
            Assert.AreEqual("0,4,99,14,5", string.Join(",", p.CurrentPQ()));
        }

        [TestCase]
        public void Min_pq_delete_tests()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            p.Insert(4);
            p.Insert(99);
            p.Insert(14);
            p.Insert(0);
            Assert.AreEqual(0, p.DelMin());
            Assert.AreEqual(4, p.DelMin());
            Assert.AreEqual(5, p.DelMin());
            Assert.AreEqual(14, p.DelMin());
            Assert.AreEqual(99, p.DelMin());
        }

        
    }
}
