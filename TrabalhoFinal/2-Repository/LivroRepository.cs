using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;
using static System.Net.Mime.MediaTypeNames;

namespace TrabalhoFinal._2_Repository
{
    public class LivroRepository
    {
        private const string ConnectionString = "Data Source=Livro.db";

        public void Adicionar(Livros v)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @"INSERT INTO Livros(NomeLivro,NumPaginas,EditoraLivro,NomeAutor) 
                                    VALUES (@NomeLivro,@NumPaginas,@EditoraLivro,@NomeAutor)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@NomeLivro", v.NomeLivro);
                    command.Parameters.AddWithValue("@NumPaginas", v.NumPaginas);
                    command.Parameters.AddWithValue("@EditoraLivro", v.EditoraLivro);
                    command.Parameters.AddWithValue("@NomeAutor", v.NomeAutor);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Livros WHERE Id = @Id;";

                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Livros> Listar()
        {
            List<Livros> livros = new List<Livros>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectCommand = "SELECT Id, NomeLivro, NumPaginas, EditoraLivro, NomeAutor FROM Livros;";
                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livros l = new Livros();
                            l.Id = int.Parse(reader["Id"].ToString());
                            l.NomeLivro = reader["NomeLivro"].ToString();
                            l.NumPaginas = int.Parse(reader["NumPaginas"].ToString());
                            l.EditoraLivro = reader["EditoraLivro"].ToString();
                            l.NomeAutor = reader["NomeAutor"].ToString();
                            livros.Add(l);
                        }
                    }
                }
            }
            return livros;
        }

        public void Editar(int id, string nomeLivro, int numPagina, string ediLivro, string nomeAutor)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var updateCommand = @"UPDATE Livros
                                SET NomeLivro = @NomeLivro,NumPaginas = @NumPaginas, EditoraLivro= @EditoraLivro, NomeAutor = @NomeAutor
                                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NomeLivro", nomeLivro);
                    command.Parameters.AddWithValue("@NumPaginas", numPagina);
                    command.Parameters.AddWithValue("@EditoraLivro", ediLivro);
                    command.Parameters.AddWithValue("@NomeAutor", nomeAutor);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void BuscarPorId(int id)
        {

        }
    }
}
