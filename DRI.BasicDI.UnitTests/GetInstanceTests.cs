using DRI.BasicDI.Exceptions;
using DRI.BasicDI.UnitTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DRI.BasicDI.UnitTests
{
    public class GetInstanceTests
    {
        [Fact]
        public void Should_instantiate_concrete_type_with_no_dependencies()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_concrete_dependency()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_multiple_concrete_dependencies()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_unregistered_type()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_type_with_unregistered_dependency()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_throw_CircularDependencyException_when_instantiating_type_with_circular_dependency()
        {
            Assert.False(true);
        }
    }
}