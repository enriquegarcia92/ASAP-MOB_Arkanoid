using System;

namespace ASAP_MOB_Arkanoid
{
    public class EmptyUserNameException : Exception
    {
        public EmptyUserNameException(string message) : base(message)
        {
        }
    }
}