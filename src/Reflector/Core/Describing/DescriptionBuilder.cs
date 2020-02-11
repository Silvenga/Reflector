using System;
using System.Collections.Generic;
using System.Linq;
using Reflector.Contracts;
using Reflector.Core.Describing.Models;

namespace Reflector.Core.Describing
{
    public class DescriptionBuilder
    {
        // TODO:
        // - Ignore IsSpecialName?
        // - Handle inheritance.

        public AccessorDescription Describe<TAccessor>() where TAccessor : ITypedReflectAccessor
        {
            var accessorType = typeof(TAccessor);

            var accessorDescription = new AccessorDescription
            {
                AccessorType = accessorType,
                DispatcherProperty = typeof(ITypedReflectAccessor).GetProperty(nameof(ITypedReflectAccessor.Dispatcher)),
                InstanceProperty = typeof(ITypedReflectAccessor).GetProperty(nameof(ITypedReflectAccessor.Instance))
            };

            // Casting for net35, because reasons... 
            var fields = BuildFields(accessorType).Cast<MemberDescription>();
            var properties = BuildProperties(accessorType).Cast<MemberDescription>();

            var members = new List<MemberDescription>();
            members.AddRange(fields);
            members.AddRange(properties);

            accessorDescription.Members = members;

            return accessorDescription;
        }

        private static IEnumerable<FieldDescription> BuildFields(Type accessorType)
        {
            return from propertyInfo in accessorType.GetProperties()
                   from attribute in propertyInfo.GetCustomAttributes(true)
                   let bindingAttribute = attribute as FieldBindingAttribute
                   where bindingAttribute != null
                   select new FieldDescription
                   {
                       SourceProperty = propertyInfo,
                       BindingAttribute = bindingAttribute,
                       FieldInfoFactory = targetType => targetType.GetField(bindingAttribute.Name, bindingAttribute.BindingFlags),
                       MemberName = bindingAttribute.Name
                   };
        }

        private static IEnumerable<PropertyDescription> BuildProperties(Type accessorType)
        {
            return from propertyInfo in accessorType.GetProperties()
                   from attribute in propertyInfo.GetCustomAttributes(true)
                   let bindingAttribute = attribute as PropertyBindingAttribute
                   where bindingAttribute != null
                   select new PropertyDescription
                   {
                       SourceProperty = propertyInfo,
                       BindingAttribute = bindingAttribute,
                       PropertyInfoFactory = targetType => targetType.GetProperty(bindingAttribute.Name, bindingAttribute.BindingFlags),
                       MemberName = bindingAttribute.Name
                   };
        }

        //private IEnumerable<MethodDescription> BuildMethods(Type accessorType)
        //{
        //    return from methodInfo in accessorType.GetMethods()
        //           from attribute in methodInfo.GetCustomAttributes(true)
        //           let methodBindingAttribute = attribute as MethodBindingAttribute
        //           where methodBindingAttribute != null
        //           select new MethodDescription
        //           {
        //               BindingAttribute = methodBindingAttribute,
        //               MethodInfoFactory = targetType => targetType.GetMethod(methodBindingAttribute.Name, methodBindingAttribute.BindingFlags),
        //               MemberName = methodBindingAttribute.Name
        //           };
        //}
    }
}