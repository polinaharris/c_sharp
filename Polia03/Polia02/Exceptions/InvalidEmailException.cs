using System;

namespace Polia02.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email: {email}") { }
    }
}
