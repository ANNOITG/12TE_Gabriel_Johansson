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

            myPaj.Add(new Paj() { pajnamn = "Äpple paj", pajsmak = "Äpple", pajingred = "Äpple" });           //Lägger till 2 objekt i listan så vi slipper göra det runtime.
            myPaj.Add(new Paj() { pajnamn = "Blåbärs paj", pajsmak = "Blåbär", pajingred = "Blåbär" });
            myPaj.Add(new Paj() { pajnamn = "Hallon paj", pajsmak = "Hallon", pajingred = "Hallon" });

            /*Console.WriteLine("Vilken paj baserat på personnummer; vill du ta fram?");
            string pajnamn = Console.ReadLine();
            Paj paj = myPaj.Single(p => p.pajnamn == pajnamn);*/


            while (true)//Medans det under stämmer.
            {

                Console.WriteLine("Tryck A för att lägga till en ny paj\n"
                                + "Tryck B för att skriva ut alla i listan\n"
                                + "Tryck X för att avsluta\n"
                                + "Tryck C för att ändra ett objekt\n"
                                + "Tryck D för att ta bort ett objekt\n"
                                + "Tryck E för att söka i listan\n");

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
                    case "c":
                        Console.WriteLine("Ändra en post via index");

                        foreach (Paj p in myPaj) //Loopar ut alla objekt av klassen Person som finns i listan myPaj. Varje objekt kallas för "p"
                        {
                            Console.WriteLine(p + "\n");
                        }

                        try
                        {
                            Console.WriteLine("Vilken paj baserat på pajnamn; vill du ta fram?");
                            string andraPajnamn = Console.ReadLine();
                            Paj andraPaj = myPaj.Single(p => p.pajnamn == andraPajnamn);

                            Console.WriteLine("Pajnamn?");
                            andraPaj.pajnamn = Console.ReadLine(); //SKriver över värdet för pajnamn

                            Console.WriteLine("Pajsmak?");
                            andraPaj.pajnamn = Console.ReadLine(); //SKriver över värdet för pajnamn

                            Console.WriteLine("Pajingrediens?");
                            andraPaj.pajnamn = Console.ReadLine(); //SKriver över värdet för pajnamn

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "d":
                        Console.WriteLine("Ta bort en post via index");

                        int removeindex = 0;
                        foreach (Paj p in myPaj) //Loopar ut alla objekt av klassen Person som finns i listan myPersons. Varje objekt kallas för "p"
                        {
                            Console.WriteLine(removeindex + ":\n" + p + "\n"); //Skriver ut data med hjälp av ToString()-metoden som vi skrivit i klassen Person
                            removeindex++;
                        }

                        try
                        {
                            Console.WriteLine("Vilket index vill du ta bort?");
                            int remIndex = int.Parse(Console.ReadLine());


                            Paj perToRem = myPaj[remIndex];
                            myPaj.Remove(perToRem);
                            Paj.counter--; //Fipplar rätt countern
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "e":
                        Console.WriteLine("Skriv in sökord:");
                        string sokOrd = Console.ReadLine();

                        var sokRes = from p in myPaj
                                     where p.pajnamn.Contains(sokOrd)
                                        || p.pajsmak.ToString().Contains(sokOrd)
                                        || p.pajingred.Contains(sokOrd)
                                     select p;

                        /*Förklaringen till hur LINQ-Söningen funkar/tänker
                        List<Person> SearchRes = new List<Person>();
                        foreach (Person p in myPersons)
                        {
                            if (p.pnr.Contains(sokOrd) || p.alder.ToString().Contains(sokOrd) || p.adress.Contains(sokOrd))
                            {
                                SearchRes.Add(p);
                            }
                        }*/

                        foreach (Paj p in sokRes)
                        {
                            Console.WriteLine(p);
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