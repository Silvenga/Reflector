using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing.Models
{
    public delegate PropertyInfo PropertyInfoFactory(Type targetType);

    public class PropertyDescription : MemberDescription
    {
        public PropertyInfo SourceProperty { get; set; }

        public PropertyBindingAttribute BindingAttribute { get; set; }

        public PropertyInfoFactory PropertyInfoFactory { get; set; }
    }
}