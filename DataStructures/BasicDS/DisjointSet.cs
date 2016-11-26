using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDS
{
    public class DisjointSet
    {
        private uint[] parent;
        private uint[] rank;
        public uint Count { get; private set; }
        public DisjointSet(uint capacity)
        {
            parent = DS.Utils.Array.CreateWithCapacity<uint>(capacity);
            rank = DS.Utils.Array.CreateWithCapacity<uint>(capacity, (uint)0);
            for(uint i=0; i<parent.Length; i++)
            { parent[i] = i; }
            Count = capacity;
        }

        #region API
        public void Union(uint p, uint q)
        {
            var ip = Find(p);
            var iq = Find(q);
            if (ip == iq) { return; }
            if (rank[p] < rank[q])
            {
                parent[ip] = iq;
            }
            else if(rank[p] > rank[q])
            {
                parent[iq] = ip;
            }
            else
            {
                parent[ip] = iq;
                rank[iq]++;
            }
            Count--;
        }
        public uint Find(uint p)
        {
            while(parent[p] != p)
            {
                parent[p] = parent[parent[p]]; //half compression
                p = parent[p];
            }
            return p;
        }
        //full compressoin
        public uint FindFullCompression(uint p)
        {
            if(parent[p] != p)
            {
                var res = FindFullCompression(parent[p]);
                parent[p] = res;
                return res;
            }
            return p;
        }
        public bool Connected(uint p, uint q) => Find(p) == Find(q);

        #endregion
    }
}
