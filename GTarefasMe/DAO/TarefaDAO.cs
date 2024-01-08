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

        public void AtualizarTarefa(int tarefaId, string novaDescricao, int novoResponsavelId, string situacao)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                try
                {
                    conexao.Open();

                    // Verificar se o novo responsável existe na tabela Usuario
                    if (!UsuarioExiste(conexao, novoResponsavelId))
                    {
                        // Lógica para lidar com o responsável inexistente
                        // Exemplo: throw new Exception("Responsável inexistente.");
                        return;
                    }

                    using (MySqlTransaction transacao = conexao.BeginTransaction())
                    {
                        try
                        {
                            string query = "UPDATE Tarefa SET Descricao = @Descricao, ResponsavelId = @ResponsavelId, Status = @Status WHERE Id = @TarefaId";
                            MySqlCommand cmd = new MySqlCommand(query, conexao, transacao);

                            cmd.Parameters.AddWithValue("@Descricao", novaDescricao);
                            cmd.Parameters.AddWithValue("@ResponsavelId", novoResponsavelId);
                            cmd.Parameters.AddWithValue("@Status", situacao);
                            cmd.Parameters.AddWithValue("@TarefaId", tarefaId);

                            cmd.ExecuteNonQuery();

                            transacao.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Se ocorrer algum erro na transação, faça o rollback
                            transacao.Rollback();
                            throw new Exception($"Erro na transação: {ex.Message}");
                        }
                    }
                } catch (Exception ex)
                {
                    throw new Exception($"Erro na transação: {ex.Message}");
                }
            }
        }

        public void ConcluirTarefa(int tarefaId)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                try
                {
                    conexao.Open();

                    string query = "UPDATE Tarefa SET Status = @Status, DataFim = @DataFim WHERE Id = @TarefaId";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    cmd.Parameters.AddWithValue("@Status", "Concluida");
                    cmd.Parameters.AddWithValue("@DataFim", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TarefaId", tarefaId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao concluir tarefa: {ex.Message}", ex);
                }
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
        private bool UsuarioExiste(MySqlConnection conexao, int userId)
        {
            string query = "SELECT COUNT(*) FROM Usuario WHERE Id = @UserId";
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("@UserId", userId);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
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



