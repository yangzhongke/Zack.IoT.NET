using System;
using System.Numerics;

namespace CrowPi2.NET
{
    public class AccelerometerAndGyro : IDisposable
    {
        private SMBus bus = new SMBus(1);
        private const byte address = 0x68;//This is the address value read via the i2cdetect command

        public AccelerometerAndGyro()
        {
            byte power_mgmt_1 = 0x6b;
            bus.WriteByteData(address, power_mgmt_1, 0);
        }

        int read_word(byte adr)
        {
            var high = bus.ReadByteData(address, adr);
            var low = bus.ReadByteData(address, (byte)(adr + 1));
            var val = (high << 8) + low;
            return val;
        }

        int read_word_2c(byte adr)
        {
            var val = read_word(adr);
            if (val >= 0x8000)
            {
                return -((65535 - val) + 1);
            }
            else return val;
        }

        double dist(double a, double b)
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        static double Degrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }
        double get_y_rotation(double x, double y, double z)
        {
            var radians = Math.Atan2(x, dist(y, z));
            return -Degrees(radians);
        }

        double get_x_rotation(double x, double y, double z)
        {
            var radians = Math.Atan2(y, dist(x, z));
            return Degrees(radians);
        }

        public Vector3 ReadGyro()
        {            
            var x = read_word_2c(0x43);
            var y = read_word_2c(0x45);
            var z = read_word_2c(0x47);
            return new Vector3(x, y, z);
        }

        public Vector3 ReadAcceleration()
        {
            var x = read_word_2c(0x3b);
            var y = read_word_2c(0x3d);
            var z = read_word_2c(0x3f);

            double GRAVITIY_MS2 = 9.80665;
            var x_scaled = x / 16384.0 * GRAVITIY_MS2;
            var y_scaled = y / 16384.0 * GRAVITIY_MS2;
            var z_scaled = z / 16384.0 * GRAVITIY_MS2;
            return new Vector3((float)x_scaled, (float)y_scaled, (float)z_scaled); ;
        }


        public void Dispose()
        {
            this.bus.Dispose();
        }
    }
}
