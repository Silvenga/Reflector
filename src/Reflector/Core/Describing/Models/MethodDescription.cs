using System;
using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Describing.Models
{
    public delegate MethodInfo MethodInfoFactory(Type targetType);

    public class MethodDescription : MemberDescription
    {
        public MethodBindingAttribute BindingAttribute { get; }

        public MethodInfo SourceMethod { get; set; }

        public MethodInfoFactory MethodInfoFactory { get; }

        public MethodDescription(int id, string memberName, MethodBindingAttribute bindingAttribute, MethodInfo sourceMethod, MethodInfoFactory methodInfoFactory) : base(id, memberName)
        {
            BindingAttribute = bindingAttribute;
            SourceMethod = sourceMethod;
            MethodInfoFactory = methodInfoFactory;
        }
    }
}