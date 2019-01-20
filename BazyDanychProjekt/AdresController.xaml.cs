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
    public partial class AdresController : Window
    {
        ZamowienieController cont;
        int mode;
        Adres adres;

        public AdresController(ZamowienieController controller, int mode)
        {
            this.cont = controller;
            this.mode = mode;
            InitializeComponent();

            if (mode == 0 && cont.osoba.idAdresu != 0)
            {
                adres = DBController.getAdres(cont.osoba.idAdresu);
                miejscowoscTextBox.Text = adres.miejscowosc;
                kodPocztowyTextBox.Text = adres.kodPocztowy;
                ulicaTextBox.Text = adres.ulica;
                nrDomuTextBox.Text = adres.nrDomu;
                nrMieszkaniaTextBox.Text = adres.nrMieszkania.ToString();
            }
            else if (mode == 1 && cont.zamowienie.idAdresuOdbioru != 0)
            {
                adres = DBController.getAdres(cont.zamowienie.idAdresuOdbioru);
                miejscowoscTextBox.Text = adres.miejscowosc;
                kodPocztowyTextBox.Text = adres.kodPocztowy;
                ulicaTextBox.Text = adres.ulica;
                nrDomuTextBox.Text = adres.nrDomu;
                nrMieszkaniaTextBox.Text = adres.nrMieszkania.ToString();
            }
            else if (mode == 2 && cont.zamowienie.idAdresuDoreczenia != 0)
            {
                adres = DBController.getAdres(cont.zamowienie.idAdresuDoreczenia);
                miejscowoscTextBox.Text = adres.miejscowosc;
                kodPocztowyTextBox.Text = adres.kodPocztowy;
                ulicaTextBox.Text = adres.ulica;
                nrDomuTextBox.Text = adres.nrDomu;
                nrMieszkaniaTextBox.Text = adres.nrMieszkania.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Adres nowyAdres = new Adres(ulicaTextBox.Text, nrDomuTextBox.Text, Int32.Parse(nrMieszkaniaTextBox.Text), kodPocztowyTextBox.Text, miejscowoscTextBox.Text);
                DBController.addAdres(nowyAdres);
                if (mode == 0)
                {
                    cont.osoba.idAdresu = DBController.getAdresId(nowyAdres);
                }
                else if (mode == 1)
                {
                    cont.zamowienie.idAdresuOdbioru = DBController.getAdresId(nowyAdres);
                }
                else
                {
                    cont.zamowienie.idAdresuDoreczenia = DBController.getAdresId(nowyAdres);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zły format danych!");
            }

 
        }
    }
}
