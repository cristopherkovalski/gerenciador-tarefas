using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTarefasGUI.ViewModel;
using GTarefasMe;
using GTarefasMe.Controller;
using GTarefasMe.DAO;
using GTarefasMe.Model;


namespace GTarefasGUI
{
    public partial class HomeTechLeaderForm : Form
    {
        public Login usuarioAutenticado;
        private TechLeaderController Controller;

        public HomeTechLeaderForm(Login login)
        {
            InitializeComponent();
            this.usuarioAutenticado = login;
            label7.Text = this.usuarioAutenticado.Email;
            TechLeaderController controller = new TechLeaderController(this);
            ConfigurarManipulacaoLinhas();
            SetController(controller);
            setDataGridActionsVisible(false);
        }

        public void SetController(TechLeaderController controller)
        {
            this.Controller = controller;

            button2.Click += (sender, e) => controller.ListarTarefas();
            button3.Click += (sender, e) => controller.AlterarTarefa();
            button5.Click += (sender, e) => controller.ConcluirTarefa();
            button6.Click += (sender, e) => controller.NovaTarefa(this.usuarioAutenticado);
            ConfiguraBotaoFiltro(controller);
            ConfigurarBotaoCadastro(controller);
        }
        public void ConfiguraBotaoFiltro(TechLeaderController controller)
        {
            if (usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
            {

                comboBox2.SelectedIndexChanged += (sender, e) => controller.AplicarFiltrosTechLeader();
            }
            else
            {
                comboBox2.SelectedIndexChanged += (sender, e) => controller.AplicarFiltrosDev();
            }
        }

        public void ConfigurarBotaoCadastro(TechLeaderController controller)
        {
            if (usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
            {
                button1.Click += (sender, e) => controller.CadastroUsuario(this.usuarioAutenticado);
                button1.Show();
            }
            else
            {
                button1.Hide();
            }

        }

        public void mostrarListaTarefa(List<Tarefa> listaTarefas)
        {
            setAlterarTarefaMenuVisible(false);
            dataGridViewTarefas.Show();
            List<TarefaViewModel> listaTarefasViewModel = listaTarefas.Select(t => new TarefaViewModel(t)).ToList();
            dataGridViewTarefas.DataSource = listaTarefasViewModel;
            dataGridViewTarefas.Columns["ResponsavelId"].Visible = false;
            dataGridViewTarefas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTarefas.CellBeginEdit += dataGridViewTarefas_CellBeginEdit;
            setDataGridActionsVisible(true);

        }
        public void mostrarAlterarMenu()
        {
            setDataGridActionsVisible(false);
            Controller.ConfigurarComboBoxAlt();
            if (dataGridViewTarefas.SelectedRows.Count > 0)
            {
                TarefaViewModel tarefaSelecionada = (TarefaViewModel)dataGridViewTarefas.SelectedRows[0].DataBoundItem;
                textBox1.Text = tarefaSelecionada.Descricao;
                setAlterarTarefaMenuVisible(true);
            }
            else
            {
                ApresentarMensagemErro("Nenhuma tarefa selecionada.");
            }
        }

        public AlteraTarefaViewModel getAlterarForm()
        {
            TarefaViewModel tarefaSelecionadaAtual = (TarefaViewModel)dataGridViewTarefas.SelectedRows[0].DataBoundItem;

            if (tarefaSelecionadaAtual != null && usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
            {

                string novaDescricao = textBox1.Text;
                int novoResponsavelId = Convert.ToInt32(comboBoxResponsavel.SelectedValue);
                string situacao = comboBoxAltSituacao.Text;
                return new AlteraTarefaViewModel(tarefaSelecionadaAtual.Id, novoResponsavelId, novaDescricao, situacao);
            }
            else if (tarefaSelecionadaAtual != null)
            {
                string novaDescricao = textBox1.Text;
                int novoResponsavelId = usuarioAutenticado.UserId;
                string situacao = comboBoxAltSituacao.Text;
                return new AlteraTarefaViewModel(tarefaSelecionadaAtual.Id, novoResponsavelId, novaDescricao, situacao);
            }
            else
            {
                return null;
            }
        }

        private void ConfigurarManipulacaoLinhas()
        {
            // Configurar o evento SelectionChanged para o dataGridViewTarefas
            dataGridViewTarefas.SelectionChanged += (sender, e) =>
            {
                if (dataGridViewTarefas.SelectedRows.Count > 0)
                {
                    string situacao = dataGridViewTarefas.SelectedRows[0].Cells["Status"].Value.ToString();
                    button3.Enabled = (situacao != "Concluida");
                    button5.Enabled = (situacao != "Concluida");
                }
                else
                {
                    setDataGridActionsVisible(false);
                }

            };
        }
        public void dataGridViewTarefas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Tornar a célula somente leitura
            e.Cancel = true;
        }

        public void setDataGridActionsVisible(bool visible)
        {
            if (visible)
            {
                comboBox2.Show();
                button3.Show();
                button5.Show();
                label3.Show();
            }
            else
            {
                comboBox2.Hide();
                button3.Hide();
                button5.Hide();
                label3.Hide();

            }
        }
        public void CarregarComboBoxUsuario(List<Usuario> usuarios)
        {
            labelResponsavel.Show();
            comboBoxResponsavel.Show();
            comboBoxResponsavel.DisplayMember = "Nome";
            comboBoxResponsavel.ValueMember = "Id";
            comboBoxResponsavel.DataSource = usuarios;
        }
        public void ApresentarMensagemErro(string message)
        {
            MessageBox.Show(message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ApresentarMensagem(string message)
        {
            MessageBox.Show(message, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void setAlterarTarefaMenuVisible(bool visible)
        {
            if (!visible)
            {
                labelResponsavel.Hide();
                label2.Hide();
                comboBoxResponsavel.Hide();
                comboBoxAltSituacao.Hide();
                textBox1.Hide();
                label4.Hide();
                button4.Hide();

            }
            else
            {
                label2.Show();
                comboBoxAltSituacao.Show();
                textBox1.Show();
                button4.Show();
                dataGridViewTarefas.Hide();
                button3.Hide();
                button5.Hide();
                comboBox2.Hide();
                label3.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Controller.AtualizarTarefa();
        }

        /*  public void PreencherComboBoxResponsaveis(List<Usuario> responsaveis, Usuario responsavelSelecionado)
          {

              comboBox1.Items.Clear();


              comboBox1.Items.AddRange(responsaveis.ToArray());


              if (responsavelSelecionado != null)
              {
                  comboBox1.SelectedItem = responsavelSelecionado;
              }
          }**/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Controller.Logout();
        }
    }


}
