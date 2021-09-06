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

        public IndexAttribute(string name, params string[] columns)
        {
            Name = name;
            IsUnique = false;
            Columns = columns;
        }
    }
}
