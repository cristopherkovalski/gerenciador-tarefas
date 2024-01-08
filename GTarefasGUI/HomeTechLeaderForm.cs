using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTarefasMe;
using GTarefasMe.Controller;
using GTarefasMe.Model;


namespace GTarefasGUI
{
    public partial class HomeTechLeaderForm : Form
    {
        private Login usuarioAutenticado;
        private TechLeaderController Controller;
        
        public HomeTechLeaderForm(Login login)
        {
            InitializeComponent();
            this.usuarioAutenticado = login;
            TechLeaderController controller = new TechLeaderController(this);
            ConfigurarManipulacaoLinhas();
            SetController(controller);   

        }

        public void SetController(TechLeaderController controller)
        {
            this.Controller = controller;
            button2.Click += (sender, e) => controller.ListarTarefas();
            button3.Click += (sender, e) => controller.AlterarTarefa();
            button4.Click += (sender, e) => controller.AtualizarTarefa();
            button5.Click += (sender, e) => controller.ConcluirTarefa();
        }

        private void ConfigurarManipulacaoLinhas()
        {
            // Configurar o evento SelectionChanged para o dataGridViewTarefas
            dataGridViewTarefas.SelectionChanged += (sender, e) =>
            {
                if (dataGridViewTarefas.SelectedRows.Count > 0)
                {
                   
                    string situacao = dataGridViewTarefas.SelectedRows[0].Cells["Status"].Value.ToString();

                  
                    button3.Show();
                    button5.Show();
                    
                    button3.Enabled = (situacao != "Concluida");
                    button5.Enabled = (situacao != "Concluida"); 
                }
                else
                {
                    // Se não houver linhas selecionadas, ocultar os botões
                   button3.Hide();
                   button5.Hide();
                }

            };

           
        }
        public void dataGridViewTarefas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                // Tornar a célula somente leitura
                e.Cancel = true;
        }


        public void ApresentarMensagemErro(string message)
        {
            MessageBox.Show(message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ApresentarMensagem(string message)
        {
            MessageBox.Show(message, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void setVisible(bool visible)
        {
            if (!visible)
            {
                label1.Hide();
                label2.Hide();
                comboBox1.Hide();
                textBox1.Hide();
                button4.Hide();
             
            }
            else{
                label1.Show();
                label2.Show();
                comboBox1.Show();
                textBox1.Show();
                button4.Show();
                dataGridViewTarefas.Hide();
                button3.Hide();
                button5.Hide();
            }



        }

        public void PreencherComboBoxResponsaveis(List<Usuario> responsaveis, Usuario responsavelSelecionado)
        {
        
            comboBox1.Items.Clear();

  
            comboBox1.Items.AddRange(responsaveis.ToArray());

      
            if (responsavelSelecionado != null)
            {
                comboBox1.SelectedItem = responsavelSelecionado;
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
