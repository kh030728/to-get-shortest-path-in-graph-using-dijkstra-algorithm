using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            Console.WriteLine("===================================\n Manual Input, press key 0\n Input using File press key 1 \n\n If you press another keys, \n program is terminated .\n===================================");
            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    MInput(g);
                    break;
                case '1':
                    if (FInput(g) == false) { Console.ReadLine(); return; }
                    break;
                default:
                    return;
            }
            string input;
            do
            {
                Console.WriteLine("\n Please enter two cities where you want to find   \n example) Seoul Busan \n===================================\n");
                input = Console.ReadLine();
                if(input != "0")
                {
                    try
                    {
                        string[] tmp = input.Split(' ');
                        int? t = g.Exec(tmp[0], tmp[1]);
                        if (t == null)
                        {
                            Console.WriteLine("This input is invalid.");
                        }
                        else
                        {
                            Console.WriteLine("The time required " + (int)t + " hour(s).");
                        }
                    }catch
                    {
                        Console.WriteLine(" This input is invalid.\n");
                    }

                }
            } while (input != "0");

            Console.ReadLine();
        }
        static void MInput(Graph g)
        {
            string input;
            Console.WriteLine();
            do
            {
                Console.WriteLine("\n Please enter city's name and location.\n example) Seoul 1,1");
                Console.WriteLine("\n If you want to stop manual input,\n please press key 0.\n===================================\n");
                input = Console.ReadLine();
                if (input != "0")
                {

                    try
                    {
                        string[] tmp = input.Split(new char[] { ' ', ',' });
                        g.AddNode(new Data(tmp[0], new int[] { int.Parse(tmp[1]), int.Parse(tmp[2]) }));
                    }
                    catch
                    {
                        Console.WriteLine("This input in invalid.");
                    }
                }
            } while (input != "0");
            Console.WriteLine();
            do
            {
                Console.WriteLine("\n Please enter time required between two cities. \n example) Seoul Busan 5");
                Console.WriteLine("\n If you want to stop manual input, please press key 0.");
                input = Console.ReadLine();
                if (input != "0")
                {

                    try
                    {
                        string[] tmp = input.Split(' ');
                        g.AddEdge(tmp[0], tmp[1], int.Parse(tmp[2]));
                    }
                    catch
                    {
                        Console.WriteLine("\n This input is invalid.\n");
                    }
                }
            } while (input != "0");
        }

        static bool FInput(Graph g)
        {
            Console.WriteLine(" Please Enter File path.>> ");
            String path = Console.ReadLine();
            String context;
            try
            {
                context = System.IO.File.ReadAllText(path,Encoding.Default);

            }catch
            {
                Console.WriteLine("There was a problem handling the file.");

                return false;
            }
            try
            {
                String[] tmp = context.Split('\n');
                String[] nodes = tmp[0].Split(';');
                foreach (String node in nodes)
                {
                    String[] ntmp = node.Split(new char[] { ' ', ',' });
                    g.AddNode(new Data(ntmp[0], new int[] { int.Parse(ntmp[1]), int.Parse(ntmp[2]) }));
                }
                Console.WriteLine("City input complete.");
                String[] edges = tmp[1].Split(';');
                foreach (String edge in edges)
                {
                    String[] etmp = edge.Split(' ');
                    g.AddEdge(etmp[0],etmp[1],int.Parse(etmp[2]));
                }
                Console.WriteLine("time required input complete.");
            }
            catch
            {
                Console.WriteLine("There was a problem entering the data.");
                return false;
            }

            return true;
        }
    }
}