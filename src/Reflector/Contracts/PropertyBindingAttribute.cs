using System;
using System.Reflection;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyBindingAttribute : Attribute
    {
        public string Name { get; set; }

        public BindingFlags BindingFlags { get; set; }

        public PropertyBindingAttribute(string name)
        {
            Name = name;
        }
    }
}