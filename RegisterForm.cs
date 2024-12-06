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
    public partial class RegisterForm : Form
    {
        MySqlConnection connection;
        String login;
        String pass;
        String passcf;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            passcf = passwordCfTB.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            String roleid;
            if (radioButton1.Checked)
            {
                roleid = "2";
            }
            else
            {
                roleid = "1";
            }
            AddUser(login, pass, passcf, roleid);
        }
        public bool AddUser(String login, String passwd, String passwdconf, String roleid)
        {
            try
            {
               
                if (passwd != passwdconf)
                {
                    throw new Exception("Passwords do not match");
                }
                MySqlCommand command = new MySqlCommand(
                    "INSERT INTO users (username, password, roleid) VALUES (@login, @passwd, @roleid)", connection);
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = passwd;
                command.Parameters.Add("@roleid", MySqlDbType.VarChar).Value = roleid;
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт был создан");
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                    
                }
                    

                else
                    throw new Exception("Incorrect SQL Query");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка регистрации пользователя\nПричина: " + e.Message);
            }
            return false;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
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

        private void loginTB_TextChanged(object sender, EventArgs e)
        {
            login = loginTB.Text;
        }

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {
            pass = passwordTB.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
