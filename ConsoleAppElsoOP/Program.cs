
using System.Numerics;
using System.Security.Cryptography;

namespace ConsoleAppElsoOP
{
    public class Haromszog
    {
        //Attribútum (adattagok)
        private double aOldal, bOldal, cOldal;
        //Metódusok (viselkedés)
        public double GetAoldal()
        {
            return aOldal;
        }
        public double GetAoldalInch()
        {
            return aOldal / 2.54;
        }
        //public double BOldal => bOldal;
        public void SetAoldal(double ujErtek)
        {
            if (ujErtek > 0)
            {
                aOldal = ujErtek;
            }
            else
            {
                throw new ArgumentException("Az oldal hossza nem lehet negatív vagy nulla!");
            }
        }
        public double Kerulet()
        {
            return aOldal + bOldal + cOldal;
        }
        public void Kiir()
        {
            Console.WriteLine($"a oldal: {aOldal}, b oldal: {bOldal}, c oldal: {cOldal}");
        }
        //Konstruktor - feladata az objektum létrehozásakor az adattagok értékadásának megkönnyítése
        public Haromszog()
        {
            aOldal = 3;
            bOldal = 4;
            cOldal = 5;
        }
        public Haromszog(double aOldal, double bOld, double cOld)
        {
            this.aOldal = aOldal;
            bOldal = bOld;
            cOldal = cOld;
        }

        public Haromszog(string csvLine)
        {
            string[] adatok = csvLine.Split(';');
            aOldal = double.Parse(adatok[0]);
            bOldal = double.Parse(adatok[1]);
            cOldal = double.Parse(adatok[2]);
        }

    }

    public class Program
    {

        static void Main(string[] args)
        {
            Auto skoda, passat;

            skoda = new Auto("AB-CD-123", "Skoda SuperB", 55, 5.23, 16000);

            //Haromszog egyebHaromszog = new Haromszog();

            Random rnd = new Random();
            for (int i = 0; i < 120; i++)
            {
                int tervezettUt = rnd.Next(100, 600);
                Console.WriteLine($"{i + 1}. ({tervezettUt}km) Út előtt: {skoda}");

                if (skoda.EsedekesSzerviz())
                {
                    Console.WriteLine("Lassan menni kellene a szervizbe!");
                }
                try
                {
                    skoda.Menj(tervezettUt);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ezt a kocsit előbb szervizelni kell!\n");
                    skoda.SzervizElvegzese();
                    try
                    {
                        skoda.Menj(tervezettUt);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Tankolni kell!");
                        skoda.Tankol(skoda.TartalyMeret);
                        skoda.Menj(tervezettUt); ;
                    }
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Tankolni kell!");
                    skoda.Tankol(skoda.TartalyMeret);
                    skoda.Menj(tervezettUt);
                }
                Console.WriteLine($"{i + 1}. Út után: {skoda}\n");

            }




            //egyebHaromszog.SetAoldal(564);
            //Console.WriteLine(egyebHaromszog.Kerulet());
            //Console.WriteLine(egyebHaromszog.GetAoldalInch());

            //Haromszog egyenloszaru = new Haromszog(12, 12, 23);

            //Haromszog altalanos = new Haromszog("12,8;34;20,345");

            //List<Haromszog> haromszogek = new List<Haromszog>();


            //haromszogek.Add(egyebHaromszog);
            //haromszogek.Add(egyenloszaru);
            //haromszogek.Add(altalanos);

            //foreach (Haromszog h in haromszogek)
            //{
            //    h.Kiir();
            //    Console.WriteLine($"Kerület: {h.Kerulet()}");
            //    Console.WriteLine();
            //}


            /*
            const int MaxOszlop = 100;
            const int MaxSor = 50;
            List<Cella> terkep = new();

            for (int oszlopIndex = 0; oszlopIndex < MaxOszlop; oszlopIndex++)
            {
                for (int sorIndex = 0; sorIndex < MaxSor; sorIndex++)
                {
                    Cella ujUres = new Cella(sorIndex, oszlopIndex, Tereptargy.sik);
                    terkep.Add(ujUres);
                }
            }

            Random rnd = new();
            for (int i = 0; i < 100; i++)
            {
                int sorIndex = rnd.Next(MaxSor);
                int oszlopIndex = rnd.Next(MaxOszlop);
                Tereptargy ujTagy = Tereptargy.sik;
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        ujTagy = Tereptargy.szikla;
                        break;
                    case 2:
                        ujTagy = Tereptargy.vizjeg;
                        break;
                    case 3:
                        ujTagy = Tereptargy.ritkaArany;
                        break;
                    case 4:
                        ujTagy = Tereptargy.ritkaAsvany;
                        break;
                }
                Cella ujCella = new Cella(sorIndex, oszlopIndex, ujTagy);
                terkep.Add(ujCella);
            }


            Console.WriteLine($"Vízjég száma:{terkep.Count(cella => cella.Targy == Tereptargy.vizjeg)}");

            List<Cella> vizjegek = terkep.Where(cella => cella.Targy == Tereptargy.vizjeg).ToList();

            // (0,0) ponthoz mért távolság
            var rendezett = vizjegek.OrderBy(x => Math.Sqrt(Math.Pow(x.SorIndex, 2) + Math.Pow(x.OszlopIndex, 2)));

            foreach (var item in rendezett)
            {
                Console.WriteLine($"{item.SorIndex}:{item.OszlopIndex}");
            }

            //Cella[,] matrixTerkep = new Cella[50, 50];
            //matrixTerkep[3, 5] = new Cella();
            */
        }
    }
}
