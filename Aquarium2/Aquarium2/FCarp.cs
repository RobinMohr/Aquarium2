using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public class FCarp:Fishes
    {
        public FCarp(int xPos, int yPos)
        {
            Name = "Carp";
            Look = "<><";
            Direction = true;
            LeftLook = "<><";
            RightLook = "><>";
            Size = 3;
            MovementPropability = 50;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
