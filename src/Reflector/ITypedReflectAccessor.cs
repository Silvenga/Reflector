using Reflector.Core;

namespace Reflector
{
    public interface ITypedReflectAccessor
    {
        object Instance { get; }

        IDispatcher Dispatcher { get; }
    }
}