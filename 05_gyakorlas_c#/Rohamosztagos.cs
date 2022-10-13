using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ZH1_Klon
{
    class Rohamosztagos
    {
        private static Random rnd = new Random();

        #region Konstruktorok
        private Rohamosztagos(uint Azonosito)
        {
            this.Azonosito = Azonosito;
            this.KikepzesIdeje = Beallitasok.Default.KikepzesIdejeMax;
            this.Klon = rnd.NextDouble() < (double)3 / 5;
            if (this.Klon) this.Szin = SugarvetoSzine.PIROS;
            else this.Szin = (SugarvetoSzine)rnd.Next(0, 3);
        }
        public Rohamosztagos(uint Azonosito, string Nev, byte KikepzesIdeje)
            : this(Azonosito)
        {
            this.Nev = Nev;
            this.KikepzesIdeje = KikepzesIdeje;
        }
        public Rohamosztagos(uint Azonosito, string Nev, byte kikepzesIdeje,
            SugarvetoSzine Szin, bool Klon)
        {
            this.Azonosito = Azonosito;
            this.Nev = Nev;
            this.KikepzesIdeje = KikepzesIdeje;
            this.Klon = Klon;
            this.Szin = this.Klon ? SugarvetoSzine.PIROS : Szin;
        }
        #endregion

        #region Mezők és property-k
        private uint azonosito;
        public uint Azonosito
        {
            get { return azonosito; }
            private set
            {
                if (value >= Beallitasok.Default.AzonositoMin)
                    azonosito = value;
                else throw new Exception("HIBA: Hibás azonosító!");
            }
        }

        private string nev;
        public string Nev
        {
            get
            {
                return nev;
            }
            protected set
            {
                if (value != null &&
                    value.Length >= Beallitasok.Default.NevHosszMin)
                {
                    nev = value;
                }
                else throw new Exception("HIBA: Hibás név!");
            }
        }

        private byte kikepzesIdeje;
        public byte KikepzesIdeje
        {
            set
            {
                if (value >= Beallitasok.Default.KikepzesIdejeMin &&
                    value <= Beallitasok.Default.KikepzesIdejeMax &&
                    value > kikepzesIdeje)
                    kikepzesIdeje = value;
                else throw new Exception("Hiba: Nem lehet 4, vagy annál kisebb szám a kiképzés ideje");
            }
            get
            {
                return kikepzesIdeje;
            }
        }

        public SugarvetoSzine Szin { get; set; }

        private bool klon;
        private bool klonBeallitva = false;
        public bool Klon
        {
            private set
            {
                if (!klonBeallitva)
                {
                    klon = value;
                    klonBeallitva = true;
                }
                else throw new Exception("Hiba: az érték már be van állítva!");

            }
            get
            {
                return klon;
            }
        }
        #endregion

        #region Megjelenítés
        public string SugarvetoSzineFormat(SugarvetoSzine Szin)
        {
            switch (Szin)
            {
                case SugarvetoSzine.KEK:
                    return "Kék";
                case SugarvetoSzine.ZOLD:
                    return "Zöld";
                case SugarvetoSzine.PIROS:
                    return "Piros";
                default:
                    throw new Exception("HIBA: Utólag definiált szín!");
            }
        }

        public override string ToString()
        {
            string minta = "Azonosító: {0}\n" +
                "Név: {1}\n" +
                "Kiképzés ideje: {2}\n" +
                "{3}lón\n" +
                "Sugárvetőszine: {4}\n";
            return string.Format(minta,
                Azonosito,
                Nev,
                KikepzesIdeje,
                Klon ? "K" : "Nem k",
                SugarvetoSzineFormat(Szin));
        }
        #endregion
    }
}