using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    public abstract class Usuario
    {
        public int? Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Endereco Endereco { get; private set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string CPF { get; private set; }

        public Usuario()
        {

        }
        public Usuario(int? id, string nome, string sobrenome, Endereco endereco, TipoUsuario tipoUsuario, string cpf)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            TipoUsuario = tipoUsuario;
            CPF = cpf;
        }

        public void SetNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void SetSobrenome(string novoSobrenome)
        {
            Sobrenome = novoSobrenome;
        }

        public void SetEndereco(Endereco novoEndereco)
        {
            Endereco = novoEndereco;
        }

        public void SetTipoUsuario(TipoUsuario tipoUsuario) {
            TipoUsuario = tipoUsuario;
        }

        public void SetCPF(string novoCPF)
        {
            CPF = novoCPF;
        }
    }
}
