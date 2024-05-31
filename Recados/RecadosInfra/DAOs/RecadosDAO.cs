using Microsoft.Data.Sqlite;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using RecadosModel;

public class RecadosDAO
{
    private string connectionString = "Data Source=db/dados.db";

    public void Inserir(Recado recado)
    {
        using (var conexao = new SqliteConnection(connectionString))
        {
            conexao.Open();

            string sql = @"INSERT INTO recados 
                           (id, mensagem, remetente, destinatario) 
                           VALUES (@Id, @Mensagem, @Remetente, @Destinatario)";

            conexao.Execute(sql, recado);
        }
    }

    public void Alterar(Recado recado)
    {
        using (var conexao = new SqliteConnection(connectionString))
        {
            conexao.Open();

            string sql = @"UPDATE recados 
                           SET mensagem = @Mensagem, 
                               remetente = @Remetente, 
                               destinatario = @Destinatario 
                           WHERE id = @Id";

            conexao.Execute(sql, recado);
        }
    }

    public void Deletar(int id)
    {
        using (var conexao = new SqliteConnection(connectionString))
        {
            conexao.Open();

            string sql = @"DELETE FROM recados 
                           WHERE id = @Id";

            conexao.Execute(sql, new { Id = id });
        }
    }

    public Recado BuscarPorId(int id)
    {
        using (var conexao = new SqliteConnection(connectionString))
        {
            conexao.Open();

            string sql = @"SELECT * FROM recados 
                           WHERE id = @Id";

            return conexao.QueryFirstOrDefault<Recado>(sql, new { Id = id });
        }
    }

    public List<Recado> ListarTodos()
    {
        using (var conexao = new SqliteConnection(connectionString))
        {
            conexao.Open();

            string sql = @"SELECT * FROM recados";

            return conexao.Query<Recado>(sql).ToList();
        }
    }
}
