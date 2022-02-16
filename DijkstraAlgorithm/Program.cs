using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ASD5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("duzy_in.txt");
            string[] dimensions = lines[0].Split(" ");
            int width = int.Parse(dimensions[0]);
            List<List<int[]>> adjacencyList = new List<List<int[]>>();
            for (int i = 0; i <= width; i++)
            {
                adjacencyList.Add(new List<int[]>());
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string c = lines[i];
                string[] d_c = c.Split(" ");
                int[] zw = new int[2];
                zw[0] = int.Parse(d_c[1]);
                zw[1] = int.Parse(d_c[2]);
                adjacencyList[int.Parse(d_c[0])].Add(zw);
                int[] dw = new int[2];
                dw[0] = int.Parse(d_c[0]);
                dw[1] = int.Parse(d_c[2]);
                adjacencyList[int.Parse(d_c[1])].Add(dw);
            }
            int[] dist = new int[width];
            bool[] QS = new bool[width];
            int[] p = new int[width];


            for (int i = 0; i < width; i++)
            {
                dist[i] = int.MaxValue;
                QS[i] = false;
                p[i] = -1;
            }

            dist[0] = 0;
            Queue<int> MyQ = new Queue<int>();
            MyQ.Enqueue(1);
            while (MyQ.Count() != 0)
            {
                var v = MyQ.Dequeue();
                QS[v - 1] = true;
                List<int[]> list = new List<int[]>(adjacencyList[v]);
                foreach (var arr in list)
                {
                    bool time = QS[arr[0] - 1];
                    if (time == true)
                    {
                        continue;
                    }
                    int cost = arr[1];
                    if (dist[v - 1] + cost < dist[arr[0] - 1])
                    {
                        dist[arr[0] - 1] = dist[v - 1] + arr[1];
                        p[arr[0] - 1] = v;
                        MyQ.Enqueue(arr[0]);
                    }
                }
            }
            Console.WriteLine(dist[width - 1]);
        }
    }
}
