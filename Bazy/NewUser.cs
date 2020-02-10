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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        string MysSqlConnect = "datasource=localhost; port=3306; username=root; password=; database=Bazadanych_2020";
        MySqlConnection connection;

        private void textBox_telefon_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox_telefon.Text, "[^0-9]"))
            {
                MessageBox.Show("Wprowadź tylko cyfry.");
                textBox_telefon.Text = textBox_telefon.Text.Remove(textBox_telefon.Text.Length - 1);
            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBox_adres.Text.ToString().Equals("") || textBox_telefon.Text.ToString().Equals(""))
            {
                MessageBox.Show("Uzupełnij brakujące informacje.");
            }
            else if (textBox_telefon.Text.Length < 9)
            {
                MessageBox.Show("Wprowadź prawidłowy numer telefonu.");
            }
            else
            {
                connection = new MySqlConnection(MysSqlConnect);
                connection.Open();

                string adres = textBox_adres.Text.ToString();
                string nr_tel = textBox_telefon.Text.ToString();
                int id_klienta = 0;
                string query = "SELECT * FROM klient ORDER BY id_klienta DESC LIMIT 1  ";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_klienta = int.Parse(reader["id_klienta"].ToString());
                }
                reader.Close();
                id_klienta += 1;

                string query_insert = "INSERT INTO klient (id_klienta, adres, nr_tel) VALUES ('" + id_klienta + "','" + adres +
                    "','" + nr_tel + "')";

                command = new MySqlCommand(query_insert, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Stworzono nowego użytkownika !");
                    this.Close();
                }
            }
        }
    }
}
