using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public abstract class Fishes
    {
        public string Name { get; set; }
        public string Look { get; set; }
        public string LeftLook { get; set; }
        public string RightLook { get; set; }
        
        public int Size { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int MovementPropability { get; set; }
        public bool Direction { get; set; }

        public static string[,] Fishes_Added(Fishes fish, string[,] aquarium, int looking)
        {
            Random random = new Random();

            int Y = aquarium.GetLength(0);
            int X = aquarium.GetLength(1);
            fish.YPos = random.Next(2, Y - 2);
            fish.XPos = random.Next(fish.Size + 2, X - fish.Size - 2);


            do
            {
                if (looking == 0)
                {
                    if (aquarium[fish.YPos, fish.XPos] != " " || aquarium[fish.YPos, fish.XPos + 2] != " " || aquarium[fish.YPos, fish.XPos + fish.Size - 2] != " " || aquarium[fish.YPos, fish.XPos + fish.Size] != " " || aquarium[fish.YPos, fish.XPos + fish.Size / 2] != " ")
                    {
                        fish.YPos = random.Next(1, Y - 2);
                        fish.XPos = random.Next(1, X - fish.Size - 2);
                    }
                    else
                    {
                        aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                        fish.Direction = true;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                        break;
                    }

                }
                if (looking == 0)
                {
                    if (aquarium[fish.YPos, fish.XPos] == " " && aquarium[fish.YPos, fish.XPos + 2] == " " && aquarium[fish.YPos, fish.XPos + fish.Size - 2] == " " && aquarium[fish.YPos, fish.XPos + fish.Size] == " " && aquarium[fish.YPos, fish.XPos + fish.Size / 2] == " ")
                    {
                        aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                        fish.Direction = true;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                        break;
                    }
                    else
                    {
                        fish.YPos = random.Next(1, Y - 2);
                        fish.XPos = random.Next(1, X - fish.Size - 2);                        
                    }

                }
                //else if (looking == 1)
                //{
                //    if (aquarium[fish.YPos, fish.XPos] != " " || aquarium[fish.YPos, fish.XPos - 2] != " " || aquarium[fish.YPos, fish.XPos - fish.Size + 2] != " " || aquarium[fish.YPos, fish.XPos - fish.Size] != " " || aquarium[fish.YPos, fish.XPos - (fish.Size / 2)] != " ")
                //    {
                //        fish.YPos = random.Next(1, Y - 2);
                //        fish.XPos = random.Next(fish.Size + 1, X - 1);
                //    }
                //    else
                //    {
                //        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                //        fish.Direction = false;
                //        for (int i = -1; i > (0-fish.Size); i--)
                //        {
                //            aquarium[fish.YPos, fish.XPos - i] = "";
                //        }
                //        break;
                //    }
                //}                //else if (looking == 1)
                //{
                //    if (aquarium[fish.YPos, fish.XPos] == " " && aquarium[fish.YPos, fish.XPos - 2] == " " && aquarium[fish.YPos, fish.XPos - fish.Size + 2] == " " && aquarium[fish.YPos, fish.XPos - fish.Size] == " " && aquarium[fish.YPos, fish.XPos - (fish.Size / 2)] == " ")
                //    {
                //        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                //        fish.Direction = false;
                //        for (int i = -1; i > (0 - fish.Size); i--)
                //        {
                //            aquarium[fish.YPos, fish.XPos - i] = "";
                //        }
                //        break;
                //    }
                //    else
                //    {
                //        fish.YPos = random.Next(1, Y - 2);
                //        fish.XPos = random.Next(fish.Size + 1, X - 1);
                        
                //    }
                //}
                else if (looking == 1)
                {
                    if (aquarium[fish.YPos, fish.XPos] == " " && aquarium[fish.YPos, fish.XPos + 2] == " " && aquarium[fish.YPos, fish.XPos + fish.Size - 2] == " " && aquarium[fish.YPos, fish.XPos + fish.Size] == " " && aquarium[fish.YPos, fish.XPos + fish.Size / 2] == " ")
                    {
                        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                        fish.Direction = false;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                        break;
                    }
                    else
                    {
                        fish.YPos = random.Next(1, Y - 2);
                        fish.XPos = random.Next(fish.Size + 1, X - 1);

                    }
                }


            } while (true);
            Console.WriteLine(fish.Direction + fish.Name);




            return aquarium;
        }
    }
}
