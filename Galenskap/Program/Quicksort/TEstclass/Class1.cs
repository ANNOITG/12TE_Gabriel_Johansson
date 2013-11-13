using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TEstclass
{
    class Paj : IComparable
    {
        public static int counter { get; set; }

        public Paj()
        {
            counter++;
        }

        public string pnr { get; set; }
        public int alder { get; set; }
        public string adress { get; set; }

        public int CompareTo(object paj)
        {

            if (this.pnr == ((Paj)paj).pnr)
            {
                return 0;
            }
            else if (this.pnr.CompareTo(((Paj)paj).pnr) < 1)
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
            return "Personnummer: " + pnr + "\nÅlder: " + alder + "\nAdress: " + adress;
        }
    }
}
