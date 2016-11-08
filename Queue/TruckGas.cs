using System;
using System.Collections.Generic;
using System.IO;
public class TruckGas
{
	public int FindStart(int[] gas, int[] dist)
	{
		int start_pt = 0;
        int remGas =0;
		var q = new Queue<int>(gas.Length);
		int N = gas.Length;
        for(int i=0; i<N; i++)
        {
            remGas += gas[i]-dist[i]; 
            q.Enqueue(gas[i]-dist[i]);            
            while(remGas < 0 && q.Count > 0)
            {
                remGas -= q.Dequeue();
                start_pt++;
            }
        }
        return start_pt > N-1 ? -1 : start_pt;
	}
	public static void Test()
	{
		using(var file = File.OpenText(@"/Users/rajivthota/dev/DSinCS/Queue/truck_input.txt"))
		{
			var T = int.Parse(file.ReadLine());
			var gas = new int[T];
			var dist = new int[T];
			
			string line;
			int i=0;
			while((line = file.ReadLine()) != null)
			{
				var data = line.Split(' ');
				gas[i] = int.Parse(data[0]);
				dist[i++] = int.Parse(data[1]);
			}
			Console.WriteLine("{0} {1}",gas.Length, dist.Length);
			var prb = new TruckGas();
			Console.WriteLine("Truck starts at {0}",prb.FindStart(gas, dist));
		}
	}
}