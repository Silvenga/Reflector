using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Reflector.Contracts;
using Reflector.Core.Describing.Models;

namespace Reflector.Core.Describing
{
    public class DescriptionBuilder
    {
        // TODO:
        // - Ignore IsSpecialName?
        // - Handle inheritance.

        private int _lastId;

        public AccessorDescription Describe<TAccessor>() where TAccessor : ITypedReflectAccessor
        {
            var accessorType = typeof(TAccessor);
            var dispatcherProperty = typeof(ITypedReflectAccessor).GetProperty(nameof(ITypedReflectAccessor.Dispatcher))
                                     ?? throw new ArgumentException("Dispatcher property is missing on ITypedReflectAccessor");
            var instanceProperty = typeof(ITypedReflectAccessor).GetProperty(nameof(ITypedReflectAccessor.Instance))
                                   ?? throw new ArgumentException("Instance property is missing on ITypedReflectAccessor");
            var accessorDescription = new AccessorDescription(
                accessorType,
                dispatcherProperty,
                instanceProperty
            );

            var members = new Dictionary<int, MemberDescription>();

            var fields = BuildFields(accessorType);
            foreach (var field in fields)
            {
                members.Add(field.Id, field);
            }

            var properties = BuildProperties(accessorType);
            foreach (var property in properties)
            {
                members.Add(property.Id, property);
            }

            var methods = BuildMethods(accessorType);
            foreach (var method in methods)
            {
                members.Add(method.Id, method);
            }

            accessorDescription.Members = members;

            return accessorDescription;
        }

        private IEnumerable<FieldDescription> BuildFields(Type accessorType)
        {
            return from propertyInfo in accessorType.GetProperties()
                   from attribute in propertyInfo.GetCustomAttributes(true)
                   let bindingAttribute = attribute as FieldBindingAttribute
                   where bindingAttribute != null
                   select new FieldDescription(
                       NextId(),
                       bindingAttribute.Name,
                       propertyInfo,
                       bindingAttribute,
                       targetType => targetType.GetField(bindingAttribute.Name, bindingAttribute.BindingFlags)
                   );
        }

        private IEnumerable<PropertyDescription> BuildProperties(Type accessorType)
        {
            return from propertyInfo in accessorType.GetProperties()
                   from attribute in propertyInfo.GetCustomAttributes(true)
                   let bindingAttribute = attribute as PropertyBindingAttribute
                   where bindingAttribute != null
                   select new PropertyDescription(
                       NextId(),
                       bindingAttribute.Name,
                       propertyInfo,
                       bindingAttribute,
                       targetType => targetType.GetProperty(bindingAttribute.Name, bindingAttribute.BindingFlags)
                   );
        }

        private IEnumerable<MethodDescription> BuildMethods(Type accessorType)
        {
            return from methodInfo in accessorType.GetMethods()
                   from attribute in methodInfo.GetCustomAttributes(true)
                   let bindingAttribute = attribute as MethodBindingAttribute
                   where bindingAttribute != null
                   select new MethodDescription(
                       NextId(),
                       bindingAttribute.Name,
                       bindingAttribute,
                       methodInfo,
                       targetType => targetType.GetMethod(bindingAttribute.Name, bindingAttribute.BindingFlags)
                   );
        }

        private int NextId()
        {
            return Interlocked.Increment(ref _lastId);
        }
    }
}