﻿namespace GTarefasGUI
{
    partial class HomeTechLeaderForm
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
        public void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            dataGridViewTarefas = new DataGridView();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarefas).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(116, 132);
            button1.Name = "button1";
            button1.Size = new Size(94, 42);
            button1.TabIndex = 0;
            button1.Text = "Cadastrar Desenvolvedor";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(565, 132);
            button2.Name = "button2";
            button2.Size = new Size(94, 42);
            button2.TabIndex = 1;
            button2.Text = "Listar Tarefas";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTarefas
            // 
            dataGridViewTarefas.AllowUserToOrderColumns = true;
            dataGridViewTarefas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTarefas.Location = new Point(116, 225);
            dataGridViewTarefas.Name = "dataGridViewTarefas";
            dataGridViewTarefas.Size = new Size(543, 183);
            dataGridViewTarefas.TabIndex = 2;
            dataGridViewTarefas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button3
            // 
            button3.Location = new Point(696, 225);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Alterar ";
            button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(458, 248);
            label1.Name = "label1";
            label1.Size = new Size(165, 15);
            label1.TabIndex = 4;
            label1.Text = "Selecione o novo Responsável";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 248);
            label2.Name = "label2";
            label2.Size = new Size(175, 15);
            label2.TabIndex = 5;
            label2.Text = "Modifique a Descrição da Tarefa";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 277);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 103);
            textBox1.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(458, 277);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 23);
            comboBox1.TabIndex = 7;
            // 
            // button4
            // 
            button4.Location = new Point(498, 373);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Atualizar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(696, 266);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 9;
            button5.Text = "Concluir";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(345, 133);
            button6.Name = "button6";
            button6.Size = new Size(94, 41);
            button6.TabIndex = 10;
            button6.Text = "Nova Tarefa";
            button6.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(458, 196);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(346, 199);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 12;
            label3.Text = "Filtrar Por Situação:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(458, 329);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(167, 23);
            comboBox3.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(498, 311);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 14;
            label4.Text = "Alterar Situação";
            // 
            // HomeTechLeaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(dataGridViewTarefas);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "HomeTechLeaderForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarefas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        public DataGridView dataGridViewTarefas;
        private Button button3;
        public Label label1;
        public Label label2;
        public TextBox textBox1;
        public ComboBox comboBox1;
        private Button button4;
        private Button button5;
        private Button button6;
        public ComboBox comboBox2;
        private Label label3;
        public ComboBox comboBox3;
        private Label label4;
    }
}