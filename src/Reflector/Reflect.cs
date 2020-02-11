using Reflector.Core;

namespace Reflector
{
    public static class Reflect
    {
        private static readonly IReflectBuilder Builder = new ReflectBuilder();

        public static T On<T>(object instance) where T : class, ITypedReflectAccessor
        {
            return Builder.Bind<T>(instance);
        }
    }
}