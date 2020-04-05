using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using Socrat.DataProvider.Properties;
using Socrat.Log;

namespace Socrat.DataProvider
{
    public static class EntityFrameworkConnection
    {
        private static SocratEntities _socratEntities;
        public static SocratEntities SocratEntities
        {
            get
            {
                if (null == _socratEntities)
                {
                    try
                    {
                        string serverName = "10.108.3.33";
                        string databaseName = GetDbName();

                        var sqlBuilder = new SqlConnectionStringBuilder();

                        sqlBuilder.DataSource = serverName;
                        sqlBuilder.InitialCatalog = databaseName;
                        sqlBuilder.IntegratedSecurity = false;
                        sqlBuilder.UserID = "sa";
                        sqlBuilder.Password = "Admin_2014";
                        sqlBuilder.MultipleActiveResultSets = true;
                        sqlBuilder.ApplicationName = "EntityFramework";

                        _socratEntities = new SocratEntities(sqlBuilder.ConnectionString);
                        _socratEntities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                        Logger.AddInfo($"Соединение: {sqlBuilder.ConnectionString}");
                    }
                    catch (Exception ex)
                    {
                        Logger.AddErrorEx("EntityFrameworkConnection", ex);
                    }

                }

                return _socratEntities;
            }
        }

        private static string GetDbName()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var userSection = (ClientSettingsSection)configuration.GetSection("userSettings/Socrat.Startup.Properties.Settings");
            return userSection.Settings.Get("dbName").Value.ValueXml.InnerText;
        }
    }
}
