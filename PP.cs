using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_application
{
    public partial class PP : Form
    {
        MySqlConnection connection;
        string status;
        int project_id;
        int req_id;
        List<Int32> projectIds = new List<Int32>();
        List<Int32> reqIds = new List<Int32>();
        
        public PP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                project_id = projectIds[listBox1.Items.IndexOf(listBox1.SelectedItem)];
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                req_id = reqIds[listBox2.Items.IndexOf(listBox2.SelectedItem)];
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
                            projectIds.Add(reader.GetInt32("project_id"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void LoadRequirements()
        {
            listBox2.Items.Clear();

            string query = "SELECT * FROM requirements";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader.GetString("type") + ", " + reader.GetString("name"));
                            reqIds.Add(reader.GetInt32("requirement_id"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }
        }

        private void ER_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();
                LoadProjects();
                LoadRequirements();

            }
            catch
            {

            }
        }

        public bool InsertRow(string values)
        {
            try
            {
                label1.Text = values;
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO project_plan (status, project_id, requirement_id) VALUES (" + values + ")",
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

        private void button1_Click(object sender, EventArgs e)
        {
    
            InsertRow("'" + status + "'," + project_id + "," + req_id);
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            status = textBox1.Text;
        }
    }
}
