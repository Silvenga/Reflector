using System;

namespace Reflector.Core
{
    public class ReflectBuilder<T> : IReflectBuilder<T>
    {
        private readonly T _instance;

        public ReflectBuilder(T instance)
        {
            _instance = instance;
        }

        public TAccessor Bind<TAccessor>() where TAccessor : class, ITypedReflectAccessor
        {
            throw new NotImplementedException();
        }
    }
}