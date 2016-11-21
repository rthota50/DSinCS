using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Utils
{
    public static class Utils
    {
        public static void PopulateWith<T>(this T[] arr, T value )
        {
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = value;
            }
        }
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> enr)
        {
            var list = enr.ToList();
            list.Sort();
            return list.AsEnumerable();
        }
    }

    public class Array
    {
        public static T[] CreateEmpty<T>()
        {
            return new T[0];
        }

        public static T[] CreateWithCapacity<T>(uint size) => new T[size];
        public static T[] CreateWithCapacity<T>(uint size, T defaultVal)
        {
            var arr = new T[size];
            for(int i=0; i<size; i++)
            {
                arr[i] = defaultVal;
            }
            return arr;
        }
    }
}
