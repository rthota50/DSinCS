using System;
public class MaxSqurareInMatrix
{
	/*
	Give a matrix of 0's and 1's , find the maximum size sqaure sub-matrix with 1's.
	1,1,0,1,0
	0,1,1,1,0
	1,1,1,1,0
	1,1,1,1,1
	0,0,0,0,0
	should give
	1 1 1
	1 1 1
	1 1 1
	*/
	//Brute force solution
	public void FindMaxSquare(int[,] M)
	{
		//l,r,t,b => left, right, top, bottom
		int ml=0, mr=0, mt=0, mb=0;
		int width = M.GetLength(1), height = M.GetLength(0);
		for(int l=0; l<width; l++)
			for(int r=l+1; r<width; r++)
				for(int t=0; t<height; t++)
					for(int b=t+1; b<height; b++)
					{
						if(IsValidMatrix(M,l,r,t,b) && ((mr-ml)+(mb-mt))<((r-l)+(b-t)))
						{
							mr = r; mt = t; mb = b; ml = l;
						}
					}
		Console.WriteLine("{0} {1} {2} {3}",ml, mr, mt, mb);
	}
	
	//dynamic programming
	/*
	The idea of the algorithm is to construct an auxiliary size matrix S[][] 
	in which each entry S[i][j] represents size of the square sub-matrix
	*/
	public void FindMaxSquare_DP(int[,] M)
	{
		int m = M.GetLength(0); //width
		int n = M.GetLength(1); //height
		var S = new int[m,n];
		int mSize = int.MinValue, mI=-1, mJ=-1;
		for(int i=0; i<m; i++)
			for(int j=0; j<n; j++)
			{
				if(i==0 || j==0)
					S[i,j] = M[i,j];
				else if(M[i,j] == 1)
				{
					S[i,j] = Math.Min(S[i-1,j-1],Math.Min(S[i-1,j],S[i,j-1]))+1;
					if(mSize<S[i,j])
					{
						mSize = S[i,j];
						mI = i; mJ = j;
					}
				}
				else
					S[i,j] = 0;
			}
		Console.WriteLine("Size : {0} Right-Bottom Postition {1},{2}",mSize, mI, mJ);		
	}
	
	private bool IsValidMatrix(int[,] M, int l, int r, int t, int b)
	{
		for(int i=l; i<=r; i++)
			for(int j=t; j<=b; j++)
			{
				if(M[i,j] != 1)
				{
					return false;
				}
			}
		return true;	
	}
	
	public static void Test()
	{
		var M = new int[,]
		{
			{1,1,1,1,1},
			{0,1,1,1,1},
			{1,1,1,1,1},
			{1,1,1,1,0},
			{0,0,0,0,0}	
		};
		var N = new int[,]
		{
			{0, 1, 1, 0, 1}, 
            {1, 1, 0, 1, 0}, 
            {0, 1, 1, 1, 0},
	        {1, 1, 1, 1, 0},
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0}
		};
		MaxSqurareInMatrix prbs = new MaxSqurareInMatrix();
		prbs.FindMaxSquare(M);
		prbs.FindMaxSquare_DP(M);
		prbs.FindMaxSquare_DP(N);
	}
}