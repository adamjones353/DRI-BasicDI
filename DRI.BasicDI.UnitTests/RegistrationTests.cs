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
            Assert.False(true);
        }

        [Fact]
        public void Should_throw_AlreadyRegisteredException_when_registering_dependency_more_than_once()
        {
            Assert.False(true);
        }
    }
}