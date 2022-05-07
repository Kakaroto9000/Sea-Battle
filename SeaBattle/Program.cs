using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Program 
    {
        static Player player1 = new Player();
        static Player player2 = new Player();
        static Arena arena1 = new Arena();
        static Arena arena2 = new Arena();
        static void Main(string[] args)
        {
            PreGameSetup();
            while (player2.GameEndCheck(arena1) == false)
            {
                PlayerTurn(player1, ref arena1, ref arena2);
                if (player1.GameEndCheck(arena2) == true)
                    break;
                PlayerTurn(player2, ref arena2, ref arena1);
            }
            if (player2.GameEndCheck(arena1) == false)
            {
                PostGame();
                Console.WriteLine("Player 1 Win");
            }
            else
            {
                PostGame();
                Console.WriteLine("Player 2 Win");
            }
            Console.ReadLine();
        }
        static void PlayerTurn(Player player,ref Arena arena,ref Arena enemyarena)
        {
            player.TurnEnd = false;
            Console.Clear();
            arena.reveal(arena.arena);
            arena.reveal(arena.YourShoots);
            while(player.TurnEnd == false && player.GameEndCheck(enemyarena)==false)
            {
                player.Turn(ref arena,ref enemyarena);
                Console.Clear();
                arena.reveal(arena.arena);
                arena.reveal(arena.YourShoots);
            }

            Console.WriteLine("Press ENTER to end turn");
            Console.ReadLine();
        }
        static void PreGameSetup()
        {
            ArenasCreations(ref arena1);
            ArenasCreations(ref arena2);
        }
        static void ArenasCreations(ref Arena arena)
        {
            arena.ArenaCreator(ref arena.arena);
            arena.ArenaCreator(ref arena.YourShoots);
            arena.ShipsCreator();
        }
        static void PostGame()
        {
            Console.Clear();
            Console.WriteLine("First Player Arena");
            arena1.reveal(arena1.arena);
            Console.WriteLine("Second Player Arena");
            arena2.reveal(arena2.arena);
        }
    }
}