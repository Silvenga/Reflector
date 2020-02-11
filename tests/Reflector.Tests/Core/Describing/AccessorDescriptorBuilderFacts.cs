using FluentAssertions;
using Reflector.Contracts;
using Reflector.Core.Describing;
using Reflector.Core.Describing.Models;
using Reflector.Tests.Fixtures;
using Xunit;

namespace Reflector.Tests.Core.Describing
{
    public class AccessorDescriptorBuilderFacts
    {
        [Fact]
        public void When_describing_fields_then_field_description_should_be_produced()
        {
            var builder  = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.MemberName == "Field")
                       .Which.Should().BeAssignableTo<FieldDescription>();
        }

        [Fact]
        public void When_describing_properties_then_property_description_should_be_produced()
        {
            var builder  = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.MemberName == "Property")
                       .Which.Should().BeAssignableTo<PropertyDescription>();
        }

        [Fact]
        public void When_accessor_then_instance_property_description_should_be_produced()
        {
            var builder  = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.InstanceProperty.Should().NotBeNull();
        }


        [Fact]
        public void When_accessor_then_dispatcher_property_description_should_be_produced()
        {
            var builder  = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.DispatcherProperty.Should().NotBeNull();
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