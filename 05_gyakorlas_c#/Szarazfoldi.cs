using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ZH1_Klon
{
    class Szarazfoldi : Rohamosztagos
    {
        public Szarazfoldi(uint Azonosito, string Nev, byte KikepzesIdeje)
            : this(Azonosito, Nev, KikepzesIdeje, SugarvetoSzine.KEK, true)
        {
            this.Nev = Nev;
            this.KikepzesIdeje = KikepzesIdeje;
        }
        public Szarazfoldi(uint Azonosito, string Nev, byte KikepzesIdeje,
            SugarvetoSzine Szin, bool Klon)
            :base(Azonosito, Nev, KikepzesIdeje, Szin, Klon)
        {
            this.Nev = "Szárazföldi " + this.Nev;
        }
        public Szarazfoldi(uint Azonosito, string Nev, byte KikepzesIdeje,
            SugarvetoSzine Szin, bool Klon, bool Tiszt, Sisak Sisak,
            byte TalalatiPontossag)
            : this(Azonosito, Nev, KikepzesIdeje, Szin, Klon)
        {
            this.Tiszt = Tiszt;
            this.Sisak = Sisak;
            this.TalalatiPontossag = TalalatiPontossag;
        }

        private bool tiszt;
        public bool Tiszt
        {
            set
            {
                if (Klon)
                    this.tiszt = false;
                else if (!Tiszt)
                    this.tiszt = value;
                else
                    throw new Exception("Hiba: Az érték csak egyszer állítható be!");
            }
            get
            {
                return tiszt;
            }
        }

        public Sisak Sisak { get; set; }

        public void SisakCsere(Sisak Sisak)
        {
            if (this.Sisak == Sisak.EBREDOEROS &&
                Sisak == Sisak.KLASSZIKUS)
                return;
            this.Sisak = Sisak;
        }

        private static string SisakFormat(Sisak Sisak)
        {
            switch (Sisak)
            {
                case Sisak.EBREDOEROS:
                    return "Ébredő erős";
                case Sisak.KLASSZIKUS:
                    return "Klasszikus";
                case Sisak.FELDERITO:
                    return "Felderítő";
                default:
                    throw new Exception("Hiba: Később definiált sisak!");
            }
        }

        private byte talalatiPontossag;
        public byte TalalatiPontossag
        {
            set
            {
                if (value >= Beallitasok.Default.TalalatiPontossagMin &&
                    value <= Beallitasok.Default.TalalatiPontossagMax)
                    this.talalatiPontossag = value;
                else throw new Exception("Hiba: Hibás érték!");
            }
            get
            {
                return talalatiPontossag;
            }
        }

        public override string ToString()
        {
            string minta = "{0}iszt\n" +
                "Sisak: {1}\n" +
                "Találati pontosság: {2}\n";
            return base.ToString() + string.Format(minta,
                this.Tiszt ? "T" : "Nem t",
                SisakFormat(this.Sisak),
                TalalatiPontossag);
        }
    }
}
