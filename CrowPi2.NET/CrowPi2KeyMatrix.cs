using Python.Runtime;

namespace CrowPi2.NET
{
    public class CrowPi2KeyMatrix
    {
        private dynamic device;
        public CrowPi2KeyMatrix()
        {
            PyModule module = (PyModule)Py.Import("CrowPi2KeyMatrix");
            this.device = module.Eval($"CrowPi2KeyMatrix()");
        }

        public int GetAdcValue()
        {
            return this.device.GetAdcValue();
        }

        public int GetKeyNum()
        {
            return this.device.GetKeyNum();
        }
    }
}
