using System;
using Concerns;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataBaseConnection
    {
        private string _connectionString;

        public DataBaseConnection()
        {
            using(FileStream connectionStream = new FileStream(Constants.FilePath.dbPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(connectionStream))
                {
                    _connectionString = reader.ReadToEnd();
                }

            }
            
            CheckDataBaseConnectionEstablishment();
        }

        void CheckDataBaseConnectionEstablishment()
        {
            while(true)
            {
                try
                {
                    SqlConnection conn = GetConnection();
                    conn.Open();
                    conn.Close();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine(Constants.connectionEstablishmentFailed);
                    Console.WriteLine(Constants.doYouWannaTryAgain);
                    Console.WriteLine(Constants.tryAgainConfiramation);
                    Console.WriteLine(Constants.closeApplication);
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1) continue;
                    Console.WriteLine(Constants.pressOneOnlyToContinue);

                }
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
