using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ZH1_Klon
{
    class Ezred
    {
        private static uint Azonosito = Beallitasok.Default.AzonositoMin;

        public Ezred(bool Klon)
        {
            this.Klon = Klon;
            this.rohamosztagosok = new List<Rohamosztagos>();
        }

        public bool Klon { get; private set; }
        private List<Rohamosztagos> rohamosztagosok;

        public void AddSzarazfoldi(string Nev, byte KikepzesIdeje,
            SugarvetoSzine Szin, bool Tiszt, Sisak Sisak,
            byte TalalatiPontossag)
        {
            Szarazfoldi s = new Szarazfoldi(Ezred.Azonosito, Nev,
                KikepzesIdeje,Szin, this.Klon, Tiszt, Sisak,
                TalalatiPontossag);
            this.rohamosztagosok.Add(s);
            Ezred.Azonosito++;
        }
    }
}
