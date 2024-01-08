using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.Model;

namespace GTarefasGUI.ViewModel
{
    public class TarefaViewModel
    {
        public int? Id { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public string? ResponsavelNome { get; set; }
        public int? ResponsavelId {  get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public TarefaViewModel(Tarefa tarefa)
        {
            Id = tarefa.Id;
            NomeTarefa = tarefa.Nome;
            Descricao = tarefa.Descricao;
            ResponsavelNome = tarefa.Responsavel != null ? tarefa.Responsavel.Nome : string.Empty;
            ResponsavelId = tarefa.Responsavel.Id;
            Status = tarefa.Status;
            DataInicio = tarefa.DataInicio;
            DataFim = tarefa.DataFim;
        }
    }
}
