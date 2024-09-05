using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._2_Repository.Data;

public static class InicializadorBD
{
    private const string ConnectionString = "Data Source=Livro.db";

    public static void Inicializar()
    {
        using var connection = new SQLiteConnection("Data Source=Livros.db");
        string criatTabela = @"
                    CREATE TABLE IF NOT EXISTS Livros(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeLivro TEXT NOT NULL,
                    NumPaginas  INTEGER NOT NULL,
                    EditoraLivro TEXT NOT NULL,
                    NomeAutor TEXT NOT NULL
                    );";
        criatTabela += @"CREATE TABLE IF NOT EXISTS Clientes(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Idade INTEGER  NOT NULL,
                        Email  INTEGER NOT NULL);";
        connection.Execute(criatTabela);//Execute  qualquer programa SQL    
    }
 }



