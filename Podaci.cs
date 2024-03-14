using Ispit_Linq.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit_Linq
{
    public class Podaci
    {
        public List<Banka> ListaBanki { get; set; }
        public List<Klijent> ListaKlijenata { get; set; }

        public Podaci()
        {
            ListaBanki = new List<Banka>();
            ListaKlijenata = new List<Klijent>();
        }



    }


}
