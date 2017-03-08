using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Coins = new Dictionary<string, int>();

            Coins.Add("Aureus", 100);
            Coins.Add("Denarius", 10);
            Coins.Add("As", 1);

            foreach (KeyValuePair<string, int> coin in Coins)
            {
                Console.WriteLine($"{coin.Key} \t{coin.Value}");
                Console.ReadKey();
            }

        }

        
    }
}
