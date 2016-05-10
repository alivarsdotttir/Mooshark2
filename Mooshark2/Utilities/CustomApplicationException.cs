using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4.Utilities
{
    public class CustomApplicationException : Exception
    {
        public CustomApplicationException()
        {

        }
        public CustomApplicationException(string message) : base(message)
        {

        }
        public CustomApplicationException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}