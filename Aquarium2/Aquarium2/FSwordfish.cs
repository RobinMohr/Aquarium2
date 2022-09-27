using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public class FSwordfish:Fishes
    {
        public FSwordfish(int xPos, int yPos)
        {
            Name = "Swordfish";
            Look = "-<><";
            Direction = true;
            LeftLook = "-<><";
            RightLook = "><>-";
            Size = 4;
            MovementPropability = 20;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
