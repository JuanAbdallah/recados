using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace RecInfra.DAOs
{
    public class RecadosDAO
    {
        const string connectionString = "Server=localhost; User ID=root; Password=root; Database=camillao";

        public void Inserir(Recado recado)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"INSERT INTO recado 
                               (mensagem, remetente, destinatario) 
                               VALUES (@Mensagem, @Remetente, @Destinatario)";

                conexao.Execute(sql, recado);
            }
        }

        public void Alterar(Recado recado)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"UPDATE recado 
                               SET mensagem = @Mensagem, 
                                   remetente = @Remetente, 
                                   destinatario = @Destinatario 
                               WHERE id = @Id";

                conexao.Execute(sql, recado);
            }
        }

        public void Deletar(int id)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"DELETE FROM recado 
                               WHERE id = @Id";

                conexao.Execute(sql, new { Id = id });
            }
        }

        public Recado BuscarPorId(int id)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"SELECT * FROM recado 
                               WHERE id = @Id";

                return conexao.QueryFirstOrDefault<Recado>(sql, new { Id = id });
            }
        }

        public List<Recado> ListarTodos()
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"SELECT * FROM recado";

                return conexao.Query<Recado>(sql).ToList();
            }
        }
    }
}
