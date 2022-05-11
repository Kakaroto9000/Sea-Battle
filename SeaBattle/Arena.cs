using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Arena
    {
        public char[,] arena;
        public char[,] YourShoots;
        public char[,] PreviosCoardinate;

        public Ship[] Ships;
        private ShipsMoving shipsMoving = new ShipsMoving();
        static InputManager inputManager = new InputManager();

        public (int x, int y) ArenaSize = (10, 10);
        public (int x, int y) CoardinatetoShoot;

        
        public void ArenaCreator(char[,] arena)
        {
            int numberofborder = 48;
            arena = new char[ArenaSize.x, ArenaSize.y];
            for (int i = 0; i < ArenaSize.y; i++)
            {
                for (int j = 0; j < ArenaSize.x; j++)
                    if (j == 0)
                    {
                        numberofborder = 48 + i;
                        arena[0, i] = ((char)numberofborder);
                    }
                    else if (i == 0)
                    {
                        numberofborder = 48 + j;
                        arena[j, 0] = ((char)numberofborder);
                    }

                    else
                        arena[j, i] = ' ';
            }
        }
        public void ShipsCreator()
        {
            PreviosCoardinate = new char[ArenaSize.x, ArenaSize.y];
            Ships = new Ship[10];
            for (int i = 0; i < Ships.Length; i++)
            {
                Ships[i] = new Ship();
            }
            for (int i = 0; i < Ships.Length; i++)
            {
                shipsMoving.ShipCreation(i,ref Ships);
                ShipControler(i);
            }
        }
        private void ShipControler(int NumbOfShip)
        {
            for(int i = 0; i< ArenaSize.y; i++)
                for (int j = 0; j < ArenaSize.x; j++)
                    PreviosCoardinate[j,i] = arena[j,i];
            AddShipToArena(NumbOfShip);
            string Direction;
            RevealBuilderShips();
            char Input = Console.ReadKey().KeyChar;

            while ((Input != 'y' && Input != 'Y'))
            {
                Direction = CheckIsCanMoved(inputManager.Movement(Input),NumbOfShip);
                shipsMoving.ShipMove(Direction, Ships, arena, NumbOfShip,PreviosCoardinate);
                RevealBuilderShips();
                Input = Console.ReadKey().KeyChar;
            }
        }
        private void RevealBuilderShips()
        {
            Console.Clear();
            reveal(arena);
            Console.WriteLine("Move your ship by pressing W A S D. Press R to rotate. And press Y if you finished. ");
        } 
        private void AddShipToArena(int NumberOfShip)
        {
            for(int i = 0; i < Ships[NumberOfShip].lenghts; i++)
            {
                arena[1, 1 + i] = '#';
            }
        }
        private int GetShipCord(string Coardinate,int NumbOfShip)
        {
            if (Coardinate == "y")
                return Ships[NumbOfShip].Coardinate.y;
            else return Ships[NumbOfShip].Coardinate.x;
        }
        public void reveal(char[,] arena)
        {
            for (int i = 0; i < ArenaSize.y; i++)
            {
                for (int j = 0; j < ArenaSize.x; j++)
                {
                    Console.Write(arena[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public char MakeShoot(int x, int y)
        {
            if (arena[x, y] == ' ')
            {
                arena[x, y] = '?';
                return ('?');
            }
            else if (arena[x, y] == '#')
            {
                arena[x, y] = '$';
                return ('$');
            }
            else if (arena[x, y] == '$')
            {
                arena[x, y] = '$';
                return ('$');
            }
            else return '?';
        }
        public void ChangeArenaAfterShoot(int x, int y, char ShotedTile)
        {
            YourShoots[x, y] = (char)ShotedTile;
        }
        private string CheckIsCanMoved(string Direction, int NumbOfShip)
        {
            if (Direction == "Yes")
                return("Error");
            else if (Direction == "Up")
            {
                if (Ships[NumbOfShip].Coardinate.y != 1)
                    return ("Up");
                else
                {
                    Console.WriteLine("You can`t move here");
                    return ("Error");
                }
            }
            else if (Direction == "Down")
            {
                if (Ships[NumbOfShip].rotation == false)
                    if (Ships[NumbOfShip].Coardinate.y + Ships[NumbOfShip].lenghts != ArenaSize.y)
                        return ("Down");
                    else
                    {
                        return ("Error");
                    }
                else 
                    if (Ships[NumbOfShip].Coardinate.y != ArenaSize.y-1)
                        return ("Down");
                    else
                    {
                        Console.WriteLine("You can`t move here");
                        return("Error");
                    }
            }
            else if (Direction == "Left")
            {
                if (Ships[NumbOfShip].Coardinate.x != 1)
                    return ("Left");
                else
                {
                    Console.WriteLine("You can`t move here");
                    return ("Error");
                }
            }
            else if (Direction == "Right")
            {
                if (Ships[NumbOfShip].rotation == true)
                    if (Ships[NumbOfShip].Coardinate.x + Ships[NumbOfShip].lenghts != ArenaSize.x)
                        return("Right");
                    else
                    {
                        Console.WriteLine("You can`t move here");
                        return ("Error");
                    }
                else
                    if (Ships[NumbOfShip].Coardinate.x != ArenaSize.x - 1)
                        return ("Right");
                    else
                    {
                        Console.WriteLine("You can`t move here");
                        return ("Error");
                    }
            }
            else if (Direction == "Rotate")
            {
                if (Ships[NumbOfShip].rotation == false)
                    if (Ships[NumbOfShip].Coardinate.x + Ships[NumbOfShip].lenghts <= ArenaSize.x)
                        return("Rotate");
                    else
                    {
                        Console.WriteLine("You can`t move here");
                        return ("Error");
                    }
                else
                    if (Ships[NumbOfShip].Coardinate.y + Ships[NumbOfShip].lenghts <= ArenaSize.y)
                        return ("Rotate");
                    else
                    {
                    Console.WriteLine("You can`t move here");
                    return ("Error");
                    }
            }
            else
            {
                Console.WriteLine("Wrong Key");
                return ("Error");
            }
        }
    }
}
