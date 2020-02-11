using FluentAssertions;
using NSubstitute;
using Reflector.Core;
using Reflector.Core.Describing;
using Reflector.Core.Describing.Models;
using Reflector.Core.Implementing;
using Xunit;

namespace Reflector.Tests.Core.Implementing
{
    public class ImplementationBuilderFacts
    {
        [Fact]
        public void When_implementation_is_build_dispatcher_property_should_return_dispatcher()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();

            // Act
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Assert
            implementation.Dispatcher.Should().Be(dispatcher);
        }

        [Fact]
        public void When_implementation_is_build_instance_property_should_return_instance()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();

            // Act
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Assert
            implementation.Instance.Should().Be(obj);
        }

        private AccessorDescription BuildAccessorDefinition<T>() where T : ITypedReflectAccessor
        {
            var builder = new DescriptionBuilder();
            var description = builder.Describe<T>();
            return description;
        }

        public interface IExampleAccessorFixture : ITypedReflectAccessor
        {
        }
    }
}