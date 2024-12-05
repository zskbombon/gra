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

        // Dodawanie postaci
        public void DodajPostac(Postac postac)
        {
            postacie[postac.ID] = postac;
        }

        // Pobieranie postaci po ID
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

        // Wyświetlenie wszystkich postaci
        public void WyswietlWszystkiePostacie()
        {
            foreach (var postac in postacie.Values)
            {
                postac.WyswietlInformacje();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PostacManager wojownicy = new PostacManager();

            // Dodawanie postaci
            wojownicy.DodajPostac(new Postac("Pyszardryssa", 1000, 300, "Tank/Berserker", 1));
            wojownicy.DodajPostac(new Postac("Misteranicki", 500, 500, "Assasin", 2));
            wojownicy.DodajPostac(new Postac("Djrav", 200, 300, "Bard", 3));
            wojownicy.DodajPostac(new Postac("Bartek", 1000, 50, "Tank", 4));
            wojownicy.DodajPostac(new Postac("Kubigaming", 700, 250, "Bruiser", 5));
            wojownicy.DodajPostac(new Postac("Szuflada", 650, 250, "Druid", 6));

            // Pobieranie pierwszego wojownika
            Console.WriteLine("Podaj ID pierwszego wojownika:");
            wojownicy.WyswietlWszystkiePostacie();
            int idPierwszego = int.Parse(Console.ReadLine());
            Postac wojownik1 = wojownicy.IDP(idPierwszego);

            if (wojownik1 != null)
            {
                Console.WriteLine("Wybrany pierwszy wojownik:");
                wojownik1.WyswietlInformacje();
            }

            // Pobieranie drugiego wojownika
            Console.WriteLine("Podaj ID drugiego wojownika:");
            int idDrugiego = int.Parse(Console.ReadLine());
            Postac wojownik2 = wojownicy.IDP(idDrugiego);

            if (wojownik2 != null)
            {
                Console.WriteLine("Wybrany drugi wojownik:");
                wojownik2.WyswietlInformacje();
            }
            Console.ReadKey();
        }
    }
}
