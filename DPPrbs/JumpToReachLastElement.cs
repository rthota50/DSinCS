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
	
	public static void Test()
	{
		var a = new int[]{2,3,1,1,4};
		var prbs = new ReachLastElement();
		var res = prbs.OptimalJumps(a);
		Console.WriteLine(res);
		var b = new int[]{1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9};
		var res2 = prbs.OptimalJumps(b);
		Console.WriteLine(res2);		
	}
}