using Python.Runtime;
using System;

namespace CrowPi2.NET
{
    public class RockerSensor:IDisposable
    {
        private dynamic sensor;
        public RockerSensor()
        {
            PyModule sevenSegment = (PyModule)Py.Import("spidev");
            this.sensor = sevenSegment.Eval("SpiDev()");
            int bus = 0, device = 1;
            this.sensor.open(bus, device);
            this.sensor.max_speed_hz = 1000000;
        }

        public int[] xfer2(int[] values)
        {
            return sensor.xfer2(values);
        }

        public int readChannel(int channel)
        {
            var adc = xfer2(new int[] { 1, (8 + channel) << 4, 0 });
            return ((adc[1] & 3) << 8) + adc[2];
        }

        public void close()
        {
            this.sensor.close();
        }

        public void Dispose()
        {
            this.sensor.close();
        }
    }
}
