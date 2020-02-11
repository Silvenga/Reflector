using Reflector.Core.Describing;
using Reflector.Core.Implementing;

namespace Reflector.Core
{
    public class ReflectBuilder : IReflectBuilder
    {
        private readonly DescriptionBuilder _descriptionBuilder = new DescriptionBuilder();
        private readonly ImplementationBuilder _implementationBuilder = new ImplementationBuilder();

        public TAccessor Bind<TAccessor>(object instance) where TAccessor : ITypedReflectAccessor
        {
            var description = _descriptionBuilder.Describe<TAccessor>();
            var implementation = _implementationBuilder.Implement<TAccessor>(instance, new Dispatcher(), description);

            return implementation;
        }
    }
}