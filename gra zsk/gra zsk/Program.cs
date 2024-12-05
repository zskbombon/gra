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


            public Postac(string nazwa, int zdrowie, int obrazenia, string klasaPostaci)
            {
                Nazwa = nazwa;
                Zdrowie = zdrowie;
                Obrazenia = obrazenia;
                KlasaPostaci = klasaPostaci;
            }
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Nazwa: {Nazwa}, Zdrowie: {Zdrowie}, Obrazenia: {Obrazenia}, Klasa: {KlasaPostaci}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Postac pyszardryssa = new Postac("Pyszardryssa", 1000, 300, "Tank/Berserker");
            Postac misteranicki = new Postac("Misteranicki", 500, 500, "Assasin");
            Postac djrav = new Postac("Djrav", 200, 300, "Bard");
            Postac bartek = new Postac("Bartek", 1000, 50, "Tank");
            Postac kubigaming = new Postac("Kubigaming", 700, 250, "Bruiser");
            Postac szuflada = new Postac("Szuflada", 650, 250, "Druid");

            pyszardryssa.WyswietlInformacje();
            misteranicki.WyswietlInformacje();
            djrav.WyswietlInformacje();
        }
    }
}
