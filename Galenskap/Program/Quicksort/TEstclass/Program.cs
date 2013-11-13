using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEstclass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Paj> unsorted = new List<Paj>(); //Listan med personer. Denna lista skapas när programmet startar.

            unsorted.Add(new Paj() { pnr = "5000000", adress = "Ost 12", alder = 98000 });           //Lägger till 2 objekt i listan så vi slipper göra det runtime.
            unsorted.Add(new Paj() { pnr = "1234567", adress = "HÅRStrå", alder = 3409 });
            unsorted.Add(new Paj() { pnr = "9999998", adress = "KO", alder = 1337 });//-----------------------------------------------------------

            // Print the unsorted array
            for (int i = 0; i < unsorted.Count(); i++)
            {
                Console.WriteLine(unsorted[i] + " ");
            }

            Console.WriteLine();

            // Sort the array
            Quicksort(unsorted, 0, unsorted.Count() - 1);

            // Print the sorted array
            for (int i = 0; i < unsorted.Count; i++)
            {
                Console.WriteLine(unsorted[i] + " ");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        public static void Quicksort(List<Paj> elements, int left, int right)
        {
            int i = left, j = right;
            Paj pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].pnr.CompareTo(pivot.pnr) < 0)
                {
                    i++;
                }

                while (elements[j].pnr.CompareTo(pivot.pnr) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Paj tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
    }
}
