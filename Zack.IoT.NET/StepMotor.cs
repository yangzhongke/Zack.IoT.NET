using System;
using System.Device.Gpio;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace Zack.IoT.NET
{
    public class StepMotor:IDisposable
    {
        private GpioPin pinA;
        private GpioPin pinB;
        private GpioPin pinC;
        private GpioPin pinD;
        private int interval;
        public StepMotor(byte pinA, byte pinB, byte pinC, byte pinD, int interval = 1)
        {
            this.interval = interval;
            this.pinA = new GpioPin(pinA);
            this.pinB = new GpioPin(pinB);
            this.pinC = new GpioPin(pinC);
            this.pinD = new GpioPin(pinD);
            this.pinA.Open(PinMode.Output);
            this.pinB.Open(PinMode.Output);
            this.pinC.Open(PinMode.Output);
            this.pinD.Open(PinMode.Output);
            this.pinA.Write(false);
            this.pinB.Write(false);
            this.pinC.Write(false);
            this.pinD.Write(false);
        }
        public void Step1()
        {
            pinD.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
        }
        public void Step2()
        {
            pinD.Write(true);
            pinC.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
            pinC.Write(false);
        }
        public void Step3()
        {
            pinC.Write(true);
            Thread.Sleep(interval);
            pinC.Write(false);
        }
        public void Step4()
        {
            pinB.Write(true);
            pinC.Write(true);
            Thread.Sleep(interval);
            pinB.Write(false);
            pinC.Write(false);
        }
        public void Step5()
        {
            pinB.Write(true);
            Thread.Sleep(interval);
            pinB.Write(false);
        }
        public void Step6()
        {
            pinA.Write(true);
            pinB.Write(true);
            Thread.Sleep(interval);
            pinA.Write(false);
            pinB.Write(false);
        }
        public void Step7()
        {
            pinA.Write(true);
            Thread.Sleep(interval);
            pinA.Write(false);
        }
        public void Step8()
        {
            pinD.Write(true);
            pinA.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
            pinA.Write(false);
        }
        public void Turn(int count)
        {
            foreach (int i in Enumerable.Range(0, count))
            {
                Step1();
                Step2();
                Step3();
                Step4();
                Step5();
                Step6();
                Step7();
                Step8();
            }
        }

        public void TurnSteps(int count)
        {
            foreach (int i in Enumerable.Range(0, count))
            {
                Turn(1);
            }
        }

        public void TurnDegrees(int count)
        {
            Turn((int)Math.Round(count * 512d / 360));
        }

        public void Dispose()
        {
            pinA.Dispose();
            pinB.Dispose();
            pinC.Dispose();
            pinD.Dispose();
        }
    }
}
