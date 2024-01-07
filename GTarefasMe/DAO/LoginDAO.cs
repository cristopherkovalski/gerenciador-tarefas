using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTarefasMe.Model;
using MySql.Data.MySqlClient;

namespace GTarefasMe.DAO
{
    public class LoginDAO
    {
        private ConnectionFactory connectionFactory;

        public LoginDAO(ConnectionFactory factory)
        {
            this.connectionFactory = factory;
        }

        public void InserirLogin(Login login)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "INSERT INTO Login (Id, Senha, Email, TipoUsuario, UsuarioId) VALUES (@Id, @Senha, @Email, @TipoUsuario, @UsuarioId)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                PreencherParametrosLogin(cmd, login);

                cmd.ExecuteNonQuery();
            }
        }

        public bool VerificarLoginExistente(string email)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT COUNT(*) FROM Login WHERE Email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public Login AutenticarLogin(string email, string senha)
        {
            using (MySqlConnection conexao = connectionFactory.CriarConexao())
            {
                conexao.Open();
                string query = "SELECT * FROM Login WHERE Email = @Email AND Senha = @Senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return LerLogin(reader);
                    }
                }
                return null;
            }
        }

        private Login LerLogin(MySqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["Id"]);
            string senha = reader["Senha"].ToString();
            string email = reader["Email"].ToString();
            string tipoUsuario =  reader["TipoUsuario"].ToString();
            int userId = Convert.ToInt32(reader["UsuarioId"]);
            if (tipoUsuario == "Desenvolvedor")
            {
                return new Login(id, senha, email, TipoUsuario.Desenvolvedor, userId);
            }
            else{
                return new Login(id, senha, email, TipoUsuario.TechLeader, userId);
            }
            

           
        }

        private void PreencherParametrosLogin(MySqlCommand cmd, Login login)
        {
            cmd.Parameters.AddWithValue("@Id", login.Id);
            cmd.Parameters.AddWithValue("@Senha", login.Senha);
            cmd.Parameters.AddWithValue("@Email", login.Email);
            cmd.Parameters.AddWithValue("@TipoUsuario", login.TipoUsuario.ToString());
            cmd.Parameters.AddWithValue("@UsuarioId", login.UserId);
        }
    }
}
