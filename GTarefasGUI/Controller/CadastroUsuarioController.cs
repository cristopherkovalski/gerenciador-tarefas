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
        private HomeTechLeaderForm homeTechLeaderForm; 
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

        static string GerarSenhaAleatoria(int comprimento)
        {
           
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] senha = new char[comprimento];
            for (int i = 0; i < comprimento; i++)
            {
                senha[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }

            return new string(senha);
        }
    

    public void InserirUsuario()
        {
            try
            {
                   if (string.IsNullOrWhiteSpace(cadastroForm.textBoxNome.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxSobrenome.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxLogradouro.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxNumero.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxCidade.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxEstado.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxCEP.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxTime.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxCPF.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(cadastroForm.comboBoxTipo.Text))
                   {
                            // Se algum campo obrigatório estiver em branco, exibe uma mensagem de erro
                            cadastroForm.ApresentarMensagemErro("Por favor, preencha todos os campos obrigatórios.");
                            return;
                   }
                string Nome = cadastroForm.textBoxNome.Text;
                string Sobrenome = cadastroForm.textBoxSobrenome.Text;
                string Logradouro = cadastroForm.textBoxLogradouro.Text;
                string Numero = cadastroForm.textBoxNumero.Text;
                string Cidade = cadastroForm.textBoxCidade.Text;
                string Estado = cadastroForm.textBoxEstado.Text;
                string CEP = cadastroForm.textBoxCEP.Text;
                string Time = cadastroForm.textBoxTime.Text;
                string CPF = cadastroForm.textBoxCPF.Text;
                Endereco Endereco = new Endereco(null, Logradouro, Cidade, Estado, CEP);
                string email = cadastroForm.textBoxEmail.Text;
                string senha = GerarSenhaAleatoria(8);
                string tipoUsuario = cadastroForm.comboBoxTipo.Text;

                if (tipoUsuario == "Desenvolvedor")
                {
                    Desenvolvedor usuario = new Desenvolvedor(null, Nome, Sobrenome, Endereco, TipoUsuario.Desenvolvedor, CPF, Time, "Ativo", DateTime.Now, null);
                    int userid = usuarioDAO.InserirDesenvolvedor(usuario);
                    Login autenticacao = new Login(null, senha, email, TipoUsuario.Desenvolvedor, userid);
                    loginDAO.InserirLogin(autenticacao);
                    cadastroForm.ApresentarMensagem("Sucesso na inserção do Desenvolvedor");
                    VoltarTela();

                }
                else if(tipoUsuario == "TechLeader")
                {
                    TechLeader usuario = new TechLeader(null, Nome, Sobrenome, Endereco, TipoUsuario.TechLeader, CPF, Time, "Ativo", DateTime.Now, null);
                    int userid = usuarioDAO.InserirDesenvolvedor(usuario);
                    Login autenticacao = new Login(null, senha, email, TipoUsuario.TechLeader, userid);
                    loginDAO.InserirLogin(autenticacao);
                    cadastroForm.ApresentarMensagem("Sucesso na inserção do Tech Leader");
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
                    homeTechLeaderForm = new HomeTechLeaderForm(cadastroForm.UsuarioLogado);
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
