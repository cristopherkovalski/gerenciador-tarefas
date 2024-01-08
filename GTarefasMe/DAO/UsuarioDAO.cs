using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.Model;
using MySql.Data.MySqlClient;

namespace GTarefasMe.DAO
{

    public class UsuarioDAO
    {
        private ConnectionFactory connectionFactory;

        public UsuarioDAO(ConnectionFactory factory)
        {
            this.connectionFactory = factory;
        }

        public Usuario GetById(int userId)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT u.*, e.* FROM Usuario u LEFT JOIN Endereco e ON u.EnderecoId = e.Id WHERE u.Id = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return LerUsuarioComEndereco(reader);
                    }
                }
            }

            return null;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Usuario";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(LerUsuarioComEndereco(reader));
                    }
                }
            }

            return usuarios;
        }

        public List<Usuario> GetByTipoUsuario(string tipoUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Usuario WHERE TipoUsuario = @TipoUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(LerUsuarioComEndereco(reader));
                    }
                }
            }

            return usuarios;
        }

        /*  public void InserirDesenvolvedor(Desenvolvedor usuario)
          {
              using (MySqlConnection conexao = connectionFactory.CriarConexao())
              {
                  conexao.Open();
                  using (MySqlTransaction transaction = conexao.BeginTransaction())
                  {
                      try
                      {

                          if (usuario.Endereco != null && usuario.Endereco.Id == null)
                          {
                              InserirEndereco(conexao, usuario.Endereco, transaction);
                          }


                          string query = "INSERT INTO Usuario (Nome, Sobrenome, EnderecoId, CPF, TipoUsuario, Time, Situacao, DataAdmissao, DataDemissao) VALUES (@Nome, @Sobrenome, @EnderecoId, @CPF, @TipoUsuario, @Time, @Situacao, @DataAdmissao, @DataDemissao)";
                          MySqlCommand cmd = new MySqlCommand(query, conexao, transaction);

                          PreencherParametrosDev(cmd, usuario);
                          cmd.ExecuteNonQuery();

                          transaction.Commit();
                      }
                      catch (Exception)
                      {
                          transaction.Rollback();
                          throw;
                      }
                  }
              }
          }*/

        public int InserirDesenvolvedor(Desenvolvedor usuario)
        {
            int idInserido = -1; // Valor padrão se algo der errado

            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                using (MySqlTransaction transaction = conexao.BeginTransaction())
                {
                    try
                    {
                        if (usuario.Endereco != null && usuario.Endereco.Id == null)
                        {
                            int idEndereco = InserirEndereco(conexao, usuario.Endereco, transaction);
                            usuario.Endereco.SetId(idEndereco);
                        }

                        string query = "INSERT INTO Usuario (Nome, Sobrenome, EnderecoId, CPF, TipoUsuario, Time, Situacao, DataAdmissao, DataDemissao) VALUES (@Nome, @Sobrenome, @EnderecoId, @CPF, @TipoUsuario, @Time, @Situacao, @DataAdmissao, @DataDemissao); SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd = new MySqlCommand(query, conexao, transaction);

                        PreencherParametrosDev(cmd, usuario);

                        // ExecuteScalar retorna o resultado da primeira coluna da primeira linha
                        idInserido = Convert.ToInt32(cmd.ExecuteScalar());

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return idInserido;
        }



        public void UpdateDesenvolvedor(Desenvolvedor usuario)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                using (MySqlTransaction transaction = conexao.BeginTransaction())
                {
                    try
                    {
                        // Atualizar o Endereco se existir
                        if (usuario.Endereco != null && usuario.Endereco.Id != null)
                        {
                            AtualizarEndereco(conexao, usuario.Endereco, transaction);
                        }

                        // Atualizar o Usuario
                        string query = "UPDATE Usuario SET Nome = @Nome, Sobrenome = @Sobrenome, CPF = @CPF, TipoUsuario = @TipoUsuario, Time = @Time, Situacao = @Situacao, DataAdmissao = @DataAdmissao, DataDemissao = @DataDemissao WHERE Id = @UserId";
                        MySqlCommand cmd = new MySqlCommand(query, conexao, transaction);

                        PreencherParametrosDev(cmd, usuario);
                        cmd.Parameters.AddWithValue("@UserId", usuario.Id);

                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    

        public void UpdateTechLeader(TechLeader usuario)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "UPDATE Usuario SET Nome = @Nome, Sobrenome = @Sobrenome, CPF = @CPF, TipoUsuario = @TipoUsuario, Time = @Time, Situacao = @Situacao, DataAdmissao = @DataAdmissao, DataDemissao = @DataDemissao WHERE Id = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                PreencherParametrosDev(cmd, usuario);
                cmd.Parameters.AddWithValue("@UserId", usuario.Id);

                cmd.ExecuteNonQuery();
            }
        }




        private Usuario LerUsuarioComEndereco(MySqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["Id"]);
            string nome = reader["Nome"].ToString();
            string sobrenome = reader["Sobrenome"].ToString();
            string cpf = reader["CPF"].ToString();
            string tpusuario = reader["TipoUsuario"].ToString();
            Console.WriteLine(tpusuario);
            string time = reader["Time"].ToString();
            string situacao = reader["Situacao"].ToString();
            DateTime dataAdmissao = Convert.ToDateTime(reader["DataAdmissao"]);
            DateTime? dataDemissao = reader["DataDemissao"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["DataDemissao"]);

            Endereco endereco = LerEndereco(reader);

            switch (tpusuario.ToLower())
            {
                case "desenvolvedor":
                    return new Desenvolvedor(id, nome, sobrenome, endereco, TipoUsuario.Desenvolvedor, cpf, time, situacao, dataAdmissao, dataDemissao);
                case "techleader":
                    return new TechLeader(id, nome, sobrenome, endereco, TipoUsuario.TechLeader, cpf, time, situacao, dataAdmissao, dataDemissao);
                default:
                    throw new NotSupportedException($"Tipo de usuário não suportado: {tpusuario}");
            }
        }


        private void PreencherParametrosDev(MySqlCommand cmd, Desenvolvedor usuario)
        {
            cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@Sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("@EnderecoId", usuario.Endereco.Id);
            cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
            cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
            cmd.Parameters.AddWithValue("@Time", usuario.Time);
            cmd.Parameters.AddWithValue("@Situacao", usuario.Situacao);
            cmd.Parameters.AddWithValue("@DataAdmissao", usuario.DataAdmissao);
            cmd.Parameters.AddWithValue("@DataDemissao", usuario.DataDemissao.HasValue ? (object)usuario.DataDemissao : DBNull.Value);
        }

        private Endereco LerEndereco(MySqlDataReader reader)
        {
            int enderecoId = Convert.ToInt32(reader["EnderecoId"]);
            Endereco endereco = ObterEnderecoPorId(enderecoId);
            return endereco;
        }

        private Endereco ObterEnderecoPorId(int enderecoId)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Endereco WHERE Id = @EnderecoId";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@EnderecoId", enderecoId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Crie e retorne um objeto Endereco com base nos dados do banco de dados
                        return new Endereco(
                            Convert.ToInt32(reader["Id"]),
                            reader["Numero"].ToString(),
                            reader["Logradouro"].ToString(),
                            reader["Cidade"].ToString(),
                            reader["Estado"].ToString(),
                            reader["CEP"].ToString()
                        );
                    }
                    return null;
                }
            }
        }
            private void PreencherParametrosEndereco(MySqlCommand cmd, Endereco endereco)
            {
                cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
                cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
                cmd.Parameters.AddWithValue("@CEP", endereco.CEP);
            }
             private int InserirEndereco(MySqlConnection conexao, Endereco endereco, MySqlTransaction transaction)
        {
            string query = "INSERT INTO Endereco (Numero, Logradouro, Cidade, Estado, CEP) VALUES (@Numero, @Logradouro, @Cidade, @Estado, @CEP); SELECT LAST_INSERT_ID();";
            MySqlCommand cmd = new MySqlCommand(query, conexao, transaction);

            PreencherParametrosEndereco(cmd, endereco);

            // ExecuteScalar retorna o resultado da primeira coluna da primeira linha
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void AtualizarEndereco(MySqlConnection conexao, Endereco endereco, MySqlTransaction transaction)
            {
                string query = "UPDATE Endereco SET Numero = @Numero, Logradouro = @Logradouro, Cidade = @Cidade, Estado = @Estado, CEP = @CEP WHERE Id = @EnderecoId";
                MySqlCommand cmd = new MySqlCommand(query, conexao, transaction);

                PreencherParametrosEndereco(cmd, endereco);
                cmd.Parameters.AddWithValue("@EnderecoId", endereco.Id);

                cmd.ExecuteNonQuery();
            }
    }
} 



