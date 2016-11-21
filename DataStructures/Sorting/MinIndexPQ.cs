using DS.Utils;

namespace Sorting
{
    public class MinIndexPQ<T> where T : System.IComparable
    {
        private T[] keys;
        private int[] pq;
        private int[] map;
        private int n;
        public MinIndexPQ(uint capacity)
        {
            n = 1;
            this.keys = Array.CreateWithCapacity<T>(capacity+1);
            pq = Array.CreateWithCapacity<int>(capacity+1);
        }
        #region API
        public void Insert(T key)
        {
            this.keys[n] = key;
            this.pq[n] = n;
            Swim(n);
            n++;
        }
        public T DelMin()
        {
            var key = keys[pq[1]];
            Swap(1, n--, pq);
            Sink(1);
            return key;
        }
        #endregion
        private void Sink(int pos)
        {
            while (2*pos < n)
            {
                var head = keys[pq[pos]];
                var lchild = keys[pq[2 * pos]];
                var rchild = (n == (2*pos) ? default(T) : keys[pq[2 * pos]]);
                int m = 2 * pos;
                int n = m + 1;
                if(keys[pq[pos]].CompareTo(keys[pq[m]])>0)
                {
                    Swap(pos, 2 * pos, pq);
                } else if(keys[pq[pos]].CompareTo(keys[pq[n]])>0)
                {

                }

            }
        }

        private void Swim(int pos)
        {
            while(pos>0 && keys[pos/2].CompareTo(keys[pos])>0)
            {
                Swap(pos, pos/2, pq);
                pos /= 2;
            }
        }

        private void Swap(int p1, int p2, int[] arr)
        {
            var temp = arr[p1];
            arr[p1] = arr[p2];
            arr[p2] = temp;
        }
    }
}
