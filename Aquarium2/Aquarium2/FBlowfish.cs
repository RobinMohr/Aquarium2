using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public class FBlowfish:Fishes
    {
        public FBlowfish(int xPos, int yPos)
        {
            Name = "Blowfish";
            Look = "<()><";
            Direction = true;
            LeftLook = "<()><";
            RightLook = "><()>";
            Size = 5;
            MovementPropability = 10;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
