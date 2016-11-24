using System;

namespace Sorting
{
    public class MinPQ<T> where T : IComparable
    {
        private T[] pq;
        private uint N;
        #region Constructor
        public MinPQ(uint capacity)
        {
            N = 1;
            pq = DS.Utils.Array.CreateWithCapacity(capacity + 1, default(T));
        }
        #endregion

        #region API
        public void Insert(T key)
        {
            pq[N] = key;
            Swim(N++, pq);
        }

        public T DelMin()
        {
            var ret = pq[1];
            pq[1] = pq[N - 1];
            pq[N - 1] = default(T);
            N--;
            Sink(1, pq);
            return ret;
        }

        public T[] CurrentPQ()
        {
            var res = new T[N - 1];
            Array.Copy(pq, 1, res, 0, N - 1);
            return res;
        }

        public T Peek()
        {
            return pq[1];
        }
        #endregion

        private void Swim(uint pos, T[] pq)
        {
            while (pos > 1 && pq[pos].CompareTo(pq[pos / 2]) < 0)
            {
                Swap(pos, pos / 2, pq);
                pos = pos / 2;
            }
        }

        private void Sink(uint pos, T[] pq)
        {
            while (2 * pos < N)
            {

                var left = 2 * pos;
                var right = left + 1;
                var other = left;

                if (right < N && pq[left].CompareTo(pq[right]) > 0)
                {
                    other = right;
                }
                if (pq[other].CompareTo(pq[pos]) < 0)
                {
                    Swap(pos, other, pq);
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(uint a, uint b, T[] arr)
        {
            var tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

    }
}
