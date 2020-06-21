using System;

namespace ASAP_MOB_Arkanoid
{
    public class EmptyscoresException : Exception
    {
        public EmptyscoresException(string message) : base(message)
        {
        }
    }
}