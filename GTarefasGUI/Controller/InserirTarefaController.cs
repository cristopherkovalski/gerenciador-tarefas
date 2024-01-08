using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.DAO;
using GTarefasMe.Model;

namespace GTarefasGUI.Controller
{
    public class InserirTarefaController
    {
        private UsuarioDAO usuarioDAO;
        private TarefaDAO tarefaDAO;
        private LoginDAO loginDAO;
        private ConnectionFactory conn;
        private static InserirTarefaForm InserirTarefaForm;
        private static HomeTechLeaderForm HomeTechLeaderForm;
        private List<Usuario> usuarios = new List<Usuario>();

        public InserirTarefaController(InserirTarefaForm inserirTForm)
        {
            this.conn = new ConnectionFactory();
            this.loginDAO = new LoginDAO(conn);
            this.tarefaDAO = new TarefaDAO(conn);
            this.usuarioDAO = new UsuarioDAO(conn);
            InserirTarefaForm = inserirTForm;
            InitController();
        }

        private void InitController()
        {
            InserirTarefaForm.SetController(this);
          
            usuarios = usuarioDAO.Listar();
            InserirTarefaForm.comboBox1.DisplayMember = "Nome";
            InserirTarefaForm.comboBox1.ValueMember = "Id";
            InserirTarefaForm.comboBox1.DataSource = usuarios;
        }

        public void InserirNovaTarefa()
        {
            try
            {
                string NomeTarefa = InserirTarefaForm.textBox1.Text;
                string Descricao = InserirTarefaForm.textBox2.Text;
                int responsavelId = Convert.ToInt32(InserirTarefaForm.comboBox1.SelectedValue);
                Usuario usuarioEncontrado = usuarios.Find(usuario => usuario.Id == responsavelId);
                Tarefa tarefa = new Tarefa(null, NomeTarefa, Descricao, (Desenvolvedor)usuarioEncontrado, "Em Andamento", DateTime.Now, null);
                tarefaDAO.InserirTarefa(tarefa);
                InserirTarefaForm.ApresentarMensagem("Tarefa Inserida com Sucesso!");
                HomeTechLeaderForm = new HomeTechLeaderForm(InserirTarefaForm.usuarioAutenticado);
                InserirTarefaForm.Hide();
                HomeTechLeaderForm.Show();
                InserirTarefaForm.Close();
                
            } catch (Exception ex) 
            {
                InserirTarefaForm.ApresentarMensagemErro("Erro ao inserir nova tarefa" + ex.Message);
                
            }
        }
    }
}
