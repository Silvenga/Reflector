﻿using AutoFixture;
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
            var builder = new ReflectBuilder();

            // Act
            var accessor = builder.Bind<IExampleAccessorFixture>(instance);

            //var propertyValue = accessor.Property;

            // Assert
            //Assert.Equal(instance.Property, propertyValue);
        }

        [ExpectType("Reflector.Tests.Fixtures." + nameof(Example))]
        public interface IExampleAccessorFixture : ITypedReflectAccessor
        {
            //[FieldBinding("Field")]
            //string Field { get; set; }

            [PropertyBinding("Property")]
            string Property { get; set; }
        }
    }
}