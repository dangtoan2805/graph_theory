using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphTheory
{
    class GraphEL
    {
        private LinkedList<Tuple<int, int>> EL;
        private int n;
        
        public GraphEL() { }

        public void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            n = Int32.Parse(reader.ReadLine());
            EL = new LinkedList<Tuple<int, int>>();
            String row = reader.ReadLine();
            while(row!=null)
            {             
                String[] line = row.Split(' ');
                EL.AddLast(Tuple.Create(Int32.Parse(line[0]), Int32.Parse(line[1])));
                row = reader.ReadLine();
            }
            reader.Close();
        }

        public void Output()
        {
            foreach( Tuple<int, int> tuple in EL)
                Console.WriteLine("{0} - {1}",tuple.Item1,tuple.Item2);
        }

        private int Degree(int k)
        {
            int count = 0;
            foreach (Tuple<int, int> i in EL)
                if (i.Item1 == k || i.Item2 == k)
                    count++;
            return count;
        }

        public void OutputDefree()
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(Degree(i)+" ");
            }
        }
    }
}
