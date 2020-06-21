using System;

namespace ASAP_MOB_Arkanoid
{
    public class OutofTilesException: Exception
    {
        public OutofTilesException(string message) : base(message)
        {
        }
    }
}