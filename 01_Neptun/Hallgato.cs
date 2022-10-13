using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Neptun
{
    class Hallgato
    {
        private Hallgato()
        {
            this.Kreditek = 0;
        }
        public Hallgato(string NeptunKod)
            : this()
        {
            this.NeptunKod = NeptunKod;
        }
        public Hallgato(string NeptunKod, DateTime SzuletesiDatum)
            : this(NeptunKod)
        {
            this.SzuletesiDatum = SzuletesiDatum;
        }

        private string nev;
        public string Nev
        {
            set
            {
                if (value.Contains(" "))
                    nev = value;
                else throw new Exception("Hiba: Használja a 'Vezetéknév Családnév' formátumot!");
            }
            get
            {
                return nev;
            }
        }

        private bool neptunkodMegadva = false;
        private string neptunKod;
        public string NeptunKod
        {
            private set
            {
                if (neptunkodMegadva)
                    throw new Exception("A neptunkód már meg van adva!");

                if (value.Length != 6)
                    throw new Exception("Hibás neptunkód!");

                string ABC = "0123456789QWERTZUIOPASDFGHJKLYXCVBNM";
                value = value.ToUpper();
                if (ABC.Substring(0, 10).Contains(value[0]))
                    throw new Exception("Az első karakter nem lehet szám!");
                for (int i = 0; i < value.Length; i++)
                    if (!ABC.Contains(value[i]))
                        throw new Exception("Tiltott karakter!");

                neptunKod = value;
                neptunkodMegadva = true;
            }
            get
            {
                return neptunKod;
            }
        }

        private bool szuletesiDatumMegadva = false;
        private DateTime szuletesiDatum;
        public DateTime SzuletesiDatum
        {
            set
            {
                if (szuletesiDatumMegadva)
                    throw new Exception("Hiba: A mező csak egyszer módosítható!");
                if ((DateTime.Now - value).TotalDays / 365 < 17)
                    throw new Exception("Hiba: A minimális életkor 17 év!");

                szuletesiDatum = value;
                szuletesiDatumMegadva = true;
            }
            get
            {
                return szuletesiDatum;
            }
        }

        public int Eletkor
        {
            get
            {
                return (int)((DateTime.Now - SzuletesiDatum).TotalDays / 365);
            }
        }

        //private Nem neme;
        //public Nem Neme
        //{
        //    set { neme = value; }
        //    get { return neme; }
        //}
        public Nem Neme { set; get; }

        private int kreditek;
        public int Kreditek
        {
            set
            {
                if (value >= 0 && value <= 190)
                    kreditek = value;
                else throw new Exception("Hiba: A kreditek száma 0 és 190 közötti egész!\n" +
                    "A hibás input: " + value);
            }
            get
            {
                return kreditek;
            }
        }

        public void Kiir()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                    Nev.Length > 15 ?
                        Nev.Substring(0, 12) + "..."
                        : Nev,
                    NeptunKod,
                    SzuletesiDatum.ToString("yyyy.MM.dd"),
                    Neme,
                    Kreditek);
        }
        public string HallgatoString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                    Nev.Length > 15 ?
                        Nev.Substring(0, 12) + "..."
                        : Nev,
                    NeptunKod,
                    SzuletesiDatum.ToString("yyyy.MM.dd"),
                    Neme,
                    Kreditek);
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t\t{5} év",
                    Nev.Length > 15 ?
                        Nev.Substring(0, 12) + "..."
                        : Nev,
                    NeptunKod,
                    SzuletesiDatum.ToString("yyyy.MM.dd"),
                    Neme,
                    Kreditek,
                    Eletkor);
        }
    }
}
