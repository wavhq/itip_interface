namespace db_application
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.employeesDataGridView = new System.Windows.Forms.DataGridView();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.whereButton = new System.Windows.Forms.Button();
            this.topicTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.searchApplicationButton = new System.Windows.Forms.Button();
            this.selfButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.functionTB = new System.Windows.Forms.TextBox();
            this.functionButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.procedureButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selfTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.whereTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // employeesDataGridView
            // 
            this.employeesDataGridView.AllowUserToAddRows = false;
            this.employeesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeesDataGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesDataGridView.Location = new System.Drawing.Point(511, 61);
            this.employeesDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.employeesDataGridView.Name = "employeesDataGridView";
            this.employeesDataGridView.ReadOnly = true;
            this.employeesDataGridView.RowHeadersWidth = 51;
            this.employeesDataGridView.Size = new System.Drawing.Size(1472, 695);
            this.employeesDataGridView.TabIndex = 0;
            this.employeesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionLabel.Location = new System.Drawing.Point(506, 27);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(81, 30);
            this.connectionLabel.TabIndex = 1;
            this.connectionLabel.Text = "label1";
            this.connectionLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // tablesListBox
            // 
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 24;
            this.tablesListBox.Items.AddRange(new object[] {
            "Сотрудники",
            "Заявки",
            "Клиенты",
            "Должности",
            "Отчеты",
            "Проекты",
            "Проекты, сотрудники",
            "Планы проектов",
            "Требования"});
            this.tablesListBox.Location = new System.Drawing.Point(21, 136);
            this.tablesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(448, 244);
            this.tablesListBox.TabIndex = 2;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(19, 405);
            this.insertButton.Margin = new System.Windows.Forms.Padding(4);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(451, 70);
            this.insertButton.TabIndex = 4;
            this.insertButton.Text = "Добавить элемент в таблицу";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.Location = new System.Drawing.Point(406, 30);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(63, 60);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // whereButton
            // 
            this.whereButton.Location = new System.Drawing.Point(19, 568);
            this.whereButton.Margin = new System.Windows.Forms.Padding(4);
            this.whereButton.Name = "whereButton";
            this.whereButton.Size = new System.Drawing.Size(451, 62);
            this.whereButton.TabIndex = 9;
            this.whereButton.Text = "Искать элемент в таблице\r\n";
            this.whereButton.UseVisualStyleBackColor = true;
            this.whereButton.Click += new System.EventHandler(this.whereButton_Click);
            // 
            // topicTextBox
            // 
            this.topicTextBox.Location = new System.Drawing.Point(22, 675);
            this.topicTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.topicTextBox.Name = "topicTextBox";
            this.topicTextBox.Size = new System.Drawing.Size(278, 29);
            this.topicTextBox.TabIndex = 11;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(343, 675);
            this.yearTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(130, 29);
            this.yearTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 646);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Год проекта";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 646);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Проект дороже чем";
            // 
            // searchApplicationButton
            // 
            this.searchApplicationButton.Location = new System.Drawing.Point(22, 717);
            this.searchApplicationButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchApplicationButton.Name = "searchApplicationButton";
            this.searchApplicationButton.Size = new System.Drawing.Size(451, 39);
            this.searchApplicationButton.TabIndex = 15;
            this.searchApplicationButton.Text = "Искать проекты с заданными параметрами";
            this.searchApplicationButton.UseVisualStyleBackColor = true;
            this.searchApplicationButton.Click += new System.EventHandler(this.searchApplicationButton_Click);
            // 
            // selfButton
            // 
            this.selfButton.Location = new System.Drawing.Point(269, 788);
            this.selfButton.Margin = new System.Windows.Forms.Padding(4);
            this.selfButton.Name = "selfButton";
            this.selfButton.Size = new System.Drawing.Size(204, 43);
            this.selfButton.TabIndex = 19;
            this.selfButton.Text = "Применить запрос";
            this.selfButton.UseVisualStyleBackColor = true;
            this.selfButton.Click += new System.EventHandler(this.selfButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 773);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1013, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Для поиска количества проектных планов с заданным статусом введите статус (исполь" +
    "зуется функция):";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // functionTB
            // 
            this.functionTB.Location = new System.Drawing.Point(1527, 771);
            this.functionTB.Margin = new System.Windows.Forms.Padding(4);
            this.functionTB.Name = "functionTB";
            this.functionTB.Size = new System.Drawing.Size(246, 29);
            this.functionTB.TabIndex = 21;
            // 
            // functionButton
            // 
            this.functionButton.Location = new System.Drawing.Point(1799, 771);
            this.functionButton.Margin = new System.Windows.Forms.Padding(4);
            this.functionButton.Name = "functionButton";
            this.functionButton.Size = new System.Drawing.Size(184, 42);
            this.functionButton.TabIndex = 22;
            this.functionButton.Text = "Искать";
            this.functionButton.UseVisualStyleBackColor = true;
            this.functionButton.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(506, 813);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(507, 50);
            this.label9.TabIndex = 23;
            this.label9.Text = "Добавление/обновление данных компании-клиента, \r\nиспользуя хранимую процедуру:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(1051, 845);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(258, 29);
            this.nameTextBox.TabIndex = 24;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(1336, 846);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(326, 29);
            this.emailTextBox.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1081, 816);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Название компании";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1472, 817);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 25);
            this.label11.TabIndex = 28;
            this.label11.Text = "Email";
            // 
            // procedureButton
            // 
            this.procedureButton.Location = new System.Drawing.Point(1693, 833);
            this.procedureButton.Margin = new System.Windows.Forms.Padding(4);
            this.procedureButton.Name = "procedureButton";
            this.procedureButton.Size = new System.Drawing.Size(290, 42);
            this.procedureButton.TabIndex = 30;
            this.procedureButton.Text = "Добавить";
            this.procedureButton.UseVisualStyleBackColor = true;
            this.procedureButton.Click += new System.EventHandler(this.procedureButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 30);
            this.label2.TabIndex = 31;
            this.label2.Text = "Выберите таблицу";
            // 
            // selfTB
            // 
            this.selfTB.Location = new System.Drawing.Point(23, 845);
            this.selfTB.Margin = new System.Windows.Forms.Padding(4);
            this.selfTB.Name = "selfTB";
            this.selfTB.Size = new System.Drawing.Size(450, 29);
            this.selfTB.TabIndex = 17;
            this.selfTB.TextChanged += new System.EventHandler(this.selfTB_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(19, 802);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ввести запрос вручную";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 30);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(214, 29);
            this.radioButton1.TabIndex = 32;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Режим просмотра";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 61);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(215, 29);
            this.radioButton2.TabIndex = 33;
            this.radioButton2.Text = "Режим изменения";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 490);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "Введите имя сотрудника";
            // 
            // whereTextBox
            // 
            this.whereTextBox.Location = new System.Drawing.Point(19, 526);
            this.whereTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.whereTextBox.Name = "whereTextBox";
            this.whereTextBox.Size = new System.Drawing.Size(451, 29);
            this.whereTextBox.TabIndex = 35;
            this.whereTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(2025, 902);
            this.Controls.Add(this.whereTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.procedureButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.functionButton);
            this.Controls.Add(this.functionTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selfButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.selfTB);
            this.Controls.Add(this.searchApplicationButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.topicTextBox);
            this.Controls.Add(this.whereButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.tablesListBox);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.employeesDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EmployeeForm";
            this.Text = "Проектирование ИТ-инфраструктуры предприятий";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeesDataGridView;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button whereButton;
        private System.Windows.Forms.TextBox topicTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchApplicationButton;
        private System.Windows.Forms.Button selfButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox functionTB;
        private System.Windows.Forms.Button functionButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button procedureButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox selfTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox whereTextBox;
    }
}