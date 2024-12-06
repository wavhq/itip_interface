using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace db_application
{
    public partial class AddEm : Form
    {
        MySqlConnection connection;
        String name_s;
        String sex_s;
        int position_s;
        string position_t;
        String table = "employee";
        public AddEm()
        {
            InitializeComponent();
        }

        private void AddEm_Load(object sender, EventArgs e)
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
            // Очищаем ListBox перед добавлением новых данных
            listBoxPosts.Items.Clear();

            // SQL запрос для извлечения всех должностей
            string query = "SELECT name FROM position"; // Замените на правильное имя столбца в таблице post

            // Создаем подключение к базе данных
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Выполняем команду и получаем результат
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Пока есть строки в результате
                        while (reader.Read())
                        {
                            // Добавляем каждую должность в ListBox
                            listBoxPosts.Items.Add(reader.GetString("name"));
                        }
                    }
                }

            }
            catch (Exception ex)
                {
                MessageBox.Show("Ошибка подключения или запроса: " + ex.Message);
                }
            }

        private void name_TextChanged(object sender, EventArgs e)
        {
            name_s = name.Text;
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            position_t = listBoxPosts.SelectedItem.ToString();

        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            sex_s = email.Text;
        }

        public bool InsertRow(string values)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(

                    "INSERT INTO employee (name, sex, position_id) VALUES (" + values + ")",
                    connection);
                label2.Text = table + values;
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
            using (MySqlCommand cmd = new MySqlCommand("SELECT position_id FROM position WHERE name = '" + position_t + "'", connection))
            {
                label2.Text = "SELECT position_id FROM position WHERE name = '" + position_t + "'";
                object result = cmd.ExecuteScalar();  // Получаем одно значение (position_id)

                // Если результат не пустой, возвращаем position_id
                if (result != null)
                {
                    int postID = Convert.ToInt32(result);  // Преобразуем в int и сохраняем в переменную
                    position_s =  postID;  // Возвращаем значение переменной
                }
            }
            label1.Text = "'" + name_s + "'," + "'" + sex_s + "'," + position_s;
            InsertRow("'" + name_s + "'," + "'" + sex_s + "'," + position_s);
            this.Hide();

        }
    }
}
