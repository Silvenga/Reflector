using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Reflector.Contracts;
using Reflector.Core;
using Reflector.Core.Describing;
using Reflector.Core.Describing.Models;
using Reflector.Core.Implementing;
using Xunit;

namespace Reflector.Tests.Core.Implementing
{
    public class ImplementationBuilderFacts
    {
        private static readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void When_implementation_is_built_then_dispatcher_property_should_return_dispatcher()
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
        public void When_implementation_is_built_then_instance_property_should_return_instance()
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

        [Fact]
        public void When_implementation_is_built_then_bound_getter_should_invoke_dispatcher()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            _ = implementation.Property;

            // Assert
            dispatcher.Received().PropertyGet(obj, Arg.Any<int>());
        }

        [Fact]
        public void When_implementation_is_built_then_bound_setter_should_invoke_dispatcher()
        {
            var input = AutoFixture.Create<string>();

            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            implementation.Property = input;

            // Assert
            dispatcher.Received().PropertySet(obj, Arg.Any<int>(), Arg.Is(input));
        }

        [Fact]
        public void When_implementation_is_built_then_bound_field_get_should_invoke_dispatcher()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            _ = implementation.Field;

            // Assert
            dispatcher.Received().FieldGet(obj, Arg.Any<int>());
        }

        [Fact]
        public void When_implementation_is_built_then_bound_field_set_should_invoke_dispatcher()
        {
            var input = AutoFixture.Create<string>();

            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            implementation.Field = input;

            // Assert
            dispatcher.Received().FieldSet(obj, Arg.Any<int>(), Arg.Is(input));
        }

        [Fact]
        public void When_implementation_is_built_then_bound_void_method_should_invoke_dispatcher()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            implementation.VoidMethod();

            // Assert
            dispatcher.Received().MethodCall(obj, Arg.Any<int>(), Arg.Is<object[]>(x => x.Length == 0));
        }

        [Fact]
        public void When_implementation_is_built_then_bound_method_with_return_should_invoke_dispatcher()
        {
            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            implementation.MethodWithReturn();

            // Assert
            dispatcher.Received().MethodCall(obj, Arg.Any<int>(), Arg.Is<object[]>(x => x.Length == 0));
        }

        [Fact]
        public void When_implementation_is_built_then_bound_method_with_return_should_return_dispatcher_return()
        {
            var ret = AutoFixture.Create<object>();

            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();
            dispatcher.MethodCall(obj, Arg.Any<int>(), Arg.Any<object[]>()).Returns(ret);

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            var result = implementation.MethodWithReturn();

            // Assert
            result.Should().Be(ret);
        }

        [Fact]
        public void When_implementation_is_built_then_bound_method_with_args_should_invoke_dispatcher()
        {
            var arg1 = AutoFixture.Create<object>();
            var arg2 = AutoFixture.Create<object>();

            var obj = new object();
            var definition = BuildAccessorDefinition<IExampleAccessorFixture>();
            var dispatcher = Substitute.For<IDispatcher>();

            var builder = new ImplementationBuilder();
            var implementation = builder.Implement<IExampleAccessorFixture>(obj, dispatcher, definition);

            // Act
            implementation.MethodWithArguments(arg1, arg2);

            // Assert
            dispatcher.Received().MethodCall(obj, Arg.Any<int>(), Arg.Is<object[]>(x => x.Length == 2));
            dispatcher.Received().MethodCall(obj, Arg.Any<int>(), Arg.Is<object[]>(x => x[0] == arg1));
            dispatcher.Received().MethodCall(obj, Arg.Any<int>(), Arg.Is<object[]>(x => x[1] == arg2));
        }

        private AccessorDescription BuildAccessorDefinition<T>() where T : ITypedReflectAccessor
        {
            var builder = new DescriptionBuilder();
            var description = builder.Describe<T>();
            return description;
        }

        public interface IExampleAccessorFixture : ITypedReflectAccessor
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
        }
    }
}