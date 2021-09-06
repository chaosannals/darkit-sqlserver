using System;
using System.Data;
using System.Data.SqlClient;
using Darkit.SQLServer.Data;
using Darkit.SQLServer.Design;
using Darkit.SQLServer.Query;

namespace Darkit.SQLServer
{
    public class SQLServerSession : IDisposable
    {
        public string ConnectString { get; private set; }
        public SqlConnection Connection { get; private set; }
        public SqlTransaction Transaction { get; private set; }
        public bool IsTransactionValid { get; private set; }

        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="trusted"></param>
        public SQLServerSession(string user=null, string password="", string server="(local)", string database="", bool trusted = true)
        {
            if (trusted && user == null)
            {
                user = Environment.MachineName + "/" + Environment.UserName;
            }
            ConnectString = string.Format(
                "Server={0};Database={1};User Id={2};Password={3};Trusted_Connection={4}",
                server, database, user, password, trusted
            );
            Connection = null;
            Transaction = null;
            IsTransactionValid = false;
        }

        /// <summary>
        /// 启动事务。
        /// </summary>
        public void StartTransaction()
        {
            EnsureConnection();
            Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务。
        /// </summary>
        public void CommitTransaction()
        {
            Transaction.Commit();
            IsTransactionValid = true;
        }

        public SQLServerQuery From(string table)
        {
            return new SQLServerQuery(this, table);
        }

        public SQLServerQuery From<T>()
        {
            return new SQLServerQuery<T>(this);
        }

        public SQLServerDesign The(string table)
        {
            return new SQLServerDesign(this, table);
        }

        public SQLServerDesign The<T>()
        {
            return new SQLServerDesign<T>(this);
        }

        /// <summary>
        /// 确保连接。
        /// </summary>
        public void EnsureConnection()
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectString);
            }
            switch (Connection.State)
            {
                case ConnectionState.Broken:
                    Connection.Close();
                    Connection.Open();
                    break;
                case ConnectionState.Closed:
                    Connection.Open();
                    break;
            }
        }

        /// <summary>
        /// 回收资源。
        /// </summary>
        public void Dispose()
        {
            if (!IsTransactionValid)
            {
                Transaction?.Rollback();
            }
            if (Connection != null && Connection.State != ConnectionState.Closed)
            {
                Connection.Dispose();
            }
        }
    }
}
