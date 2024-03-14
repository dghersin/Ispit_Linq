using Ispit_Linq.Model;

namespace Ispit_Linq
{
    public class Program
    {
        static void Main(string[] args)

        //////    DANIEL GHERSINICH dghersin@gmail.com   ///////////

        {
            Podaci podaci = new Podaci();

            podaci.ListaBanki.Add(new Banka { Simbol = "XYZ", Naziv = "Zagrebačka Banka" });
            podaci.ListaBanki.Add(new Banka { Simbol = "ABC", Naziv = "Privredna Banka" });
            podaci.ListaBanki.Add(new Banka { Simbol = "DEF", Naziv = "Erste Banka" });

            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Marko Marković", Stanje = 102000000, Banka = "XYZ" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Mirko Mirković", Stanje = 65000, Banka = "ABC" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Zlatko Zlatić", Stanje = 70, Banka = "ABC" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Franko Frankić", Stanje = 6200000, Banka = "DEF" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Darko Darkić", Stanje = 300000, Banka = "XYZ" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Ivica Ivić", Stanje = 7500, Banka = "ABC" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Pero Perić", Stanje = 9000000, Banka = "DEF" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Žarko Žarkovski", Stanje = 1200000, Banka = "DEF" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Suljo Suljić", Stanje = 684000000, Banka = "ABC" });
            podaci.ListaKlijenata.Add(new Klijent { ImePrezime = "Boris Božić", Stanje = 3200, Banka = "XYZ" });




            //var SviKorisnici = podaci.ListaKlijenata
            //    .Where(k => k.Stanje >= 0)
            //    .GroupBy(k => k.Banka)
            //    .Select(g => new GrupiraniMilijunasi
            //    {
            //        Banka = g.Key,
            //        Milijunasi = g.Select(k => k.ImePrezime)
            //    });
            //foreach (var grupa in SviKorisnici)
            //{
            //    Console.WriteLine("***************************");
            //    Console.WriteLine($"Šifra Banke: {grupa.Banka}");
            //    foreach (var milijunas in grupa.Milijunasi)
            //    {
            //        Console.WriteLine($"Milijunaš: {milijunas}");
            //    }
            //}
            //Console.WriteLine("***************************");


            //////////////////////////////////////////////////////

            var GrupirajPremaBanci = podaci.ListaKlijenata
                .Where(k => k.Stanje >= 1000000)
                .GroupBy(k => k.Banka)
                .Select(g => new GrupiraniMilijunasi
                {
                    Banka = g.Key,
                    Milijunasi = g.Select(k => k.ImePrezime)
                });
            
            
            foreach (var grupa in GrupirajPremaBanci)
            {
                Console.WriteLine("***************************");
                Console.WriteLine($"Šifra Banke: {grupa.Banka}");
                foreach (var milijunas in grupa.Milijunasi)
                {
                    Console.WriteLine($"Milijunaš: {milijunas}");
                }
            }
            Console.WriteLine("***************************");
            
            /////////////////////////////////////////////////////

            var IzvjestajMilijunasa = podaci.ListaKlijenata
                .Where(k => k.Stanje >= 1000000)
                .Select(k => new { ImePrezime = k.ImePrezime,
                    Stanje = k.Stanje, Banka = podaci.ListaBanki
                .First(b => b.Simbol == k.Banka).Naziv });


            Console.WriteLine();
            Console.WriteLine("Popis miljunaša, pripadajuće banke i iznos na računu");
            Console.WriteLine();
            foreach (var klijent in IzvjestajMilijunasa)
            {
                Console.WriteLine($"Ime i prezime: {klijent.ImePrezime}, Banka: {klijent.Banka}, Stanje: {klijent.Stanje:N2}");
            }



        }
    }
}
