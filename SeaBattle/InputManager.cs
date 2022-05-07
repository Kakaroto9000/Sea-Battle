using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class InputManager
    {
        public string Movement(char Input)
        {
            if (Input == 'a' || Input == 'A')
                return "Left";
            else if (Input == 'w' || Input == 'W')
                return "Up";
            else if (Input == 's' || Input == 'S')
                return "Down";
            else if (Input == 'd' || Input == 'D')
                return "Right";
            else if (Input == 'y' || Input == 'Y')
                return "Yes";
            else if (Input == 'r' || Input == 'R')
                return "Rotate";
            else return "ERROR";
        }
    }
}
