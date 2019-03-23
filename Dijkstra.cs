using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Dijkstra
    {
        private int MinDistance(int[] dist, bool[] sptSet,int n)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < n; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }
        
        public int Exec(int[,] graph, int src, int dest,ref String history)
        {
            int[] dist = new int[graph.GetLength(0)];
            String[] hist = new String[graph.GetLength(0)];

            bool[] sptSet = new bool[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
                hist[i] = "< "+src+" > ";
            }

            dist[src] = 0;
            String htmp = "";
            for (int count = 0; count < graph.GetLength(0) - 1; count++)
            {
                int u = MinDistance(dist, sptSet, graph.GetLength(0));
                sptSet[u] = true;
                htmp = hist[u];

                for (int v = 0; v < graph.GetLength(0); v++)
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                        hist[v] = htmp + v+" > ";
                    }
            }
            history = hist[dest];
            return dist[dest];
        }
    }
}
