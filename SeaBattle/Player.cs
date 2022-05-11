using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Player
    {
        private bool[,] IsPlaxeNotShooted = new bool[10,10];
        public bool IsBot = false;
        public bool TurnEnd = false;
        
        private Random Random = new Random();
        public void Turn(Arena arena,Arena enemyArena)
        {     
            (int X,int Y) = GetCordinateToShoot();
            char HittedTile = enemyArena.MakeShoot(X, Y);
            arena.ChangeArenaAfterShoot(X, Y, HittedTile);
            if (HittedTile != '$')
            {
                TurnEnd = true;
            }
        }
        private (int X, int Y) GetCordinateToShoot()
        {
            int X, Y;
            if (IsBot == false)
            {
                string InputX = Console.ReadLine();
                string InputY = Console.ReadLine();
                Console.WriteLine("Write X Cordinate from 1 to 9. And press ENTER");
                while (!int.TryParse(InputX, out X) && X < 10 && X > 0)
                {
                    Console.WriteLine("Please write number from 1 to 9.And press ENTER");
                    InputX = Console.ReadLine();
                
                }
                Console.WriteLine("Write Y Cordinate from 1 to 9. And press ENTER");
                while (!int.TryParse(InputY, out Y) && Y < 10 && Y > 0)
                {
                    Console.WriteLine("Please write number from 1 to 9.And press ENTER");
                    InputY = Console.ReadLine();
                }
                return (X, Y);
            }
            do
            {
                X = Random.Next(1, 10);
                Y = Random.Next(1, 10);
            } while (IsPlaxeNotShooted[X, Y] == true);
            IsPlaxeNotShooted[X,Y] = false;
            return (X,Y);
        }
        public bool GameEndCheck(Arena Enemyarena)
        {
            for(int i = 0; i < Enemyarena.ArenaSize.y; i++)
            {
                for (int j = 0; j < Enemyarena.ArenaSize.x; j++)
                    if (Enemyarena.arena[j, i] == '#')
                        return false;
            }
            return true;
        }
    }
}