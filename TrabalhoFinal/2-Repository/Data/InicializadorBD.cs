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

    public static void Inicializar()
    {
        using var connection = new SQLiteConnection("Data Source=Biblioteca.db");
        string criatTabela = @"
                    CREATE TABLE IF NOT EXISTS Livros(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeLivro TEXT NOT NULL,
                    NumPaginas  INTEGER NOT NULL,
                    EditoraLivro TEXT NOT NULL,
                    NomeAutor TEXT NOT NULL,
                    Preco Real NOT NULL
                    );";

        criatTabela += @"CREATE TABLE IF NOT EXISTS Clientes(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        UsuarioName TEXT NOT NULL,
                        Idade INTEGER  NOT NULL,
                        Email  TEXT NOT NULL,
                        Senha TEXT NOT NULL);";

        criatTabela += @"CREATE TABLE IF NOT EXISTS Enderecos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Cidade TEXT NOT NULL,
                        Rua TEXT NOT NULL,
                        Bairro TEXT  NOT NULL,
                        Num  INTEGER NOT NULL,
                        ClienteId INTEGER NOT NULL);";
 
    criatTabela += @"CREATE TABLE IF NOT EXISTS Carrinhos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteId INTEGER NOT NULL,
                        LivroId INTEGER NOT NULL,
                       PrecoId INTEGER NOT NULL);";

    criatTabela += @"CREATE TABLE IF NOT EXISTS Vendas(
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       ValorFret INTEGER NOT NULL,
                       ValorTotal INTEGER NOT NULL,
                       FormaPagamento INTEGER NOT NULL,
                       UsuarioNameId INTEGER NOT NULL,
                       CarrinhoId INTEGER NOT NULL);";

        connection.Execute(criatTabela);//Execute  qualquer programa SQL    
    }
 }



