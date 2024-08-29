using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._2_Repository.Data
{
    public static class InicializadorBD
    {
        private const string ConnectionString = "Data Source=CRUD.db";

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Times(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeLivro TEXT NOT NULL,
                    NumPaginas  INTEGER NOT NULL,
                    EditoraLivro TEXT NOT NULL,
                    Tipo TEXT NOT NULL,
                    Classificacoes TEXT NOT NULL,
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
