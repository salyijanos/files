using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Vilagegyetem
{
    class Bolygo : Egitest
    {
        private static string Utotag = "-B";        

        public Bolygo(string Azonosito)
            : this(Azonosito, null, 0)
        {
        }
        public Bolygo(string Azonosito, string Nev, ushort Eletkor)
            : base(Azonosito, Nev, Eletkor)
        {
            this.Azonosito += Utotag;
            this.KeringesiTavolsag = Beallitasok.Default.MinKeringesiTavolsag;
        }
        public Bolygo(string Azonosito, string Nev, ushort Eletkor,
            BolygoOsztaly Osztaly, float KeringesiTavolsag)
            : this(Azonosito, Nev, Eletkor)
        {
            this.Osztaly = Osztaly;
            this.KeringesiTavolsag = KeringesiTavolsag;
        }

        public BolygoOsztaly Osztaly { get; set; }
        private string BolygoOsztalyFormat(BolygoOsztaly Osztaly)
        {
            switch (Osztaly)
            {
                case BolygoOsztaly.KOZET:
                    return "Kőzetbolygó";
                case BolygoOsztaly.GAZ:
                    return "Gázbolygó";
                case BolygoOsztaly.JEG:
                    return "Jégbolygó";
                case BolygoOsztaly.EXO:
                    return "Exobolygó";
                case BolygoOsztaly.ORIAS:
                    return "Óriásbolygó";
                default:
                    throw new Exception("Utólag definiált Bolygó Osztály!");
            }
        }

        private float keringesiTavolsag;
        public float KeringesiTavolsag
        {
            set
            {
                if (value >= Beallitasok.Default.MinKeringesiTavolsag &&
                    value <= Beallitasok.Default.MaxKeringesiTavolsag)
                    keringesiTavolsag = value;
                else throw new Exception("Hibás keringési távolság!");
            }
            get
            {
                return keringesiTavolsag;
            }
        }

        public bool Foldszeru
        {
            get
            {
                if (this.KeringesiTavolsag >= 0.9 &&
                    this.KeringesiTavolsag <= 1.1)
                    return true;
                return false;
            }
        }

        public override Egitest Clone()
        {
            Bolygo b = new Bolygo(this.Azonosito.Split('-')[1]);
            b.Nev = this.Nev;
            b.Eletkor = this.Eletkor;
            b.KeringesiTavolsag = this.KeringesiTavolsag;
            b.Osztaly = this.Osztaly;
            return b;
        }

        public override string ToString()
        {
            string minta = "Osztály: {0}\n" +
                "Keringési távolság: {1} CsE\n";
            return base.ToString() + 
                string.Format(minta,
                BolygoOsztalyFormat(Osztaly),
                KeringesiTavolsag);
        }
    }
}
