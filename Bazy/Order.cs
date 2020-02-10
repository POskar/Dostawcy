using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bazy
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        string MysSqlConnect = "datasource=localhost; port=3306; username=root; password=; database=Bazadanych_2020";
        MySqlConnection connection;
        private void Order_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(MysSqlConnect);
                string query = "SELECT id_klienta FROM klient";
                string query2 = "SELECT nazwa FROM restauracje";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox_id.Items.Add(reader.GetString("id_klienta"));
                }

                reader.Close();
                command = new MySqlCommand(query2, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox_restauracje.Items.Add(reader.GetString("nazwa"));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private void comboBox_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(MysSqlConnect);
                connection.Open();

                string id = comboBox_id.SelectedItem.ToString();
                string query = "SELECT * FROM klient WHERE id_klienta = '" + id + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    textBox_adres.Text = (reader["adres"].ToString());
                    textBox_tel.Text = (reader["nr_tel"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button_zamow_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(MysSqlConnect);
                connection.Open();

                if (comboBox_id.Text.Length == 0 || comboBox_ilosc.Text.Length == 0 ||
                    comboBox_platnosc.Text.Length == 0 || comboBox_restauracje.Text.Length == 0)
                {
                    MessageBox.Show("Uzupełnij brakujące dane !");
                }
                else
                {

                    int id_zamowienia = 0;

                    string query1 = "SELECT * FROM zamówienia ORDER BY id_zamowienia DESC LIMIT 1  ";

                    MySqlCommand command = new MySqlCommand(query1, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        id_zamowienia = int.Parse(reader["id_zamowienia"].ToString());
                    }
                    reader.Close();
                    id_zamowienia += 1;

                    string typ_zamowienia = "";
                    int ilosc = int.Parse(comboBox_ilosc.SelectedItem.ToString());
                    if (ilosc <= 2)
                    {
                        typ_zamowienia = "Małe";
                    }
                    else if (ilosc > 2 && ilosc < 7)
                    {
                        typ_zamowienia = "Średnie";
                    }
                    else if (ilosc >= 7)
                    {
                        typ_zamowienia = "Duże";
                    }

                    string id_klienta = comboBox_id.SelectedItem.ToString();
                    string id_restauracji = "", koszt = "", nazwa_restauracji = comboBox_restauracje.SelectedItem.ToString();

                    string query2 = "SELECT * FROM restauracje WHERE nazwa ='" + nazwa_restauracji + "'";

                    command = new MySqlCommand(query2, connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        id_restauracji = reader["id_restauracji"].ToString();
                        koszt = reader["cena"].ToString();
                    }
                    reader.Close();

                    string typ_pojazdu, id_dostawcy = "", query3 = "SELECT * FROM dostawcy ORDER BY typ_pojazdu DESC";
                    command = new MySqlCommand(query3, connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        switch (typ_zamowienia)
                        {
                            case "Małe":
                                if (reader["typ_pojazdu"].ToString().Equals("Rower") || reader["typ_pojazdu"].ToString().Equals("Samochód osobowy"))
                                {
                                    if (reader["dostępność"].ToString().Equals("True"))
                                    {
                                        id_dostawcy = reader["id_dostawcy"].ToString();
                                    }
                                }
                                break;
                            case "Średnie":
                                if (reader["typ_pojazdu"].ToString().Equals("Samochód osobowy") || reader["typ_pojazdu"].ToString().Equals("Dostawczy"))
                                {
                                    if (reader["dostępność"].ToString().Equals("True"))
                                    {
                                        id_dostawcy = reader["id_dostawcy"].ToString();
                                    }
                                }
                                break;
                            case "Duże":
                                if (reader["typ_pojazdu"].ToString().Equals("Dostawczy"))
                                {
                                    if (reader["dostępność"].ToString().Equals("True"))
                                    {
                                        id_dostawcy = reader["id_dostawcy"].ToString();
                                    }
                                }
                                break;
                            default:
                                id_dostawcy = "";
                                break;
                        }
                    }
                    reader.Close();

                    string typ_platnosci = comboBox_platnosc.SelectedItem.ToString();

                    float cena = ilosc * float.Parse(koszt);

                    if (id_dostawcy.Equals(""))
                    {
                        MessageBox.Show("Wybacz, ale nie mamy teraz żadnych dostępnych dostawców. \nSpróbuj później !");
                    }
                    else
                    {
                        string query_insert = "INSERT INTO zamówienia (id_zamowienia, typ_zamowienia, id_klienta, id_restauracji, id_dostawcy," +
                        "typ_platnosci, cena, ilosc, powodzenie) VALUES ('" + id_zamowienia + "','" + typ_zamowienia + "','" + id_klienta
                        + "','" + id_restauracji + "','" + id_dostawcy + "','" + typ_platnosci + "','" + cena + "','" + ilosc + "', '0')";

                        string query4 = "UPDATE dostawcy SET dostępność = 0 WHERE id_dostawcy ='" + id_dostawcy + "'";

                        command = new MySqlCommand(query_insert, connection);
                        if (command.ExecuteNonQuery() == 1)
                        {
                            command = new MySqlCommand(query4, connection);

                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Twoje zamówieni zostało złożone !\nProsimy o cierpliwość !");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private void create_account_Click(object sender, EventArgs e)
        {
            NewUser nowy_uzytkownik = new NewUser();
            nowy_uzytkownik.Show();
            this.Close();
        }
    }
}
