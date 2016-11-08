using System;
using System.Collections.Generic;
using System.Linq;
public class NumberSpell
{
	private List<string> nums, plural, teen, decs;
	public NumberSpell()
	{
		nums = new List<string>(){"One","Two","Three","Four","Five","Six","Seven","Eight","Nine"};
		teen = new List<string>(){"eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","ninteen"};
		plural = new List<string>(){"Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninty"};
		decs = new List<string>(){"Hundred","Thousand","Million"};
	}
	public string Spell(int num)
	{
		string res = string.Empty;;
		int loop = 0;
		while(num > 0)
		{
			if(loop>0 && num%1000>0)
			{
				res = decs[loop] + res;
			}
			res = PrintThreeNums(num%1000) + res;
			
			num = num / 1000;
			loop++;
		}
		return res;
	}
	private string PrintThreeNums(int num)
	{
		//var numChar = Array.ConvertAll(num.ToString().ToCharArray(), (x) => Convert.ToInt32(x));
		string res = string.Empty;
		int prev = -1;
		int pos = 0;
		while(num >0 && num%10 >= 0)
		{
			int curr = num % 10;
			if(curr != 0)
			{			
				if(pos==0)
				{
					res = nums[curr-1];
				}
				else if(curr == 1 && pos == 1)
				{
					//Console.WriteLine(prev);
					res = teen[prev-1];
				}
				else if(pos == 2)
				{
					res = nums[curr-1] + decs[pos-2]+res;
				}
				else
				{
					res = plural[curr-2] + res;
				}
			}
			prev = curr;
			pos++;
			num = num/10;
		}
		
		return res;
	}
	public static void Test()
	{
		int t = 900000009;
		var prb = new NumberSpell();
		Console.WriteLine("{0} - > {1}",t.ToString(),prb.Spell(t));
	}
}