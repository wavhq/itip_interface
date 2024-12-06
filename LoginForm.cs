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
    public partial class LoginForm : Form
    {
        String login;
        String password;
        MySqlConnection connection;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginTB_TextChanged(object sender, EventArgs e)
        {
            login = loginTB.Text;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

            // Закрываем текущую форму авторизации
            this.Hide();
        }

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {
            password = passwordTB.Text;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Проверка введённых данных
            if (CheckUserCredentials(login, password, out int roleId))
            {
                // Если данные верны, открываем EmployeeForm и передаем roleId
                EmployeeForm employeeForm = new EmployeeForm(roleId);
                employeeForm.Show();
                this.Hide(); // Скрываем форму авторизации
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль.");
            }
        }

        private bool CheckUserCredentials(string login, string password, out int roleId)
        {
            roleId = 0;

            try
            {

                string query = "SELECT roleid FROM users WHERE username = @login AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    roleId = Convert.ToInt32(result);
                    return true; // Пользователь найден
                }
            }
            catch
            {
            }
            return false; // Пользователь не найден
        }

        private void LoginForm_Load(object sender, EventArgs e)
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
    }
}
