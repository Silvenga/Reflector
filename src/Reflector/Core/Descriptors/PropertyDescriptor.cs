using System.Reflection;
using Reflector.Contracts;

namespace Reflector.Core.Implementation
{
    public class PropertyDescriptor : MemberDescriptor
    {
        public PropertyBindingAttribute BindingAttribute { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}