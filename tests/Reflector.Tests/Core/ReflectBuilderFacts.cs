using AutoFixture;
using Reflector.Contracts;
using Reflector.Core;
using Reflector.Tests.Fixtures;
using Xunit;

namespace Reflector.Tests.Core
{
    public class ReflectBuilderFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void METHOD_NAME()
        {
            var instance = AutoFixture.Create<Example>();
            var builder = new ReflectBuilder<object>(instance);

            // Act
            var accessor = builder.Bind<IExampleAccessorFixture>();

            var propertyValue = accessor.Property;

            // Assert
            Assert.Equal(instance.Property, propertyValue);
        }

        public interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            [FieldBinding("Field")]
            string Field { get; set; }

            [PropertyBinding("Property")]
            string Property { get; set; }
        }
    }
}