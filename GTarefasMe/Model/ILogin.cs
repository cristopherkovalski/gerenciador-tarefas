using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    internal interface ILogin
    {
        int? Id { get;}
        string Senha { get; }
        string Email { get; }
        Enum TipoUsuario { get; }
        int UserId { get; }

        void setUserId(int novoUserId);
        void SetSenha(string novaSenha);
        void SetEmail(string novoEmail);
        void SetTipoUsuario(Enum novoTipoUsuario);
      

    }
}
