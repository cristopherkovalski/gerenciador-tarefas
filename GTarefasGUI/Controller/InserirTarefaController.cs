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
        private ConnectionFactory conn;
        private InserirTarefaForm InserirTarefaForm;
        private HomeTechLeaderForm HomeTechLeaderForm;
        public List<Usuario> usuarios = new List<Usuario>();

        public InserirTarefaController(InserirTarefaForm inserirTForm)
        {
            this.conn = new ConnectionFactory();
            this.tarefaDAO = new TarefaDAO(conn);
            this.usuarioDAO = new UsuarioDAO(conn);
            InserirTarefaForm = inserirTForm;
            InitController();
        }

        private void InitController()
        {
            InserirTarefaForm.SetController(this);
           
        }
        public void ListaUsuarios()
        {
            try
            {
                if (this.InserirTarefaForm.usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
                {
                    usuarios = usuarioDAO.Listar();
                    InserirTarefaForm.CarregaResponsavelComboBox(usuarios);
                }
                else
                {
                    usuarios = usuarioDAO.Listar();
                    InserirTarefaForm.CarregaResponsavelComboBox(null);
                }

            }catch (Exception ex)
            {
                InserirTarefaForm.ApresentarMensagemErro("Erro ao carregar combobox" + ex.Message);
            }
        }

        public void InserirNovaTarefa()
        {
            try
            {
                Tarefa tarefa = InserirTarefaForm.GetTarefaForm();
                tarefaDAO.InserirTarefa(tarefa);
                InserirTarefaForm.ApresentarMensagem("Tarefa Inserida com Sucesso!");
                VoltaTela();

            }
            catch (Exception ex)
            {
                InserirTarefaForm.ApresentarMensagemErro("Erro ao inserir nova tarefa" + ex.Message);

            }
        }

        public void VoltaTela()
        {
            if (HomeTechLeaderForm == null || HomeTechLeaderForm.IsDisposed)
            {
                HomeTechLeaderForm = new HomeTechLeaderForm(InserirTarefaForm.usuarioAutenticado);
                InserirTarefaForm.Hide();
                HomeTechLeaderForm.Show();
                InserirTarefaForm.Close();

            }
            else
            {
                HomeTechLeaderForm.BringToFront();
                InserirTarefaForm.Hide();
                InserirTarefaForm.Close();

            }
        }
    }
}
