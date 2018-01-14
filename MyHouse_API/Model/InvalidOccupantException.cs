using System;

namespace MyHouseAPI.Model
{
    public class InvalidOccupantException : Exception
    {
        public InvalidOccupantException()
        {
        }

        public InvalidOccupantException(string message)
            : base(message)
        {
        }

        public InvalidOccupantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}