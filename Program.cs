using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipML = "MATRIX.INP";
            string ipLL = "DATA.INP";
            string ipEL = "EDGE.INP";
            
            GraghML mL = new GraghML();
            mL.ReadFile(ipML);
            mL.Output();
            mL.IsEuler();
            

            /*
            GraphLL ll = new GraphLL();
            ll.ReadFile(ipLL);
            ll.Output();
            Console.WriteLine();
            ll.Eluer();
            */
            

            /*
            GraphEL el = new GraphEL();
            el.ReadFile(ipEL);
            el.Output();
            Console.WriteLine();
            el.OutputDefree();
            */
            
            

         
        }
    }
}
