using System;
using NUnit.Framework;
using Arrays;

namespace DSTests
{
	[TestFixture]
	public class ArrayTests
	{
		[TestCase]
		public void find_shortest_distance_between_two_elements()
		{
			var arr = new int[] { 1, 9, 2, 5, 8, 4, 7, 8, 9, 5, 3, 2, 1, 1, 4, 8, 6 };
			int a = 5;
			int b = 6;
			var dist = Shortest.ShortestDistance(arr, a, b);
			Assert.AreEqual(7, dist);
		}
	}
}
