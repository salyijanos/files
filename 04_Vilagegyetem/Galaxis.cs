using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Vilagegyetem
{
    class Galaxis
    {
        //Blake Crouch - Sötét Anyag

        private static int Id = 1;

        public Galaxis()
        {
            this.egitestek = new List<Egitest>();
        }

        private List<Egitest> egitestek;
        public List<Egitest> Egitestek
        {
            get
            {
                List<Egitest> temp = new List<Egitest>();
                foreach (Egitest egitest in egitestek)
                {
                    temp.Add(egitest.Clone());
                }
                return temp;
                //return new List<Egitest>(egitestek);
            }
        }
        public List<Bolygo> Bolygok
        {
            get
            {
                List<Bolygo> temp = new List<Bolygo>();
                foreach (Egitest egitest in Egitestek)
                {
                    if (egitest is Bolygo)
                        temp.Add(egitest as Bolygo);
                }
                return temp;
            }
        }
        public List<Bolygo> FoldszeruBolygok
        {
            get
            {
                List<Bolygo> temp = new List<Bolygo>();
                foreach (Bolygo bolygo in Bolygok)
                {
                    if (bolygo.Foldszeru)
                        temp.Add(bolygo);
                }
                return temp;
            }
        }
        public List<Csillag> Csillagok
        {
            get
            {
                List<Csillag> temp = new List<Csillag>();
                foreach (Egitest egitest in Egitestek)
                {
                    if (egitest is Csillag)
                        temp.Add(egitest as Csillag);
                }
                return temp;
            }
        }
        public List<Csillag> Neutroncsillagok
        {
            get
            {
                List<Csillag> temp = new List<Csillag>();
                foreach (Csillag csillag in Csillagok)
                {
                    if (csillag.Osztaly == CsillagOsztaly.NEUTRON)
                        temp.Add(csillag);
                }
                return temp;
            }
        }
        public List<Csillag> HasonloCsillagok(Csillag csillag)
        {
            List<Csillag> temp = new List<Csillag>();
            foreach (Csillag star in Csillagok)
            {
                if (star.Hasonlo(csillag))
                    temp.Add(star);
            }
            return temp;
        }

        public Egitest this[int index]
        {
            get
            {                
                return Egitestek[index];
            }
            //set
            //{
            //    egitestek[index] = value;
            //}
        }
        public Egitest this[string Azonosito]
        {
            get
            {
                foreach (Egitest egitest in Egitestek)
                {
                    if (egitest.Azonosito == Azonosito)
                        return egitest;
                }
                throw new Exception("A megadott azonosító nem létezik!");
            }
        }

        private string GetId()
        {
            return Id.ToString().PadLeft(5, '0');
        }

        public void AddCsillag()
        {
            egitestek.Add(new Csillag(GetId()));
            Id++;
        }
        public void AddCsillag(string Nev, ushort Eletkor)
        {
            egitestek.Add(new Csillag(GetId(), Nev, Eletkor));
            Id++;
        }
        public void AddCsillag(string Nev, ushort Eletkor, CsillagOsztaly Osztaly, float Atmero)
        {
            egitestek.Add(new Csillag(GetId(), Nev, Eletkor, Osztaly, Atmero));
            Id++;
        }

        public void AddBolygo()
        {
            egitestek.Add(new Bolygo(GetId()));
            Id++;
        }
        public void AddBolygo(string Nev, ushort Eletkor)
        {
            egitestek.Add(new Bolygo(GetId(), Nev, Eletkor));
            Id++;
        }
        public void AddBolygo(string Nev, ushort Eletkor,
            BolygoOsztaly Osztaly, float KeringesiTavolsag)
        {
            egitestek.Add(new Bolygo(GetId(), Nev, Eletkor,
                Osztaly, KeringesiTavolsag));
            Id++;
        }
    }
}
