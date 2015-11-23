using System;
public class MaxElemDiff
{
	/*Given an array arr[] of integers, find out the difference between any two elements 
	such that larger element appears after the smaller number in arr[]. 
	*/
	//brute force method O(n*n)
	public int GetMaxDiff_BF(int[] arr)
	{
		int res = int.MinValue;
		for(int i=0; i<arr.Length; i++)
		{
			int j=i++;
			var n = arr[j];
			while(n > arr[j++])
			{
				if(j==arr.Length) break;
			}
			for(; j<arr.Length; j++)
			{
				if(arr[j]>n)
				{
					res = Math.Max(res, arr[j]-n);
				}
			}
		}
		return res;
	}
	
	public int GetMaxDiff(int[] arr)
	{
		int maxDiff = int.MinValue;
		int minSoFar = arr[0];
		
		for(int i=1; i<arr.Length; i++)
		{
			maxDiff = Math.Max(maxDiff, arr[i]-minSoFar);
			minSoFar = Math.Min(minSoFar, arr[i]);			
		}
		return maxDiff;
	}
	
	//Alternative approach - geeksforgeeks.org
	/*First find the difference between the adjacent elements of the array 
	and store all differences in an auxiliary array diff[] of size n-1. 
	Now this problems turns into finding the maximum sum subarray of this difference array.
	*/
	public static void Test()
	{
		var prb = new MaxElemDiff();
		var arr = new int[]{1, 2, 90, 10, 110};
		Console.WriteLine(prb.GetMaxDiff_BF(arr));	
		Console.WriteLine(prb.GetMaxDiff(arr));	
	}
}