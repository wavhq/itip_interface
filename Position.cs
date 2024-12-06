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
    public partial class Position : Form
    {
        MySqlConnection connection;
        String name;
        public Position()
        {
            InitializeComponent();
        }

        private void Post_Load(object sender, EventArgs e)
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

                    "INSERT INTO position (name) VALUES (" + values + ")",
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
            InsertRow("'" + name + "'");
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }
}
