using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._3_Entidade;

namespace TrabalhoFinal._2_Repository
{
    public class LivroRepository
    {
        private const string ConnectionString = "Data Source=CRUD.db";

        public void Adicionar(Livros v)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @"INSERT INTO Livros(NomeLivro,NumPaginas,EditoraLivro,Tipo,Classificacoes) 
                                    VALUES (@NomeLivro,@NumPaginas,@EditoraLivro,@Tipo,@Classificacoes)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@NomeLivro", v.@NomeLivro);
                    command.Parameters.AddWithValue("@NumPaginas", v.NumPaginas);
                    command.Parameters.AddWithValue("@EditoraLivro", v.EditoraLivro);
                    command.Parameters.AddWithValue("@Tipo", v.Tipo);
                    command.Parameters.AddWithValue("@Classificacoes", v.Classificacoes);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover()
        {

        }

        public void Listar()
        {

        }

        public void Editar()
        {

        }

        public void BuscarPorId()
        {

        }
    }
}
