using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace TT_Project.Models
{

    public static class DapperORM
    {
        private static string connectionString = @"Data Source = localhost, 1433; UserID = sa; Password = Mypasswordisgreat; Initial catalog= Movies;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);

            }


        }
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);

            }
        }

    }
}
//builder.DataSource = "localhost, 1433";
//                builder.UserID = "sa";
//                builder.Password = "Mypasswordisgreat";
//                builder.InitialCatalog = "Movies";