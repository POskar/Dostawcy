using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bazy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        string sql,sql2,sql3, MysSqlConnect = "datasource=localhost; port=3306; username=root; password=; database=Bazadanych_2020";
        MySqlConnection connection;
        MySqlDataAdapter da,da2,da3;
        DataTable dt,dt2,dt3;


        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(MysSqlConnect);
            sql = "SELECT id_dostawcy, imię AS 'Imię', nazwisko AS 'Nazwisko', typ_pojazdu,dostępność FROM dostawcy;";
            sql2 = "SELECT id_restauracji, nazwa, adres,właściciel FROM restauracje;";
            sql3 = "SELECT id_zamowienia, d.imię AS 'Imie dostawcy', d.nazwisko AS 'Nazwisko Dostawcy',r.nazwa AS 'Nazwa Restauracji'," +
                "r.adres AS 'Adres Restauracji',z.typ_platnosci,z.cena,z.ilosc,z.powodzenie, k.adres AS 'Adres Klienta' " +
                "FROM zamówienia z INNER JOIN dostawcy d ON d.id_dostawcy = z.id_dostawcy INNER JOIN restauracje r " +
                "ON z.id_restauracji = r.id_restauracji INNER JOIN klient k ON k.id_klienta = z.id_klienta;";

            try
            {
                connection.Open();

                da = new MySqlDataAdapter(sql,connection);
                dt = new DataTable();
                da.Fill(dt);

                da2 = new MySqlDataAdapter(sql2, connection);
                dt2 = new DataTable();
                da2.Fill(dt2);

                da3 = new MySqlDataAdapter(sql3, connection);
                dt3 = new DataTable();
                da3.Fill(dt3);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
            finally
            {
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;

                dataGridView2.Refresh();
                dataGridView2.DataSource = dt2;

                dataGridView3.Refresh();
                dataGridView3.DataSource = dt3;

            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(MysSqlConnect);
                connection.Open();

                int rowindex = dataGridView3.CurrentRow.Index;
                int id_zamowienia = int.Parse(dataGridView3.Rows[rowindex].Cells[0].Value.ToString());
                int id_dostawcy = 0;
                string powodzenieIsNull = "";

                string query = "SELECT * FROM zamówienia WHERE id_zamowienia ='" + id_zamowienia + "'";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    powodzenieIsNull = reader["powodzenie"].ToString();
                    id_dostawcy = int.Parse(reader["id_dostawcy"].ToString());
                }
                reader.Close();

                if (powodzenieIsNull.Equals("False"))
                {
                    string query2 = "UPDATE zamówienia SET powodzenie = 1 WHERE id_zamowienia ='" + id_zamowienia + "'";
                    command = new MySqlCommand(query2, connection);

                    DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz potwierdzić?", "Potwierdzenie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            string query3 = "UPDATE dostawcy SET dostępność = 1 WHERE id_dostawcy ='" + id_dostawcy + "'";
                            command = new MySqlCommand(query3, connection);

                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Odbiór zamówienia o numerze ID '" + id_zamowienia + "' został potwierdzony !");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("To zamówienie jest już odebrane !");
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

        private void add_restaurator_Click(object sender, EventArgs e)
        {
            NewRestauracja restauracja = new NewRestauracja();
            restauracja.Show();
        }

        private void add_dostawca_Click(object sender, EventArgs e)
        {
            NewDostawca dostawca = new NewDostawca();
            dostawca.Show();
        }

        private void delete_dostawca_Click(object sender, EventArgs e)
        {
           
        }

        private void delete_restaurator_Click(object sender, EventArgs e)
        {

        }
    }
}
