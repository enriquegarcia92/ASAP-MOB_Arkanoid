using System.Data;
using Npgsql;

namespace ASAP_MOB_Arkanoid
{
    public class BaseDatos
    {
        
        private static string host = "127.0.0.1",
            puerto = "5432",
            database = "ASAP-MOB",
            userId = "postgres",
            password = "A$APMOB";

        private static string sConnection =
            $"Server={host};Port={puerto};User Id={userId};Password={password};Database={database};";

        public static DataTable ExecuteQuery(string query)
        {
            
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            DataSet ds = new DataSet();
                
            connection.Open();
                
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);
                
            connection.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            connection.Open();
                
            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();
                
            connection.Close();
        }

    }
}