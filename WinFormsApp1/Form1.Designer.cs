namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox2 = new TextBox();
            checkBox3 = new CheckBox();
            textBox3 = new TextBox();
            checkBox4 = new CheckBox();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            IP = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            PC = new DataGridViewTextBoxColumn();
            MotherBoard = new DataGridViewTextBoxColumn();
            CPU = new DataGridViewTextBoxColumn();
            GPU = new DataGridViewTextBoxColumn();
            RAM = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(83, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "192";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(12, 41);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 4;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += check;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(101, 41);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 6;
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += check;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(101, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(83, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "168";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(190, 41);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(15, 14);
            checkBox3.TabIndex = 8;
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += check;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(190, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(83, 23);
            textBox3.TabIndex = 7;
            textBox3.Text = "100";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(279, 41);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(15, 14);
            checkBox4.TabIndex = 10;
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += check;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(279, 12);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(83, 23);
            textBox4.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IP, Username, PC, MotherBoard, CPU, GPU, RAM });
            dataGridView1.Location = new Point(12, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1254, 405);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(415, 12);
            button1.Name = "button1";
            button1.Size = new Size(172, 43);
            button1.TabIndex = 12;
            button1.Text = "Check";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1001, 40);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(593, 12);
            button2.Name = "button2";
            button2.Size = new Size(170, 43);
            button2.TabIndex = 14;
            button2.Text = "ToExcel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // IP
            // 
            IP.HeaderText = "IP";
            IP.Name = "IP";
            IP.ReadOnly = true;
            // 
            // Username
            // 
            Username.HeaderText = "Username";
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // PC
            // 
            PC.HeaderText = "PC";
            PC.Name = "PC";
            PC.ReadOnly = true;
            // 
            // MotherBoard
            // 
            MotherBoard.HeaderText = "MotherBoard";
            MotherBoard.Name = "MotherBoard";
            MotherBoard.ReadOnly = true;
            // 
            // CPU
            // 
            CPU.HeaderText = "CPU";
            CPU.Name = "CPU";
            CPU.ReadOnly = true;
            // 
            // GPU
            // 
            GPU.HeaderText = "GPU";
            GPU.Name = "GPU";
            GPU.ReadOnly = true;
            // 
            // RAM
            // 
            RAM.HeaderText = "RAM";
            RAM.Name = "RAM";
            RAM.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 494);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(checkBox4);
            Controls.Add(textBox4);
            Controls.Add(checkBox3);
            Controls.Add(textBox3);
            Controls.Add(checkBox2);
            Controls.Add(textBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox2;
        private CheckBox checkBox3;
        private TextBox textBox3;
        private CheckBox checkBox4;
        private TextBox textBox4;
        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private Button button2;
        private DataGridViewTextBoxColumn IP;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn PC;
        private DataGridViewTextBoxColumn MotherBoard;
        private DataGridViewTextBoxColumn CPU;
        private DataGridViewTextBoxColumn GPU;
        private DataGridViewTextBoxColumn RAM;
    }
}