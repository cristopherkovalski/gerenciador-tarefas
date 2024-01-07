using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.DAO;

namespace GTarefasMe.Controller
{
    public class LoginController
    {
        private ConnectionFactory conn;
        private LoginDAO logindao;
        public LoginController()
        {
            this.conn = new ConnectionFactory();
            this.logindao = new LoginDAO(conn);
        }

        public Login AutenticarUsuario(string email, string senha)
        {
            return logindao.AutenticarLogin(email, senha);
        }

    }
}
