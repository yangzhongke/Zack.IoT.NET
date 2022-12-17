using Python.Runtime;

namespace CrowPi2.NET
{
    public class LightSensor
    {
        private dynamic device;
        public LightSensor()
        {
            PyModule module = (PyModule)Py.Import("LightSensor");
            this.device = module.Eval($"LightSensor()");
        }

        public double ReadLight()
        {
            return this.device.readLight();
        }
    }
}
