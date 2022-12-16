using System;

namespace CrowPi2.NET
{
    public static class CrowPi2Helpers
    {
        public static void EnsureStarted()
        {
            if (CrowPi2Engine.IsStarted()) return;
            CrowPi2Engine.Start();
            Console.CancelKeyPress += (_, _) => {
                CrowPi2Engine.Stop();
            };
        }
    }
}
