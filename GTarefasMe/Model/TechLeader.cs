using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    public class TechLeader : Desenvolvedor
    {

        public TechLeader(int id, string nome, string sobrenome, Endereco endereco, TipoUsuario tipoUsuario, string cpf, string time, string situacao, DateTime dataAdmissao, DateTime? dataDemissao) : base(id, nome, sobrenome, endereco, tipoUsuario, cpf, time, situacao, dataAdmissao, dataDemissao)
        {
        }
    }
}
