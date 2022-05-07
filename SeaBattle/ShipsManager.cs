using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class ShipsManager
    {
        public void ShipCreation(int i, ref Ship[] Ships)
        {
            Ships[i].rotation = false;
            if (i < 4)
                Ships[i].lenghts = 1;
            else if (i < 7)
                Ships[i].lenghts = 2;
            else if (i < 9)
                Ships[i].lenghts = 3;
            else
                Ships[i].lenghts = 4;
        }
        public void ShipMove(string Direction,ref Ship[] Ships,ref char[,] arena,int NumbOfShip,char[,] PreviosCoardinate)
        {
            (int x, int y) = Ships[NumbOfShip].Coardinate;
            int lenght = Ships[NumbOfShip].lenghts;
            bool rotation = Ships[NumbOfShip].rotation;
            if (Direction == "Up")
            {
                if (rotation == true)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x + j, y - 1] = '#';
                        arena[x + j, y] = PreviosCoardinate[x + j, y];
                    }   
                    Ships[NumbOfShip].Coardinate = (x, y - 1);
                }
                else
                {
                    arena[x, y + lenght - 1] = PreviosCoardinate[x, y + lenght - 1];
                    arena[x, y - 1] = '#';
                    Ships[NumbOfShip].Coardinate = (x, y - 1);
                }
            }
            else if (Direction == "Down")
            {
                if (rotation == true)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x + j, y + 1] = '#';
                        arena[x + j, y] = PreviosCoardinate[x + j, y];
                        Ships[NumbOfShip].Coardinate = (x, y + 1);
                    }
                }
                else 
                {
                    arena[x, y] = PreviosCoardinate[x, y];
                    arena[x, y + lenght] = '#';
                    Ships[NumbOfShip].Coardinate = (x, y + 1);
                }
            }
            else if (Direction == "Left")
            {
                if (rotation == true)
                {
                    arena[x - 1 , y] = '#';
                    arena[x +lenght - 1, y] = PreviosCoardinate[x + lenght - 1, y];
                    Ships[NumbOfShip].Coardinate = (x - 1 , y);
                }
                else 
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x, y + j] = PreviosCoardinate[x, y + j];
                        arena[x - 1, y + j ] = '#';
                        Ships[NumbOfShip].Coardinate = (x - 1, y);
                    }
                }
            }
            else if (Direction == "Right")
            {
                if (rotation == true)
                {
                    arena[x + lenght, y] = '#';
                    arena[x, y] = PreviosCoardinate[x, y];
                    Ships[NumbOfShip].Coardinate = (x+1, y);
                }
                else 
                {

                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x, y + j] = PreviosCoardinate[x,y+j];
                        Console.WriteLine(PreviosCoardinate[x,y+j]);
                        arena[x + 1, y + j] = '#';
                        Ships[NumbOfShip].Coardinate = (x + 1, y);
                    }
                }
            }
            else if (Direction == "Rotate")
            {
                if (rotation == true)
                {
                    Ships[NumbOfShip].rotation = false;
                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x + j, y] = PreviosCoardinate[x + j, y];
                        arena[x, y + j] = '#';
                    }
                }
                else 
                {
                    Ships[NumbOfShip].rotation = true;
                    for (int j = 0; j < lenght; j++)
                    {
                        arena[x, y + j] = PreviosCoardinate[x, y + j];
                        arena[x + j, y] = '#';
                    }
                }
            }
        }
    }
}
