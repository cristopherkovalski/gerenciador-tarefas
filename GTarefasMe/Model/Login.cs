using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.Model;

namespace GTarefasMe
{
    public class Login : ILogin
    {
        public int? Id { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public Enum TipoUsuario { get; private set; }

        public int UserId { get; private set; }

        public Login(int? id, string senha, string email, Enum tipoUsuario, int userId)
        {
            Id = id;
            Senha = senha;
            Email = email;
            TipoUsuario = tipoUsuario;
            UserId = userId;
        }

        public Login()
        {
        }

        public void setUserId(int novoUserId)
        {
            UserId = novoUserId;
        }
        public void SetSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        public void SetEmail(string novoEmail)
        {
            Email = novoEmail;
        }

        public void SetTipoUsuario(Enum novoTipoUsuario)
        {
            TipoUsuario = novoTipoUsuario;
        }
    }

}
