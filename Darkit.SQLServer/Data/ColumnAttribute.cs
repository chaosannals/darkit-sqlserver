using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.SQLServer.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public bool IsNotNull { get; set; }
        public string Default { get; set; }
        public ColumnAttribute(string name)
        {
            Name = name;
            Length = 0;
            Precision = 0;
            Scale = 0;
            IsNotNull = false;
        }
    }
}
