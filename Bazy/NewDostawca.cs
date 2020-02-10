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
    public partial class NewDostawca : Form
    {
        public NewDostawca()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        string MysSqlConnect = "datasource=localhost; port=3306; username=root; password=; database=Bazadanych_2020";
        MySqlConnection connection;

        private void textBox_nazwisko_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button_create_Click(object sender, EventArgs e)
        {
            try
            {
                string nazwisko = "", imie = "", typ_pojazdu = "";
                if(textBox_imie.Text.Equals("") || textBox_nazwisko.Text.Equals("") || comboBox_typ_pojazdu.Text.Equals(""))
                {
                    MessageBox.Show("Uzupełnij brakujące informacje !");
                }
                else
                {
                    connection = new MySqlConnection(MysSqlConnect);
                    connection.Open();

                    int id_dostawcy = 0;

                    string query = "SELECT id_dostawcy FROM dostawcy ORDER BY id_dostawcy DESC LIMIT 1  ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        id_dostawcy = int.Parse(reader["id_dostawcy"].ToString());
                    }
                    reader.Close();
                    id_dostawcy += 1;

                    nazwisko = textBox_nazwisko.Text;
                    imie = textBox_imie.Text;
                    typ_pojazdu = comboBox_typ_pojazdu.SelectedItem.ToString();

                    string query_insert = "INSERT INTO dostawcy (id_dostawcy, imię, nazwisko, typ_pojazdu, dostępność) VALUES" +
                        "('" + id_dostawcy + "','" + imie + "','" + nazwisko + "','" + typ_pojazdu + "', '1')";

                    command = new MySqlCommand(query_insert, connection);
                    if(command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Nowy dostawca zostal utworzony z numerem ID '" + id_dostawcy + "'.");
                        this.Close();
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
    }
}
