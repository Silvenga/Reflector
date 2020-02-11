using System;

namespace Reflector.Core.Describing.Models
{
    public class MethodParameterDescription
    {
        public string Name { get; set; }

        public Type Type { get; set; }

        public int Index { get; set; }
    }
}