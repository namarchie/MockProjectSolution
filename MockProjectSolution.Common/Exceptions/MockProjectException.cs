using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Common.Exceptions
{
    public class MockProjectException : Exception
    {
        public MockProjectException()
        {
        }

        public MockProjectException(string message)
            : base(message)
        {
        }

        public MockProjectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
