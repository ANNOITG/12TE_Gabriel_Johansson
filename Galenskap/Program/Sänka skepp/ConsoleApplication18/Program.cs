using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



        /////////////////////
        /////Sänka skepp/////
        /////////////////////

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();

            string[,] gameboard = new string[10, 10];//storlek på gameboard

            for (int y1 = 0; y1 < 10; y1++)
            {
                for (int x1 = 0; x1 < 10; x1++)
                {
                    gameboard[x1, y1] = "#";//allt vatten är i form av #
                }
            }


            //båt 1
            gameboard[1, 2] = "*";
            gameboard[1, 3] = "*";
            gameboard[1, 4] = "*";
            //båt 2
            gameboard[4, 6] = "*";
            gameboard[5, 6] = "*";
            gameboard[6, 6] = "*";
            //båt 3
            gameboard[9, 2] = "*";
            gameboard[9, 3] = "*";

            while (true)//Kör om skott sekvensen
            {
                Console.ForegroundColor = ConsoleColor.Green;//Byter färg
                Console.WriteLine("Du ska skriva in 2 kordinater:");
                Console.WriteLine("skriv in x kordinaten.");

                Console.ResetColor();//Återställer färgen



                int x;

                while (true)
                {

                    string inm = Console.ReadLine();
                    try
                    {
                        x = Convert.ToInt32(inm);
                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//Byter färg
                        Console.WriteLine("Du är galen du ska bara skriva 1 kordinat i taget och det måste vara en siffra!");
                        Console.WriteLine("Tryck enter för att stänga av.");
                        string close = Console.ReadLine();
                        if (close == "&")
                        {
                            Console.WriteLine("Du är galen man använder aldrig &");
                        }
                        else
                        {

                            Environment.Exit(0);
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;//Byter färg
                Console.WriteLine("Skriv in y kordinaten.");
                Console.ResetColor();//Återställer färgen

                int y;
                while (true)
                {







                    string inm2 = Console.ReadLine();
                    try
                    {
                        y = Convert.ToInt32(inm2);
                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;//Byter färg
                        Console.WriteLine("Du är galen du ska bara skriva 1 kordinat i taget och det måste vara en siffra!");
                        Console.WriteLine("Tryck enter för att stänga av.");
                        string close = Console.ReadLine();
                        if (close == "&")
                        {
                            Console.WriteLine("Du är galen man använder aldrig &");
                        }
                        else
                        {

                            Environment.Exit(0);
                        }
                    }
                }

                if (gameboard[x, y] == "*")// * står för båt
                {

                    gameboard[x, y] = "X";// X står för att båtten är skadad
                }
                else
                {
                    gameboard[x, y] = "O";// O står för miss
                }
                bool al = false;//alla båtar är träffade
                foreach (string s in gameboard)
                {
                    if (s == "*")
                    {
                        al = true;//alla båtar är inte träffade
                    }
                }

/*-----------------------------------Avslutning av spelet----------------------------------------------------------------------------------------------------------------*/

                if (al == false)//om alla båtar är träffade
                {
                    Console.ForegroundColor = ConsoleColor.Green;//Byter färg
                    Console.WriteLine("Grattis du har träffat all båtar bra gjort!");
                    Console.WriteLine("Tryck villken knapp du vill för att stänga ner programmet.");
                    Console.ResetColor();//Återställer färgen
                    Console.ReadKey();
                    Environment.Exit(0);//Stänger ner datorn
                }

/*--------------------------------------------------------------------------------------------------------------------------------------------------------------  */

                //Skriv ut gameboard

                Console.ForegroundColor = ConsoleColor.Green;//Byter färg
                Console.WriteLine("Så här ser spelplanen ut!");
                Console.ResetColor();//Återställer färgen
                for (int y_ = 0; y_ < 10; y_++)
                {
                    for (int x_ = 0; x_ < 10; x_++)
                    {
                        if (gameboard[x_, y_] != "*")
                        {
                            Console.Write(gameboard[x_, y_]);
                        }
                        else
                        {
                            Console.Write("#");
                        }
                    }
                    Console.WriteLine("|");
                }


                Console.ReadKey();
            }
        }



        static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Byter färg
            Console.WriteLine("Hej och välkommen till Galenskap's sänka skepp!");
            Console.ResetColor();//Återställer färgen
            Console.WriteLine("");//Space
            Console.ForegroundColor = ConsoleColor.Green;//Byter färg
            Console.WriteLine("Var vänlig skriv ditt namn.");
            Console.ResetColor();//Används för att se skillnad på det användaren skriver och det consolen skriver.
            string namn = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;//Byter färg
            Console.WriteLine("Ok " + namn + " nu ska jag berätta hur du spelar.");
            Console.WriteLine("Du ska gissa på 2 tal som är kordinater som antingen kan träffa eller missa, det måste vara heltal.");
            Console.WriteLine("Tryck enter för att forsätta.");
            Console.ReadKey();
        }
    }
}
