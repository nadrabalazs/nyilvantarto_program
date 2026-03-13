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
                BeolvasasFajlbol();
                udvozloKep();

            }
            //todo: Nádra
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

        private static void termekekKiListazasa()
        {
            Console.Clear();
            Console.WriteLine("=== AKTUÁLIS KÉSZLET ===");
            if (termekNevek.Count == 0) Console.WriteLine("A raktár üres.");
            else
            {
                Console.WriteLine("Név".PadRight(15) + " | " + "Készlet".PadLeft(7) + " | " + "Ár".PadLeft(10) + " | Beszállító");
                Console.WriteLine(new string('-', 60));
                for (int i = 0; i < termekNevek.Count; i++)
                {
                    Console.WriteLine(termekNevek[i].PadRight(15) + " | " +
                                      termekMennyisegek[i].ToString().PadLeft(4) + " db | " +
                                      termekArak[i].ToString().PadLeft(7) + " Ft | " +
                                      termekBeszallitok[i]);
                }
            }
            Console.WriteLine("\nNyomjon egy gombot a visszatéréshez...");
            Console.ReadKey();
            udvozloKep();
            // TODO: Simon

        }
        private static void ujTermekFelvetele()
        {
            Console.Clear();
            Console.WriteLine("=== ÚJ TERMÉK FELVÉTELE ===");

            string nev = "";
            while (nev == "")
            {
                Console.Write("Termék neve: ");
                nev = Console.ReadLine();
            }

            int mennyiseg = -1;
            while (mennyiseg < 0)
            {
                Console.Write("Mennyiség (db): ");
                try
                {
                    mennyiseg = int.Parse(Console.ReadLine());
                    if (mennyiseg < 0) Console.WriteLine("Hiba! Nem lehet negatív!");
                }
                catch
                {
                    Console.WriteLine("Hiba! Csak számot írj!");
                }
                // TODO: Simon
            }

            int ar = -1;
            while (ar < 0)
            {
                Console.Write("Egységár (Ft): ");
                try
                {
                    ar = int.Parse(Console.ReadLine());
                    if (ar < 0) Console.WriteLine("Hiba! Nem lehet negatív!");
                }
                catch
                {
                    Console.WriteLine("Hiba! Csak számot írj!");
                }
            }

            Console.Write("Beszállító: ");
            string beszallito = Console.ReadLine();
            if (beszallito == "") beszallito = "Ismeretlen";

            termekNevek.Add(nev);
            termekMennyisegek.Add(mennyiseg);
            termekArak.Add(ar);
            termekBeszallitok.Add(beszallito);

            mentesFajlba();
            Console.WriteLine("\nSikeres rögzítés! Mehet a menet vissza.");
            Console.ReadKey();
            udvozloKep();
            // TODO: Simon
        }
        private static void termekKiadasa()
        {

            Console.Clear();
            Console.WriteLine("=== TERMÉK KIADÁSA / TÖRLÉSE ===");
            Console.Write("Add meg a termék nevét: ");
            string keresett = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < termekNevek.Count; i++)
            {
                if (termekNevek[i].ToLower() == keresett.ToLower()) index = i;
            }

            if (index == -1)
            {
                Console.WriteLine("Nincs ilyen termék!");
            }
            else
            {
                Console.WriteLine("Talált termék: " + termekNevek[index] + " (" + termekMennyisegek[index] + " db)");
                Console.WriteLine("1. Mennyiség levonása");
                Console.WriteLine("2. Termék teljes törlése");
                Console.Write("Válassz: ");
                string valasztas = Console.ReadLine();

                if (valasztas == "1")
                {
                    Console.Write("Mennyit adunk ki? ");
                    try
                    {
                        int darab = int.Parse(Console.ReadLine());
                        if (darab > 0 && darab <= termekMennyisegek[index])
                        {
                            termekMennyisegek[index] -= darab;
                            Console.WriteLine("Kiadva!");
                        }
                        else Console.WriteLine("Hiba! Nincs ennyi raktáron vagy rossz szám!");
                    }
                    catch { Console.WriteLine("Hiba! Rossz formátum!"); }
                }
                else if (valasztas == "2")
                {
                    termekNevek.RemoveAt(index);
                    termekMennyisegek.RemoveAt(index);
                    termekArak.RemoveAt(index);
                    termekBeszallitok.RemoveAt(index);
                    Console.WriteLine("Termék törölve!");
                }
                mentesFajlba();
            }
            Console.ReadKey();
            udvozloKep();
            // TODO: Simon
        }
        private static void riasztasokLejaratokLekerdezese()
        {
            Console.Clear();
            Console.WriteLine("=== RIASZTÁSOK (KEVÉS ÁRU) ===");
            bool voltRiasztas = false;

            for (int i = 0; i < termekNevek.Count; i++)
            {
                if (termekMennyisegek[i] < 5)
                {
                    Console.WriteLine("FIGYELEM: " + termekNevek[i] + "nevű termékből már csak " + termekMennyisegek[i] + " db van!");
                    voltRiasztas = true;
                }
            }

            if (!voltRiasztas) Console.WriteLine("Mindenből van elég készlet (min. 5 db).");

            Console.WriteLine("\nNyomjon egy gombot a visszatéréshez...");
            Console.ReadKey();
            udvozloKep();
            // TODO: Simon
        }

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
                    // TODO: Nádra
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
