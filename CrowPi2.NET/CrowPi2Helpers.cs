using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using static Python.Runtime.Py;

namespace CrowPi2.NET
{
    public static class CrowPi2Helpers
    {
        private static GILState GL;
        public static bool IsStarted()
        {
            return GL != null;
        }
        public static void Start()
        {
            if (IsStarted()) return;
            Runtime.PythonDLL = @"libpython3.7m.so.1.0";
            List<string> listPyPaths = new List<string>
            {
                PythonEngine.PythonPath,
                "/usr/lib/python3/dist-packages",
                "/usr/lib/python3.7",
                "/usr/local/lib/python3.7/dist-packages",
                AppDomain.CurrentDomain.BaseDirectory
            };
            listPyPaths.AddRange(Directory.GetFiles("/usr/local/lib/python3.7/dist-packages/", "*.egg"));
            //it should go before PythonEngine.Initialize();
            PythonEngine.PythonPath = string.Join(":", listPyPaths);
            PythonEngine.Initialize();
            GL = Py.GIL();
        }
        public static void Stop()
        {
            if (!IsStarted()) return;
            GL.Dispose();
            GL = null;
            PythonEngine.Shutdown();
        }
    }
}
