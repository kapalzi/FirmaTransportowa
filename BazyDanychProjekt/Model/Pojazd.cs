using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanychProjekt.Model
{

    public class Pojazd
    {
        public int idPojazdu;
        public string numerRejestracyjny;
        public string rodzaj;
        public string marka;
        public string model;
        public bool sprawnosc;
        public bool dostepnosc;

        public Pojazd(string numerRejestracyjny,
        string rodzaj,
        string marka,
        string model,
        bool sprawnosc,
        bool dostepnosc)
        {
            this.numerRejestracyjny = numerRejestracyjny;
            this.rodzaj = rodzaj;
            this.marka = marka;
            this.model = model;
            this.sprawnosc = sprawnosc;
            this.dostepnosc = dostepnosc;
        }

        public Pojazd(Dictionary<string, object> dictionary)
        {
            this.numerRejestracyjny = (string)dictionary["numerRejestracyjny"];
            this.rodzaj = (string)dictionary["rodzajPojazdu"];
            this.marka = (string)dictionary["markaPojazdu"];
            this.model = (string)dictionary["modelPojazdu"];
            this.sprawnosc = (bool)dictionary["sprawnoscPojazdu"];
            this.dostepnosc = (bool)dictionary["dostepnoscPojazdu"];
        }

        public Pojazd()
        {

        }
    }
}
