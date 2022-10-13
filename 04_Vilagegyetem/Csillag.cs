using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Vilagegyetem
{
    class Csillag : Egitest
    {
        private static string Utotag = "-CS";        

        #region Konstruktorok
        public Csillag(string Azonosito)
            : this(Azonosito, null, 0)
        { 
        }
        public Csillag(string Azonosito, string Nev, ushort Eletkor)
            : base(Azonosito, Nev, Eletkor)
        {
            this.Azonosito += Utotag;
        }
        public Csillag(string Azonosito, string Nev, ushort Eletkor,
            CsillagOsztaly Osztaly, float Atmero)
            : this(Azonosito, Nev, Eletkor)
        {
            this.Osztaly = Osztaly;
            this.Atmero = Atmero;
        }
        #endregion

        #region Mezők és property-k
        public CsillagOsztaly Osztaly { get; set; }

        private float atmero;
        /// <summary>
        /// Az átmérő Napátmérőben értendő.
        /// </summary>
        public float Atmero
        {
            set
            {
                if (value >= Beallitasok.Default.MinAtmero &&
                    value <= Beallitasok.Default.MaxAtmero)
                    atmero = value;
                else throw new Exception("Hibás átmérő!");
            }
            get
            {
                return atmero;
            }
        }
        #endregion

        #region Metódusok és függvények

        #endregion
        public bool Hasonlo(Csillag masik)
        {
            if (this.Osztaly == masik.Osztaly &&
                Math.Abs(this.Atmero - masik.Atmero) <=
                 (Beallitasok.Default.MaxAtmero -
                Beallitasok.Default.MinAtmero) * 0.1)
                return true;
            return false;
        }

        public override Egitest Clone()
        {
            Csillag cs = new Csillag(this.Azonosito.Split('-')[1]);
            cs.Nev = this.Nev;
            cs.Eletkor = this.Eletkor;
            cs.Atmero = this.Atmero;
            cs.Osztaly = Osztaly;
            return cs;
        }

        //public Csillag Clone()
        //{
        //    Csillag cs = new Csillag(this.Azonosito.Split('-')[1]);
        //    cs.Nev = this.Nev;
        //    cs.Eletkor = this.Eletkor;
        //    cs.Atmero = this.Atmero;
        //    cs.Osztaly = Osztaly;
        //    return cs;
        //}

        #region Megjelenítés
        public static string CsillagOsztalyFormat(CsillagOsztaly Osztaly)
        {
            switch (Osztaly)
            {
                case CsillagOsztaly.NEUTRON:
                    return "Neutroncsillag";
                case CsillagOsztaly.BARNATORPE:
                    return "Barna törpe";
                case CsillagOsztaly.HALAL:
                    return "Halálcsillag";
                case CsillagOsztaly.HALAL2:
                    return "Második Halálcsillag";
                case CsillagOsztaly.VOROSORIAS:
                    return "Vörös óriás";
                case CsillagOsztaly.VOROSTORPE:
                    return "Vörös törpe";
                case CsillagOsztaly.FEHERORIAS:
                    return "Fehér óriás";
                default:
                    throw new Exception("Utólag definiált Csillag Osztály!");
            }
        }

        public override string ToString()
        {
            string minta = "Osztály: {0}\n" +
                "Átmérő: {1} NE\n";
            return base.ToString() +
                string.Format(minta,
                Csillag.CsillagOsztalyFormat(Osztaly),
                Atmero);
        }
        #endregion
    }
}
