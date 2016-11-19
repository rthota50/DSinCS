using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace DSinCS.Utils
{
    public static class Printme
    {
        private static void OutLine(string s) => Console.WriteLine(s);
        private static void Out(string s) => Console.Write(s);

        public static void ToConsole<K,V>(this Dictionary<K,V> map)
        {
            foreach(var kv in map)
            {
                if(kv.Value.GetType().GetMethod("ToConsole") != null)
                {
                    dynamic v = kv.Value;
                    OutLine($"{kv.Key} => {v.ToConsole}");
                }
                else 
                { 
                    OutLine($"{kv.Key} => {kv.Value}");
                }
            }
        }

        public static void ToConsole<T>(this List<T> l)
        {
            OutLine($"[{string.Join(",", l)}]");
        }
    }
}