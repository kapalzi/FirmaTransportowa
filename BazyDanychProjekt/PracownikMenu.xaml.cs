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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class PracownikMenu : Menu
    {
        List<string> items = new List<string>();
        public Zamowienie wybraneZamowienie;
        public PracownikMenu()
        {
            this.GetListeZamowien();
            List<string> list = this.GetListeZamowienDoWyswietlenia();

            InitializeComponent();

            listBox.ItemsSource = list;
        }


        //przypisz pojazd
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zamowienie wybraneZamowienie = listaZamowien[listBox.SelectedIndex];
                WyswietlListePojazdow(wybraneZamowienie);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nie wybrano zamówienia!");
            }
        }

        private void WyswietlListePojazdow(Zamowienie zamowienie)
        {
            PojazdController pojazdController = new PojazdController(this);
            pojazdController.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybraneZamowienie = listaZamowien[listBox.SelectedIndex];
        }
    }
}
