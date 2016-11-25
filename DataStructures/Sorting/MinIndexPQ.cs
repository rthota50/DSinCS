using DS.Utils;

namespace Sorting
{
    public class MinIndexPQ<T> where T : System.IComparable
    {
        private T[] keys;
        private int[] pqIndex;
        private int[] keyMap; //required for ChangeKey() method
        private int N = 1;
        public MinIndexPQ(uint capacity)
        {
            keys = Array.CreateWithCapacity<T>(capacity + 1);
            pqIndex = Array.CreateWithCapacity<int>(capacity + 1, -1);
            keyMap = Array.CreateWithCapacity<int>(capacity + 1);
        }
        #region API
        public void InsertKey(int position, T key)
        {
            keys[position] = key;
            pqIndex[N] = (int)position;
            keyMap[position] = N;
            Swim(N, pqIndex, keys, keyMap);
            N++;
        }
        public void ChangeKey(int position, T key)
        {
            keys[position] = key;
            Swim(position, pqIndex, keys, keyMap);
            Sink(position, pqIndex, keys, keyMap);
        }
        public uint MinIndex()
        {
            return (uint)pqIndex[1];
        }
        public T DelMinKey()
        {
            var key = keys[pqIndex[1]];
            keys[pqIndex[1]] = default(T);
            keyMap[pqIndex[1]] = -1;
            Swap(1, --N, pqIndex);
            Sink(1, pqIndex, keys, keyMap);
            pqIndex[N] = -1;
            return key;
        }
        public int DelMin()
        {
            var min = pqIndex[1];
            DelMinKey();
            return min;
        }
        public T MinKey() => keys[pqIndex[1]];
        public bool IsEmpty() => N == 1;
        public bool Contains(int i) => keyMap[i] == -1;

        #endregion

        #region Infrastructure
        private void Sink(int pos, int[] pq, T[] keys, int[] map)
        {
            while (2 * pos < N)
            {
                var m = 2 * pos;
                if (m + 1 < N && keys[pq[m]].CompareTo(keys[pq[m + 1]]) > 0)
                {
                    m = m + 1;
                }
                if (keys[pq[m]].CompareTo(keys[pq[pos]]) < 0)
                {
                    Swap(m, pos, pq);
                    Swap(pq[m], pq[pos], map);
                }
                else
                {
                    break;
                }
                pos = m;
            }
        }

        private void Swim(int pos, int[] pq, T[] keys, int[] map)
        {
            while (pos > 1 && keys[pq[pos / 2]].CompareTo(keys[pq[pos]]) > 0)
            {
                Swap(pos, pos / 2, pq);
                Swap(pq[pos], pq[pos / 2], map);
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
