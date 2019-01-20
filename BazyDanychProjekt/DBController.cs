using BazyDanychProjekt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BazyDanychProjekt
{
    public class DBController
    {
        static String connectionString;
        static String user;

        public static bool loginToDb(String login, String password)
        {
            String conStr = "SERVER=localhost;DATABASE=firma_transportowa;uid =" + login + ";Password=" + password + ";";
            Console.WriteLine(conStr);
            MySqlConnection sqlConnection = new MySqlConnection(conStr);
            try
            {
                sqlConnection.Open();
                connectionString = conStr;
                user = login;

                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zły login lub hasło!");
            }

            return false;
        }

        public static List<Zamowienie> getListaZamowien()
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select * from zlecenia";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                List<Zamowienie> zamowienia = new List<Zamowienie>();
                while (reader.Read())
                { 
                    for (int lp = 0; lp < reader.FieldCount; lp++)
                    {
                        dict.Add(reader.GetName(lp), reader.GetValue(lp));
                    }
                    Zamowienie tmp = new Zamowienie(dict);
                    zamowienia.Add(tmp);
                    dict = new Dictionary<string, object>();
                }

                sqlConnection.Close();
                return zamowienia;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return null;
        }

        public static Zamowienie getZamowienieForUser()
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select * from zlecenia where user ='" + user+"'";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                List<Zamowienie> zamowienia = new List<Zamowienie>();
                while (reader.Read())
                {
                    for (int lp = 0; lp < reader.FieldCount; lp++)
                    {
                        dict.Add(reader.GetName(lp), reader.GetValue(lp));
                    }
                    Zamowienie tmp = new Zamowienie(dict);
                    zamowienia.Add(tmp);
                    dict = new Dictionary<string, object>();
                }

                sqlConnection.Close();
                return zamowienia.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return null;
        }

        public static bool addZamowienie(Zamowienie zamowienie)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                String sql = "insert into zlecenia(idPracownika,idPojazdu,idOsoby,miejsceOdbioru,miejsceDoreczenia,cena," +
                    "dataZamowienia,terminZlecenia,wagaPaczki,stanZamowienia,sciezkaDoPlikuFaktury,user)" +
                    " values(2,0,@idOsoby, @miejsceOdbioru, @miejsceDoreczenia, @cena, @dataZamowienia, @terminZlecenia, @wagaPaczki, @stanZamowienia, @sciezkaDoPlikuFaktury, @user)";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idOsoby", zamowienie.idOsoby);
                cmd.Parameters.AddWithValue("@miejsceOdbioru", zamowienie.idAdresuOdbioru);
                cmd.Parameters.AddWithValue("@miejsceDoreczenia", zamowienie.idAdresuDoreczenia);
                cmd.Parameters.AddWithValue("@cena", "1500");
                cmd.Parameters.AddWithValue("@dataZamowienia", DateTime.Now);
                cmd.Parameters.AddWithValue("@terminZlecenia", DateTime.Now);
                cmd.Parameters.AddWithValue("@wagaPaczki", zamowienie.wagaPaczki);
                cmd.Parameters.AddWithValue("@stanZamowienia", "Nowe");
                cmd.Parameters.AddWithValue("@sciezkaDoPlikuFaktury", "C:");
                cmd.Parameters.AddWithValue("@user", user);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return false;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return true;
        }

        public static bool addAdres(Adres adres)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                String sql = "insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) values(@ulica, @nrDomu, @nrMieszkania, @kodPocztowy, @miejscowosc)";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ulica", adres.ulica);
                cmd.Parameters.AddWithValue("@nrDomu", adres.nrDomu);
                cmd.Parameters.AddWithValue("@nrMieszkania", adres.nrMieszkania);
                cmd.Parameters.AddWithValue("@kodPocztowy", adres.kodPocztowy);
                cmd.Parameters.AddWithValue("@miejscowosc", adres.miejscowosc);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
                return false;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return true;
        }

        public static Adres getAdres(int id)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select * from adresy where idAdresu=" + id.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                List<Adres> osoby = new List<Adres>();
                while (reader.Read())
                {
                    for (int lp = 0; lp < reader.FieldCount; lp++)
                    {
                        dict.Add(reader.GetName(lp), reader.GetValue(lp));
                    }
                    Adres tmp = new Adres(dict);
                    osoby.Add(tmp);
                    dict = new Dictionary<string, object>();
                }

                sqlConnection.Close();
                return osoby.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return null;
        }

        public static int getAdresId(Adres adres)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select idAdresu from adresy where kodPocztowy = '"+adres.kodPocztowy+"'";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader.GetValue(0);
                }

                sqlConnection.Close();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return 0;
        }

        public static bool addOsoba(Osoba osoba)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                String sql = "insert into osoby(idAdresu,imie,nazwisko,numerTelefonu,rola) values(@idAdresu, @imie, @nazwisko, @numerTelefonu, @rola)";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idAdresu", osoba.idAdresu);
                cmd.Parameters.AddWithValue("@imie", osoba.imie);
                cmd.Parameters.AddWithValue("@nazwisko", osoba.nazwisko);
                cmd.Parameters.AddWithValue("@numerTelefonu", osoba.numerTelefonu);
                cmd.Parameters.AddWithValue("@rola", "klient");
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine("Exception: " + ex);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return true;
        }

        public static int getIdOsoby(Osoba osoba)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select idOsoby from osoby where numerTelefonu = '" + osoba.numerTelefonu + "'";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader.GetValue(0);
                }

                sqlConnection.Close();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return 0;
        }

        public static Osoba getOsoba(int id)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select * from osoby where idOsoby="+ id.ToString();
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                List<Osoba> osoby = new List<Osoba>();
                while (reader.Read())
                {
                    for (int lp = 0; lp < reader.FieldCount; lp++)
                    {
                        dict.Add(reader.GetName(lp), reader.GetValue(lp));
                    }
                    Osoba tmp = new Osoba(dict);
                    osoby.Add(tmp);
                    dict = new Dictionary<string, object>();
                }

                sqlConnection.Close();
                return osoby.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return null;
        }

        public static List<Pojazd> getListaPojazdow()
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select * from pojazdy";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                Dictionary<string, object> dict = new Dictionary<string, object>();
                List<Pojazd> pojazdy = new List<Pojazd>();
                while (reader.Read())
                {
                    for (int lp = 0; lp < reader.FieldCount; lp++)
                    {
                        dict.Add(reader.GetName(lp), reader.GetValue(lp));
                    }
                    Pojazd tmp = new Pojazd(dict);
                    pojazdy.Add(tmp);
                    dict = new Dictionary<string, object>();
                }

                sqlConnection.Close();
                return pojazdy;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return null;
        }

        public static int getIdPojazdu(Pojazd pojazd)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                String sql = "select idPojazdu from pojazdy where numerRejestracyjny = '" + pojazd.numerRejestracyjny+ "'";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                reader = cmd.ExecuteReader();
                int id = 0;
                while (reader.Read())
                {
                    id = (int)reader.GetValue(0);
                }

                sqlConnection.Close();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }

            return 0;
        }

        public static bool editPojazd(Pojazd pojazd)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                String sql = "update pojazdy set numerRejestracyjny ='"+pojazd.numerRejestracyjny+"', rodzajPojazdu = '"+ pojazd.rodzaj+"', markaPojazdu ='"+ pojazd.marka+"'," +
                    " modelPojazdu = '"+pojazd.model+"', sprawnoscPojazdu ="+ pojazd.sprawnosc+", dostepnoscPojazdu ="+ pojazd.dostepnosc+ " where numerRejestracyjny = '" + pojazd.numerRejestracyjny + "'; ";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                cmd.Prepare();

                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy!");
                Console.WriteLine("Exception: " + ex);
                return false;
            }
            finally
            {
                MessageBox.Show("Zapisano zmiany!");
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            return true;
        }

        public static void editZamowienie(Zamowienie zamowienie)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                String sql = "update zlecenia set idPojazdu =" + zamowienie.idPojazdu +" where idZlecenia = " + zamowienie.idZamowienia + "; ";
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);
                cmd.Prepare();

                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy!");
                Console.WriteLine("Exception: " + ex);
            }
            finally
            {
                MessageBox.Show("Zapisano zmiany!");
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
