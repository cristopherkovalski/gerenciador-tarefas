using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GTarefasMe.DAO
{
    public class ConnectionFactory
    { 
        private string connectionString;
        private string server = "localhost";
        private string database = "GerenciadorTarefas";
        private string username = "root";
        private string password = "vivimage";

        public ConnectionFactory()
            {
                connectionString = $"Server={server};Database={database};User ID={username};Password={password};";
            }

            public MySqlConnection CriarConexao()
            {
                MySqlConnection conexao = new MySqlConnection(connectionString);
                return conexao;
            }
        
    }
}
