using System;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParameterBindingAttribute : Attribute
    {
        public string Name { get; }

        public string TypeName { get; set; }

        public ParameterBindingAttribute(string name)
        {
            Name = name;
        }
    }
}