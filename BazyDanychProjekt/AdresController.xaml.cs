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

        public AdresController(ZamowienieController controller, int mode)
        {
            this.cont = controller;
            this.mode = mode;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Adres adres = new Adres(ulicaTextBox.Text, nrDomuTextBox.Text, Int32.Parse(nrMieszkaniaTextBox.Text), kodPocztowyTextBox.Text, miejscowoscTextBox.Text);
            DBController.addAdres(adres);
            if(mode == 0)
            {
                cont.nowaOsoba.idAdresu = DBController.getAdresId(adres);
            }
            else if (mode == 1)
            {
                cont.noweZamowienie.idAdresuOdbioru = DBController.getAdresId(adres);
            } else
            {
                cont.noweZamowienie.idAdresuDoreczenia = DBController.getAdresId(adres);
            }
            
            Close();
        }
    }
}
