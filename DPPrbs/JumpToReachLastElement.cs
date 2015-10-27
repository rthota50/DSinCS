using System;
public class ReachLastElement
{
	/*
	Find optimal number of jumps to reach last element in an array. 
	The length of this jump can be atmost the value of the element at current position
	*/
	public ReachLastElement()
	{
		this._jumps = int.MaxValue;
	}
	private int _jumps;
	#region brute force
	public int OptimalJumps(int[] a)
	{
		_jumps = int.MaxValue;	
		OptimalJumps(a, 0, 0);
		return _jumps;
	}
	
	private void OptimalJumps(int[] a, int index, int jumps)
	{
		//Console.Write("status idx {0} jmp {1} ", index, jumps);
		if(index >= a.Length)
			return;
		else if(index == a.Length-1)
		{	
			//Console.Write(" reached in {0} ",jumps);
			_jumps = Math.Min(jumps, _jumps);
			return;
		}
			
		int max = a[index];
		int i=1;
		while(i<=max)
		{
			//Console.Write(i+" ");
			OptimalJumps(a, index + i++, jumps+1);	
		}
	}
	#endregion
	
	#region dynamic programming
	/*From left find the min jumps required to reach a postion p
		2  3  1  1  4
	    ------------------
	Min  -> 0  1  1  2  2 <- Ans @ Res[n-1] where n is size of array
	*/
	public int OptimalJumps_DP1(int[] a)
	{
		int n = a.Length;
		var Res = new int[n];
		Res[0] = 0;
		for(int i=1; i<n; i++) //2
		{
			Res[i] = int.MaxValue; //[2]-> max
			for(int j=0; j<i; j++)
			{
				if(i <= j+a[j] && Res[j] != int.MaxValue)
				{
					Res[i] = Math.Min(Res[i], Res[j]+1); // int_max vs 1
					break;	
				}						
			}
		}
		return Res[n-1];
	}
	
	/*
	Solving from right to left. Find min steps to reach end from from any position
	O(n*n) in worst case
		2 3 1 1 4
	min:	2 1 2 1 0
	Soln: inspired from geekforgeeks.org
	*/
	public int MinJumps_DP2(int[] a)
	{
		int n = a.Length;
		var jumps = new int[n];
		int i=n-1;
		jumps[i] = 0; //last element
		for( i--; i>=0; i--)
		{
			
			if(a[i]==0) 
				jumps[i] = int.MaxValue;
			else if(a[i]>=n-i-1) 
				jumps[i] = 1;
			else 
			{
				int min = int.MaxValue;
				for(int j=i+1; j<n && j <= a[i]+i; j++)
				{
					if(jumps[j]<min-1) //or jumps[j]+1<min which could result in max_int overflow
						min = jumps[j]+1;
				}
				jumps[i] = min;
			}
		}
		return jumps[0];
	}
	
	
	#endregion
	public static void Test()
	{
		var a = new int[]{2,3,1,1,4};
		var prbs = new ReachLastElement();
		var res = prbs.OptimalJumps(a);
		Console.WriteLine(res);		
		var b = new int[]{1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9};
		var res2 = prbs.OptimalJumps(b);
		Console.WriteLine(res2);
		
		var res_dp1 = prbs.OptimalJumps_DP1(a);
		Console.WriteLine(res_dp1);
		var res_dp1_2 = prbs.OptimalJumps_DP1(b);
		Console.WriteLine(res_dp1_2);
		var c = new int[]{1, 3, 6, 1, 0, 9};
		var res_dp1_3 = prbs.OptimalJumps(c);
		Console.WriteLine(res_dp1_3);
		
		var res_dp2 = prbs.MinJumps_DP2(a);
		Console.WriteLine(res_dp2);
		var res_dp2_2 = prbs.MinJumps_DP2(b);
		Console.WriteLine(res_dp2_2);		
		var res_dp2_3 = prbs.MinJumps_DP2(c);
		Console.WriteLine(res_dp2_3);
			
	}
}
