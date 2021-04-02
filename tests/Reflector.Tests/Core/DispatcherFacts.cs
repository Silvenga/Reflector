using System.Linq;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Reflector.Contracts;
using Reflector.Core;
using Reflector.Core.Describing;
using Xunit;

namespace Reflector.Tests.Core
{
    public class DispatcherFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void When_PropertyGet_is_called_then_instance_property_should_be_accessed()
        {
            var input = AutoFixture.Create<string>();
            var instanceMock = Substitute.For<IExampleAccessorFixture>();
            instanceMock.Property.Returns(input);

            var description = new DescriptionBuilder().Describe<IExampleAccessorFixture>();
            var dispatcher = new Dispatcher(description);

            var id = description.Members.Single(x => x.Value.MemberName == "Property").Key;

            // Act
            var result = dispatcher.PropertyGet(instanceMock, id);

            // Assert
            result.Should().Be(input);
        }

        [Fact]
        public void When_PropertySet_is_called_then_instance_property_should_be_set()
        {
            var input = AutoFixture.Create<string>();
            var instanceMock = Substitute.For<IExampleAccessorFixture>();
            var description = new DescriptionBuilder().Describe<IExampleAccessorFixture>();
            var dispatcher = new Dispatcher(description);

            var id = description.Members.Single(x => x.Value.MemberName == "Property").Key;

            // Act
            dispatcher.PropertySet(instanceMock, id, input);

            // Assert
            instanceMock.Received().Property = input;
        }

        [Fact]
        public void When_FieldGet_is_called_then_instance_field_should_be_accessed()
        {
            var input = AutoFixture.Create<string>();
            var instanceFake = new FieldExampleFixture
            {
                Field = input
            };
            var description = new DescriptionBuilder().Describe<IFieldExampleAccessorFixture>();
            var dispatcher = new Dispatcher(description);

            var id = description.Members.Single(x => x.Value.MemberName == "Field").Key;

            // Act
            var result = dispatcher.FieldGet(instanceFake, id);

            // Assert
            result.Should().Be(input);
        }

        [Fact]
        public void When_FieldSet_is_called_then_instance_field_should_be_set()
        {
            var input = AutoFixture.Create<string>();
            var instanceFake = new FieldExampleFixture();
            var description = new DescriptionBuilder().Describe<IFieldExampleAccessorFixture>();
            var dispatcher = new Dispatcher(description);

            var id = description.Members.Single(x => x.Value.MemberName == "Field").Key;

            // Act
            dispatcher.FieldSet(instanceFake, id, input);

            // Assert
            instanceFake.Field.Should().Be(input);
        }

        [Fact]
        public void When_MethodCall_is_called_then_instance_method_should_be_accessed()
        {
            var instanceMock = Substitute.For<IExampleAccessorFixture>();
            var description = new DescriptionBuilder().Describe<IExampleAccessorFixture>();
            var dispatcher = new Dispatcher(description);

            var id = description.Members.Single(x => x.Value.MemberName == "VoidMethod").Key;

            // Act
            dispatcher.MethodCall(instanceMock, id, new object[0]);

            // Assert
            instanceMock.Received().VoidMethod();
        }

        public interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            [PropertyBinding("Property")]
            string Property { get; set; }

            [MethodBinding("VoidMethod")]
            void VoidMethod();
        }

        public interface IFieldExampleAccessorFixture : ITypedReflectAccessor
        {
            [FieldBinding("Field")]
            string Field { get; set; }
        }

        public class FieldExampleFixture
        {
            public string Field;
        }
    }
}