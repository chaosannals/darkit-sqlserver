using System;

namespace Darkit.SQLServer.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IdentityAttribute : Attribute
    {
        public int Initial { get; set; }
        public int Step { get; set; }

        public IdentityAttribute()
        {
            Initial = 1;
            Step = 1;
        }

        public static IdentityAttribute GetIdentityAttribute(Type type)
        {
            object[] ias = type.GetCustomAttributes(typeof(IdentityAttribute), false);
            return ias.Length > 0 ? (ias[0] as IdentityAttribute) : null;
        }
    }
}
