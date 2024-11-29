using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concerns;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class SwitchData
    {

        public DataBaseConnection conn;

        public SwitchData()
        {
            conn = new DataBaseConnection();
        }
        public int GetApplianceCount(string appliance)
        {
            int count;
            using(SqlConnection connection = conn.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GetCountByName, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", appliance);
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
    }
}
