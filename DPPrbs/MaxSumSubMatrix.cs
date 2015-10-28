using System;
public class MaxSumSubMatrix
{
	/*
	Give a m*n matrix of positive and negative numbers, find the submatrix with maximum sum
	*/
	#region BruteForce
	public int MaxSum(int[,] m)
	{
		int sum = int.MinValue;
		int w = m.GetLength(0);
		int h = m.GetLength(1);
		for(int i=0; i<w-1; i++)
			for(int j=i+1; j<w; j++)
				for(int k=0; k<h-1; k++)
					for(int l=k+1; l<h; l++)
					{
						int s = ComputeSum(m, i,j,k,l);
						//  Console.Write(s+" ");
						if(s > sum){
							 sum = s;
							 //Console.WriteLine(i+" "+j+" "+k+" "+l);
						}
					}		
		return sum;
	}
	
	private int ComputeSum(int[,] m, int i, int j, int k, int l)
	{
		int sum = 0;
		for(int o = i; o<=j; o++)
			for(int p=k; p<=l; p++)
				sum += m[o,p];
		return sum;		
	}
	#endregion
	public static void Test()
	{
		var m = new int[,]{	{ 1, 2,-1,-4,-20},
							{-8,-3, 4, 2,  1},
							{ 3, 8,10, 1,  3},
							{-4,-1, 1, 7, -6}};	
		var prb = new MaxSumSubMatrix();
		Console.WriteLine(prb.MaxSum(m));
	}
}