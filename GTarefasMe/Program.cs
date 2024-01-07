using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.DAO;
using GTarefasMe.Model;

namespace GTarefasMe
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            ConnectionFactory connectionFactory = new ConnectionFactory();
            UsuarioDAO dao = new UsuarioDAO(connectionFactory);
            Desenvolvedor dev = new Desenvolvedor();
            dev = (Desenvolvedor)dao.GetById(1);
            Console.WriteLine(dev.Endereco.Cidade);
            Console.WriteLine(dev.TipoUsuario);
            TipoUsuario tipo = new TipoUsuario();
            try
            {
                dev.SetNome("Testovaldo");
                dev.SetTipoUsuario(TipoUsuario.Desenvolvedor);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dao.UpdateDesenvolvedor(dev);
            TarefaDAO tarefaDAO = new TarefaDAO(connectionFactory);
            Tarefa tarefa = new Tarefa();
            tarefa = tarefaDAO.ObterTarefaPorId(1);
            Console.WriteLine(tarefa.Responsavel.Nome);
            Console.ReadLine();
        }
    }
}
