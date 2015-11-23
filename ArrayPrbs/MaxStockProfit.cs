using System;
public class MaxStockProfit
{
	//stackoverflow 
	/*Reading from the end, look at price of that day. Is this the highest price so far (from the end), then sell! 
	The last day (where we start reading) you will always sell. */
	public int MaxProfit(int[] arr)
	{
		int profit = 0;
		int maxSoFar = arr[arr.Length-1];
		for(int i=arr.Length-2; i>=0; i--)
		{
			if(arr[i]<maxSoFar)
				profit += maxSoFar - arr[i];
			else
				maxSoFar = arr[i];
		}
		return profit;
	}
	
	//find the buying and selling dates
	public static void Test()
	{
		var prb = new MaxStockProfit();
		var arr = new int[]{1,1,20,1,1,1,1,50,1,13};
		Console.WriteLine(prb.MaxProfit(arr));
	}
}