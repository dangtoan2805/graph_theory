using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class GraghML
    {
        private int n;
        private int[,] matrix;


        public GraghML() { }

        public void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            n = Int32.Parse(reader.ReadLine());
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                String[] temp = reader.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Int32.Parse(temp[j]);
                }

            }
            reader.Close();
        }

        public void Output()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int Degree(int i)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
                if (matrix[i, j] == 1)
                    count += 1;
            return count;
        }

        public Tuple<int, int>[] DegreeOutAndIn()
        {
            Tuple<int, int>[] temp = new Tuple<int, int>[n];
            for (int k = 0; k < n; k++)
            {
                int row = 0;
                int col = 0;
                for (int i = 0; i < n; i++)
                    if (matrix[i, k] == 1)
                        col += 1;
                for (int j = 0; j < n; j++)
                    if (matrix[k, j] == 1)
                        row += 1;
                temp[k] = Tuple.Create(row, col);
            }
            return temp;
        }

        public void OutDergeeOutAndIn()
        {
            foreach (Tuple<int, int> i in DegreeOutAndIn())
                Console.WriteLine("{0} - {1}", i.Item1, i.Item2);
        }

        public void DFS(int x, ref bool[] visited)
        {
            if (!visited[x])
            {
                visited[x] = true;
                for (int k = x; k < n; k++)
                    if (!visited[k] && matrix[x, k] == 1)
                        DFS(k, ref visited);
            }
        }

        public void OutDFS()
        {
            bool[] vs = new bool[n];
            DFS(0, ref vs);
        }


        public void RoadOfEuler(int s,ref List<int> ls)
        {

            for (int j = 0; j < n; j++)
                if (matrix[s, j] == 1)
                {
                    matrix[s, j] = -1;
                    matrix[j, s] = -1;
                    RoadOfEuler(j, ref ls);
                }
            ls.Add(s);
        }

        public bool IsEuler()
        {
            bool[] vs = new bool[n];
            DFS(0, ref vs);
            for (int i = 0; i < n; i++)
            {
                if (!vs[i] || Degree(i) % 2 != 0)
                {
                    Console.WriteLine("No Euler");
                    return false;
                }
            }
            Console.Write("Euler Graph: ");
            List<int> ls = new List<int>();
            RoadOfEuler(0,ref ls);
            foreach(int i in ls)
                Console.Write(i+1+" ");
            return true;
        }

    }
}
