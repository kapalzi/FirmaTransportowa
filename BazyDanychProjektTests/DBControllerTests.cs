using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazyDanychProjekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazyDanychProjekt.Model;

namespace BazyDanychProjekt.Tests
{
    [TestClass()]
    public class DBControllerTests
    {
        [TestMethod()]
        public void addAdresTest()
        {
            DBController.loginToDb("klient", "");

            string ulica = "Jakas Ulica";
            string nrDomu = "12";
            string nrMieszkania = "4";
            string kodPocztowy = "45-231";
            string miejscowosc = "Wroclaw";

            Adres adres = new Adres(ulica, nrDomu,
                Int32.Parse(nrMieszkania),
                kodPocztowy,
                miejscowosc);

            Assert.AreEqual(true, DBController.addAdres(adres));
        }

        [TestMethod()]
        public void addOsobaTest()
        {
            DBController.loginToDb("klient", "");

            Osoba osoba = new Osoba();
            osoba.idAdresu = 2;
            osoba.imie = "Jan";
            osoba.nazwisko = "Nowak";
            osoba.numerTelefonu = "34269";

            Assert.AreEqual(true, DBController.addOsoba(osoba));
        }
    }
}