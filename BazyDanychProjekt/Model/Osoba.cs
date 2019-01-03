using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanychProjekt.Model
{
    public class Osoba
    {
        public int idAdresu;
        public string imie;
        public string nazwisko;
        public int idOsoby;
        public string numerTelefonu;
        public string rola;

        public Osoba(int idAdresu,
        string imie,
        string nazwisko,
        int idOsoby,
        string numerTelefonu,
        string rola)
        {
            this.idAdresu = idAdresu;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.idOsoby = idOsoby;
            this.numerTelefonu = numerTelefonu;
            this.rola = rola;
        }

        public Osoba(Dictionary<string, object> dictionary)
        {
            this.idAdresu = (int)dictionary["idAdresu"];
            this.imie = (string)dictionary["imie"];
            this.nazwisko = (string)dictionary["nazwisko"];
            this.idOsoby = (int)dictionary["idOsoby"];
            this.numerTelefonu = (string)dictionary["numerTelefonu"];
            this.rola = (string)dictionary["rola"];
        }

        public Osoba()
        {

        }
    }
}
