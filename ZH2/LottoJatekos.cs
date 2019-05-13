using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    class LottoJatekos : Szemely
    {
        public static int MIN_SZAM { get; } = 1;
        public static int MAX_SZAM { get; } = 90;
        public static int MIN_KORHATAR { get; } = 18;
        public static int TIPPEK_SZAMA { get; } = 5;
        public List<int> Valaha_Megtett_Szamok { get; } = new List<int>();
        public int[] Aktualis_Megtett_Szamok { get; private set;} = new int[5];
        public LottoJatekos(string _nev) : base(_nev)
        {
        }

        public LottoJatekos(string _nev, int[] _szuletesi_ev) : base(_nev, _szuletesi_ev)
        {
        }

        public LottoJatekos(string _nev, int[] _szuletesi_ev, string _szul_hely) : base(_nev, _szuletesi_ev, _szul_hely)
        {
        }

        public new int Kora()
        {
            int kor = base.Kora();
            if (kor < MIN_KORHATAR)
            {
                Console.WriteLine("A játékos nem játszhat, mert túl fiatal");
                Console.WriteLine("Ennyi idő múlva játszhat majd: {0}", MIN_KORHATAR - kor);
                throw new TulFiatalException(kor);
            }
            return kor;
        }
        public void TippekBekerese()
        {
            this.Kora();
            int[] szamok = new int[TIPPEK_SZAMA];
            for (int i = 0; i < szamok.Length; i++)
            {
                int szam;
                do
                {
                    szam = AdatBekeres.EllenorzottSzamBekeres("Add meg megtett szamod", MIN_SZAM, MAX_SZAM);
                    if (szamok.Contains(szam))
                    {
                        Console.WriteLine("Számot már tippelted");
                    }
                } while (szamok.Contains(szam));
                szamok[i] = szam;
            }
            // emelkedo sorba rakja
            List<int> szamok2 = szamok.ToList();
            szamok2.Sort();
            Aktualis_Megtett_Szamok = szamok2.ToArray();
        }
    }
}
