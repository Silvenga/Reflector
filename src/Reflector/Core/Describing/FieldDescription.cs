using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing
{
    public delegate FieldInfo FieldInfoFactory(Type targetType);

    public class FieldDescription : MemberDescription
    {
        public FieldBindingAttribute BindingAttribute { get; set; }

        public FieldInfoFactory FieldInfoFactory { get; set; }
    }
}