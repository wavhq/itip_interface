using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlDataAdapter = MySql.Data.MySqlClient.MySqlDataAdapter;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace db_application
{
    public partial class EmployeeForm : Form
    {
        string[] tableOldNames = new string[]
        {
            "employee",
            "request",
            "client",
            "position",
            "report",
            "project",
            "project_employee",
            "project_plan",
            "requirements"
        };
        string[] tableNames = new string[]
        {
            "itip.view_employee",
            "itip.view_request",
            "itip.view_client",
            "itip.view_position",
            "itip.view_report",
            "itip.view_project",
            "itip.view_project_employee",
            "itip.view_project_plan",
            "itip.view_requirements"
        };

        MySql.Data.MySqlClient.MySqlConnection connection;
        MySql.Data.MySqlClient.MySqlDataAdapter adapter;
        DataSet ds;
        string currentTable;
        private int userRoleId;

        public EmployeeForm(int roleid)
        {
            
            InitializeComponent();
            userRoleId = roleid;

            // Вывод сообщения о роли пользователя
            if (userRoleId == 1)
            {
                MessageBox.Show("Осуществлен вход в систему под ролью Администратор");
            }
            else if (userRoleId == 2)
            {
                MessageBox.Show("Осуществлен вход в систему под ролью Пользователь");
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=itip");
                
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    connectionLabel.Text = "Соединение с базой данных установлено";
                }
                else
                {
                    connectionLabel.Text = "Нет соединения с базой данных";
                }
                employeesDataGridView.CellValueChanged += employeesDataGridView_CellValueChanged;
                employeesDataGridView.UserDeletingRow += employeesDataGridView_UserDeletingRow;

            }
            catch
            {

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void employeesDataGridView_UserDeletingRow(object sender,
    DataGridViewRowCancelEventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                DataGridViewRow changedRow = e.Row;
                string primaryKey = GetPrimaryKeyNames(currentTable)[0];
                string id = changedRow.Cells[primaryKey].Value.ToString();



                if (currentTable != "employee_research" && currentTable != "standarts_research")
                {
                    DeleteRow(currentTable, primaryKey, id);
                }
                else
                {
                    string value1 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[0]].Value.ToString();
                    string value2 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[1]].Value.ToString();


                    string st1 = GetPrimaryKeyNames(currentTable)[0] + " = " + value1;
                    string st2 = GetPrimaryKeyNames(currentTable)[1] + " = " + value2;

                    DeleteRow2keys(currentTable, st1, st2);
                }
            }
            
        }


        private void employeesDataGridView_CellValueChanged(
            object sender, DataGridViewCellEventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                DataGridViewRow changedRow = employeesDataGridView.Rows[e.RowIndex];
                string primaryKey = GetPrimaryKeyNames(currentTable)[0];
                string id = changedRow.Cells[primaryKey].Value.ToString();
                string changedColumnName = employeesDataGridView.Columns[e.ColumnIndex].Name.ToString();
                var newValue = changedRow.Cells[e.ColumnIndex].Value.ToString();


                if (currentTable != "employee_research" && currentTable != "standarts_research")
                {
                    UpdateRow(currentTable, primaryKey, changedColumnName, id, newValue);
                }
                else
                {
                    string value1 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[0]].Value.ToString();
                    string value2 = changedRow.Cells[GetPrimaryKeyNames(currentTable)[1]].Value.ToString();
                    string st1;
                    if (changedColumnName == GetPrimaryKeyNames(currentTable)[0])
                    {
                        st1 = GetPrimaryKeyNames(currentTable)[1] + " = " + value2;
                    }
                    else
                    {
                        st1 = GetPrimaryKeyNames(currentTable)[0] + " = " + value1;
                    }

                    //label2.Text = st1;
                    UpdateRow2keys(currentTable, st1, changedColumnName, newValue);
                }

            }
            
            
        }
        private string[] GetPrimaryKeyNames(string tableName)
        {
            List<string> primaryKeys = new List<string>();

            try
            {
                using (MySqlCommand command = new MySqlCommand(
                    "SELECT COLUMN_NAME " +
                    "FROM information_schema.KEY_COLUMN_USAGE " +
                    "WHERE TABLE_SCHEMA = @dbName AND TABLE_NAME = @tableName AND CONSTRAINT_NAME = 'PRIMARY'", connection))
                {
                    command.Parameters.AddWithValue("@dbName", "itip");
                    command.Parameters.AddWithValue("@tableName", tableName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            primaryKeys.Add(reader.GetString("COLUMN_NAME"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении названия первичных ключей: " + ex.Message);
            }

            return primaryKeys.ToArray();
        }



        public bool UpdateRow(string table, string primarykey, string column, string id, string value)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(
                    "UPDATE " + table + " SET " + column + "=\"" + value + "\" WHERE " + primarykey + "=" + id,
                    connection);

                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");

                MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Incorrect date value: \'") &&
                    e.Message.Contains("\' for column \'") &&
                    e.Message.Contains("\' at row "))
                {
                    try
                    {
                        MySqlCommand command = new MySqlCommand(
                        "UPDATE " + table + " SET " + column + "=STR_TO_DATE(\"" + value + "\",\"%d.%m.%Y 0:%i:%s\") WHERE " + primarykey + "=" + id,
                        connection);

                        if (command.ExecuteNonQuery() != 1)
                            throw new Exception("Строки не существует в базе данных");
                        MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Ошибка изменения строки\nПричина: " + e1.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
                }
            }
            return false;
        }

        public bool UpdateRow2keys(string table, string st1, string column, string value)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE " + table + " SET " + column + "=" + value + " WHERE " + st1, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Данные успешно изменены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
            }
            return false;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                employeesDataGridView.AllowUserToDeleteRows = true;
                employeesDataGridView.ReadOnly = false;
                currentTable = tableOldNames[tablesListBox.SelectedIndex];
                PrintTable(tableOldNames[tablesListBox.SelectedIndex]);

            }
            else
            {
                employeesDataGridView.AllowUserToDeleteRows = false;
                employeesDataGridView.ReadOnly = true;
                currentTable = tableNames[tablesListBox.SelectedIndex];
                PrintTable(tableNames[tablesListBox.SelectedIndex]);
            }

            switch (tablesListBox.SelectedIndex)
            {
                case 0:
                    label1.Text = "Введите имя сотрудника";
                    break;
                case 1:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 2:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 3:
                    label1.Text = "Введите название должности";
                    break;
                case 4:
                    label1.Text = "Введите номер отчета";
                    break;
                case 5:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 6:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 7:
                    label1.Text = "Введите название компании клиента";
                    break;
                case 8:
                    label1.Text = "Введите тип требования";
                    break;

            }

        }

        public bool PrintTable(string tablename)
        {
            try
            {
                ds = new DataSet();
                adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + tablename,connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds, tablename);
                currentTable = tablename;
                employeesDataGridView.DataSource = ds.Tables[tablename];
                //label2.Text = GetPrimaryKeyNames(currentTable)[0];
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Данные не заполнены\nПричина: " + e.Message);
            }
            Close();
            return false;
        }

        public bool DeleteRow(string table, string column, string id)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM " + table + " WHERE " + column + "=" + id, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Строка успешно удалена");
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка удаления строки\nПричина: " + e.Message);
            }
            return false;
        }

        public bool DeleteRow2keys(string table, string st1, string st2)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM " + table + " WHERE " + st1 + " AND " + st2, connection);
                if (command.ExecuteNonQuery() != 1)
                    throw new Exception("Строки не существует в базе данных");
                MessageBox.Show("Данные успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения строки\nПричина: " + e.Message);
            }
            return false;
        }

        public DataTable SearchRow(string table, string where)
        {
            DataTable resultTable = new DataTable(); // Для хранения результатов

            try
            {
                // Создаем SQL запрос
                MySqlCommand command = new MySqlCommand("SELECT * FROM " + table + " WHERE " + where, connection);

                // Используем MySqlDataAdapter для заполнения DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(resultTable); // Заполняем результат
                }

                // Проверяем, найдены ли строки
                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.");
                }
                else
                {
                    MessageBox.Show("Найдено строк: " + resultTable.Rows.Count);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка поиска строки\nПричина: " + e.Message);
            }

            return resultTable; // Возвращаем результаты поиска
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            //label2.Text = insertTextBox.Text;
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                switch (tablesListBox.SelectedIndex)
                {
                    case 0:
                        AddEm addEm = new AddEm();
                        addEm.Show();
                        break;
                    case 1:
                        Request req = new Request();
                        req.Show();
                        break;
                    case 2:
                        Сlient client = new Сlient();
                        client.Show();
                        break;
                    case 3:
                        Position post = new Position();
                        post.Show();
                        break;
                    case 4:
                        Report rep = new Report();
                        rep.Show();
                        break;
                    case 5:
                        Project pr = new Project();
                        pr.Show();
                        break;
                    case 6:
                        PE pe = new PE();
                        pe.Show();
                        break;
                    case 7:
                        PP pp = new PP();
                        pp.Show();
                        break;
                    case 8:
                        Requirement requirement = new Requirement();
                        requirement.Show();
                        break;
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentTable != null)
            {
                PrintTable(currentTable);
            }
           
        }

        private void whereButton_Click(object sender, EventArgs e)
        {
            string tableName = currentTable;
            string whereClause = whereTextBox.Text;
            switch (tablesListBox.SelectedIndex)
            {
                case 0:
                    whereClause = "`Employee Name` like '%" + whereClause + "%'";
                    break;
                case 1:
                    whereClause = "`Company Name` like '%" + whereClause + "%'";
                    break;
                case 2:
                    whereClause = "`Company Name` like '%" + whereClause + "%'";
                    break;
                case 3:
                    whereClause = "`Position Name` like '%" + whereClause + "%'";
                    break;
                case 4:
                    whereClause = "`Report Number` like '" + whereClause + "'";
                    break;
                case 5:
                    whereClause = "`Company Name` like '%" + whereClause + "%'";
                    break;
                case 6:
                    whereClause = "`Company Name` like '%" + whereClause + "%'";
                    break;
                case 7:
                    whereClause = "`Company Name` like '%" + whereClause + "%'";
                    break;
                case 8:
                    whereClause = "`Requirement Type` like '%" + whereClause + "%'";
                    break;
            }
            //label1.Text = whereClause;



            // Выполняем поиск
            if (radioButton2.Checked)
            {
                MessageBox.Show("Недоступно в режиме изменения");
            }
            else
            {
                DataTable searchResults = SearchRow(tableName, whereClause);

                // Если результаты не пустые, привязываем их к DataGridView
                if (searchResults != null && searchResults.Rows.Count > 0)
                {
                    employeesDataGridView.DataSource = searchResults;
                }
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public DataTable SearchApplication(string year, Int32 cost)
        {
            DataTable resultTable = new DataTable(); // Для хранения результатов

            try
            {
                // Создаем SQL запрос
                MySqlCommand command = new MySqlCommand("SELECT * FROM view_project WHERE `Deadline Date` like(\"" + year + "%\") AND `Cost` >(\"%" + cost + "%\")", connection);

                // Используем MySqlDataAdapter для заполнения DataTable
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(resultTable); // Заполняем результат
                }

                // Проверяем, найдены ли строки
                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.");
                }
                else
                {
                    MessageBox.Show("Найдено строк: " + resultTable.Rows.Count);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка поиска строки\nПричина: " + e.Message);
            }

            return resultTable; // Возвращаем результаты поиска
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchApplicationButton_Click(object sender, EventArgs e)
        {

            // Выполняем поиск
            DataTable searchResults = SearchApplication(yearTextBox.Text, Convert.ToInt32(topicTextBox.Text));

            // Если результаты не пустые, привязываем их к DataGridView
            if (searchResults != null && searchResults.Rows.Count > 0)
            {
                employeesDataGridView.DataSource = searchResults;
            }
        }
        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void selfButton_Click(object sender, EventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                // Получаем текст запроса, введенного пользователем
                string userQuery = selfTB.Text.Trim();

                // Проверка на допустимость команды (примитивная, но дает базовую защиту)
                if (string.IsNullOrWhiteSpace(userQuery) ||
                    userQuery.StartsWith("DROP", StringComparison.OrdinalIgnoreCase) ||
                    userQuery.StartsWith("ALTER", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Запрос не может быть выполнен. Недопустимая команда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    MySqlCommand command = new MySqlCommand(userQuery, connection);

                    // Определяем тип запроса по ключевому слову
                    if (userQuery.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        // Запрос на получение данных
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        // Отображаем результат в DataGridView
                        employeesDataGridView.DataSource = resultTable;
                        MessageBox.Show("Запрос успешно выполнен и данные отображены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Запрос на изменение данных (INSERT, UPDATE, DELETE)
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"Запрос выполнен. Затронуто строк: {rowsAffected}.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем таблицу после изменения
                        if (!string.IsNullOrEmpty(currentTable))
                        {
                            PrintTable(currentTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void selfTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void functionButton_Click(object sender, EventArgs e)
        {
            
            Int32 countStatus = GetEmployeeNamesByPostId(functionTB.Text);
            if (countStatus <= 0)
            {
                MessageBox.Show("Проектных планов со статусом " + functionTB.Text + " не найдено");
            }
            else
            {
                MessageBox.Show("Количество проектных планов со статусом " + functionTB.Text + ": " + countStatus);
            }
            
        }

        private Int32 GetEmployeeNamesByPostId(String status)
        {
            Int32 result = -1;
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT CountProjectsByStatus(@status)", connection);
                command.Parameters.AddWithValue("@status", status);
                result = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка вызова функции count_employee\nПричина: " + e.Message);
            }
            return result;
        }

        private void UpsertClient(string name, string email)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("CALL AddOrUpdateCompany(@name, @p_email, @p_message);", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;

                    // Параметры для процедуры
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@p_email", email);

                    // Параметр OUT
                    MySql.Data.MySqlClient.MySqlParameter outputParam = new MySql.Data.MySqlClient.MySqlParameter("@p_message", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100);
                    outputParam.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    // Открытие соединения
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    // Выполнение команды
                    command.ExecuteNonQuery();

                    // Получение значения параметра OUT
                    string resultMessage = outputParam.Value.ToString();

                    // Вывод результата
                    MessageBox.Show(resultMessage, "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка вызова процедуры UpsertClient\nПричина: " + e.Message);
            }
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void procedureButton_Click(object sender, EventArgs e)
        {
            if (userRoleId == 2)
            {
                MessageBox.Show("Недостаточно прав. Требуется роль Администратора");
            }
            else
            {
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;
                UpsertClient(name, email);
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
