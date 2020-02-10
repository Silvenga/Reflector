using System;
using System.Linq;
using System.Reflection;
using Reflector.Contracts;
using Reflector.Core.Implementation;

namespace Reflector.Core.Descriptors
{
    public class AccessorDescriptorBuilder
    {
        public AccessorDescriptor Build(Type targetType, Type accessorDefinition)
        {
            var accessorDescription = new AccessorDescriptor();

            return accessorDescription;
        }

        private void BuildFields(Type targetType, Type accessorDefinition, AccessorDescriptor accessorDescriptor)
        {
            from propertyInfo in accessorDefinition.GetProperties()
                from attribute in propertyInfo.GetCustomAttributes()
                let bindingAttribute = attribute as FieldBindingAttribute
                    where bindingAttribute != null
                          select new FieldDescriptor
                          {
                              BindingAttribute = bindingAttribute,
                              FieldInfo = 
                          }
        }
    }
}