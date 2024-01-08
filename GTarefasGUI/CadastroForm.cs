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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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



        private void button1_Click(object sender, EventArgs e)
        {
            this.Controller.InserirUsuario();

        }
        public void ApresentarMensagemErro(string message)
        {
            MessageBox.Show(message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ApresentarMensagem(string message)
        {
            MessageBox.Show(message, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
