using Reflector.Core;

namespace Reflector
{
    public class Reflect
    {
        public static IReflectBuilder<T> On<T>(T instance)
        {
            return new ReflectBuilder<T>(instance);
        }
    }
}