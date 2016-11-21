using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Utils
{
    public class Map<K1, K2>
    {
        private Dictionary<K1, K2> forward;
        private Dictionary<K2, K1> reverse;
        public Indexer<K1, K2> Forward;
        public Indexer<K2, K1> Reverse;
        public int Count { get { return forward.Count; }  }
        public Map()
        {
            this.forward = new Dictionary<K1, K2>();
            this.reverse = new Dictionary<K2, K1>();
            Forward = new Indexer<K1,K2>(this.forward);
            Reverse = new Indexer<K2,K1>(this.reverse);
        }

        public void Add(K1 key, K2 val)
        {
            forward.Add(key, val);
            reverse.Add(val, key);
        }

        public struct Indexer<T1, T2>
        {
            private Dictionary<T1, T2> dict;
            public Indexer(Dictionary<T1, T2> dict)
            {
                this.dict = dict;
            }
            public T2 this[T1 key]
            {
                get { return dict[key]; }
            }
            public bool ContainsKey(T1 key) => dict.ContainsKey(key);
        }

    }
}
