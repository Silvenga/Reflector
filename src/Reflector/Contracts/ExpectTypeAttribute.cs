using System;

namespace Reflector.Contracts
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ExpectTypeAttribute : ExpectAttribute
    {
        public string TypeName { get; }

        public ExpectTypeAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }
}