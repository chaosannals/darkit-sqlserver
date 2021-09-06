using System;
using System.Collections.Generic;
using System.Linq;
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

    public class SQLServerDesign<T> : SQLServerDesign
    {
        public SQLServerDesign(SQLServerSession session): base(session, TableAttribute.GetTableName<T>()){}
    }
}
