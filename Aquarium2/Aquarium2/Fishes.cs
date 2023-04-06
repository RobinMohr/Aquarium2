using System;
using System.Collections.Generic;

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

        public static string[,] Fishes_Added(Fishes fish, string[,] aquarium)
        {
            Random random = new Random();

            int Y = aquarium.GetLength(0);
            int X = aquarium.GetLength(1);
            fish.YPos = random.Next(2, Y - 2);
            fish.XPos = random.Next(fish.Size + 2, X - fish.Size - 2);


            do
            {
                int looking = Convert.ToInt32(random.Next(0, 2));
                if (looking == 0)
                {
                    if (aquarium[fish.YPos, fish.XPos] == "~" && aquarium[fish.YPos, fish.XPos + 2] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size - 2] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size / 2] == "~")
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

                else if (looking == 1)
                {
                    if (aquarium[fish.YPos, fish.XPos] == "~" && aquarium[fish.YPos, fish.XPos + 2] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size - 2] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size] == "~" && aquarium[fish.YPos, fish.XPos + fish.Size / 2] == "~")
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

            return aquarium;
        }


        public static string[,] Fish_Movement(string[,] aquarium, List<Fishes> fishes)
        {
            Random r = new Random();

            for (int i = 0; i < aquarium.GetLength(0); i++)
            {
                for (int j = 0; j < aquarium.GetLength(1); j++)
                {
                    if (j == 0 || j == (aquarium.GetLength(1) - 1))
                    {
                        if (i == aquarium.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                aquarium[i, j] = "╚";
                            }
                            if (j == aquarium.GetLength(1) - 1)
                            {
                                aquarium[i, j] = "╝";
                            }
                            
                        }
                        else
                        {
                            aquarium[i, j] = "║";
                        }
                    }
                    else if (i == aquarium.GetLength(0) - 1)
                    {
                        aquarium[i, j] = "═";
                    }
                    else
                    {
                        aquarium[i, j] = "~";
                    }
                }
            }


            foreach (Fishes fish in fishes)
            {
                int changeX = r.Next(0, 100);
                if (!fish.Direction)
                {
                    if (changeX < 2)
                    {
                        fish.Direction = true;
                        fish.XPos = fish.XPos--;
                        aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                    }

                    else if (aquarium[fish.YPos, fish.XPos + fish.Size + 1] == "~")
                    {
                        fish.XPos++;
                        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                    }
                    else
                    {
                        fish.Direction = true;
                        fish.XPos = fish.XPos--;
                        aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                    }
                }
                else if (fish.Direction == true)
                {
                    if (changeX < 2)
                    {
                        fish.Direction = false;
                        fish.XPos = fish.XPos++;
                        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                    }

                    else if (aquarium[fish.YPos, fish.XPos - 1] == "~")
                    {
                        fish.XPos--;
                        aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }

                    }
                    else
                    {
                        fish.Direction = false;
                        fish.XPos = fish.XPos++;
                        aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                        for (int i = 1; i < fish.Size; i++)
                        {
                            aquarium[fish.YPos, fish.XPos + i] = "";
                        }
                    }
                }
            }
            return aquarium;
        }
        public static string[,] Fish_UpOrDown(string[,] aquarium, List<Fishes> fishes, int height_aqua)
        {
            Random r = new Random();

            for (int i = 0; i < aquarium.GetLength(0); i++)
            {
                for (int j = 0; j < aquarium.GetLength(1); j++)
                {
                    if (j == 0 || j == (aquarium.GetLength(1) - 1))
                    {
                        if (i == aquarium.GetLength(0) - 1)
                        {
                            if (j == 0)
                            {
                                aquarium[i, j] = "╚";
                            }
                            if (j == aquarium.Length - 1)
                            {
                                aquarium[i, j] = "╝";
                            }                            
                        }
                        else
                        {
                            aquarium[i, j] = "║";
                        }
                    }
                    else if (i == aquarium.GetLength(0) - 1)
                    {
                        aquarium[i, j] = "═";
                    }
                    else
                    {
                        aquarium[i, j] = "~";
                    }
                }
            }

            foreach (Fishes fish in fishes)
            {
                int counter = 0;
                int changeY = r.Next(0, 100);
                int changeUpOrDown = r.Next(0, 100);
                if (fish.MovementPropability <= changeY)
                {
                    if (fish.YPos == 0)
                    {
                        changeUpOrDown = 60;
                    }
                    if (fish.YPos == height_aqua)
                    {
                        changeUpOrDown = 30;
                    }
                    if (changeUpOrDown < 50)
                    {
                        if (!fish.Direction)
                        {
                            for (int i = fish.XPos; i <= fish.XPos + fish.Size; i++)
                            {
                                if (aquarium[fish.YPos + 1, i] != "~" || aquarium[fish.YPos + 1, i] == aquarium[0, i] || aquarium[fish.YPos + 1, i] == "║")
                                {
                                    counter++;
                                    break;
                                }
                            }
                            if (counter == 0)
                            {
                                fish.YPos++;
                                aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                                for (int i = 1; i < fish.Size; i++)
                                {
                                    aquarium[fish.YPos, fish.XPos + i] = "";
                                }
                            }
                        }
                        else if (fish.Direction)
                        {
                            for (int i = fish.XPos; i >= fish.XPos - fish.Size; i--)
                            {
                                if (aquarium[fish.YPos + 1, i] != "~" || aquarium[fish.YPos + 1, i] == aquarium[0, i] || aquarium[fish.YPos + 1, i] == "║")
                                {
                                    counter++;
                                    break;
                                }
                            }
                            if (counter == 0)
                            {
                                fish.YPos++;
                                aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                                for (int i = 1; i < fish.Size; i++)
                                {
                                    aquarium[fish.YPos, fish.XPos + i] = "";
                                }
                            }
                        }
                    }
                    else if (changeUpOrDown >= 50)
                    {
                        if (!fish.Direction)
                        {
                            for (int i = fish.XPos; i <= fish.XPos + fish.Size; i++)
                            {
                                if (aquarium[fish.YPos - 1, i] != "~" || aquarium[fish.YPos - 1, i] == "═" || aquarium[fish.YPos + 1, i] == "║")
                                {
                                    counter++;
                                    break;
                                }
                            }
                            if (counter == 0)
                            {
                                fish.YPos--;
                                aquarium[fish.YPos, fish.XPos] = fish.RightLook;
                                for (int i = 1; i < fish.Size; i++)
                                {
                                    aquarium[fish.YPos, fish.XPos + i] = "";
                                }
                            }
                        }
                        else if (fish.Direction)
                        {
                            for (int i = fish.XPos; i >= fish.XPos - fish.Size; i--)
                            {
                                if (aquarium[fish.YPos - 1, i] != "~" || aquarium[fish.YPos - 1, i] == "═" || aquarium[fish.YPos + 1, i] == "║")
                                {
                                    counter++;
                                    break;
                                }
                            }
                            if (counter == 0)
                            {
                                fish.YPos--;
                                aquarium[fish.YPos, fish.XPos] = fish.LeftLook;
                                for (int i = 1; i < fish.Size; i++)
                                {
                                    aquarium[fish.YPos, fish.XPos + i] = "";
                                }
                            }
                        }
                    }
                }
            }
            return aquarium;
        }
    }
}
