using Python.Runtime;

namespace CrowPi2.NET
{
    public class DHT11
    {
        private dynamic device;
        public DHT11(int pin=4)
        {
            PyModule module = (PyModule)Py.Import("DHT11");
            this.device = module.Eval($"DHT11(pin={pin})");
        }

        public (bool isValid, double temperature,double humidity) Read()
        {
            var result = this.device.read();
            if(result.is_valid())
            {
                return (true, result.temperature, result.humidity);
            }
            else
            {
                return (false, 0, 0);
            }
        }
    }
}
