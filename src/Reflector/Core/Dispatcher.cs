using System;
using Reflector.Core.Describing.Models;

namespace Reflector.Core
{
    public interface IDispatcher
    {
        object PropertyGet(object instance, int id);
        void PropertySet(object instance, int id, object value);
        object FieldGet(object instance, int id);
        void FieldSet(object instance, int id, object value);
        object MethodCall(object instance, int id, object[] arguments);
    }

    public class Dispatcher : IDispatcher
    {
        private readonly AccessorDescription _description;

        public Dispatcher(AccessorDescription description)
        {
            _description = description;
        }

        public object PropertyGet(object instance, int id)
        {
            throw new NotImplementedException();
        }

        public void PropertySet(object instance, int id, object value)
        {
            throw new NotImplementedException();
        }

        public object FieldGet(object instance, int id)
        {
            throw new NotImplementedException();
        }

        public void FieldSet(object instance, int id, object value)
        {
            throw new NotImplementedException();
        }

        public object MethodCall(object instance, int id, object[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}