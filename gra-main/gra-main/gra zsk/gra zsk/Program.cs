using System;
using System.Collections.Generic;

namespace gra_zsk
{
    public class Postac
    {
        public string Nazwa { get; set; }
        public int Zdrowie { get; set; }
        public int Obrazenia { get; set; }
        public string KlasaPostaci { get; set; }
        public int ID { get; set; }

        public Postac(string nazwa, int zdrowie, int obrazenia, string klasaPostaci, int id)
        {
            Nazwa = nazwa;
            Zdrowie = zdrowie;
            Obrazenia = obrazenia;
            KlasaPostaci = klasaPostaci;
            ID = id;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"ID: {ID}, Nazwa: {Nazwa}, Zdrowie: {Zdrowie}, Obrazenia: {Obrazenia}, Klasa: {KlasaPostaci}");
        }
    }

    public class PostacManager
    {
        private Dictionary<int, Postac> postacie = new Dictionary<int, Postac>();

        public void DodajPostac(Postac postac)
        {
            postacie[postac.ID] = postac;
        }

        public Postac IDP(int id)
        {
            if (postacie.ContainsKey(id))
            {
                return postacie[id];
            }
            else
            {
                Console.WriteLine($"Nie znaleziono postaci o ID {id}.");
                return null;
            }
        }

        public void WyswietlWszystkiePostacie()
        {
            foreach (var postac in postacie.Values)
            {
                postac.WyswietlInformacje();
            }
        }
    }

    public static class Walka
    {
        private static Random random = new Random();

        public static void RozpocznijWalke(Postac wojownik1, Postac wojownik2)
        {
            Console.WriteLine($"Rozpoczyna się walka między {wojownik1.Nazwa} a {wojownik2.Nazwa}!");
            Console.WriteLine();

            while (wojownik1.Zdrowie > 0 && wojownik2.Zdrowie > 0)
            {
                int obrazeniaWojownik1 = ObliczObrazenia(wojownik1, wojownik2);
                wojownik2.Zdrowie -= obrazeniaWojownik1;
                Console.WriteLine($"{wojownik1.Nazwa} zadaje {obrazeniaWojownik1} obrażeń {wojownik2.Nazwa}. Zdrowie {wojownik2.Nazwa}: {Math.Max(wojownik2.Zdrowie, 0)}");

                if (wojownik2.Zdrowie <= 0)
                {
                    Console.WriteLine($"{wojownik2.Nazwa} został pokonany!");
                    break;
                }

                int obrazeniaWojownik2 = ObliczObrazenia(wojownik2, wojownik1);
                wojownik1.Zdrowie -= obrazeniaWojownik2;
                Console.WriteLine($"{wojownik2.Nazwa} zadaje {obrazeniaWojownik2} obrażeń {wojownik1.Nazwa}. Zdrowie {wojownik1.Nazwa}: {Math.Max(wojownik1.Zdrowie, 0)}");

                if (wojownik1.Zdrowie <= 0)
                {
                    Console.WriteLine($"{wojownik1.Nazwa} został pokonany!");
                    break;
                }

                Console.WriteLine();
            }
        }

        private static int ObliczObrazenia(Postac atakujacy, Postac obronca)
        {
            int obrazenia = atakujacy.Obrazenia;
            int zablokowane = 0;
            int wyleczone = 0;

            if (atakujacy.KlasaPostaci == "Assasin")
            {
                bool krytyczne = random.NextDouble() < 0.25;
                if (krytyczne)
                {
                    obrazenia = (int)(obrazenia * 2.5);
                    Console.WriteLine($"Krytyczne uderzenie {atakujacy.Nazwa} za {obrazenia} obrażeń!");
                }
            }

            if (atakujacy.KlasaPostaci == "Druid/Bard")
            {
                wyleczone = (int)(atakujacy.Zdrowie * 0.2);
                atakujacy.Zdrowie = Math.Min(atakujacy.Zdrowie + wyleczone, atakujacy.Zdrowie);
                obrazenia = (int)(obrazenia * 1.1);
                Console.WriteLine($"{atakujacy.Nazwa} wyleczył się o {wyleczone} punktów zdrowia i zadaje dodatkowe obrażenia.");
            }

            if (obronca.KlasaPostaci == "Tank")
            {
                zablokowane = (int)(obrazenia * 0.1);
                obrazenia -= zablokowane;
                Console.WriteLine($"{obronca.Nazwa} zablokował {zablokowane} obrażeń!");
            }

            return obrazenia;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PostacManager wojownicy = new PostacManager();

            wojownicy.DodajPostac(new Postac("Pyszardryssa", 3000, 200, "Tank", 1));
            wojownicy.DodajPostac(new Postac("Misteranicki", 1000, 500, "Assasin", 2));
            wojownicy.DodajPostac(new Postac("Djrav", 2000, 300, "Druid/Bard", 3));
            wojownicy.DodajPostac(new Postac("Bartek", 5000, 100, "Tank", 4));
            wojownicy.DodajPostac(new Postac("Kubigaming", 1500, 350, "Assasin", 5));
            wojownicy.DodajPostac(new Postac("Szuflada", 3500, 200, "Druid/Bard", 6));

            bool kontynuuj = true;

            while (kontynuuj)
            {
                Console.WriteLine("Podaj ID pierwszego wojownika:");
                wojownicy.WyswietlWszystkiePostacie();
                int idPierwszego = int.Parse(Console.ReadLine());
                Postac wojownik1 = wojownicy.IDP(idPierwszego);

                if (wojownik1 == null) continue;

                Console.WriteLine("Podaj ID drugiego wojownika:");
                int idDrugiego = int.Parse(Console.ReadLine());
                Postac wojownik2 = wojownicy.IDP(idDrugiego);

                if (wojownik2 == null) continue;

                Walka.RozpocznijWalke(wojownik1, wojownik2);

                Console.WriteLine("Czy chcesz rozegrać kolejną walkę? (tak/nie)");
                string odpowiedz = Console.ReadLine().ToLower();
                kontynuuj = odpowiedz == "tak";
            }
        }
    }
}
