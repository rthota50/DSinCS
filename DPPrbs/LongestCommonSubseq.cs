using System;
public class LongestCommonSubsequence
{
	public string Find_BF(int[] a, int[] b)
	{
		var maxSeq = string.Empty;
		var maxCur = string.Empty;
		
		return LCS(a, 0, b, 0);
		
	}
	
	public string LCS(int[] a, int ai, int[] b, int bi)
	{
		if(ai == a.Length || bi == b.Length)
			return string.Empty;
		if(a[ai] == b[bi])
			return a[ai].ToString() + LCS(a, ai+1, b, bi+1);
		else
		{
			var resA = LCS(a, ai+1, b, bi);
			var resB = LCS(a, ai, b, bi+1);
			if(resA.Length > resB.Length)
				return resA;
			return resB;
		}
	}
	
	public string LCS(int[] a, int[] b)
	{
		var lcs = new int[a.Length+1,b.Length+1];
		for(int i=0; i<=a.Length; i++)
			lcs[i,0] = 0;
		for(int i=0; i<=b.Length; i++)
			lcs[0,i] = 0;
			
		for(int i=1; i<=a.Length; i++)
		{
			for(int j=1; j<=b.Length; j++)
			{
				if(a[i-1] == b[j-1])
					lcs[i,j] = 1 + lcs[i-1,j-1];
				else
					lcs[i,j] = Math.Max(lcs[i-1,j],lcs[i,j-1]);
			}
		}
		
		//build string - traceback
		
		return Traceback(lcs, a, b, a.Length, b.Length);
	}
	
	private string Traceback(int[,] lcs, int[] a, int[] b, int i, int j)
	{
		if(i==0 || j==0)
			return string.Empty;
		else if(a[i-1] == b[j-1])
		{
			//Console.WriteLine("a : {0}, i: {1} ",a[i-1],i);
			return Traceback(lcs, a, b, i-1, j-1) + a[i-1];
		}
		else
		{
			//Console.WriteLine("i : {0}, j: {1} ",i,j);			
			//Console.WriteLine("lcs : {0}, lcs: {1} ",lcs[i-1,j],lcs[i,j-1]);			
			if(lcs[i-1,j] > lcs[i,j-1])
				return Traceback(lcs, a, b, i-1, j);
			else
				return Traceback(lcs, a, b, i, j-1);
		}
	}
	
	public static void Test()
	{
		var prb = new LongestCommonSubsequence();
		var arr = new int[]{1, 2, 3, 4, 1};
		var brr = new int[]{3, 4, 1, 1, 2, 1, 3};
		Console.WriteLine(prb.Find_BF(arr,brr));
		Console.WriteLine(prb.LCS(arr,brr));
	}
}