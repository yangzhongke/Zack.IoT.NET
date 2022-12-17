using Python.Runtime;

namespace CrowPi2.NET
{
    public class RockerSensor
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

        public int[] Xfer2(int[] values)
        {
            return sensor.xfer2(values);
        }

        public int ReadChannel(int channel)
        {
            var adc = Xfer2(new int[] { 1, (8 + channel) << 4, 0 });
            return ((adc[1] & 3) << 8) + adc[2];
        }

        public void Close()
        {
            this.sensor.close();
        }
    }
}
