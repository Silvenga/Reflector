using System;
using System.Reflection;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodBindingAttribute : Attribute
    {
        public string Name { get; set; }

        public BindingFlags BindingFlags { get; set; } = BindingFlags.Instance | BindingFlags.Public;

        public MethodBindingAttribute(string name)
        {
            Name = name;
        }
    }
}