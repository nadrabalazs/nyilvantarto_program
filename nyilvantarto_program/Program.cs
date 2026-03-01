using System;
using System.Collections.Generic;

namespace RaktarkeszletKezelo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdvozloKep();
        }

        private static void UdvozloKep()
        {
            Console.Clear();
            Console.WriteLine("=== RAKTÁRKÉSZLET-KEZELŐ RENDSZER ===");
            Console.WriteLine("Jelenleg 0 termék van a raktárban.");
            Console.WriteLine("---------------------------------------");

            List<string> menupontok = new List<string>
            {
                "Termékek listázása (F1)",
                "Új termék érkeztetése (F2)",
                "Termék kiadása / Törlése (F3)",
                "Készlethiány és Riasztások (F4)",
                "Mentés és Kilépés (Esc)"
            };

            ListazMenu(menupontok);
            Console.WriteLine("---------------------------------------");
            ValasztasMenubol();
        }

        private static void ListazMenu(List<string> menupontok)
        {
            foreach (string menuPont in menupontok)
            {
                Console.WriteLine(menuPont);
            }
        }

        private static void ValasztasMenubol()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.F1:
                    TermekekListazasa();
                    break;
                case ConsoleKey.F2:
                    UjTermekErkeztetese();
                    break;
                case ConsoleKey.F3:
                    TermekKiadasa();
                    break;
                case ConsoleKey.F4:
                    RiasztasokLekerdezese();
                    break;
                case ConsoleKey.Escape:
                    MentesEsKilepes();
                    break;
                default:
                    UdvozloKep();
                    break;
            }
        }

        private static void TermekekListazasa() { }
        private static void UjTermekErkeztetese() { }
        private static void TermekKiadasa() { }
        private static void RiasztasokLekerdezese() { }

        private static void MentesEsKilepes()
        {
            Console.WriteLine("\nSikeres mentés!");
            Console.WriteLine("\nNyomjon egy gombot a kilépéshez...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}