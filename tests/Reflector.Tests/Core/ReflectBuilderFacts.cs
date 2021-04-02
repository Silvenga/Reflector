using System.Reflection;
using AutoFixture;
using FluentAssertions;
using Reflector.Contracts;
using Reflector.Core;
using Xunit;

namespace Reflector.Tests.Core
{
    public class ReflectBuilderFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void When_instance_is_bound_then_accessor_should_access_public_property_getter()
        {
            var instanceFake = AutoFixture.Create<Example>();
            var builder = new ReflectBuilder();

            // Act
            var accessor = builder.Bind<IExampleAccessorFixture>(instanceFake);

            // Assert
            accessor.Property.Should().Be(instanceFake.Property);
        }

        [Fact]
        public void When_instance_is_bound_then_accessor_should_access_private_property_setter()
        {
            var input = AutoFixture.Create<string>();
            var instanceFake = AutoFixture.Create<Example>();
            var builder = new ReflectBuilder();

            var accessor = builder.Bind<IExampleAccessorFixture>(instanceFake);

            // Act
            accessor.Property = input;

            // Assert
            instanceFake.Property.Should().Be(input);
        }

        [Fact]
        public void When_instance_is_bound_then_accessor_should_access_private_method()
        {
            var instanceFake = AutoFixture.Create<Example>();
            var builder = new ReflectBuilder();

            var accessor = builder.Bind<IExampleAccessorFixture>(instanceFake);

            // Act
            var result = accessor.MethodWithReturn();

            // Assert
            result.Should().Be("value");
        }

        [ExpectType("Reflector.Tests.Core.Example")]
        public interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            [FieldBinding("Field")]
            string Field { get; set; }

            [PropertyBinding("Property")]
            string Property { get; set; }

            [MethodBinding("MethodWithReturn", BindingFlags = BindingFlags.Instance | BindingFlags.NonPublic)]
            string MethodWithReturn();
        }

        public class Example
        {
            public string Field;

            public string Property { get; private set; }

            private string MethodWithReturn()
            {
                return "value";
            }
        }
    }
}