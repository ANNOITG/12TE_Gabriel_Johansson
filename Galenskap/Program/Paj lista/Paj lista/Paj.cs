using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paj_lista
{
    class Paj: IComparable
    {
        public static int counter { get; set; }
         public Paj()
        {
            counter++;
        }
         public string pajnamn { get; set; }
         public string pajsmak { get; set; }//Smak på pajerna
         public string pajingred { get; set; }

         public int CompareTo(object paj)
         {

             if (this.pajnamn == ((Paj)paj).pajnamn)
             {
                 return 0;
             }
             else if (this.pajnamn.CompareTo(((Paj)paj).pajnamn) < 1)
             {
                 return -1;
             }
             else
             {
                 return 1;
             }
         }

         public override string ToString()
         {
             return "Pajnamn: " + pajnamn + "\npajsmak: " + pajsmak + "\nIngredienser: " + pajingred;//Utskrivningar av pajer och deras information
         }
    }
}
