using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing.Models
{
    public delegate FieldInfo FieldInfoFactory(Type targetType);

    public class FieldDescription : MemberDescription
    {
        public PropertyInfo SourceProperty { get; set; }

        public FieldBindingAttribute BindingAttribute { get; set; }

        public FieldInfoFactory FieldInfoFactory { get; set; }
    }
}