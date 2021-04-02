using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing.Models
{
    public delegate PropertyInfo? PropertyInfoFactory(Type targetType);

    public class PropertyDescription : MemberDescription
    {
        public PropertyInfo SourceProperty { get; }

        public PropertyBindingAttribute BindingAttribute { get; }

        public PropertyInfoFactory PropertyInfoFactory { get; }

        public PropertyDescription(int id, string memberName, PropertyInfo sourceProperty, PropertyBindingAttribute bindingAttribute,
                                   PropertyInfoFactory propertyInfoFactory) : base(id, memberName)
        {
            SourceProperty = sourceProperty;
            BindingAttribute = bindingAttribute;
            PropertyInfoFactory = propertyInfoFactory;
        }
    }
}