using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Parcial1 {


public class SeriesTVRepository {

    public SeriesTVRepository()
    {
        
    }
        private const string DBCON = @"Data Source=mydb.db;";

        public static void IniciarBD(){
        using (var connection = new SqliteConnection(DBCON))
//        ("" +    new SqliteConnectionStringBuilder()  {        DataSource = "data.db"  }))
        {
            connection.Open();
            connection.Execute(
                @"CREATE TABLE IF NOT EXISTS SeriesTV (
                        Id IDENTITY PRIMARY KEY,
                        Nombre TEXT NULL,
                        Plataforma TEXT NULL,
                        Calificacion INT NULL
                ) ;");
        }
                                    }
        internal List<SerieTV> LeerTodos()
        {
            using(var con = new SqliteConnection(DBCON)){

                return con.Query<SerieTV>("SELECT Id, Nombre, Plataforma, Calificacion FROM SeriesTV ").ToList();
            }

        }

        internal SerieTV LeerPorId(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                return con.Query<SerieTV>("SELECT Id, Nombre, Plataforma, Calificacion FROM SeriesTV WHERE Id = @Id "
                    , new { Id = id }).FirstOrDefault();
            }
        }

        internal void Crear(SerieTV model)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("INSERT INTO SeriesTV ( Nombre, Plataforma, Calificacion) VALUES ( @Nombre, @Plataforma, @Calificacion ) "
                    , model);
            }
        }

        internal void Actualizar(SerieTV model)
        {
             using(var con = new SqliteConnection(DBCON)){
                 con.Execute("UPDATE SeriesTV SET  Nombre = @Nombre , Plataforma = @Plataforma, Calificacion = @Calificacion WHERE Id = @Id "
                    , model);
            }
        }

        internal void Borrar(int id)
        {
            using(var con = new SqliteConnection(DBCON)){
                con.Execute("DELETE FROM SeriesTV WHERE Id = @Id "
                    , new { Id = id });
            }
        }
    }


}
