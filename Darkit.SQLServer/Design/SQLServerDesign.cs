using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Darkit.SQLServer.Data;

namespace Darkit.SQLServer.Design
{
    public class SQLServerDesign
    {
        public string Table { get; private set; }
        public SQLServerSession Session { get; private set; }

        public SQLServerDesign(SQLServerSession session, string table)
        {
            Table = table;
            Session = session;
        }

        public SQLServerDesign Column<T>(string one, params string[] columns)
        {
            return this;
        }
    }

    public class SQLServerDesign<T>
    {
        public SQLServerSession Session { get; private set; }

        public SQLServerDesign(SQLServerSession session)
        {
            Session = session;
        }

        public void Create()
        {
            Type type = typeof(T);
            string table = TableAttribute.GetTableName(type);
            string[] keys = PrimaryKeyAttribute.GetPrimaryKeys(type);

            List<string> columns = new List<string>();
            // 
            foreach(PropertyInfo pi in type.GetProperties())
            {
                ColumnAttribute ca = ColumnAttribute.GetColumnAttribute(pi.PropertyType);
                string name = ca == null ? pi.Name : ca.Name;

                IdentityAttribute ia = IdentityAttribute.GetIdentityAttribute(pi.PropertyType);
                if (ia != null)
                {

                }
            }
            $"CREATE TABLE {table} "
        }
    }
}
