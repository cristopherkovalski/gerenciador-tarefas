using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTarefasGUI.Controller;
using GTarefasMe;
using GTarefasMe.Controller;
using GTarefasMe.DAO;
using GTarefasMe.Model;

namespace GTarefasGUI
{
    public partial class InserirTarefaForm : Form
    {
        public Login usuarioAutenticado;
        public InserirTarefaController Controller;
        private TechLeaderController techLeaderController;


        public InserirTarefaForm(Login login, TechLeaderController techLeaderController)
        {
            InitializeComponent();
            this.Controller = new InserirTarefaController(this);
            this.techLeaderController = techLeaderController;
            this.usuarioAutenticado = login;
            SetController(Controller);
            this.Controller.ListaUsuarios();
        }
        public void SetController(InserirTarefaController controller)
        {
            this.Controller = controller;
        }

        public void CarregaResponsavelComboBox(List<Usuario>? usuarios)
        {
                if (usuarios != null)
                {
                   comboBox1.Show();
                   comboBox1.DisplayMember = "Nome";
                   comboBox1.ValueMember = "Id";
                   comboBox1.DataSource = usuarios;
                }
                else
                {
                    comboBox1.Hide();
                    label3.Hide();
                }
         }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Controller.InserirNovaTarefa();
        }

        public Tarefa GetTarefaForm()
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) ||
                  string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                this.ApresentarMensagemErro("Preencher todos os campos!");
                return null;
            }
            else
            {
                if (usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
                {
                    string NomeTarefa = this.textBox1.Text;
                    string Descricao = this.textBox2.Text;
                    int responsavelId = Convert.ToInt32(this.comboBox1.SelectedValue);
                    Usuario usuarioEncontrado = Controller.usuarios.Find(usuario => usuario.Id == responsavelId);
                    Tarefa tarefa = new Tarefa(null, NomeTarefa, Descricao, (Desenvolvedor)usuarioEncontrado, "Em Andamento", DateTime.Now, null);
                    return tarefa;
                }
                else
                {

                    string NomeTarefa = this.textBox1.Text;
                    string Descricao = this.textBox2.Text;
                    int responsavelId = usuarioAutenticado.UserId;
                    Usuario usuarioEncontrado = Controller.usuarios.Find(usuario => usuario.Id == responsavelId);
                    Tarefa tarefa = new Tarefa(null, NomeTarefa, Descricao, (Desenvolvedor)usuarioEncontrado, "Em Andamento", DateTime.Now, null);
                    return tarefa;
                }

            }
        }

        public void ApresentarMensagemErro(string message)
        {
            MessageBox.Show(message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ApresentarMensagem(string message)
        {
            MessageBox.Show(message, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller.VoltaTela();
        }
    }
}
