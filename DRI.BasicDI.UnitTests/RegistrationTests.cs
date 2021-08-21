using System;
using Xunit;
using DRI.BasicDI.UnitTests.TestClasses;
using DRI.BasicDI.Exceptions;

namespace DRI.BasicDI.UnitTests
{
    public class RegistrationTests
    {

        [Fact]
        public void Should_register_concrete_types()
        {
            Container container = new Container();
            container.Register<TestClassC>();

            Assert.Contains(typeof(TestClassC),container);
        }

        [Fact]
        public void Should_throw_AlreadyRegisteredException_when_registering_dependency_more_than_once()
        {
            Container container = new Container();
            container.Register<TestClassC>();

            Assert.Throws<AlreadyRegisteredException>(() => container.Register<TestClassC>());
        }
    }
}