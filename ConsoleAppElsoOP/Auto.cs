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

        // A példányosítás során kapnak értéket és a működés során változatlanok
        string rendszam;
        string tipusNev; //Leíró adat
        double atlagfogyasztas;  // 100km-re vetített átlagfogyasztás literben
        int osszesMegtett_km;  //km óra állása a teljes élettartam alatt
        int tartalyMeret; //tartály térfogata literben
        int eloirtSzerviz_km; //Előírt szervizciklus km-ben

        // Belső változók, amelyek értékei működés közben változnak
        int szervizUtani_km;  //A fevett új/használt jármű frissen szervizelt
        double uzemanyagSzintje; //Mennyi van a tartályban
        double eddigiFogyasztas;

        public Auto(string rendszam, string tipusNev, int tartalyMeret, double fogyasztas, int szervizkm, int kmora = 0)
        {
            this.rendszam = rendszam;
            this.tipusNev = tipusNev;
            this.tartalyMeret = tartalyMeret;
            this.atlagfogyasztas = fogyasztas;
            this.osszesMegtett_km = kmora;
            this.eloirtSzerviz_km = szervizkm;

            this.szervizUtani_km = 0;
            this.eddigiFogyasztas = 0;
            this.uzemanyagSzintje = this.tartalyMeret / 2;
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
        public double Atlagfogyasztas { get => atlagfogyasztas; }
        public int Kmora { get => osszesMegtett_km; }
        public int Szervizkm { get => eloirtSzerviz_km; }

        //public int TartalyMeret()
        //{
        //    return this.tartalyMeret;
        //}

        public int TartalyMeret
        {
            get
            {
                return this.tartalyMeret;
            }
        }
        //public double TartalyMeret3 { get => uzemanyagSzintje; }



        public double UzemanyagSzintje { get => uzemanyagSzintje; }

        //public string GetInfo()
        //{
        //    return $"Rendszám: {this.rendszam}, Típus: {this.tipusNev}, Fogyasztás: {this.fogyasztas:F1}l/100km, km óra állása: {this.kmora}";
        //}

        public override string? ToString()
        {
            return $"|{this.rendszam}, Típus: {this.tipusNev}, Fogyasztás: {this.atlagfogyasztas:F1}l/100km, km óra állása: {this.osszesMegtett_km}km, eddigi fogyasztása: {this.eddigiFogyasztas:f2} l, tartályban van [{this.uzemanyagSzintje:f1} l]";
        }

        public void Menj(int mennyi_km)
        {
            if (mennyi_km < 0)
            {
                throw new ArgumentException("Negatív érték nem fogadható el!");
            }
            if (this.szervizUtani_km + mennyi_km > eloirtSzerviz_km + megengedettTulfutas)
            {
                throw new ArgumentException("Ezt a kocsit előbb szervizelni kell!");
            }

            double mennyitFogyottAzUtaAlatt = mennyi_km / 100d * atlagfogyasztas;
            if (uzemanyagSzintje - mennyitFogyottAzUtaAlatt < 0)
            {
                throw new OverflowException("Nincs elegendő üzemanyag!");
            }


            this.osszesMegtett_km += mennyi_km;
            this.szervizUtani_km += mennyi_km;

            this.eddigiFogyasztas += mennyitFogyottAzUtaAlatt;

            this.uzemanyagSzintje -= mennyitFogyottAzUtaAlatt;
        }

        public void Tankol(double mennyiLiter)
        {
            if (uzemanyagSzintje + mennyiLiter > tartalyMeret)  //túltankolás esete
            {
                this.uzemanyagSzintje = tartalyMeret;
            }
            else
            {
                this.uzemanyagSzintje += mennyiLiter;
            }
        }
    }
}
