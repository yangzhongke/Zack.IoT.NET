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
        private bool direction = true;
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

        public bool Direction
        {
            get { return direction; }
            set { this.direction = value; }
        }
        private void Step1()
        {
            pinD.Write(direction);
            Thread.Sleep(interval);
            pinD.Write(!direction);
        }
        private void Step2()
        {
            pinD.Write(direction);
            pinC.Write(direction);
            Thread.Sleep(interval);
            pinD.Write(!direction);
            pinC.Write(!direction);
        }
        private void Step3()
        {
            pinC.Write(direction);
            Thread.Sleep(interval);
            pinC.Write(!direction);
        }
        private void Step4()
        {
            pinB.Write(direction);
            pinC.Write(direction);
            Thread.Sleep(interval);
            pinB.Write(!direction);
            pinC.Write(!direction);
        }
        private void Step5()
        {
            pinB.Write(direction);
            Thread.Sleep(interval);
            pinB.Write(!direction);
        }
        private void Step6()
        {
            pinA.Write(direction);
            pinB.Write(direction);
            Thread.Sleep(interval);
            pinA.Write(!direction);
            pinB.Write(!direction);
        }
        private void Step7()
        {
            pinA.Write(direction);
            Thread.Sleep(interval);
            pinA.Write(!direction);
        }
        private void Step8()
        {
            pinD.Write(direction);
            pinA.Write(direction);
            Thread.Sleep(interval);
            pinD.Write(!direction);
            pinA.Write(!direction);
        }
        public void Turn(int count)
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
