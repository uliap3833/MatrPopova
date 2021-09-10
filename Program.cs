using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Proga Calc = new Proga("InputData.csv", "OutputData.txt");
            Calc.CalcStart();
        }
    }
}
