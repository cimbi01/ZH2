using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2
{
    abstract class Szemely
    {
        private string szuletesi_hely,
            nev;
        private int[] szuletesi_ido = new int[3];
        public Szemely(string _nev)
        {
            this.nev = _nev;
        }
        public Szemely(string _nev, int[] _szuletesi_ev)
        {
            this.nev = _nev;
            this.szuletesi_ido = _szuletesi_ev;
        }
        public Szemely(string _nev, int[] _szuletesi_ev, string _szul_hely)
        {
            this.nev = _nev;
            this.szuletesi_ido = _szuletesi_ev;
            this.szuletesi_hely = _szul_hely;
        }
        public string Nev { get { return this.nev; } }
        public string Szuletesi_hely { set { this.nev = value; } get { return this.nev; } }
        public int Kora()
        {
            /// HA NEM INICIALIZÁJUK, KÉRJÜK BE A SZMÉLY SZÜLETÉSI IDEJÉT, AKKOR MINDE 3 INT 0 LESZ
            DateTime ma = DateTime.Today;
            int kor = ma.Year - this.szuletesi_ido[0] - 1;
            // ha a hónap nagyobb > akkor +1 mert betöltötte
            if (ma.Month > this.szuletesi_ido[1]) { kor++; }
            // TODO
            /* ha egyenlő akkor meg kell nézni, hogy a hónap napja egyenlő a 
            else if (ma.Month == this.szuletesi_ido[1]) */
            Console.WriteLine("Személy kora: {0}", kor);
            return kor;
        } 
    }
}
