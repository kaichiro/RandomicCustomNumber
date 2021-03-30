using System;
using System.Collections.Generic;
using Lib;

namespace app
{
    class Program
    {
        static void Main(/*string[] args*/)
        {
            // NewIntRandom();
            NewDoubleRandom();
        }

        private static void NewDoubleRandom()
        {
            List<double> list = new List<double> { 1.2/*, 1.4, 1.6, 1.8, 2.1, 2.3, 2.5, 2.7, 2.9*/ };
            RandomCustomDouble randomCustomDouble = new RandomCustomDouble(StartNumber: 1, FinalNumber: 2.9, PrecisionDecimal: 1, DoublesToIgnore: list);
            Console.WriteLine(randomCustomDouble.AsString());
            double randomDoubleProcess;
            for (int i = 0; i < 20; i++)
            {
                randomDoubleProcess = randomCustomDouble.Process();
                if (list.Exists(item => item.Equals(randomDoubleProcess)))
                    Console.WriteLine($"{i} | new Double: {randomDoubleProcess} | {(!list.Exists(item => item.Equals(randomDoubleProcess)) ? "T" : "F")}");
            }
        }

        private static void NewIntRandom()
        {
            List<int> list = new List<int> {1, 3, 5, 7, 9, 12, 14, 16, 18, 20};
            RandomCustomInteger randomCustomInteger = new RandomCustomInteger(StartNumber: 0, FinalNumber: 20, IntsToIgnore: list);
            for (int i = 0; i < 100; i++)
            {
                int v = randomCustomInteger.Process();
                if (list.Exists(item => item.Equals(v))) Console.WriteLine($"{i} | {v} | {(!list.Exists(item => item.Equals(v)) ? "t": "False")}");
            }
        }
    }
}
