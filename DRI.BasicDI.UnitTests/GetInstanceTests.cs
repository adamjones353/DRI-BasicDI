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
            Container container = new Container();
            container.Register<TestClassC>();
            object test = container.GetInstance<TestClassC>();
            Assert.NotNull(test);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_concrete_dependency()
        {
            Container container = new Container();
            container.Register<TestClassB>();
            container.Register<TestClassC>();
            object test = container.GetInstance<TestClassB>();
            Assert.NotNull(test);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_multiple_concrete_dependencies()
        {
            Container container = new Container();
            container.Register<TestClassA>();
            container.Register<TestClassB>();
            container.Register<TestClassC>();
            object test = container.GetInstance<TestClassA>();
            Assert.NotNull(test);
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_unregistered_type()
        {
            Container container = new Container();
            Assert.Throws<UnregisteredDependencyException>(() => container.GetInstance<TestClassC>());
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_type_with_unregistered_dependency()
        {
            Container container = new Container();
            container.Register<TestClassB>();
            Assert.Throws<UnregisteredDependencyException>(() => container.GetInstance<TestClassB>());
        }

        [Fact]
        public void Should_throw_CircularDependencyException_when_instantiating_type_with_circular_dependency()
        {
            Container container = new Container();
            container.Register<CircularClassA>();
            container.Register<CircularClassB>();
            container.Register<CircularClassC>();
            Assert.Throws<CircularDependencyException>(() => container.GetInstance<CircularClassA>());
        }
    }
}