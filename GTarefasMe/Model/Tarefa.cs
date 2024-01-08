using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasMe.Model
{
    public class Tarefa
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Desenvolvedor Responsavel { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public Tarefa() { }

        public Tarefa(int? id, string nome, string descricao, Desenvolvedor responsavel, string status, DateTime dataInicio, DateTime? dataFim)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Responsavel = responsavel;
            Status = status;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
