using System;
using System.Reflection;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldBindingAttribute : Attribute
    {
        public string Name { get; }

        public BindingFlags BindingFlags { get; set; } = BindingFlags.Instance | BindingFlags.Public;

        public FieldBindingAttribute(string name)
        {
            Name = name;
        }
    }
}