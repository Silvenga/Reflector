namespace Reflector
{
    public interface IReflectBuilder
    {
        TAccessor Bind<TAccessor>(object instance) where TAccessor : ITypedReflectAccessor;
    }
}