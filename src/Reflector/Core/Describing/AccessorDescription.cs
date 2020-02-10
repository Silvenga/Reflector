using System;
using System.Collections.Generic;

namespace Reflector.Core.Describing
{
    public class AccessorDescription
    {
        public Type AccessorType { get; set; }

        public ICollection<MemberDescription> Members { get; set; }

        public ICollection<AccessorExpectation> Expectations { get; set; }
    }
}