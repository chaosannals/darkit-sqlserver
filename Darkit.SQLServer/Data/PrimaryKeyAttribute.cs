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

        public static string[] GetPrimaryKeys(Type type)
        {
            object[] pkas = type.GetCustomAttributes(typeof(PrimaryKeyAttribute), false);
            return pkas.Length > 0 ? (pkas[0] as PrimaryKeyAttribute).Columns : new string[] { "id" };
        }

        public static string[] GetPrimaryKeys<T>()
        {
            return GetPrimaryKeys(typeof(T));
        }
    }
}
