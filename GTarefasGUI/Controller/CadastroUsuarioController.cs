using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe;
using GTarefasMe.DAO;
using GTarefasMe.Model;

namespace GTarefasGUI.Controller
{
    public class CadastroUsuarioController
    {
        private UsuarioDAO usuarioDAO;
        private LoginDAO loginDAO;
        private TarefaDAO tarefaDAO;
        private ConnectionFactory conn;
        private HomeForm homeTechLeaderForm; 
        private CadastroForm cadastroForm;

        public CadastroUsuarioController(CadastroForm cadastrarForm)
        {
            this.conn = new ConnectionFactory();
            this.tarefaDAO = new TarefaDAO(conn);
            this.loginDAO = new LoginDAO(conn);
            this.usuarioDAO = new UsuarioDAO(conn);
            this.cadastroForm = cadastrarForm;
            InitController();
     
        }

        public void InitController()
        {
            this.cadastroForm.SetController(this);
            ConfigurarcBox();

        }

       
    

        public void InserirUsuario()
        {
            try
            {
                Usuario usuario = this.cadastroForm.GetUsuarioForm();
                if (usuario.TipoUsuario == TipoUsuario.Desenvolvedor)
                {
                    int userid = usuarioDAO.InserirDesenvolvedor((Desenvolvedor)usuario);
                    Login autenticacao = this.cadastroForm.GetLoginForm(userid);
                    loginDAO.InserirLogin(autenticacao);
                    cadastroForm.ApresentarMensagem("Sucesso na inserção do Desenvolvedor");
                    VoltarTela();
                }
                else
                {
                    int userid = usuarioDAO.InserirDesenvolvedor((TechLeader)usuario);
                    Login autenticacao = this.cadastroForm.GetLoginForm(userid);
                    loginDAO.InserirLogin(autenticacao);
                    cadastroForm.ApresentarMensagem("Sucesso na inserção do Desenvolvedor");
                    VoltarTela();
                }

                 
            }
            catch (Exception ex)
            {
                cadastroForm.ApresentarMensagemErro("Erro na inserção" + ex);
            }
        }

        public void ConfigurarcBox()
        {
            List<string> opcoesSituacao = new List<string>
            {
                "Desenvolvedor",
                "TechLeader"
            };
            cadastroForm.comboBoxTipo.DataSource = opcoesSituacao;
        }

        public void VoltarTela()
        {
            {
                if (homeTechLeaderForm == null || homeTechLeaderForm.IsDisposed)
                {
                    homeTechLeaderForm = new HomeForm(cadastroForm.UsuarioLogado);
                    homeTechLeaderForm.Show();
                    cadastroForm.Hide();
                    cadastroForm.Close();

                }
                else
                {
                    homeTechLeaderForm.BringToFront();
                    cadastroForm.Hide();
                    cadastroForm.Close();

                }
            }

        }

    }
}
