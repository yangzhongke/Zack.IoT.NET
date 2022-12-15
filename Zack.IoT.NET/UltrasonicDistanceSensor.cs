using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace Zack.IoT.NET
{
    public class UltrasonicDistanceSensor : IDisposable
    {

        private GpioPin triggerPin;
        private GpioPin echoPin;

        public UltrasonicDistanceSensor(int triggerPinNum, int echoPinNum)
        {
            this.triggerPin = new GpioPin(triggerPinNum);
            this.echoPin = new GpioPin(echoPinNum);
            triggerPin.Open(PinMode.Output);
            echoPin.Open(PinMode.Input);
            triggerPin.Write(PinValue.Low);
        }
        public void Dispose()
        {
            this.triggerPin.Dispose();
            this.echoPin.Dispose();
        }

        public double GetDistance()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            mre.WaitOne(500);
            Stopwatch pulseLength = new Stopwatch();

            //Send pulse
            triggerPin.Write(PinValue.High);
            mre.WaitOne(TimeSpan.FromMilliseconds(0.01));
            triggerPin.Write(PinValue.Low);

            //Recieve pusle
            while (this.echoPin.Read() == PinValue.Low)
            {
            }
            pulseLength.Start();


            while (this.echoPin.Read() == PinValue.High)
            {
            }
            pulseLength.Stop();

            //Calculating distance
            TimeSpan timeBetween = pulseLength.Elapsed;
            double distance = timeBetween.TotalSeconds * 17000;
            return distance;
        }
    }
}
