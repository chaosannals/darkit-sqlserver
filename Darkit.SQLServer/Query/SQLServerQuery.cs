using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Darkit.SQLServer.Data;

namespace Darkit.SQLServer.Query
{
    public class SQLServerQuery
    {
        public string Table { get; private set; }
        public SQLServerSession Session { get; private set; }
        public SQLServerQueryCondition Conditions { get; private set; }

        public SQLServerQuery(SQLServerSession session, string table)
        {
            Table = table;
            Session = session;
            Conditions = new SQLServerQueryCondition()
            {
                Kind = SQLServerQueryConditionKind.AndGroup,
                Group = new List<SQLServerQueryCondition>(),
            };
        }

        public SQLServerQuery Where(Action<SQLServerQueryCondition> action)
        {
            SQLServerQueryCondition condition = new SQLServerQueryCondition
            {
                Kind = SQLServerQueryConditionKind.AndGroup,
                Group = new List<SQLServerQueryCondition>(),
            };
            action.Invoke(condition);
            Conditions.Group.Add(condition);
            return this;
        }

        public List<T> Select<T>(int? limit=null, int? offset=null)
        {
            List<T> result = new List<T>();
            return result;
        }
    }

    public class SQLServerQuery<T>
    {
        public string Table { get; private set; }
        public SQLServerSession Session { get; private set; }

        public SQLServerQuery(SQLServerSession session)
        {
            Table = TableAttribute.GetTableName<T>();
            Session = session;
        }

        public SQLServerQuery<T, J> Join<J>(Func<T, J, bool> nexus)
        {
            return new SQLServerQuery<T, J>(Session);
        }

        public SQLServerQuery<T> Where(Func<T, bool> condition)
        {
            return this;
        }

        public List<T> Select()
        {
            List<T> result = new List<T>();
            return result;
        }
    }

    public class SQLServerQuery<T, J> : SQLServerQuery<T>
    {
        public SQLServerQuery(SQLServerSession session) : base(session) { }

        public SQLServerQuery<T, J, J2> Join<J2>(Func<T, J, J2> nexus)
        {
            return new SQLServerQuery<T, J, J2>(Session);
        }

        public SQLServerQuery<T, J> Where(Func<T, J, bool> condition)
        {
            return this;
        }
    }

    public class SQLServerQuery<T, J1, J2> : SQLServerQuery<T, J1>
    {
        public SQLServerQuery(SQLServerSession session): base(session) { }

        public SQLServerQuery<T, J1, J2> Where(Func<T, J1, J2, bool> condition)
        {
            return this;
        }
    }
}
