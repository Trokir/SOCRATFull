using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

namespace Socrat.Lib
{
    /// <summary>
    /// Класс работы с SQL-сервером
    /// </summary>
    public class SqlHelper
    {
        public SqlHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString { get; set; }

        private SqlConnection _connection;

        private SqlConnection GetConnection()
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

        private string GetConnectionString()
        {
            return _connectionString;
        }

        public SqlParameter NewInParameter(String name, Object value)
        {
            SqlParameter param = value == null ? new SqlParameter(name, DBNull.Value) : new SqlParameter(name, value);
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public SqlParameter NewInParameter(String name, DateTime? value)
        {
            SqlParameter param = value == null ? new SqlParameter(name, SqlDbType.DateTime) { Value = DBNull.Value } : new SqlParameter(name, SqlDbType.DateTime) { Value = value };
            param.Direction = ParameterDirection.Input;
            return param;
        }

        public SqlParameter NewInParameter(String name, Guid value)
        {
            var param = new SqlParameter(name, value) { Direction = ParameterDirection.Input };
            return param;
        }

        public SqlParameter NewOutParameter(String name, SqlDbType type)
        {
            var param = new SqlParameter(name, type) { Direction = ParameterDirection.Output };
            return param;
        }

        public SqlParameter NewOutParameter(String name, SqlDbType type, Int32 size)
        {
            var param = new SqlParameter(name, type, size) { Direction = ParameterDirection.Output };
            return param;
        }

        public SqlParameter NewInOutParameter(String name, Object value, SqlDbType type)
        {
            var param = new SqlParameter(name, type) { Value = value, Direction = ParameterDirection.InputOutput };
            return param;
        }

        public void ExecuteProcedure(String cmdText, SqlParameter[] cmdPrms)
        {
            ExecuteNonQuery(cmdText, cmdPrms, CommandType.StoredProcedure);
        }

        public void ExecuteNonQuery(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            using (var cnn = GetConnection())
            {
                ExecuteNonQuery(cnn, cmdText, cmdPrms, cmdType);
            }
        }

        public void ExecuteNonQuery(SqlConnection conn, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            PrepareCommand(conn, cmdText, cmdPrms, cmdType).ExecuteNonQuery();
        }

        public Object ExecuteScalar(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            return PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType).ExecuteScalar();
        }

        public void FillTable(DataTable table, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            var adpt = new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType));
            adpt.Fill(table);
        }

        public void FillDataSet(DataSet dataSet, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType)).Fill(dataSet);
        }

        public void FillDataSet(DataSet dataSet, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType, DataTableMapping[] tableMappings)
        {
            var sqlDataAdapter = new SqlDataAdapter(PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType));
            sqlDataAdapter.TableMappings.AddRange(tableMappings);
            sqlDataAdapter.Fill(dataSet);
        }

        public SqlDataReader ExecuteReader(String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            return PrepareCommand(GetConnection(), cmdText, cmdPrms, cmdType).ExecuteReader();
        }

        private SqlCommand PrepareCommand(SqlConnection conn, String cmdText, SqlParameter[] cmdPrms, CommandType cmdType)
        {
            var cmd = new SqlCommand(cmdText, conn);
            if (cmdPrms != null)
            {
                cmd.Parameters.AddRange(cmdPrms);
            }
            cmd.CommandType = cmdType;
            return cmd;
        }

        public void Disconnect()
        {
            _connection.Close();
        }

    }
}