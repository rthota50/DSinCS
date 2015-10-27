using System;
public class MinSumSubMatrix
{
	/*
	Give a m*n matrix of positive and negative numbers, find the submatrix with maximum sum
	*/
	#region BruteForce
	public int MaxSum(int[,] m)
	{
		
	}
	#endregion
	public static void Test()
	{
		var m = new int[,]{{1,2,-1,-4,-20},{-8,-3,4,2,1},{-4,-1,1,7,-6}};	
		var prb = new MinSumSubMatrix();
		Console.WriteLine(prb.MaxSum(m));
	}
}