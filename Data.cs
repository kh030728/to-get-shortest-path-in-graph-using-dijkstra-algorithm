using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Data
    {
        public string name;
        public int[] xy = new int[2];
        public Data(string name, int[] xy)
        {
            this.name = name;
            this.xy = xy;
        }
        
    }
}
