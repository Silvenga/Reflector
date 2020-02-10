using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing
{
    public delegate MethodInfo MethodInfoFactory(Type targetType);

    public class MethodDescription : MemberDescription
    {
        public MethodBindingAttribute BindingAttribute { get; set; }

        public MethodInfoFactory MethodInfoFactory { get; set; }
    }
}