using FluentAssertions;
using Reflector.Contracts;
using Reflector.Core.Describing;
using Reflector.Core.Describing.Models;
using Xunit;

namespace Reflector.Tests.Core.Describing
{
    public class AccessorDescriptorBuilderFacts
    {
        [Fact]
        public void When_describing_fields_then_field_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.Value.MemberName == "Field")
                       .Which.Value.Should().BeAssignableTo<FieldDescription>();
        }

        [Fact]
        public void When_describing_properties_then_property_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.Value.MemberName == "Property")
                       .Which.Value.Should().BeAssignableTo<PropertyDescription>();
        }

        [Fact]
        public void When_describing_void_methods_then_method_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.Value.MemberName == "VoidMethod")
                       .Which.Value.Should().BeAssignableTo<MethodDescription>();
        }

        [Fact]
        public void When_describing_methods_with_returns_then_method_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.Value.MemberName == "MethodWithReturn")
                       .Which.Value.Should().BeAssignableTo<MethodDescription>();
        }

        [Fact]
        public void When_describing_methods_with_arguments_then_method_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.Members.Should().ContainSingle(x => x.Value.MemberName == "MethodWithArguments")
                       .Which.Value.Should().BeAssignableTo<MethodDescription>();
        }

        [Fact]
        public void When_accessor_then_instance_property_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.InstanceProperty.Should().NotBeNull();
        }

        [Fact]
        public void When_accessor_then_dispatcher_property_description_should_be_produced()
        {
            var builder = new DescriptionBuilder();

            // Act
            var description = builder.Describe<IExampleAccessorFixture>();

            // Assert
            description.DispatcherProperty.Should().NotBeNull();
        }

        private interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            [FieldBinding("Field")]
            string Field { get; set; }

            [PropertyBinding("Property")]
            string Property { get; set; }

            [MethodBinding("VoidMethod")]
            void VoidMethod();

            [MethodBinding("MethodWithReturn")]
            object MethodWithReturn();

            [MethodBinding("MethodWithArguments")]
            void MethodWithArguments(object obj1, object obj2);

            string NoBinding { get; set; }
        }
    }
}