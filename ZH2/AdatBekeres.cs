using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    static class AdatBekeres
    {
        public static int EllenorzottSzamBekeres(string bekero_szoveg, int min, int max)
        {
            Console.WriteLine(bekero_szoveg);
            string adat_be = Console.ReadLine();
            int szam = 0;
            try
            {
                szam = Convert.ToInt32(adat_be);
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott adat nem szám");
                szam = EllenorzottSzamBekeres(bekero_szoveg, min, max);
            }
            if (szam > max || szam < min)
            {
                Console.WriteLine("A megadott szám nincs a megadott intervallumban\n" +
                    "Min: {0}\n" +
                    "Max: {1}\n" +
                    "Sebaj, próbáld újra", min, max);
                szam = EllenorzottSzamBekeres(bekero_szoveg, min, max);
            }
            return szam;
        }
    }
}
