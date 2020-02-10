using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Implementation
{
    public class FieldDescriptor : MemberDescriptor
    {
        public FieldBindingAttribute BindingAttribute { get; set; }

        public FieldInfo FieldInfo { get; set; }
    }
}