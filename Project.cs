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
    public partial class Project : Form
    {
        MySqlConnection connection;
        Int32 cost;
        String date;
        int charged_employee_id;
        string charged_employee;
        int request_id;
        List<Int32> ids = new List<Int32>();
        public Project()
        {
            InitializeComponent();
        }

        private void Resr_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();
                LoadEmployees();
                LoadRequests();

            }
            catch
            {

            }
        }

        private void LoadEmployees()
        {
            listBox1.Items.Clear();

            string query = "SELECT name FROM employee"; 
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader.GetString("name"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void LoadRequests()
        {
            listBox1.Items.Clear();

            string query = "SELECT * FROM view_request_id";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetDateTime("date_of_creation").ToString() + ", " + reader.GetString("status") + ", " + reader.GetString("company_name"));
                            ids.Add(reader.GetInt32("request_id"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (MySqlCommand cmd = new MySqlCommand("SELECT employee_id FROM employee WHERE name = '" + charged_employee + "'", connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    charged_employee_id = Convert.ToInt32(result);
                }
            }
            InsertRow("'" + cost + "','" + date + "'," + charged_employee_id + "," + request_id);
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cost = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления строки\nПричина: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            date = textBox2.Text;
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO project (cost, deadline, charged_employee_id, request_id) VALUES (" + values + ")",
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            charged_employee = listBox2.SelectedItem.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                request_id = ids[listBox1.Items.IndexOf(listBox1.SelectedItem)];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выбора заявки\nПричина: " + ex.Message);
            }
        }
    }
}
