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
        MySqlConnection connection, conn;
        MySqlDataAdapter da, da2, da3;
        DataTable dt, dt2, dt3;
        MySqlCommand cmd;


        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(MysSqlConnect);
            conn = new MySqlConnection(MysSqlConnect);
            sql = "SELECT id_dostawcy, imię AS 'Imię', nazwisko AS 'Nazwisko', typ_pojazdu,dostępność FROM dostawcy;";
            sql2 = "SELECT id_restauracji, nazwa, adres, właściciel, cena FROM restauracje;";
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
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
                connection.Close();
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
                            connection.Open();
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
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            string querry = "SELECT COUNT(powodzenie) FROM zamówienia z INNER JOIN dostawcy d ON z.id_dostawcy = d.id_dostawcy WHERE d.id_dostawcy='" + id + "' AND z.powodzenie='0'";
            MySqlCommand command = new MySqlCommand(querry, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();


            reader.Read();

            if (reader["COUNT(powodzenie)"].ToString() == "0")
            {
                sql = " DELETE FROM dostawcy WHERE id_dostawcy='" + id + "'";
                cmd = new MySqlCommand(sql, connection);
                connection.Open();
                String dostepny = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                try
                {
                    da = new MySqlDataAdapter(cmd);

                    da.DeleteCommand = connection.CreateCommand();

                    da.DeleteCommand.CommandText = sql;

                    if (MessageBox.Show("Czy na pewno usunąć?", "Usuwanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Usunięto");
                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }

            }
            else
            {
                MessageBox.Show("Nie można usunąć aktywnego kierowcy", "Usuwanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            conn.Close();
        }

        private void delete_restaurator_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView2.CurrentRow.Index;
            String selected = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            int idd = Convert.ToInt32(selected);
            string querry = "SELECT COUNT(powodzenie) FROM zamówienia z INNER JOIN restauracje r ON z.id_restauracji = r.id_restauracji WHERE z.powodzenie = '0' AND r.id_restauracji = '" + idd + "'";
            MySqlCommand command = new MySqlCommand(querry, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();


            if (reader["COUNT(powodzenie)"].ToString() == "0")
            {
                sql = " DELETE FROM restauracje WHERE id_restauracji='" + idd + "'";
                cmd = new MySqlCommand(sql, connection);
                connection.Open();
                try
                {
                    da = new MySqlDataAdapter(cmd);

                    da.DeleteCommand = connection.CreateCommand();

                    da.DeleteCommand.CommandText = sql;

                    if (MessageBox.Show("Czy na pewno usunąć?", "Usuwanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Usunięto");
                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }

            }
            else
            {
                MessageBox.Show("Nie można usunąć aktywnej restauracji", "Usuwanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            conn.Close();
        }
    }
}
