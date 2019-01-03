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
    public class Menu : Window
    {
        public List<Zamowienie> listaZamowien;
        String userLogin;

        public Menu()
        {
           // this.userLogin = login;
        }

        private bool AreOrdersForUser()
        {
            return true;
        }

        public void GetListeZamowien()
        {
            listaZamowien = DBController.getListaZamowien();
        }

        public List<String> GetListeZamowienDoWyswietlenia()
        {
            List<String> list = new List<String>();
            listaZamowien.ForEach(x => {
                Console.WriteLine(x.idZamowienia.ToString());
                String tmp = "Zamówienie nr " + x.idZamowienia.ToString();
                list.Add(tmp); });

            return list;
        }
    }
}
