using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paj_lista//Namn
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Paj> myPaj = new List<Paj>();//Lista över pajer

            while (true)//Medans det under stämmer.
            {

                Console.WriteLine("Tryck A för att lägga till en ny paj\n"
                                + "Tryck B för att skriva ut alla i listan\n"
                                + "Tryck X för att avsluta");

                string val = Console.ReadLine().ToLower();// Val utav alternativ ovan ^

                switch (val)
                {
                    case "a":// Om personen trycker a

                        Paj per = new Paj();

                        Console.WriteLine("Namn på pajen?");
                        per.pajnamn = Console.ReadLine();

                        Console.WriteLine("Paj smak?");
                        per.pajsmak = Console.ReadLine();

                        Console.WriteLine("Paj ingrediens?");
                        per.pajingred = Console.ReadLine();


                        myPaj.Add(per);//Lägger till en paj

                        break;

                    case "b"://Om personen trycker på b
                        Console.WriteLine("Antal skapade pajer: " + Paj.counter);

                        foreach (Paj p in myPaj)
                        {
                            Console.WriteLine(p + "\n");
                        }
                        break;

                    case "x"://om personen trycker på x
                        Environment.Exit(0);//Stänger ner consolen
                        break;

                    default:
                        Console.WriteLine("Du gjorde ett felaktigt val.");//Ogiltig kanapp.
                        Console.Clear();
                        break;
                }
            }
            Console.ReadKey();

        }
    }
}
//ENDOFCODE//