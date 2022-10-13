using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ZH1_Klon
{
    class Pilota : Rohamosztagos
    {
        public Pilota(uint Azonosito, string Nev, byte KikepzesIdeje)
            : this(Azonosito, Nev, KikepzesIdeje, SugarvetoSzine.KEK, true)
        {
            this.Nev = Nev;
            this.KikepzesIdeje = KikepzesIdeje;
        }
        public Pilota(uint Azonosito, string Nev, byte KikepzesIdeje,
            SugarvetoSzine Szin, bool Klon)
            :base(Azonosito, Nev, KikepzesIdeje, Szin, Klon)
        {
            this.Nev = this.Nev + " Pilóta";
        }
        public Pilota(uint Azonosito, string Nev, byte KikepzesIdeje,
            SugarvetoSzine Szin, bool Klon, 
            Jarmu MitVezet, byte BalesetekSzama)
            : this(Azonosito, Nev, KikepzesIdeje, Szin, Klon)
        {
            this.MitVezet = MitVezet;
            this.BalesetekSzama = BalesetekSzama;
        }

        public Jarmu MitVezet { get; set; }
        public byte BalesetekSzama { get; set; }
    }
}
