using Google.Protobuf.WellKnownTypes;
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
    public partial class PE : Form
    {
        MySqlConnection connection;
        int project_id;
        List<Int32> ids = new List<Int32>();
        int employee_id;
        string employee;
        public PE()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SR_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();
                LoadProjects();
                LoadEmployees();

            }
            catch
            {

            }
        }

        private void LoadProjects()
        {
            listBox1.Items.Clear();

            string query = "SELECT * FROM view_project_id"; 
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetInt32("cost").ToString() + ", " + reader.GetDateTime("deadline").ToString()
                                + ", " + reader.GetString("name") + ", " + reader.GetString("company_name"));
                            ids.Add(reader.GetInt32("project_id"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void LoadEmployees()
        {
            listBox2.Items.Clear();

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

        public bool InsertRow(string values)
        {
            try
            {
                label1.Text = values;
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO project_employee (project_id, employee_id) VALUES (" + values + ")",
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                project_id = ids[listBox1.Items.IndexOf(listBox1.SelectedItem)];
            }
            catch
            {

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                employee = listBox2.SelectedItem.ToString();
            }
            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (MySqlCommand cmd = new MySqlCommand("SELECT employee_id FROM employee WHERE name = '" + employee + "'", connection))
            {
                object result2 = cmd.ExecuteScalar();
                if (result2 != null)
                {
                    employee_id = Convert.ToInt32(result2);
                }
            }

            InsertRow(project_id + "," + employee_id);
            this.Hide();
        }

        private void PE_Load(object sender, EventArgs e)
        {

        }
    }
}
