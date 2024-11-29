using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Concerns;

namespace DataAccessLayer
{
    public class ApplianceOperations
    {
        static DataBaseConnection conn = new DataBaseConnection();

        public static void InsertAppliances(string appliance)
        {
            using (SqlConnection connection = conn.GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(Constants.StoredProcedures.InsertIntoAppliance, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@name", appliance);

                sqlCommand.Parameters.AddWithValue("@status", Constants.offStatus);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public static string GetStatusById(int id)
        {
            using (SqlConnection connection = conn.GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(Constants.StoredProcedures.GetStatusById, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@id", id);
                return (string)sqlCommand.ExecuteScalar();
            }
        }

        public static void UpdateStatusById(string status, int id)
        {
            using (SqlConnection connection = conn.GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(Constants.StoredProcedures.UpdateByStatus, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static bool CheckTableHasRows()
        {
            bool hasRows = false;
            using (SqlConnection connection = conn.GetConnection())
            {
                String query = Constants.Query.getAllAppliances;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                hasRows = sqlCommand.ExecuteReader().HasRows;
            }
            return hasRows;
        }
        public static void TruncateApplianceData()
        {
            using (SqlConnection connection = conn.GetConnection())
            {
                SqlCommand sql = new SqlCommand(Constants.Query.truncateTable, connection);
                connection.Open();
                sql.ExecuteNonQuery();
            }
        }

    }
}
