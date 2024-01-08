using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    public class Endereco
    {
        public int? Id { get; private set; }
        public string Numero {  get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        public Endereco(int? id, string numero, string logradouro, string cidade, string estado, string cep)
        {   
            Id = id;
            Numero = numero;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }

        public Endereco(int? id, string logradouro, string cidade, string estado, string cep)
        {
            Id = id;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
        public void SetId(int id)
        {
           Id = id;
        }

        public void SetNumero(string numero)
        {
            Numero = numero;
        }

        public void SetLogradouro(string novoLogradouro)
        {
            Logradouro = novoLogradouro;
        }

        public void SetCidade(string novaCidade)
        {
            Cidade = novaCidade;
        }

        public void SetEstado(string novoEstado)
        {
            Estado = novoEstado;
        }

        public void SetCEP(string novoCEP)
        {
            CEP = novoCEP;
        }
    }
}
