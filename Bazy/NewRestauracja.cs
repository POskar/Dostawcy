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
    public partial class NewRestauracja : Form
    {
        public NewRestauracja()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        string MysSqlConnect = "datasource=localhost; port=3306; username=root; password=; database=Bazadanych_2020";
        MySqlConnection connection;

        private void button_create_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(MysSqlConnect);
                connection.Open();

                if (textBox_nazwa.Text.Equals("") || textBox_adres.Text.Equals("") || textBox_imie.Text.Equals("") || textBox_cena.Text.Equals(""))
                {
                    MessageBox.Show("Uzupełnij brakujące informacje !");
                }
                else
                {
                    string nazwa = "", adres = "", imie = "";
                    int id_restauracji = 0;
                    float cena = 0;
                    string query = "SELECT id_restauracji FROM restauracje ORDER BY id_restauracji DESC LIMIT 1  ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        id_restauracji = int.Parse(reader["id_restauracji"].ToString());
                    }
                    reader.Close();
                    id_restauracji += 1;

                    nazwa = textBox_nazwa.Text;
                    imie = textBox_imie.Text;
                    adres = textBox_adres.Text;
                    cena = float.Parse(textBox_cena.Text);

                    if(cena > 100 || cena <= 0)
                    {
                        MessageBox.Show("Absurdalna cena !");
                    }
                    else
                    {
                        string query_insert = "INSERT INTO restauracje (id_restauracji, nazwa, adres, właściciel, cena) VALUES" +
                                                "('" + id_restauracji + "','" + nazwa + "','" + adres + "','" + imie + "','" + cena + "')";

                        command = new MySqlCommand(query_insert, connection);
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Nowa restauracja została dodana z numerem ID '" + id_restauracji + "'.");
                            this.Close();
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

        private void textBox_nazwa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Wprowadź tylko litery !");
            }
        }

        private void textBox_adres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Wprowadź tylko litery !");
            }
        }

        private void textBox_imie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Wprowadź tylko litery !");
            }
        }

        private void textBox_cena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
