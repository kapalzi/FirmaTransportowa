using BazyDanychProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BazyDanychProjekt
{
    /// <summary>
    /// Interaction logic for ZamowienieController.xaml
    /// </summary>
    public partial class ZamowienieController : Window
    {
        public Zamowienie zamowienie;
        public Osoba osoba;

        public ZamowienieController()
        {
            InitializeComponent();

            zamowienie = DBController.getZamowienieForUser();
            if (zamowienie != null)
            {
                osoba = DBController.getOsoba(zamowienie.idOsoby);
                imieTextBox.Text = osoba.imie;
                nazwiskoTextBox.Text = osoba.nazwisko;
                nrTelefonuTextBox.Text = osoba.numerTelefonu;
                wagaPaczkiTextBox.Text = zamowienie.wagaPaczki.ToString();
            }
            else
            {
                zamowienie = new Zamowienie();
                osoba = new Osoba();
            }
        }

        public void addAdresOsoby()
        {
            AdresController adres = new AdresController(this, 0);
            adres.Show();
        }

        private void addAdresOdbioru()
        {
            AdresController adres = new AdresController(this, 1);
            adres.Show();
        }

        private void addAdresDoreczenia()
        {
            AdresController adres = new AdresController(this, 2);
            adres.Show();
        }

        private void sprawdzPoprawnosc()
        {
            float val;

            if(float.TryParse(wagaPaczkiTextBox.Text, out val) == true)
            {
                zapisz();
            }
            else
            {
                MessageBox.Show("Waga powinna być liczbą!");
            }
        }

        public void zapisz()
        {
            osoba.imie = imieTextBox.Text;
            osoba.nazwisko = imieTextBox.Text;
            osoba.numerTelefonu = nrTelefonuTextBox.Text;
            zamowienie.wagaPaczki = float.Parse(wagaPaczkiTextBox.Text);

            DBController.addOsoba(osoba);
            zamowienie.idOsoby = DBController.getIdOsoby(osoba);
            if(DBController.addZamowienie(zamowienie))
            {
                MessageBox.Show("Zamówienie zapisane!");
            }
        }

        //dodaj adres osoby
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addAdresOsoby();
        }

        //adres odboioru
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addAdresOdbioru();
        }

        //Adres doreczenia
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addAdresDoreczenia();
        }
        
        //wyslij
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sprawdzPoprawnosc();
        }
    }
}
