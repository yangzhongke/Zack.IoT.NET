using System;
using System.Device.Gpio;
using System.Linq;
using System.Threading;

namespace Zack.IoT.NET
{
    public class StepMotor : IDisposable
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
        private void Step1()
        {
            pinD.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
        }
        private void Step2()
        {
            pinD.Write(true);
            pinC.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
            pinC.Write(false);
        }
        private void Step3()
        {
            pinC.Write(true);
            Thread.Sleep(interval);
            pinC.Write(false);
        }
        private void Step4()
        {
            pinB.Write(true);
            pinC.Write(true);
            Thread.Sleep(interval);
            pinB.Write(false);
            pinC.Write(false);
        }
        private void Step5()
        {
            pinB.Write(true);
            Thread.Sleep(interval);
            pinB.Write(false);
        }
        private void Step6()
        {
            pinA.Write(true);
            pinB.Write(true);
            Thread.Sleep(interval);
            pinA.Write(false);
            pinB.Write(false);
        }
        private void Step7()
        {
            pinA.Write(true);
            Thread.Sleep(interval);
            pinA.Write(false);
        }
        private void Step8()
        {
            pinD.Write(true);
            pinA.Write(true);
            Thread.Sleep(interval);
            pinD.Write(false);
            pinA.Write(false);
        }
        public void Turn(int count,bool direction=true)
        {
            if (direction)
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
            else
            {
                foreach (int i in Enumerable.Range(0, count))
                {
                    Step8();
                    Step7();
                    Step6();
                    Step5();
                    Step4();
                    Step3();
                    Step2();
                    Step1();
                }
            }
        }

        public void TurnSteps(int count, bool direction = true)
        {
            foreach (int i in Enumerable.Range(0, count))
            {
                Turn(1, direction);
            }
        }

        public void TurnDegrees(int count, bool direction = true)
        {
            Turn((int)Math.Round(count * 512d / 360), direction);
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
