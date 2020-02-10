using System;
using System.Reflection;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldBindingAttribute : Attribute
    {
        public string Name { get; set; }

        public BindingFlags BindingFlags { get; set; }

        public FieldBindingAttribute(string name)
        {
            Name = name;
        }
    }
}