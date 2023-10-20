using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib.WordOfTanks;

namespace Day7__Tanks_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tank[] t34Tanks = new Tank[5];
            Tank[] panteraTanks = new Tank[5];
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                t34Tanks[i] = new Tank("T-34_" + (i + 1), rnd.Next(0, 101), rnd.Next(0, 101), rnd.Next(0, 101));
                panteraTanks[i] = new Tank("Pantera_" + (i + 1), rnd.Next(0, 101), rnd.Next(0, 101), rnd.Next(0, 101));
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{t34Tanks[i]} vs {panteraTanks[i]}");
                bool t34Wins = t34Tanks[i] ^ panteraTanks[i];
                Console.WriteLine(t34Wins ? "T-34 Wins!" : "Pantera Wins!");
            }
            Console.ReadKey();
        }
    }
}
