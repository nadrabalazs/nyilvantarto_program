using System;
using System.Collections.Generic;

namespace RaktarkeszletKezelo
{
    class Program
    {
        static List<string> termekNevek = new List<string>();
        static List<int> termekMennyisegek = new List<int>();
        static List<int> termekArak = new List<int>();
        static List<string> termekBeszallitok = new List<string>();

        static string fajlUtvonal = "";

        static void Main(string[] args)
        {
            melyikFajlbolDolgozunk();
        }

        private static void melyikFajlbolDolgozunk()
        {
            Console.WriteLine("Add meg, hogy melyik fájlból szeretnél beolvasni: ");
            fajlUtvonal = Console.ReadLine();
            if (!File.Exists(fajlUtvonal))
            {
                Console.WriteLine("A megadott fájl nem létezik. Kérem, ellenőrizze az útvonalat és próbálja újra.");
                Console.WriteLine("Szeretné hogy létrehozzunk egy ilyen üres .txt fájlt?(igen/nem?)");
                string valasz = Console.ReadLine();
                if (valasz.ToLower() == "igen")
                {
                    try
                    {
                        File.Create(fajlUtvonal).Close();
                        Console.WriteLine("Sikeresen létrehoztuk a fájlt: " + fajlUtvonal); 
                        udvozloKep();
                    }
                    catch (Exception fajlLetrehozasHiba)
                    {
                        Console.WriteLine("Hiba történt a fájl létrehozása során: " + fajlLetrehozasHiba.Message);
                        Console.WriteLine("A program leáll.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("A program leáll.");
                    return;
                }
            }
            else
            { 
                udvozloKep();
            }
            //todo: Nádra
        }

        private static void udvozloKep()
        {
            BeolvasasFajlbol();
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
            ConsoleKeyInfo bekertBillenytu = Console.ReadKey(true);
            switch (bekertBillenytu.Key)
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

        private static void termekekKiListazasa() {
            Console.WriteLine();
        }
        private static void ujTermekFelvetele() { }
        private static void termekKiadasa() { }
        private static void riasztasokLejaratokLekerdezese() { }

        private static void BeolvasasFajlbol() 
        {
            string[] sorok = File.ReadAllLines(fajlUtvonal);
            foreach (string sor in sorok)
            {
                if (sor != "")
                {
                    string[] a = sor.Split(';');
                    termekNevek.Add(a[0]);
                    termekMennyisegek.Add(int.Parse(a[1]));
                    termekArak.Add(int.Parse(a[2]));
                    termekBeszallitok.Add(a[3]);
                }
            }
        }
        private static void mentesFajlba() 
        {
            try
            {
                List<string> fajlbaMentettLista = new List<string>();
                for (int i = 0; i < termekNevek.Count; i++)
                    fajlbaMentettLista.Add(termekNevek[i] + ";" + termekMennyisegek[i] + ";" + termekArak[i] + ";" + termekBeszallitok[i]);
                File.WriteAllLines(fajlUtvonal, fajlbaMentettLista);
            }
            catch (Exception fajlbaMentesHiba)
            {
                 Console.WriteLine("Hiba történt a fájlba mentés során: " + fajlbaMentesHiba.Message);
            }
            // todo: Nádra
        }

        private static void mentesKilepes()
        {
            Console.WriteLine("\nSikeres mentés!");
            Console.WriteLine("\nNyomjon egy gombot a kilépéshez...");
            Console.ReadKey();
            Environment.Exit(0);
            // todo: Nádra
        }
    }
}