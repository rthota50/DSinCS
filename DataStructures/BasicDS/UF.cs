using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDS
{
    public class UF
    {
        private int[] id;
        private uint count;
        public UF(uint capacity)
        {
            id = DS.Utils.Array.CreateWithCapacity(capacity+1, -1);
            count = 0;
        }

        #region API
        public void Union(int p, int q)
        {
            if(id[p] == -1 && id[q] == -1)
            {
                count++;
                id[p] = p;
                id[q] = p;
            }
            else if(id[p] == -1)
            {
                id[p] = id[q];
            }
            else if(id[q] == -1)
            {
                id[q] = id[p];
            }
            else
            {
                count--;
                for(int i=1; i<id.Length; i++)
                {
                    if(id[i] == id[q]) { id[i] = id[p]; }
                }
            }
        }
        public int Find(int p)
        {
            return id[p];
        }
        public bool Connected(int p, int q) => id[p] == id[q];
        public uint Count() => count;
        
        #endregion
    }
}
