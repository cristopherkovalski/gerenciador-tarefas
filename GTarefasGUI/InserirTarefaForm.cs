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
        }
            public void SetController(InserirTarefaController controller)
        {
            this.Controller = controller;
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Controller.InserirNovaTarefa();
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
