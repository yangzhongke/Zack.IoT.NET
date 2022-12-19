using System;

namespace CrowPi2.NET
{
    public class LightSensor:IDisposable
    {
        private SMBus bus = new SMBus(1);
        private const byte DEVICE = 0x5c;
        private const byte ONE_TIME_HIGH_RES_MODE_1 = 0x20;

        private double convertToNumber(byte[] data)
        {
            return ((data[1] + (256 * data[0])) / 1.2);
        }
        

        public double ReadLight()
        {
            var data = bus.Read_I2C_BlockData(DEVICE, ONE_TIME_HIGH_RES_MODE_1);
            return convertToNumber(data);
        }

        public void Dispose()
        {
            this.bus.Dispose();
        }
    }
}
