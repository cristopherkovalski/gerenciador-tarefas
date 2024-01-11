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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GTarefasGUI
{
    public partial class CadastroForm : Form
    {
        private CadastroUsuarioController Controller;
        public Login UsuarioLogado;
        public CadastroForm(Login login)
        {
            UsuarioLogado = login;
            InitializeComponent();
            CadastroUsuarioController controller = new CadastroUsuarioController(this);
            SetController(controller);
        }

        public void SetController(CadastroUsuarioController controller)
        {
            this.Controller = controller;
        }

        public Usuario GetUsuarioForm()
        {
            if (string.IsNullOrWhiteSpace(this.textBoxNome.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxSobrenome.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxLogradouro.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxNumero.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxCidade.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxEstado.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxCEP.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxTime.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxCPF.Text) ||
                  string.IsNullOrWhiteSpace(this.textBoxEmail.Text) ||
                  string.IsNullOrWhiteSpace(this.comboBoxTipo.Text))
            {

                this.ApresentarMensagemErro("Por favor, preencha todos os campos obrigatórios.");
                return null;
            }
            else
            {
                string Nome = this.textBoxNome.Text;
                string Sobrenome = this.textBoxSobrenome.Text;
                string Logradouro = this.textBoxLogradouro.Text;
                string Numero = this.textBoxNumero.Text;
                string Cidade = this.textBoxCidade.Text;
                string Estado = this.textBoxEstado.Text;
                string CEP = this.textBoxCEP.Text;
                string Time = this.textBoxTime.Text;
                string CPF = this.textBoxCPF.Text;
                Endereco Endereco = new Endereco(null, Logradouro, Cidade, Estado, CEP);
                string tipoUsuario = this.comboBoxTipo.Text;
                if (tipoUsuario == "Desenvolvedor")
                {
                    Desenvolvedor usuario = new Desenvolvedor(null, Nome, Sobrenome, Endereco, TipoUsuario.Desenvolvedor, CPF, Time, "Ativo", DateTime.Now, null);
                    return usuario;
                }
                else if (tipoUsuario == "TechLeader")
                {
                    TechLeader usuario = new TechLeader(null, Nome, Sobrenome, Endereco, TipoUsuario.TechLeader, CPF, Time, "Ativo", DateTime.Now, null);
                    return usuario;
                }
                return null;
            }

        }

        public Login GetLoginForm(int userId)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxEmail.Text) ||
              string.IsNullOrWhiteSpace(this.comboBoxTipo.Text))
            {
                this.ApresentarMensagemErro("Por favor, preencha todos os campos obrigatórios.");
                return null;
            }
            else
            {
                string email = this.textBoxEmail.Text;
                string senha = GerarSenhaAleatoria(8);
                string tipoUsuario = this.comboBoxTipo.Text;
                if (tipoUsuario == "Desenvolvedor")
                {
                    Login autenticacao = new Login(null, senha, email, TipoUsuario.Desenvolvedor, userId);
                    return autenticacao;
                }
                else
                {
                    Login autenticacao = new Login(null, senha, email, TipoUsuario.TechLeader, userId);
                    return autenticacao;

                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Controller.InserirUsuario();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Controller.VoltarTela();
        }
        public void ApresentarMensagemErro(string message)
        {
            MessageBox.Show(message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ApresentarMensagem(string message)
        {
            MessageBox.Show(message, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CadastroForm_Load(object sender, EventArgs e)
        {

        }
    }
}
