using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Darkit.SQLServer.Query
{
    public class SQLServerQueryCondition
    {
        public SQLServerQueryConditionKind Kind { get; set; }
        public string Statement { get; set; }
        public List<SqlParameter> Parameters { get; set; }
        public List<SQLServerQueryCondition> Group { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            switch (Kind)
            {
                case SQLServerQueryConditionKind.Single:
                    builder.Append(Statement);
                    break;
                case SQLServerQueryConditionKind.AndGroup:
                    builder.Append(string.Join(" AND ", Group.Select(i => string.Format("({0})", i)).ToArray()));
                    break;
                case SQLServerQueryConditionKind.OrGroup:
                    builder.Append(string.Join(" OR ", Group.Select(i => string.Format("({0})", i)).ToArray()));
                    break;
            }
            builder.Append(")");
            return builder.ToString();
        }

        public List<SqlParameter> GetAllParameters()
        {
            if (Kind == SQLServerQueryConditionKind.Single)
            {
                return Parameters;
            }

            List<SqlParameter> result = new List<SqlParameter>();
            foreach (SQLServerQueryCondition i in Group)
            {
                result.AddRange(i.GetAllParameters());
            }
            return result;
        }
    }
}
