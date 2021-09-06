using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }

        public static string GetTableName<T>()
        {
            Type type = typeof(T);
            object[] tas = type.GetCustomAttributes(typeof(TableAttribute), false);
            return tas.Length > 0 ? (tas[0] as TableAttribute).Name : type.Name;
        }
    }
}
