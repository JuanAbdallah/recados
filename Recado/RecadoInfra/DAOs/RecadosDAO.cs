using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using RecadoModel;

namespace RecadosInfra.DAOs
{
    public class RecadosDAO
    {
        const string connectionString = "Server=localhost; User ID=root; Password=Rafael050300!; Database=camillao";

        public void Inserir(RecModel recado)
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

        public void Alterar(RecModel recado)
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

        public RecModel BuscarPorId(int id)
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"SELECT * FROM recado 
                               WHERE id = @Id";

                return conexao.QueryFirstOrDefault<RecModel>(sql, new { Id = id });
            }
        }

        public List<RecModel> ListarTodos()
        {
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"SELECT * FROM recado";

                return conexao.Query<RecModel>(sql).ToList();
            }
        }
    }
}
