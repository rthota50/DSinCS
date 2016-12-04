using System;
using System.Collections.Generic;
namespace Arrays
{
	public class Shortest
	{
		public static uint ShortestDistance(int[] arr, int a, int b)
		{
			if (a == b) { return 0; }
			var x = new List<uint>();
			var y = new List<uint>();
			for (uint i = 0; i < arr.Length; i++)
			{
				if (arr[i] == a) { x.Add(i); }
				else if (arr[i] == b) { y.Add(i); }
			}
			var dist = uint.MaxValue;
			var f = x.ToArray();
			var s = y.ToArray();
			for (int i = 0, j = 0; i < f.Length && j < s.Length;)
			{
				dist = Math.Min(dist, (uint)Math.Abs((int)f[i] - (int)s[j]));
				if (f[i] < s[j]) { i++; }
				else { j++; }
			}
			return dist;
		}
	}
}
