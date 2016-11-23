using DS.Utils;

namespace Sorting
{
    public class MinIndexPQ<T> where T : System.IComparable
    {
        private T[] keys;
        private int[] pq;
        //private int[] map;
        private int N = 1;
        public MinIndexPQ(uint capacity)
        {
            this.keys = Array.CreateWithCapacity<T>(capacity + 1);
            pq = Array.CreateWithCapacity<int>(capacity + 1, -1);
        }
        #region API
        public void Insert(T key)
        {
            this.keys[N] = key;
            this.pq[N] = N;
            Swim(N);
            N++;
        }
        public T DelMin()
        {
            var key = keys[pq[1]];
            keys[pq[1]] = default(T);
            Swap(1, --N, pq);
            Sink(1);
            pq[N] = -1;
            return key;
        }
        #endregion

        #region Infrastructure
        public void Sink(int pos)
        {
            while (2 * pos < N)
            {
                int m = 2 * pos;
                if (m + 1 < N && keys[pq[m]].CompareTo(keys[pq[m + 1]]) > 0)
                {
                    m = m + 1;
                }
                if (keys[pq[m]].CompareTo(keys[pq[pos]]) < 0)
                {
                    Swap(m, pos, pq);
                }
                else
                {
                    break;
                }
                pos = m;
            }
        }

        public void Swim(int pos)
        {
            while (pos > 1 && keys[pos / 2].CompareTo(keys[pos]) > 0)
            {
                Swap(pos, pos / 2, pq);
                pos /= 2;
            }
        }

        private void Swap(int p1, int p2, int[] arr)
        {
            var temp = arr[p1];
            arr[p1] = arr[p2];
            arr[p2] = temp;
        }
        #endregion
    }
}
