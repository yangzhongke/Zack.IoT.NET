using System;

namespace Zack.IoT.NET
{
    public static class IoTExtensions
    {
        public static void AddClosingHook<T>(this T disposable,Action<T> action) where T:IDisposable
        {
            Console.CancelKeyPress += (a, b) =>
            {
                action(disposable);
                disposable.Dispose();
            };
        }
    }
}
