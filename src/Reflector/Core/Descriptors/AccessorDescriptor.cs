using System;
using System.Collections.Generic;

namespace Reflector.Core.Implementation
{
    public class AccessorDescriptor
    {
        public Type Type { get; set; }

        public ICollection<MemberDescriptor> Members { get; set; }
    }
}