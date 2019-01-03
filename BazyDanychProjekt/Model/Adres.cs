using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanychProjekt.Model
{
    class Adres
    {
        public int idAdresu;
        public string ulica;
        public string nrDomu;
        public int nrMieszkania;
        public string kodPocztowy;
        public string miejscowosc;

        public Adres(
        string ulica,
        string nrDomu,
        int nrMieszkania,
        string kodPocztowy,
        string miejscowosc)
        {
            this.ulica = ulica;
            this.nrDomu = nrDomu;
            this.nrMieszkania = nrMieszkania;
            this.kodPocztowy = kodPocztowy;
            this.miejscowosc = miejscowosc;
        }

        public Adres(Dictionary<string, object> dictionary)
        {
            this.idAdresu = (int)dictionary["idAdresu"];
            this.ulica = (string)dictionary["ulica"];
            this.nrDomu = (string)dictionary["nrDomu"];
            this.nrMieszkania = (int)dictionary["nrMieszkania"];
            this.kodPocztowy = (string)dictionary["kodPocztowy"];
            this.miejscowosc = (string)dictionary["miejscowosc"];
        }
    }
}
