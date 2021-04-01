using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Core.Describing.Models
{
    public class AccessorDescription
    {
        public Type AccessorType { get; set; }

        public PropertyInfo DispatcherProperty { get; set; }

        public PropertyInfo InstanceProperty { get; set; }

        public IReadOnlyDictionary<int, MemberDescription> Members { get; set; } = new Dictionary<int, MemberDescription>();

        public IReadOnlyList<AccessorExpectation> Expectations { get; set; } = new List<AccessorExpectation>();

        public AccessorDescription(Type accessorType, PropertyInfo dispatcherProperty, PropertyInfo instanceProperty)
        {
            AccessorType = accessorType;
            DispatcherProperty = dispatcherProperty;
            InstanceProperty = instanceProperty;
        }
    }
}