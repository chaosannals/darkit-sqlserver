using System;

namespace Darkit.SQLServer.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string[] Columns { get; set; }
        public PrimaryKeyAttribute(string first, params string[] other)
        {
            Columns = new string[other.Length + 1];
            Columns[0] = first;
            Array.Copy(other, 0, Columns, 1, other.Length);
        }
    }
}
