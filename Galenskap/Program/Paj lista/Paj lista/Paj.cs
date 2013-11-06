using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paj_lista
{
    class Paj
    {
        public static int counter { get; set; }
         public Paj()
        {
            counter++;
        }
         public string pajnamn { get; set; }
         public int pajsmak { get; set; }//Från 1 till 10
         public string pajingred { get; set; }

         public override string ToString()
         {
             return "Pajnamn: " + pajnamn + "\npajsmak: " + pajsmak + "\nIngredienser: " + pajingred;
         }
    }
}
