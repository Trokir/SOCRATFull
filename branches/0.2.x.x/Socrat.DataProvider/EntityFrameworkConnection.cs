using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
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
                        string providerName = "System.Data.SqlClient";
                        string serverName = "10.108.3.33";
                        string databaseName = "Socrat_Guid";

                        var sqlBuilder = new SqlConnectionStringBuilder();

                        sqlBuilder.DataSource = serverName;
                        sqlBuilder.InitialCatalog = databaseName;
                        sqlBuilder.IntegratedSecurity = false;
                        sqlBuilder.UserID = "sa";
                        sqlBuilder.Password = "Admin_2014";
                        sqlBuilder.MultipleActiveResultSets = true;
                        sqlBuilder.ApplicationName = "EntityFramework";

                        string providerString = sqlBuilder.ToString();

                        var entityBuilder = new EntityConnectionStringBuilder();

                        entityBuilder.Provider = providerName;

                        entityBuilder.ProviderConnectionString = providerString;
                        
                        entityBuilder.Metadata = @"res://*/";

                        _socratEntities = new SocratEntities(entityBuilder.ToString());
                        _socratEntities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    }
                    catch (Exception ex)
                    {
                        Logger.AddErrorEx("EntityFrameworkConnection", ex);
                    }

                }

                return _socratEntities;
            }
        }
    }
}
