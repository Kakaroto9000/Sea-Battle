using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Player
    {
        public bool TurnEnd = false;
        public void Turn(ref Arena arena,ref Arena enemyArena)
        {
            Console.WriteLine("Write X Cordinate from 1 to 9. And press ENTER");
            int X = GetCordinateToShoot();
            Console.WriteLine("Write Y Cordinate from 1 to 9. And press ENTER");
            int Y = GetCordinateToShoot();
            char HittedTile = enemyArena.MakeShoot(X, Y);
            arena.ChangeArenaAfterShoot(X, Y, HittedTile);
            if (HittedTile != '$')
            {
                TurnEnd = true;
            }
        }
        private int GetCordinateToShoot()
        {
            int CoardinateToShoot = Convert.ToInt32(Console.ReadLine());
            while (CoardinateToShoot > 9 || CoardinateToShoot < 1)
            {
                CoardinateToShoot = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please write number from 1 to 9.And press ENTER");
            }
            return CoardinateToShoot;
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