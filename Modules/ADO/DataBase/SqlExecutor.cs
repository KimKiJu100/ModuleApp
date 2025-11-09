using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.ADO.DataBase
{
    public class SqlExecutor
    {
        private readonly string _connectionString;

        public SqlExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(sql, conn);

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + param.Key, param.Value ?? DBNull.Value);
                }

                var adapter = new SqlDataAdapter(cmd);
                var result = new DataTable();
                adapter.Fill(result);

                return result;
            }
        }
    }
}
