using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Core.Describing.Models
{
    public class AccessorDescription
    {
        public Type AccessorType { get; }

        public PropertyInfo DispatcherProperty { get; }

        public PropertyInfo InstanceProperty { get; }

        public IReadOnlyDictionary<int, MemberDescription> Members { get; }

        public IReadOnlyList<AccessorExpectation> Expectations { get; set; } = new List<AccessorExpectation>();

        public AccessorDescription(Type accessorType,
                                   PropertyInfo dispatcherProperty, 
                                   PropertyInfo instanceProperty,
                                   IReadOnlyDictionary<int, MemberDescription> members)
        {
            AccessorType = accessorType;
            DispatcherProperty = dispatcherProperty;
            InstanceProperty = instanceProperty;
            Members = members;
        }
    }
}