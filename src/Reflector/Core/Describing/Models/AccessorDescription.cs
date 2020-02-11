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

        public ICollection<MemberDescription> Members { get; set; }

        public ICollection<AccessorExpectation> Expectations { get; set; }
    }
}