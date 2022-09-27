using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium2
{
    internal class Program
    {
        public string[,] Aquarium_Itself { get; set; }
        public int Aquarium_Lenght { get; set; }
        public int Aquarium_Height { get; set; }

        public Program(string[,] aquarium_Itself, int aquarium_Lenght, int aquarium_Height)
        {
            Aquarium_Itself = aquarium_Itself;
            Aquarium_Lenght = aquarium_Lenght;
            Aquarium_Height = aquarium_Height;
        }

        public Program()
        {

        }
        static void Main(string[] args)
        {
            Random r = new Random();
            Aquarium a = new Aquarium();
            do
            {
                Console.WriteLine("Wie groß soll dein Aquarium sein?", "Höhe:");
                a.Aquarium_Height = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Länge:");
                a.Aquarium_Lenght = Convert.ToInt32(Console.ReadLine());

                if (a.Aquarium_Height < 30 || a.Aquarium_Lenght < 30)
                {
                    Console.WriteLine("Deine Werte waren zu klein, bitte gib mindestens 30x30 ein");
                }
                else
                {
                    break;
                }
            } while (true);

            a.Aquarium_Itself =  Aquarium.Aquarium_Creation(a);

            int xpos1 = r.Next(4, a.Aquarium_Lenght - 4);
            int ypos1 = r.Next(1, a.Aquarium_Height - 2);

            int xpos2 = r.Next(11, a.Aquarium_Lenght - 11);
            int ypos2 = r.Next(1, a.Aquarium_Height - 2);

            int xpos3 = r.Next(6, a.Aquarium_Lenght - 6);
            int ypos3 = r.Next(1, a.Aquarium_Lenght - 2);

            int xpos4 = r.Next(5, a.Aquarium_Lenght - 5);
            int ypos4 = r.Next(1, a.Aquarium_Lenght - 2);

            List<Fishes> fishes = new List<Fishes>();

            FCarp fish1 = new FCarp(ypos1,xpos1);
            FShark fish2 = new FShark(ypos2,xpos2);
            FBlowfish fish3 = new FBlowfish(ypos3, xpos3);
            FSwordfish fish4 = new FSwordfish(ypos4, xpos4);

            fishes.Add(fish1);
            fishes.Add(fish2);
            fishes.Add(fish3);
            fishes.Add(fish4);

            foreach(Fishes f in fishes)
            {
                int looking = Convert.ToInt32(r.Next(0, 2));
                a.Aquarium_Itself = Fishes.Fishes_Added(f, a.Aquarium_Itself,looking);
            }

           
           

            Aquarium.Aquarium_Printing(a.Aquarium_Itself);



            Console.ReadKey();

        }
    }
}
