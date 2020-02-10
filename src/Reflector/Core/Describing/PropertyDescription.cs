using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing
{
    public delegate PropertyInfo PropertyInfoFactory(Type targetType);

    public class PropertyDescription : MemberDescription
    {
        public PropertyBindingAttribute BindingAttribute { get; set; }

        public PropertyInfoFactory PropertyInfoFactory { get; set; }
    }
}