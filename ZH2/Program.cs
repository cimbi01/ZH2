using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class Program
    {
        private const int JATEKOSOK_SZAMA = 5;
        private static int[] aktualis_lotto_szamok = new int[5];
        private static List<int> valaha_huzott_lotto_szamok = new List<int>();
        private static List<LottoJatekos> lottoJatekosok = new List<LottoJatekos>();
        static void Main(string[] args)
        {
            LottoJatekosokInicializalas();
            LottoSzamokBekerese();
            LottoSzamokGeneralasa();
            TalalatokSzama();
            SzamTobbszor();
            FilebeIras();
            Console.ReadKey();
        }
        private static void LottoJatekosokInicializalas()
        {
            for (int i = 0; i < JATEKOSOK_SZAMA; i++)
            {
                lottoJatekosok.Add(new LottoJatekos("Jani"));
            }
        }
        private static void LottoSzamokBekerese()
        {
            for (int i = 0; i < JATEKOSOK_SZAMA; i++)
            {
                try
                {
                    lottoJatekosok[i].TippekBekerese();
                }
                catch (TulFiatalException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine();
            }
        }
        private static void LottoSzamokGeneralasa()
        {
            int[] szamok = new int[LottoJatekos.TIPPEK_SZAMA];
            Random rnd = new Random();
            for (int i = 0; i < szamok.Length; i++)
            {
                int szam;
                do
                {
                    szam = rnd.Next(LottoJatekos.MIN_SZAM, LottoJatekos.MAX_SZAM);
                } while (szamok.Contains(szam));
                szamok[i] = szam;
            }
            aktualis_lotto_szamok = szamok;
        }
        private static void TalalatokSzama()
        {
            int[] talalatok = new int[JATEKOSOK_SZAMA];
            for (int i = 0; i < JATEKOSOK_SZAMA; i++)
            {
                talalatok[i] = lottoJatekosok[i].Aktualis_Megtett_Szamok.Where
                    (szam => aktualis_lotto_szamok.Contains(szam))
                    .Count();
                Console.WriteLine("{0} találata: {1}", lottoJatekosok[i].Nev, talalatok[i]);
            }
        }
        private static void SzamTobbszor()
        {
            // csak a huzott szamok
            bool vanbenne = false;
            foreach (var item in aktualis_lotto_szamok)
            {
                if (valaha_huzott_lotto_szamok.Contains(item))
                {
                    vanbenne = true;
                }
                valaha_huzott_lotto_szamok.Add(item);
            }

            // a tippelt szamok
            // ha van benne felesleges megnézni
            foreach (var item in lottoJatekosok)
            {
                foreach (var item2 in item.Aktualis_Megtett_Szamok)
                {
                    if (item.Valaha_Megtett_Szamok.Contains(item2))
                    {
                        vanbenne = true;
                    }
                    item.Valaha_Megtett_Szamok.Add(item2);
                }
            }
            if(!vanbenne)
            {
                Console.WriteLine("Nincs");
            }
            else
            {
                Console.WriteLine("Van");
            }
        }
        private static void ParatlanSzamok()
        {
            int ptlan = valaha_huzott_lotto_szamok.Count(szam => szam % 2 == 1) + aktualis_lotto_szamok.Count(szam => szam%2 == 1);
            Console.WriteLine("Ptlan szamok szam: {0}", ptlan);
        }
        private static void FilebeIras()
        {
            string filenev = "lottoszamok.dat";
            string[] sorok;
            // beolvassa majd törli a tartalmát
            if (File.Exists(filenev))
            {
                sorok = File.ReadAllLines(filenev);
            }
            else
            {
                sorok = new string[JATEKOSOK_SZAMA + 1];
            }
            StreamWriter file = new StreamWriter(filenev);
            // majd újra írja a meglevo adatokkal játékosok aktuális számával
            for (int i = 0; i < lottoJatekosok.Count; i++)
            {
                LottoJatekos jatekos = lottoJatekosok[i];
                jatekos.Aktualis_Megtett_Szamok.ToList().
                    ForEach(szam => sorok[i] += ' ' + szam.ToString());
                file.WriteLine(sorok[i]);
            }
            // majd az aktuális lottoszámokkal
            aktualis_lotto_szamok.ToList().
                ForEach(szam => sorok[sorok.Length-1] += ' ' + szam.ToString());
            file.Close();
        }
    }
}
