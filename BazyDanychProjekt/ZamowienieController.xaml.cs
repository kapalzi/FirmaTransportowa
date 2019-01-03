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
        public Zamowienie noweZamowienie;
        public Osoba nowaOsoba;

        public ZamowienieController()
        {
            noweZamowienie = new Zamowienie();
            nowaOsoba = new Osoba();
            InitializeComponent();
        }

        //dodaj adres osoby
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdresController adres = new AdresController(this,0);
            adres.Show();
        }

        //adres odboioru
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdresController adres = new AdresController(this,1);
            adres.Show();
        }

        //Adres doreczenia
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdresController adres = new AdresController(this,2);
            adres.Show();
        }
        
        //wyslij
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            nowaOsoba.imie = imieTextBox.Text;
            nowaOsoba.nazwisko = imieTextBox.Text;
            nowaOsoba.numerTelefonu = nrTelefonuTextBox.Text;
            noweZamowienie.wagaPaczki = float.Parse(wagaPaczkiTextBox.Text);

            DBController.addOsoba(nowaOsoba);
            noweZamowienie.idOsoby = DBController.getIdOsoby(nowaOsoba);
            DBController.addZamowienie(noweZamowienie);
        }
    }
}
