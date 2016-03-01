using System;
public class IncreasingSubSequence
{
	public int Solve(int[] a, int size)
	{
		var count = 0;
		count = FindSum(a, 1, 0, 1, size);
		return count;
	}
	
	private int FindSum(int[] a,int curr, int prev, int tot, int size)
	{
		Console.WriteLine("Tot {0} Size {1}", tot, size);		
		if(size == tot)
		{
			Console.WriteLine("Yay hit");
			return 1;
		}
		int count = 0;
		for(int i=curr; i<a.Length; i++)
		{
			if(a[i] > a[prev])
			{
				Console.WriteLine("curr {0} prev {1}",a[i], a[prev]);
				count += FindSum(a, i+1, i, tot+1, size);
			}
		}
		return count;
	}
	public static void Test()
	{
		var arr = new int[]{1,2,3,4};
		var prb = new IncreasingSubSequence();
		var size = 3;
		var res = prb.Solve(arr, size);
		Console.WriteLine(res);
	}
}