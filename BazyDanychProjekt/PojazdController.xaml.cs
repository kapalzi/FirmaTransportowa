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
    /// Interaction logic for PojazdController.xaml
    /// </summary>
    public partial class PojazdController : Window
    {
        List<Pojazd> listaPojazdow;
        Pojazd wybranyPojazd;
        public PracownikMenu pracownikMenu;

        public PojazdController(PracownikMenu pracownikMenu)
        {
            this.pracownikMenu = pracownikMenu;
            RefreshList();
        }

        private void RefreshList()
        {
            this.listaPojazdow = DBController.getListaPojazdow();
            List<string> list = this.GetListePojazdowDoWyswietlenia();
            InitializeComponent();
            listBox.ItemsSource = list;
        }

        //wyswietl info
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nrRejestracyjnyTextBox.Text = wybranyPojazd.numerRejestracyjny;
                rodzajTextBox.Text = wybranyPojazd.rodzaj;
                markaTextBox.Text = wybranyPojazd.marka;
                modelTextBox.Text = wybranyPojazd.model;
                sprawnoscTextBox.Text = wybranyPojazd.sprawnosc.ToString();
                dostepnoscTextBox.Text = wybranyPojazd.dostepnosc.ToString();

                saveEditBtn.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Nie wybrano pojazdu!");
            }
        }

        //edytuj
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wybranyPojazd.rodzaj = rodzajTextBox.Text;
            wybranyPojazd.marka = markaTextBox.Text;
            wybranyPojazd.model = modelTextBox.Text;
            if (sprawnoscTextBox.Text.ToLower() == "true")
            {
                wybranyPojazd.sprawnosc = true;
            } else
            {
                wybranyPojazd.sprawnosc = false;
            }
            if (dostepnoscTextBox.Text.ToLower() == "true")
            {
                wybranyPojazd.dostepnosc = true;
            }
            else
            {
                wybranyPojazd.dostepnosc = false;
            }

            DBController.editPojazd(wybranyPojazd);
            RefreshList();
        }

        //przypisz
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pracownikMenu.wybraneZamowienie.idPojazdu = DBController.getIdPojazdu(wybranyPojazd);
            DBController.editZamowienie(pracownikMenu.wybraneZamowienie);
            Close();
        }

        private List<string> GetListePojazdowDoWyswietlenia()
        {
            List<String> list = new List<String>();
            listaPojazdow.ForEach(x => {
                String tmp = x.numerRejestracyjny;
                list.Add(tmp);
            });

            return list;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranyPojazd = listaPojazdow[listBox.SelectedIndex];
        }
    }
}