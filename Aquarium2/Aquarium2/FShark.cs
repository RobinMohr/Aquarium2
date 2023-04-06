using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public class FShark:Fishes
    {
        public FShark(int xPos, int yPos)
        {
            Name = "Shark";
            Look = "<///====><";
            Direction = true;
            LeftLook = "<///====><";
            RightLook = @"><====\\\>";
            Size = 10;
            MovementPropability = 25;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
