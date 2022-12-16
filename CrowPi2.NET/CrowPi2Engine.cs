using Python.Runtime;
using System;
using static Python.Runtime.Py;

namespace CrowPi2.NET
{
    public static class CrowPi2Engine
    {
        private static GILState GL;
        public static void Start()
        {
            Runtime.PythonDLL = @"libpython3.7m.so.1.0";
            //it should go before PythonEngine.Initialize();
            PythonEngine.PythonPath = PythonEngine.PythonPath + ":" + AppDomain.CurrentDomain.BaseDirectory;
            PythonEngine.Initialize();
            GL = Py.GIL();
        }
        public static void Stop()
        {
            GL.Dispose();
            PythonEngine.Shutdown();
        }
    }
}
