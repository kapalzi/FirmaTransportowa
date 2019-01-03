using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BazyDanychProjekt
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String login = loginTextField.Text;
            String password = passwordTextField.Text;

            if (DBController.loginToDb(login, password))
            {
                if (klientCheckBox.IsChecked.Value)
                {
                    KlientMenu klient = new KlientMenu();
                    klient.Show();
                }
                else if (pracownikCheckBox.IsChecked.Value)
                {
                    PracownikMenu pracownik = new PracownikMenu();
                    pracownik.Show();
                } else
                {
                    MessageBox.Show("Nie wybrano roli!");
                    return;
                }
                Close();
            }
        }
    }
}
