using Iot.Device.Display;
using System;
using System.Device.I2c;

namespace Zack.IoT.NET
{
    public class CrowPi2SevenSegmentDisplay : IDisposable
    {
        private I2cDevice i2cDevice;
        private Large4Digit7SegmentDisplay sevenSegDisplay;
        public CrowPi2SevenSegmentDisplay()
        {
            this.i2cDevice = I2cDevice.Create(new I2cConnectionSettings(1, 0x70));
            this.sevenSegDisplay = new Large4Digit7SegmentDisplay(i2cDevice);
            this.sevenSegDisplay.Clear();
        }
        public void Clear()
        {
            this.sevenSegDisplay.Clear();
        }
        public void Flush()
        {
            this.sevenSegDisplay.Flush();
        }
        public Segment this[int address]
        {
            get => this.sevenSegDisplay[address];
            set
            {
                this.sevenSegDisplay[address] = value;
            }
        }
        public void Dispose()
        {
            this.i2cDevice.Dispose();
            this.sevenSegDisplay.Dispose();
        }
    }
}
