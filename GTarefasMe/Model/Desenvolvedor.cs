using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    public class Desenvolvedor : Usuario
    {
        public string Time { get; private set; }
        public string Situacao { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime? DataDemissao { get; private set; }
        

        public Desenvolvedor(int id, string nome, string sobrenome, Endereco endereco, TipoUsuario tipoUsuario, string cpf, string time, string situacao, DateTime dataAdmissao, DateTime? dataDemissao) : base(id, nome, sobrenome, endereco, tipoUsuario, cpf)
        {
            Time = time;
            Situacao = situacao;
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
        }

        public Desenvolvedor(int id, string nome, string sobrenome, Endereco endereco, TipoUsuario tipoUsuario, string cpf, string time) : base(id, nome, sobrenome, endereco, tipoUsuario, cpf)
        {
        }

        public Desenvolvedor()
        {
        }

        public void SetTime(string time)
        {
            Time = time;
        }

        public void SetSituacao (string situacao)
        {
            Situacao = situacao;
        }
        
        public void SetDataAdmissao (DateTime dataInicio)
        {
           DataAdmissao = dataInicio;
        }

        public void SetDataDemissao (DateTime demissao)
        {
           DataDemissao = demissao; 
        }


    }

}
