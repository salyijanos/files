using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04_Vilagegyetem
{
    class Program
    {
        static Random rnd = new Random();
        static Galaxis Tejut = new Galaxis();

        static void FajlBeolvas(string FajlNev)
        {
            StreamReader sr = new StreamReader(FajlNev);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                if (adatok[0] == "cs") Tejut.AddCsillag(
                    adatok[1] == string.Empty ? null : adatok[1],
                    Convert.ToUInt16(adatok[2]),
                    (CsillagOsztaly)Enum.Parse(typeof(CsillagOsztaly), adatok[3]),
                    (float)Convert.ToDouble(adatok[4]));
                else if (adatok[0] == "b") Tejut.AddBolygo(
                    adatok[1] == string.Empty ? null : adatok[1],
                    Convert.ToUInt16(adatok[2]),
                    (BolygoOsztaly)Enum.Parse(typeof(BolygoOsztaly), adatok[3]),
                    (float)Convert.ToDouble(adatok[4]));
            }
            sr.Close();
        }

        static void Main(string[] args)
        {
            Tejut.AddCsillag();
            Tejut.AddCsillag("Nap", 4603);
            Tejut.AddCsillag("Proxima Centauri", 4853, CsillagOsztaly.VOROSTORPE, 2.6f);
            Tejut.AddBolygo();
            Tejut.AddBolygo("Föld", 2453);
            Tejut.AddBolygo("Mars", 2426, BolygoOsztaly.KOZET, 3.45f);

            FajlBeolvas("Egitestek.csv");

            foreach (Egitest egitest in Tejut.Egitestek)
                Console.WriteLine(egitest);

            //for (int i = 1; i <= 50; i++)
            //{
            //    Tejut.AddCsillag("Csillag" + i,
            //        (ushort)rnd.Next(13600),
            //        (CsillagOsztaly)rnd.Next(6),
            //        (float)rnd.NextDouble() * Beallitasok.Default.MaxAtmero);
            //}

            //Tejut[2] = new Bolygo("66666", "Tatuin", 1234, BolygoOsztaly.KOZET, 1.1f);
            Tejut[2].Nev = "Teszt bolygó"; //!!!
            Console.WriteLine(Tejut[2]);

            //Console.WriteLine(Tejut["E-00003-CS"]);

            //foreach (Egitest egitest in Tejut.Neutroncsillagok)
            //{
            //    Console.WriteLine(egitest);
            //}

            //Egitest eg1 = new Egitest("00015");
            //Egitest eg2 = new Egitest("00016", "Ufo meteor", 127);
            //Console.WriteLine(eg1);
            //Console.WriteLine(eg2);

            //Csillag cs1 = new Csillag("00017");
            //Csillag cs2 = new Csillag("00018", "Nap", 4603);
            //Csillag cs3 = new Csillag("00019",
            //    "Proxima Centauri", 4853,
            //    CsillagOsztaly.VOROSTORPE, 2.6f);
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(cs1);
            //Console.WriteLine(cs2);
            //Console.WriteLine(cs3);

            //Bolygo b1 = new Bolygo("00020");
            //Bolygo b2 = new Bolygo("00021", "Föld", 2453);
            //Bolygo b3 = new Bolygo("00022", "Mars", 2426,
            //    BolygoOsztaly.KOZET, 3.45f);
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(b1);
            //Console.WriteLine(b2);
            //Console.WriteLine(b3);

            Console.ReadLine();
        }
    }
}
