using System;
using System.Collections.Generic;

namespace RaktarkeszletKezelo
{
    class Program
    {
        static List<string> termekNevek = new List<string>();

        static void Main(string[] args)
        {
            fajbolValoBeolvasas();
            udvozloKep();
        }

        private static void udvozloKep()
        {
            Console.Clear();
            Console.WriteLine("=== RAKTÁRKÉSZLET-KEZELŐ RENDSZER ===");
            Console.WriteLine("Jelenleg " + termekNevek.Count + " termék van az adatbázisban.");
            Console.WriteLine("---------------------------------------");

            List<string> menupontok = new List<string>
            {
                "Termékek listázása (F1)",
                "Új termék érkeztetése (F2)",
                "Termék kiadása / Törlése (F3)",
                "Készlethiány és Riasztások (F4)",
                "Mentés és Kilépés (Esc)"
            };

            foreach (string menuPont in menupontok) Console.WriteLine(menuPont);
            Console.WriteLine("---------------------------------------");
            valasztasMenubol();
            // todo: Nádra
        }

        private static void valasztasMenubol()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.F1: termekekKiListazasa(); break;
                case ConsoleKey.F2: ujTermekFelvetele(); break;
                case ConsoleKey.F3: termekKiadasa(); break;
                case ConsoleKey.F4: riasztasokLejaratokLekerdezese(); break;
                case ConsoleKey.Escape: mentesKilepes(); break;
                default: udvozloKep(); break;
            }
            // todo: Nádra
        }

        private static void termekekKiListazasa()
        {
            
        }

        private static void ujTermekFelvetele() { }
        private static void termekKiadasa() { }
        private static void riasztasokLejaratokLekerdezese() { }

        private static void mentesKilepes()
        {
            Console.WriteLine("\nSikeres mentés!");
            Console.WriteLine("\nNyomjon egy gombot a kilépéshez...");
            Console.ReadKey();
            Environment.Exit(0);
            // todo: Nádra
        }
        private static void fajbolValoBeolvasas() { }
    }
}