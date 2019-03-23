using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Graph
    {
        List<Data> _datalist = new List<Data>();
        public int[,] weightArray = null;
        Dijkstra dijkstra = new Dijkstra();
        public void AddNode(Data data)
        {
            foreach(Data d in _datalist)
            {
                if (d.name == data.name || (d.xy[0] == data.xy[0] && d.xy[1] == data.xy[1]))
                {
                    Console.WriteLine("추가에 실패하였습니다.");
                    return;
                }
            }
            _datalist.Add(data);
            weightArray = GenerateWeightArray();
        }
        public void AddEdge(string from, string to,int weight)
        {
            if(from == to)
            {
                Console.WriteLine("출발지와 목적지가 같습니다.");
                return;
            }
            int? fromIndex = null; int? toIndex = null;
            for(int i = 0; i < _datalist.Count; i++)
            {
                if(_datalist[i].name == from)
                {
                    fromIndex = i;
                    break;
                }
            }
            for (int i = 0; i < _datalist.Count; i++)
            {
                if (_datalist[i].name == to)
                {
                    toIndex = i;
                    break;
                }
            }
            if(fromIndex != null && toIndex != null) // 값이 모두 정상인 경우
            {
                weightArray[(int)fromIndex, (int)toIndex] = weight;
                weightArray[(int)toIndex, (int)fromIndex] = weight;
            }
            else // 값이 하나라도 null인 경우
            {
                Console.WriteLine("간선을 있는데 실패하였습니다.");
            }
        }
        private int[,] GenerateWeightArray()
        {
            int[,] tmp = new int[_datalist.Count, _datalist.Count];
            if(weightArray != null)
            {
                for(int i = 0; i < weightArray.GetLength(0); i++)
                {
                    for(int j = 0; j < weightArray.GetLength(0); j++)
                    {
                        tmp[i, j] = weightArray[i, j];
                    }
                }
            }

            return tmp;
        }
        public void PrintWeight()
        {
            for(int i = 0; i < weightArray.GetLength(0); i++)
            {
                for(int j = 0; j < weightArray.GetLength(0); j++)
                {
                    Console.Write(weightArray[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int? Exec(int src, int dest)
        {
            String history = null;
            int? dist = (int?)dijkstra.Exec(weightArray, src, dest,ref history);
            for(int i = 0; i < _datalist.Count;i++)
            {
                history = history.Replace(i+"",_datalist[i].name);
            }
            Console.WriteLine(history);
            return dist;
        }
        public int? Exec(string src, string dest)
        {
            int? srcIndex = null;
            int? destIndex = null;
            for (int i = 0; i < _datalist.Count; i++)
            {
                if (_datalist[i].name == src)
                {
                    srcIndex = i;
                    break;
                }
            }
            for (int i = 0; i < _datalist.Count; i++)
            {
                if (_datalist[i].name == dest)
                {
                    destIndex = i;
                    break;
                }
            }

            if(srcIndex != null && destIndex != null)
            {
                return Exec((int)srcIndex, (int)destIndex);
            }
            else
            {
                return null;
            }

        }
    }
}
