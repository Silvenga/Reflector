using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing.Models
{
    public delegate FieldInfo? FieldInfoFactory(Type targetType);

    public class FieldDescription : MemberDescription
    {
        public PropertyInfo SourceProperty { get; }

        public FieldBindingAttribute BindingAttribute { get; }

        public FieldInfoFactory FieldInfoFactory { get; }

        public FieldDescription(int id, string memberName,
                                PropertyInfo sourceProperty,
                                FieldBindingAttribute bindingAttribute,
                                FieldInfoFactory fieldInfoFactory)
            : base(id, memberName)
        {
            SourceProperty = sourceProperty;
            BindingAttribute = bindingAttribute;
            FieldInfoFactory = fieldInfoFactory;
        }
    }
}