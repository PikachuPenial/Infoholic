using System;
using System.Collections.Generic;
using System.Text;

namespace Infoholic.Utilities
{
    internal class InfoholicDebug
    {
        public static void Log(object message)
        {
            if (Infoholic.DebugMode)
            {
                UnityEngine.Debug.Log(message);
            }
        }
    }
}