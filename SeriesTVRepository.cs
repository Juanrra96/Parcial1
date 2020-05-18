using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Parcial1 {


public class SeriesTVRepository {

    public SeriesTVRepository()
    {
        
    }

        public static void IniciarBD(){
        using (var connection = new SqliteConnection(@"Data Source=mydb.db;"))
//        ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS Leches (
                        Id INT PRIMARY KEY,
                        Nombre TEXT NULL,
                        Plataforma TEXT NULL,
                        Calificacion INT NULL
                ) ;");
        }
                                    }
        internal List<SerieTV> LeerTodos()
        {
            throw new NotImplementedException();
        }

        internal SerieTV LeerPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal void Crear(SerieTV model)
        {
            throw new NotImplementedException();
        }

        internal void Actualizar(SerieTV model)
        {
            throw new NotImplementedException();
        }

        internal void Borrar(int id)
        {
            throw new NotImplementedException();
        }
    }


}
