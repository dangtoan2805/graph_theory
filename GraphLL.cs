using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphTheory
{
    class GraphLL
    {
        private LinkedList<int>[] LinkedList;
        private int n;

        public GraphLL() { }

        public void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            n = Int32.Parse(reader.ReadLine());
            LinkedList = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                String[] line = reader.ReadLine().Split();
                LinkedList<int> ls = new LinkedList<int>();
                foreach (String s in line)
                {
                    if (s != "")
                        ls.AddLast(Int32.Parse(s)-1);                       
                }
                LinkedList[i] = ls;
            }
            reader.Close();
        }

        public void Output()
        {
            foreach (LinkedList<int> i in LinkedList)
            {
                foreach (int k in i)
                    Console.Write(k + " ");
                Console.WriteLine();
            }
        }

        private int Degree(int x)
        {
            return LinkedList[x].Count;
        }

        public void OutputDegree()
        {
            
        }

        public void BFS(int x, ref bool[] visited)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(x);
            visited[x] = true;
            while (q.Count!=0)
            {
                x = q.Dequeue();
                Console.Write(x+1 + " ");
                foreach (int u in LinkedList[x])
                    if (visited[u] != true)
                    {
                        q.Enqueue(u);
                        visited[u] = true;
                    }
            }

        }

        public void OutputBFS()
        {
            bool[] visted = new bool[n];
            List<int> output = new List<int>();
            //BFS(2,7, ref visted);
            DFS(2,7,ref visted,ref output);
        }

        public void BFS(int x, int y, ref bool[] visited)
        {
            visited[x] = true;
            Queue<int> q = new Queue<int>();
            q.Enqueue(x);
            while (q.Count != 0)
            {
                x = q.Dequeue();
                Console.Write(x + 1 + " ");
                foreach(int u in LinkedList[x])
                    if (visited[u] != true)
                    {
                        q.Enqueue(u);
                        visited[u] = true;
                    }
            }
        }

        public void DFS(int x, ref bool[] visited,ref List<int> list)
        {          
            if(visited[x]!=true)
            {
                visited[x] = true;
                list.Add(x);
                foreach (int u in LinkedList[x])
                    DFS(u, ref visited,ref list);
            }
        }

        public void DFS(int x,int y, ref bool[] visited, ref List<int> list)
        {
            if (visited[x] != true)
            {
                visited[x] = true;
                list.Add(x);
                if(x!=y)
                    foreach (int u in LinkedList[x])
                        DFS(u, ref visited, ref list);
            }
        }

        public void DFSstack(int x, ref bool[] visited)
        {

        }

        public bool Eluer()
        {
            bool[] visited = new bool[n];
            List<int> ls = new List<int>();
            DFS(0, ref visited, ref ls);
            for(int i = 0; i < n; i++)
            {
                if (Degree(i) % 2 != 0 || !visited[i])
                {
                    Console.WriteLine("- No Euler Graph");
                    return false;
                }
                    
            }
            Console.Write("Euler Graph: ");
            foreach(int i in ls)
                Console.Write(i+" ");
            return true;         
        }

    }
}
