using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_application
{
    public partial class Request : Form
    {
        MySqlConnection connection;
        String date;
        String status;
        int client_id;
        string company_name;
        public Request()
        {
            InitializeComponent();
        }

        private void Appl_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();
                LoadPostTitles();

            }
            catch
            {

            }
        }

        private void LoadPostTitles()
        {
            listBox1.Items.Clear();

            string query = "SELECT company_name FROM client";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetString("company_name"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }


        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO request (status, date_of_creation, client_id) VALUES (" + values + ")",
                    connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Что-то пошло не так при добавлении строки");
                MessageBox.Show("Строка успешно добавлена");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления строки\nПричина: " + e.Message);
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            date = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            status = textBox2.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            company_name = listBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT client_id FROM client WHERE company_name = '" + company_name + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    client_id = Convert.ToInt32(result);
                }
            }
            //label2.Text = "'" + status + "','" + date + "','" + client_id;
            InsertRow("'" + status + "','" + date + "','" + client_id + "'");
            this.Hide();

        }
    }
}
