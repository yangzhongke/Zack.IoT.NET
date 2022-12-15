using System;
using System.Device.Gpio;

namespace Zack.IoT.NET
{
    public class GpioPin : IDisposable
    {
        private int pinNumber;
        public GpioController Controller { get; private set; }
        public GpioPin(int pinNumber, PinNumberingScheme pinNumberingScheme= PinNumberingScheme.Logical)
        {
            this.pinNumber = pinNumber;
            Controller = new GpioController(pinNumberingScheme);
        }
        public void Open(PinMode pinMode)
        {
            Close();
            Controller.OpenPin(pinNumber, pinMode);
            if (!Controller.IsPinOpen(pinNumber))
            {
                throw new InvalidOperationException($"Open pin {pinNumber} failed.");
            }
        }

        public void Close()
        {
            if (Controller.IsPinOpen(pinNumber))
            {
                Controller.ClosePin(pinNumber);
            }
        }

        public PinValue Read()
        {
            return Controller.Read(pinNumber);
        }
        public void Write(PinValue value)
        {
            Controller.Write(pinNumber, value);
        }
        public void Dispose()
        {
            Close();
            Controller.Dispose();
        }
    }
}
