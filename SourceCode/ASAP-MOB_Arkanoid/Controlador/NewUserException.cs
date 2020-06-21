using System;

namespace ASAP_MOB_Arkanoid
{
    public class NewUserException: Exception
    {
        public NewUserException(string message) : base(message)
        {
        }
    }
}