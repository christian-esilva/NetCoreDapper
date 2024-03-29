using GameStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GameStore.Infra.StoreContext.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}