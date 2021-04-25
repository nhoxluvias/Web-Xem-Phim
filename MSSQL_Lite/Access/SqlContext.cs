﻿using MSSQL_Lite.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL_Lite.Access
{
    public class SqlContext
    {
        public SqlContext()
        {

        }

        private void ThrowExceptionOfQueryString(string queryString)
        {
            if (queryString == null)
                throw new Exception("@'queryString' must be not null");
            if (queryString == "")
                throw new Exception("@'queryString' must be not empty");
        }

        public async Task<int> ExecuteNonQueryAsync(SqlCommand sqlCommand)
        {
            ThrowExceptionOfQueryString(sqlCommand.CommandText);
            return await SqlData.ExecuteNonQueryAsync(sqlCommand);
        }

        public async Task<object> ExecuteReaderAsync(SqlCommand sqlCommand)
        {
            ThrowExceptionOfQueryString(sqlCommand.CommandText);
            return await SqlData.ExecuteReaderAsync(sqlCommand);
        }

        public async Task<object> ExecuteReaderAsync(SqlCommand sqlCommand, Type type)
        {
            ThrowExceptionOfQueryString(sqlCommand.CommandText);
            SqlData sqlData = await SqlData.ExecuteReaderAsync(sqlCommand);
            if (type == null)
                throw new Exception("@'type' must be not null");
            if (type.Equals(typeof(Dictionary<string, object>)))
                return sqlData.ToDictionary();
            else if (type.Equals(typeof(List<Dictionary<string, object>>)))
                return sqlData.ToDictionaryList();
            else
                throw new Exception("@'type' is not valid");
        }

        public async Task<object> ExecutScalarAsync(SqlCommand sqlCommand)
        {
            ThrowExceptionOfQueryString(sqlCommand.CommandText);
            return await SqlData.ExecuteScalarAsync(sqlCommand);
        }
    }
}
