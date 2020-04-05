using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

namespace Socrat.Log.Core
{
    public static class SqlHelper
    {
        public static string ConnectionString { get; set; }

        private static SqlConnection _connection;

        public static SqlConnection GetConnection()
        {
            if (_connection == null)
                _connection = new SqlConnection();
            else
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            var cs = GetConnectionString();

            while (_connection.State == ConnectionState.Open)
            {
                Thread.Sleep(2000);
            }

            _connection.ConnectionString = cs;
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        private static string GetConnectionString()
        {
            return ConnectionString;
        }

        public static SqlParameter NewInParameter(String name, Object value)
        {
            SqlParameter param = value == null ? new SqlParameter(name, DBNull.Value) : new SqlParameter(name, value);
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public static SqlParameter NewInParameter(String name, DateTime? value)
        {
            SqlParameter param = value == null ? new SqlParameter(name, SqlDbType.DateTime) { Value = DBNull.Value } : new SqlParameter(name, SqlDbType.DateTime) { Value = value };
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public static SqlParameter NewInParameter(String name, Guid value)
        {
            var param = new SqlParameter(name, value) { Direction = ParameterDirection.Input };
            return param;
        }

        public static SqlParameter NewOutParameter(String name, SqlDbType type)
        {
            var param = new SqlParameter(name, type) { Direction = ParameterDirection.Output };
            return param;
        }

        public static SqlParameter NewOutParameter(String name, SqlDbType type, Int32 size)
        {
            var param = new SqlParameter(name, type, size) { Direction = ParameterDirection.Output };
            return param;
        }

        public static SqlParameter NewInOutParameter(String name, Object value, SqlDbType type)
        {
            var param = new SqlParameter(name, type) { Value = value, Direction = ParameterDirection.InputOutput };
            return param;
        }

        public static void ExecuteProcedure(String cmdText, SqlParameter[] cmdPrms)
        {
            ExecuteNonQuery(cmdText, cmdPrms, CommandType.StoredProcedure);
        }

        public static void ExecuteNonQuery(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            using (var cnn = SqlHelper.GetConnection())
            {
                ExecuteNonQuery(cnn, cmdText, cmdPrms, cmdType);
            }
        }

        public static void ExecuteNonQuery(SqlConnection conn, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            PrepareCommand(conn, cmdText, cmdPrms, cmdType).ExecuteNonQuery();
        }

        public static Object ExecuteScalar(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            return PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType).ExecuteScalar();
        }

        public static void FillTable(DataTable table, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            var adpt = new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType));
            adpt.Fill(table);
        }

        public static void FillDataSet(DataSet dataSet, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType)).Fill(dataSet);
        }

        public static void FillDataSet(DataSet dataSet, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType, DataTableMapping[] tableMappings)
        {
            var sqlDataAdapter = new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType));
            sqlDataAdapter.TableMappings.AddRange(tableMappings);
            sqlDataAdapter.Fill(dataSet);
        }

        public static SqlDataReader ExecuteReader(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            return PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType).ExecuteReader();
        }

        private static SqlCommand PrepareCommand(SqlConnection conn, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            var cmd = new SqlCommand(cmdText, conn);
            if (cmdPrms != null)
            {
                cmd.Parameters.AddRange(cmdPrms);
            }
            cmd.CommandType = cmdType;
            return cmd;
        }

        public static void Disconnect()
        {
            _connection.Close();
        }

    }
}