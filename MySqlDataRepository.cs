using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    internal class MySqlDataRepository
    {
        private string _connStr;
        public MySqlDataRepository(string connStr)
        {
            _connStr = connStr;
        }

        public List<String> Query(string sql, string tableName)
        {
            List<String> output = new List<String>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string data = reader.GetString(tableName);
                            output.Add(data);
                        }
                    }
                    return output;
                }
            } catch
            {
                return output;
            }
        }
    }
}
