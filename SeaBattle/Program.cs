using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Program 
    {
        static Game game = new Game();

        static int FirstPlayerWins = 0;
        static int SecondPlayerWins = 0;
        static void Main(string[] args)
        {
            int NumberOfRounds = GetNumberOfRounds();
            for (int i = 0; i < NumberOfRounds; i++)
            {
                int Whowin = game.StartRound();
                AddWins(Whowin);
                if (FirstPlayerWins*2 > NumberOfRounds || SecondPlayerWins*2 > NumberOfRounds)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("{0} = First player wins", FirstPlayerWins);
            Console.WriteLine("{0} = Second player wins", SecondPlayerWins);
            Console.ReadLine();
        }
        static  void AddWins(int Whowin)
        {
            if (Whowin == 1) 
                FirstPlayerWins++;
            if (Whowin == 2)
                SecondPlayerWins++;
        }
        static int GetNumberOfRounds()
        {
            Console.WriteLine("Write Number Of Matches");
            string Input = Console.ReadLine();
            int Result;
            while (!int.TryParse(Input, out Result))
            {   
                Console.WriteLine("Write Number Of Matches");
                Input = Console.ReadLine();
            }
            return Result;
        }
    }
}