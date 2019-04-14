using System;

namespace Polia02.Exceptions
{
    public class InvalidBirthdayException : Exception
    {
        public InvalidBirthdayException(DateTime birthday) : base($"Invalid birthday: {birthday.ToShortDateString()}") { }
    }
}
