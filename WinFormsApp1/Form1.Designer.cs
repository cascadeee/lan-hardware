﻿namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            IP = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            PC = new DataGridViewTextBoxColumn();
            MotherBoard = new DataGridViewTextBoxColumn();
            CPU = new DataGridViewTextBoxColumn();
            GPU = new DataGridViewTextBoxColumn();
            RAM = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            // button1
            // 
            button1.Location = new Point(366, 16);
            button1.Name = "button1";
            button1.Size = new Size(172, 43);
            button1.TabIndex = 12;
            button1.TabStop = false;
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
            button2.Location = new Point(544, 16);
            button2.Name = "button2";
            button2.Size = new Size(170, 43);
            button2.TabIndex = 14;
            button2.TabStop = false;
            button2.Text = "ToExcel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(95, 27);
            textBox1.MaxLength = 100;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(225, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "192.168.100.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 30);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 19;
            label2.Text = "IP";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 494);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            ShowIcon = false;
            Text = "lan-hardware";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private TextBox textBox1;
        private Label label2;
    }
}