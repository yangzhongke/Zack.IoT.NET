using System;
using System.Device.Gpio;

namespace Zack.IoT.NET
{
    public class GpioPin : IDisposable
    {
        private int pin;
        public GpioController Controller { get; private set; }
        public GpioPin(int pin, PinNumberingScheme pinNumberingScheme= PinNumberingScheme.Logical)
        {
            this.pin = pin;
            Controller = new GpioController(pinNumberingScheme);
        }
        public void Open(PinMode pinMode)
        {
            if (Controller.IsPinOpen(pin))
            {
                Controller.ClosePin(pin);
            }
            Controller.OpenPin(pin, pinMode);
            if (!Controller.IsPinOpen(pin))
            {
                throw new InvalidOperationException($"Open pin {pin} failed.");
            }
        }
        public PinValue Read()
        {
            return Controller.Read(pin);
        }
        public void Write(PinValue value)
        {
            Controller.Write(pin, value);
        }
        public void Dispose()
        {
            Controller.ClosePin(pin);
            Controller.Dispose();
        }
    }
}
