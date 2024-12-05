using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"Nazwa: {Nazwa}, Zdrowie: {Zdrowie}, Obrazenia: {Obrazenia}, Klasa: {KlasaPostaci}, ID: {ID}");
        }

    }

    public class PostacManager
    {
        private Dictionary<int, Postac> postacie = new Dictionary<int, Postac>();
        public void DodajPostac(Postac postac)
        {
            postacie[postac.ID] = postac;
        }
    }

    public Postac PobierzPostacPoId(int id)
        { 
            if (postacie.ContainsKey(id))
            {
                return postacie[id];
            }
        }

        internal class Program
    {
        static void Main(string[] args)
        {
            Postac pyszardryssa = new Postac("Pyszardryssa", 1000, 300, "Tank/Berserker", 1);
            Postac misteranicki = new Postac("Misteranicki", 500, 500, "Assasin", 2);
            Postac djrav = new Postac("Djrav", 200, 300, "Bard", 3);
            Postac bartek = new Postac("Bartek", 1000, 50, "Tank", 4);
            Postac kubigaming = new Postac("Kubigaming", 700, 250, "Bruiser", 5);
            Postac szuflada = new Postac("Szuflada", 650, 250, "Druid", 6);


            Console.Write("Podaj id pierwszego wojownika: \n");
            pyszardryssa.WyswietlInformacje();
            misteranicki.WyswietlInformacje();
            djrav.WyswietlInformacje();
            bartek.WyswietlInformacje();
            kubigaming.WyswietlInformacje();
            szuflada.WyswietlInformacje();
            string input1 = Console.ReadLine();
            int wojownik1 = int.Parse(input1);

            Console.Write("Podaj id drugiego wojownika: \n");
            pyszardryssa.WyswietlInformacje();
            misteranicki.WyswietlInformacje();
            djrav.WyswietlInformacje();
            bartek.WyswietlInformacje();
            kubigaming.WyswietlInformacje();
            szuflada.WyswietlInformacje();
            string input2 = Console.ReadLine();
            int wojownik2 = int.Parse(input2);




        }
    }


}
