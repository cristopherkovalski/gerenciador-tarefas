using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTarefasGUI.ViewModel
{
    public class AlteraTarefaViewModel
    {
       
        public int? tarefaId { get; set; }
        public int ResponsavelId { get; set; }
        public string Descricao { get; set; }
        public string SituacaoTarefa { get; set; }
        public AlteraTarefaViewModel(int? tarefaId, int responsavelId, string descricao, string situacaoTarefa)
        {
            this.tarefaId = tarefaId;
            ResponsavelId = responsavelId;
            Descricao = descricao;
            SituacaoTarefa = situacaoTarefa;
        }

    }


}
