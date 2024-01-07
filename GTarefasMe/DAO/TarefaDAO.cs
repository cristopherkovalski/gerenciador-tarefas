using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.Model;
using MySql.Data.MySqlClient;

namespace GTarefasMe.DAO
{
    public class TarefaDAO
    {
        private ConnectionFactory connectionFactory;
        private UsuarioDAO userDao;
        public TarefaDAO(ConnectionFactory factory)
        {
            this.connectionFactory = factory;
        }

        public List<Tarefa> ListarTodasTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Tarefa";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarefas.Add(LerTarefa(reader));
                    }
                }
            }

            return tarefas;
        }

        public Tarefa ObterTarefaPorId(int tarefaId)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Tarefa WHERE Id = @TarefaId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@TarefaId", tarefaId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return LerTarefa(reader);
                    }
                }
            }

            return null;
        }

        public List<Tarefa> ObterTarefasPorUserId(int userId)
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Tarefa WHERE ResponsavelId = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarefas.Add(LerTarefa(reader));
                    }
                }
            }

            return tarefas;
        }
        public void InserirTarefa(Tarefa tarefa)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "INSERT INTO Tarefa (Nome, Descricao, ResponsavelId, Status, DataInicio, DataFim) VALUES (@Nome, @Descricao, @ResponsavelId, @Status, @DataInicio, @DataFim)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                PreencherParametrosTarefa(cmd, tarefa);

                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarTarefa(int tarefaId, string novaDescricao, int novoResponsavelId)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "UPDATE Tarefa SET Descricao = @Descricao, ResponsavelId = @ResponsavelId WHERE Id = @TarefaId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                cmd.Parameters.AddWithValue("@Descricao", novaDescricao);
                cmd.Parameters.AddWithValue("@ResponsavelId", novoResponsavelId);
                cmd.Parameters.AddWithValue("@TarefaId", tarefaId);

                cmd.ExecuteNonQuery();
            }
        }

        private void PreencherParametrosTarefa(MySqlCommand cmd, Tarefa tarefa)
        {
            cmd.Parameters.AddWithValue("@Nome", tarefa.Nome);
            cmd.Parameters.AddWithValue("@Descricao", tarefa.Descricao);
            cmd.Parameters.AddWithValue("@ResponsavelId", tarefa.Responsavel.Id);
            cmd.Parameters.AddWithValue("@Status", tarefa.Status);
            cmd.Parameters.AddWithValue("@DataInicio", tarefa.DataInicio);
            cmd.Parameters.AddWithValue("@DataFim", tarefa.DataFim);
        }

        private Tarefa LerTarefa(MySqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["Id"]);
            string nome = reader["Nome"].ToString();
            string descricao = reader["Descricao"].ToString();
            int responsavelId = Convert.ToInt32(reader["ResponsavelId"]);
            string status = reader["Status"].ToString();
            DateTime dataInicio = Convert.ToDateTime(reader["DataInicio"]);
            DateTime? dataFim = reader["DataFim"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["DataFim"]);

            Desenvolvedor responsavel = ObterResponsavelPorId(responsavelId);

            return new Tarefa
            {
                Id = id,
                Nome = nome,
                Descricao = descricao,
                Responsavel = responsavel,
                Status = status,
                DataInicio = dataInicio,
                DataFim = dataFim
            };
        }

        private Desenvolvedor ObterResponsavelPorId(int responsavelId)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO(connectionFactory);

            // Chama o método GetById da UsuarioDAO para obter o usuário pelo ID
            Usuario usuario = usuarioDAO.GetById(responsavelId);

            // Verifica se o usuário é do tipo Desenvolvedor
            if (usuario is Desenvolvedor)
            {
                return (Desenvolvedor)usuario;
            }

            // Verifica se o usuário é do tipo TechLeader
            if (usuario is TechLeader)
            {
                // Aqui você pode lançar uma exceção ou tomar ação apropriada, dependendo dos requisitos
                return (TechLeader)usuario;
            }

            // Se o usuário não for do tipo Desenvolvedor ou TechLeader, retorna null ou lança uma exceção, dependendo dos requisitos
            return null;
        }
    }
}



