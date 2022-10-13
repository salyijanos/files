using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Neptun
{
    class Program
    {
        static List<Hallgato> Hallgatok = new List<Hallgato>();
        static bool Kilepes = false;

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("*** Neptun ***\n");
            Console.WriteLine("1 - Új hallgató");
            Console.WriteLine("2 - Hallgatók listája");
            Console.WriteLine("3 - Törlés");
            Console.WriteLine("Esc - Kilépés");
        }
        static void MenuKezeles()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    HallgatoRegisztralas();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    HallgatokListaja();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    break;
                case ConsoleKey.Escape:
                    Kilepes = true;
                    break;
                default:
                    break;
            }
        }

        static void HallgatoRegisztralas()
        {
            Console.Clear();
            Console.WriteLine("*** Új hallgató ***\n");

            Console.Write("Neptun kód: ");
            Hallgato hallgato = new Hallgato(Console.ReadLine());

            Console.Write("Név: ");
            hallgato.Nev = Console.ReadLine();            
            Console.WriteLine("Születési dátum: ");
            int ev, honap, nap;
            Console.Write("Év: ");
            ev = int.Parse(Console.ReadLine());
            Console.Write("Hónap: ");
            honap = int.Parse(Console.ReadLine());
            Console.Write("Nap: ");
            nap = int.Parse(Console.ReadLine());
            hallgato.SzuletesiDatum =
                new DateTime(ev, honap, nap);
            Console.Write("Neme: ");
            hallgato.Neme = (Nem)Enum.Parse(typeof(Nem), Console.ReadLine(), true);
            Console.Write("Kreditek száma: ");
            hallgato.Kreditek = int.Parse(Console.ReadLine());

            Hallgatok.Add(hallgato);
            Console.WriteLine("\nSikeres mentés!");
            Console.ReadLine();
        }
        static void HallgatokListaja()
        {
            Console.Clear();
            Console.WriteLine("*** Hallgatók ***\n");
            Console.WriteLine("Név\t\tNeptKod\tSzulDatum\tNeme\tKreditek\tÉletkor");
            foreach (Hallgato hallgato in Hallgatok)
            {
                //hallgato.Kiir();
                //Console.WriteLine(hallgato.HallgatoString());
                Console.WriteLine(hallgato);
            }

            Console.WriteLine("\nNyomjon Enter-t a folytatáshoz!");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //Tantargy MagProg2 = new Tantargy();
            //MagProg2.

            Hallgato hallgato = new Hallgato("ABC775");
            hallgato.Nev = "Nagy Géza";
            hallgato.SzuletesiDatum =
                new DateTime(1991, 8, 3);
            hallgato.Neme = Nem.FERFI;
            //hallgato.Kreditek = 180;
            Hallgatok.Add(hallgato);

            Hallgato hallgato2 = new Hallgato("DFE885",
                new DateTime(1969, 9, 27));
            hallgato2.Nev = "Kiss Péter";
            hallgato2.Neme = Nem.FERFI;
            hallgato2.Kreditek = 181;
            Hallgatok.Add(hallgato2);

            Hallgato hallgato3 = new Hallgato("GHJ762");
            hallgato3.Nev = "Horváth Gizi";
            hallgato3.SzuletesiDatum =
                new DateTime(1981, 9, 5);
            hallgato3.Neme = Nem.NO;
            hallgato3.Kreditek = 20;
            Hallgatok.Add(hallgato3);

            do
            {
                Menu();
                MenuKezeles();
            } while (!Kilepes);
        }
    }
}
