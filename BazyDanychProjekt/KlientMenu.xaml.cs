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
    /// Interaction logic for Klient.xaml
    /// </summary>
    public partial class KlientMenu : Window
    {
        public KlientMenu()
        {
           InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zlozNoweZamowienie();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            oplacZamowienie();
        }

        private void zlozNoweZamowienie()
        {
            ZamowienieController zamowienie = new ZamowienieController();
            zamowienie.Show();
        }

        private void oplacZamowienie()
        {

        }
    }
}
