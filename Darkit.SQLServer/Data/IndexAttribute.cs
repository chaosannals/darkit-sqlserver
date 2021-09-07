using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class IndexAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public string[] Columns { get; set; }

        public IndexAttribute(params string[] columns)
        {
            IsUnique = false;
            Columns = columns;
            Name = string.Join("_", columns.Select(c => c.ToUpper()).ToArray()) + "_INDEX";
        }
    }
}
