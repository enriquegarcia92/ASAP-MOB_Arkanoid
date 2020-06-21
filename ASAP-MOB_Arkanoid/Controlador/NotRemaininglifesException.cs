using System;

namespace ASAP_MOB_Arkanoid
{
    public class NotRemaininglifesException : Exception
    {
        public NotRemaininglifesException(string message) : base(message)
        {
        }
    }
}