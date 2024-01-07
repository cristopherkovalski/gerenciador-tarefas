using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTarefasMe;
using GTarefasMe.Controller;
using GTarefasMe.Model;

namespace GTarefasGUI
{
    public partial class Form2 : Form
    {   
        private LoginController loginController;
        public Form2()
        {
            InitializeComponent();
            this.loginController = new LoginController();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (!IsValidEmail(textBox1.Text))
            {
                MessageBox.Show("Email inválido. Por favor, insira um email válido.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = textBox1.Text;
            string senha = textBox2.Text;

            Login usuarioAutenticado = loginController.AutenticarUsuario(email, senha);

            if (usuarioAutenticado != null)
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                HomeTechLeaderForm formPrincipal = new HomeTechLeaderForm(usuarioAutenticado);
                formPrincipal.Show();

                // Oculte o formulário de login (opcional)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas. Tente novamente.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool IsValidEmail(string email)
        {
           
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(emailPattern);

            return regex.IsMatch(email);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }


}

