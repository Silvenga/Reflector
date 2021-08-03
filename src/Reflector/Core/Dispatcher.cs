using Reflector.Core.Describing.Models;
using Reflector.Exceptions;

namespace Reflector.Core
{
    public interface IDispatcher
    {
        AccessorDescription Description { get; }

        object PropertyGet(object instance, int id);
        void PropertySet(object instance, int id, object value);
        object FieldGet(object instance, int id);
        void FieldSet(object instance, int id, object value);
        object MethodCall(object instance, int id, object[] arguments);
    }

    public class Dispatcher : IDispatcher
    {
        public AccessorDescription Description { get; }

        public Dispatcher(AccessorDescription description)
        {
            Description = description;
        }

        public object PropertyGet(object instance, int id)
        {
            var member = (PropertyDescription) Description.Members[id];
            var propertyInfo = member.PropertyInfoFactory.Invoke(instance.GetType());
            if (propertyInfo == null)
            {
                throw new InvalidInvocationException($"Property '{member.MemberName}' could not be found.");
            }

            if (!propertyInfo.CanRead)
            {
                throw new InvalidInvocationException($"Property '{member.MemberName}' has no getter.");
            }

            return propertyInfo.GetValue(instance);
        }

        public void PropertySet(object instance, int id, object value)
        {
            var member = (PropertyDescription) Description.Members[id];
            var propertyInfo = member.PropertyInfoFactory.Invoke(instance.GetType());
            if (propertyInfo == null)
            {
                throw new InvalidInvocationException($"Property '{member.MemberName}' could not be found.");
            }

            if (!propertyInfo.CanWrite)
            {
                throw new InvalidInvocationException($"Property '{member.MemberName}' has no setter.");
            }

            propertyInfo.SetValue(instance, value);
        }

        public object FieldGet(object instance, int id)
        {
            var member = (FieldDescription) Description.Members[id];
            var fieldInfo = member.FieldInfoFactory.Invoke(instance.GetType());
            if (fieldInfo == null)
            {
                throw new InvalidInvocationException($"Field '{member.MemberName}' could not be found.");
            }

            return fieldInfo.GetValue(instance);
        }

        public void FieldSet(object instance, int id, object value)
        {
            var member = (FieldDescription) Description.Members[id];
            var fieldInfo = member.FieldInfoFactory.Invoke(instance.GetType());
            if (fieldInfo == null)
            {
                throw new InvalidInvocationException($"Field '{member.MemberName}' could not be found.");
            }

            if (fieldInfo.IsInitOnly)
            {
                throw new InvalidInvocationException($"Field '{member.MemberName}' is read-only.");
            }

            fieldInfo.SetValue(instance, value);
        }

        public object MethodCall(object instance, int id, object[] arguments)
        {
            var member = (MethodDescription) Description.Members[id];
            var methodInfo = member.MethodInfoFactory.Invoke(instance.GetType());
            if (methodInfo == null)
            {
                throw new InvalidInvocationException($"Method '{member.MemberName}' could not be found.");
            }

            return methodInfo.Invoke(instance, arguments);
        }
    }
}