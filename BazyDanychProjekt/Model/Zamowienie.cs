using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanychProjekt.Model
{
    public class Zamowienie
    {
        public int idZamowienia;
        public int idPracownika;
        public int idPojazdu;
        public int idOsoby;
        public int idAdresuOdbioru;
        public int idAdresuDoreczenia;
        public float cena;
        public DateTime dataZamowienia;
        public DateTime terminZamowienia;
        public bool czyOplacono;
        public float wagaPaczki;
        public string stanZamowienia;
        public string sciezkaDoPlikuFaktury;

        public Zamowienie(
        int idPracownika,
        int idPojazdu,
        int idOsoby,
        int idAdresuOdbioru,
        int idAdresuDoreczenia,
        float cena,
        DateTime dataZamowienia,
        DateTime terminZamowienia,
        bool czyOplacono,
        float wagaPaczki,
        string stanZamowienia,
        string sciezkaDoPlikuFaktury)
        {
            this.idPracownika = idPracownika;
            this.idPojazdu = idPojazdu;
            this.idOsoby = idOsoby;
            this.idAdresuOdbioru = idAdresuOdbioru;
            this.idAdresuDoreczenia = idAdresuDoreczenia;
            this.cena = cena;
            this.dataZamowienia = dataZamowienia;
            this.terminZamowienia = terminZamowienia;
            this.czyOplacono = czyOplacono;
            this.wagaPaczki = wagaPaczki;
            this.stanZamowienia = stanZamowienia;
            this.sciezkaDoPlikuFaktury = sciezkaDoPlikuFaktury;
        }

        public Zamowienie(Dictionary<string, object> dictionary)
        {
            this.idZamowienia = (int)dictionary["idZlecenia"];
            this.idPracownika = (int)dictionary["idPracownika"];
            this.idPojazdu = (int)dictionary["idPojazdu"];
            this.idOsoby = (int)dictionary["idOsoby"];
            this.idAdresuOdbioru = (int)dictionary["miejsceOdbioru"];
            this.idAdresuDoreczenia = (int)dictionary["miejsceDoreczenia"];
            this.cena = (float)dictionary["cena"];
            this.dataZamowienia = (DateTime)dictionary["dataZamowienia"];
            this.terminZamowienia = (DateTime)dictionary["terminZlecenia"];
            this.czyOplacono = (bool)dictionary["czyOplacone"];
            this.wagaPaczki = (float)dictionary["wagaPaczki"];
            this.stanZamowienia = (string)dictionary["stanZamowienia"];
            this.sciezkaDoPlikuFaktury = (string)dictionary["sciezkaDoPlikuFaktury"];
        }

        public Zamowienie()
        {

        }

    }
}
