using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
using System.Xml.Linq;

namespace db_application
{
    public partial class Report : Form
    {
        MySqlConnection connection;
        String status;
        int charged_employee_id;
        string charged_employee;
        int project_id;
        List<Int32> ids = new List<Int32>();
        public Report()
        {
            InitializeComponent();
            
        }
        private void LoadLists()
        {
            listBox1.Items.Clear();

            string query = " SELECT `p`.`project_id`,`p`.`cost`,`p`.`deadline`,`e`.`name`,`c`.`company_name` FROM" +
                "(((`project` `p` JOIN `employee` `e` ON ((`p`.`charged_employee_id` = `e`.`employee_id`)))" +
                "JOIN `request` `r` ON ((`p`.`request_id` = `r`.`request_id`)))" +
                "JOIN `client` `c` ON ((`r`.`client_id` = `c`.`client_id`)))";
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
                            
                            //listBox1_hidden.Items.Add(reader.GetInt32("project_id"));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
            }


            listBox2.Items.Clear();

            query = " SELECT name FROM employee";
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
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO report (status, charged_employee_id, project_id) VALUES (" + values + ")",
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
            if (listBox1.Items.IndexOf(listBox1.SelectedItem) != -1){
                project_id = ids[listBox1.Items.IndexOf(listBox1.SelectedItem)];
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            charged_employee = listBox2.SelectedItem.ToString();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            status = textBox2.Text;
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
            label2.Text = "'" + status + "','" + charged_employee + "','" + project_id + "'";
            InsertRow("'" + status + "','" + charged_employee_id + "','" + project_id + "'");
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();
                LoadLists();

            }
            catch
            {

            }
        }

    }
}
