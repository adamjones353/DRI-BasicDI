using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.Exceptions
{
    public sealed class CircularDependencyException : Exception
    {
        public CircularDependencyException() : base()
        {
        }
        public CircularDependencyException(string message) : base(message)
        {
        }
    }
}