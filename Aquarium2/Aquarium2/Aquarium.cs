using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    public class Aquarium
    {
        public string[,] Aquarium_Itself { get; set; }
        public int Aquarium_Lenght { get; set; }
        public int Aquarium_Height { get; set; }

        public Aquarium(string[,] aquarium_Itself, int aquarium_Lenght, int aquarium_Height)
        {
            Aquarium_Itself = aquarium_Itself;
            Aquarium_Lenght = aquarium_Lenght;
            Aquarium_Height = aquarium_Height;
        }

        public Aquarium()
        {

        }

        public static string[,] Aquarium_Creation(Aquarium a)
        {
            
            
            string[,] aquarium = new string[a.Aquarium_Height,a.Aquarium_Lenght];

            for (int i = 0; i < a.Aquarium_Height; i++)
            {
                for (int j = 0; j < a.Aquarium_Lenght; j++)
                {
                    if (j == 0 || j == (a.Aquarium_Lenght - 1))
                    {
                        if (i == a.Aquarium_Height - 1)
                        {
                            aquarium[i, j] = "+";
                        }
                        else
                        {
                            aquarium[i, j] = "|";
                        }
                    }
                    else if (i == a.Aquarium_Height - 1)
                    {
                        aquarium[i, j] = "-";
                    }
                    else
                    {
                        aquarium[i, j] = " ";
                    }
                }
            }
            a.Aquarium_Itself = aquarium;
            return aquarium;
        }

        public static void Aquarium_Printing(string[,] aquarium)
        {
            Console.Clear();

            for (int i = 0; i < aquarium.GetLength(0); i++)
            {
                for (int j = 0; j < aquarium.GetLength(1); j++)
                {
                    Console.Write(aquarium[i,j]);
                }
                Console.Write("\n");
            }
        }
    }
}
