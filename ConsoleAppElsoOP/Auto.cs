using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppElsoOP
{
    public class Auto
    {
        const int szervizElorejelzes = 700; //Szervizelés előrejelzése 700km-rel a szervizciklus előtt
        const int megengedettTulfutas = 100; //A szervizciklus túlfutása 100km-ig még megengedett

        string rendszam;
        string tipusNev; //Leíró adat
        double fogyasztas;  // 100km-re vetített átlagfogyasztás
        int osszesMegtett_km;
        int eloirtSzerviz_km; //Szervizciklus km-ben

        int szervizUtani_km;  //A fevett új/használt jármű frissen szervizelt
        double eddigiFogyasztas;

        public Auto(string rendszam, string tipusNev, double fogyasztas, int szervizkm, int kmora = 0)
        {
            this.rendszam = rendszam;
            this.tipusNev = tipusNev;
            this.fogyasztas = fogyasztas;
            this.osszesMegtett_km = kmora;
            this.eloirtSzerviz_km = szervizkm;

            this.szervizUtani_km = 0;
            this.eddigiFogyasztas = 0;
        }

        public bool EsedekesSzerviz()
        {
            return szervizUtani_km > eloirtSzerviz_km - szervizElorejelzes;
        }
        public void SzervizElvegzese()
        {
            this.szervizUtani_km = 0;
        }

        public double FelhasznaltUzemanyag()
        {
            return eddigiFogyasztas;
        }
        public string Rendszam { get => rendszam; }
        public string TipusNev { get => tipusNev; }
        public double Fogyasztas { get => fogyasztas; }
        public int Kmora { get => osszesMegtett_km; }
        public int Szervizkm { get => eloirtSzerviz_km; }

        //public string GetInfo()
        //{
        //    return $"Rendszám: {this.rendszam}, Típus: {this.tipusNev}, Fogyasztás: {this.fogyasztas:F1}l/100km, km óra állása: {this.kmora}";
        //}

        public override string? ToString()
        {
            return $"|{this.rendszam}, Típus: {this.tipusNev}, Fogyasztás: {this.fogyasztas:F1}l/100km, km óra állása: {this.osszesMegtett_km}km, eddigi fogyasztása: {this.eddigiFogyasztas:f2} l";
        }

        public void Menj(int mennyit)
        {
            if (mennyit < 0)
            {
                throw new ArgumentException("Negatív érték nem fogadható el!");
            }
            if (this.szervizUtani_km + mennyit > eloirtSzerviz_km + megengedettTulfutas)
            {
                throw new Exception("Ezt a kocsit előbb szervizelni kell!");
            }
            this.osszesMegtett_km += mennyit;
            this.szervizUtani_km += mennyit;
            this.eddigiFogyasztas += mennyit / 100 * fogyasztas;
        }
    }
}
