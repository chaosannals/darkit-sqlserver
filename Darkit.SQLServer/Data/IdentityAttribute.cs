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
    }
}
