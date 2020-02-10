using FluentAssertions;
using Reflector.Contracts;
using Reflector.Core.Describing;
using Reflector.Tests.Fixtures;
using Xunit;

namespace Reflector.Tests.Describing
{
    public class AccessorDescriptorBuilderFacts
    {
        [Fact]
        public void When_describing_fields_then_field_description_should_be_produced()
        {
            var builder  = new AccessorDescriptorBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.MemberName == "Field")
                       .Which.Should().BeAssignableTo<FieldDescription>();
        }

        [Fact]
        public void When_describing_properties_then_property_description_should_be_produced()
        {
            var builder  = new AccessorDescriptorBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.MemberName == "Property")
                       .Which.Should().BeAssignableTo<PropertyDescription>();
        }

        [ExpectType("Reflector.Tests.Fixtures." + nameof(Example))]
        private interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            [FieldBinding("Field")]
            string Field { get; set; }

            [PropertyBinding("Property")]
            string Property { get; set; }

            string NoBinding { get; set; }
        }
    }
}