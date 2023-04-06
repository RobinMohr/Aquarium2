using System;
using System.Collections.Generic;
using System.Threading;

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

            a.Aquarium_Itself = Aquarium.Aquarium_Creation(a);

            List<Fishes> fishes = new List<Fishes>();
            Console.WriteLine("Wie viele Karpfen möchtest du hinzufügen?");
            int carp_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < carp_count; i++)
            {
                FCarp fish1 = new FCarp(r.Next(4, a.Aquarium_Lenght - 4), r.Next(1, a.Aquarium_Height - 2));
                fishes.Add(fish1);
            }

            Console.WriteLine("Wie viele Haie möchtest du hinzufügen?");
            int shark_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < shark_count; i++)
            {
                FShark fish2 = new FShark(r.Next(11, a.Aquarium_Lenght - 11), r.Next(1, a.Aquarium_Height - 2));
                fishes.Add(fish2);
            }

            Console.WriteLine("Wie viele KugelFische möchtest du hinzufügen?");
            int blowfish_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < blowfish_count; i++)
            {
                FBlowfish fish3 = new FBlowfish(r.Next(6, a.Aquarium_Lenght - 6), r.Next(1, a.Aquarium_Lenght - 2));
                fishes.Add(fish3);
            }

            Console.WriteLine("Wie viele Schwertfische möchtest du hinzufügen?");
            int swordfish_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < swordfish_count; i++)
            {
                FSwordfish fish4 = new FSwordfish(r.Next(5, a.Aquarium_Lenght - 5), r.Next(1, a.Aquarium_Lenght - 2));
                fishes.Add(fish4);
            }

            foreach (Fishes fish_ in fishes)
            {
                a.Aquarium_Itself = Fishes.Fishes_Added(fish_, a.Aquarium_Itself);
            }



            Aquarium.Aquarium_Printing(a.Aquarium_Itself);
            do
            {
                a.Aquarium_Itself = Fishes.Fish_UpOrDown(a.Aquarium_Itself, fishes, a.Aquarium_Height);
                a.Aquarium_Itself = Fishes.Fish_Movement(a.Aquarium_Itself, fishes);
                Aquarium.Aquarium_Printing(a.Aquarium_Itself);
                Thread.Sleep(200);

            } while (true);






            Console.ReadKey();

        }
    }
}
