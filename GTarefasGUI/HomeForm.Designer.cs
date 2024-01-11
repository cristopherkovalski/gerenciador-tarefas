namespace GTarefasGUI
{
    partial class HomeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button1 = new Button();
            button2 = new Button();
            dataGridViewTarefas = new DataGridView();
            button3 = new Button();
            labelResponsavel = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            comboBoxResponsavel = new ComboBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBoxAltSituacao = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTarefas).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(116, 132);
            button1.Name = "button1";
            button1.Size = new Size(94, 42);
            button1.TabIndex = 0;
            button1.Text = "Cadastrar Desenvolvedor";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
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
            dataGridViewTarefas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewTarefas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTarefas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTarefas.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTarefas.Location = new Point(116, 225);
            dataGridViewTarefas.Name = "dataGridViewTarefas";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewTarefas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTarefas.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewTarefas.Size = new Size(543, 183);
            dataGridViewTarefas.TabIndex = 2;
            dataGridViewTarefas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(696, 225);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Alterar ";
            button3.UseVisualStyleBackColor = true;
            // 
            // labelResponsavel
            // 
            labelResponsavel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelResponsavel.AutoSize = true;
            labelResponsavel.Location = new Point(458, 248);
            labelResponsavel.Name = "labelResponsavel";
            labelResponsavel.Size = new Size(165, 15);
            labelResponsavel.TabIndex = 4;
            labelResponsavel.Text = "Selecione o novo Responsável";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(144, 248);
            label2.Name = "label2";
            label2.Size = new Size(175, 15);
            label2.TabIndex = 5;
            label2.Text = "Modifique a Descrição da Tarefa";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(144, 277);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 103);
            textBox1.TabIndex = 6;
            // 
            // comboBoxResponsavel
            // 
            comboBoxResponsavel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxResponsavel.FormattingEnabled = true;
            comboBoxResponsavel.Location = new Point(458, 277);
            comboBoxResponsavel.Name = "comboBoxResponsavel";
            comboBoxResponsavel.Size = new Size(165, 23);
            comboBoxResponsavel.TabIndex = 7;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(498, 373);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Atualizar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(696, 266);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 9;
            button5.Text = "Concluir";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top;
            button6.Location = new Point(345, 133);
            button6.Name = "button6";
            button6.Size = new Size(94, 41);
            button6.TabIndex = 10;
            button6.Text = "Nova Tarefa";
            button6.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(458, 196);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(165, 23);
            comboBox2.TabIndex = 11;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(346, 199);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 12;
            label3.Text = "Filtrar Por Situação:";
            // 
            // comboBoxAltSituacao
            // 
            comboBoxAltSituacao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxAltSituacao.FormattingEnabled = true;
            comboBoxAltSituacao.Location = new Point(458, 329);
            comboBoxAltSituacao.Name = "comboBoxAltSituacao";
            comboBoxAltSituacao.Size = new Size(167, 23);
            comboBoxAltSituacao.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(498, 311);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 14;
            label4.Text = "Alterar Situação";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Location = new Point(355, 29);
            label5.Name = "label5";
            label5.Size = new Size(73, 30);
            label5.TabIndex = 15;
            label5.Text = "Home";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(696, 29);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 16;
            label6.Text = "Bem-vindo!";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.Location = new Point(696, 44);
            label7.Name = "label7";
            label7.Size = new Size(69, 40);
            label7.TabIndex = 17;
            label7.Text = "default";
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.BackColor = Color.FromArgb(255, 192, 192);
            button7.Location = new Point(696, 78);
            button7.Name = "button7";
            button7.Size = new Size(69, 23);
            button7.TabIndex = 18;
            button7.Text = "Logout";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBoxAltSituacao);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(comboBoxResponsavel);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(labelResponsavel);
            Controls.Add(button3);
            Controls.Add(dataGridViewTarefas);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "HomeForm";
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
        public Label labelResponsavel;
        public Label label2;
        public TextBox textBox1;
        public ComboBox comboBoxResponsavel;
        private Button button4;
        private Button button5;
        private Button button6;
        public ComboBox comboBox2;
        private Label label3;
        public ComboBox comboBoxAltSituacao;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button7;
    }
}