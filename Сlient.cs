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
    public partial class Сlient : Form
    {
        MySqlConnection connection;
        String name;
        String email;
        public Сlient()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");

                connection.Open();

            }
            catch
            {

            }
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO client (company_name, email) VALUES (" + values + ")",
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
            name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            email = textBox2.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InsertRow("'" + name + "','" + email + "'");
            this.Hide();
        }
    }
}
