using Iot.Device.Display;
using System.Device.Gpio;
using System.Device.I2c;
using Zack.IoT.NET;
using Python.Runtime;
using CrowPi2.NET;

//clock
/*
CrowPi2SevenSegmentDisplay segment = new CrowPi2SevenSegmentDisplay();
bool b = false;
while (true)
{
    segment.clear();
    var now = DateTime.Now;
    segment.set_digit(0, (now.Minute / 10));
    segment.set_digit(1, now.Minute % 10);
    segment.set_digit(2, now.Second / 10);
    segment.set_digit(3, now.Second % 10);
    //segment.set_digit(3, 'F');
    segment.set_colon(b);
    b = !b;
    segment.write_display();
    Thread.Sleep(1000);
}*/
//七段走马灯
/*
CrowPi2SevenSegmentDisplay segment = new CrowPi2SevenSegmentDisplay();
var data = new[] { new { Addr=0,Segment=Segment.Top} , new { Addr = 1, Segment = Segment.Top },
                    new { Addr = 2, Segment = Segment.Top }, new { Addr=3,Segment=Segment.Top},
new { Addr = 3, Segment = Segment.TopRight }, new { Addr=3,Segment=Segment.BottomRight},
new { Addr = 3, Segment = Segment.Bottom }, new { Addr=2,Segment=Segment.Bottom},
new { Addr = 1, Segment = Segment.Bottom }, new { Addr=0,Segment=Segment.Bottom},
new { Addr = 0, Segment = Segment.BottomLeft }, new { Addr=0,Segment=Segment.TopLeft}};
while (true)
{
    foreach (var item in data)
    {
        segment.clear();
        segment.set_digit_raw(item.Addr, item.Segment);
        segment.write_display();
        Thread.Sleep(300);
    }
}*/

//UltrasonicDistanceSensor
/*
int trigPin = 16;
int echoPin = 26;

using UltrasonicDistanceSensor ucSensor = new UltrasonicDistanceSensor(trigPin, echoPin);
while (true)
{
    Console.WriteLine(ucSensor.GetDistance());
}*/


//Beep

/*
using GpioPin gpioPin = new GpioPin(18);

gpioPin.AddClosingHook(e => e.Write(false));
gpioPin.Open(PinMode.Output);
while (true)
{
    gpioPin.Write(PinValue.High);
    Thread.Sleep(500);
    gpioPin.Write(PinValue.Low);
    Thread.Sleep(500);
}
*/
//Tilt
/*
using GpioPin gpioPin = new GpioPin(22);
gpioPin.Open(PinMode.Input);
while (true)
{
    var r = gpioPin.Read();
    Console.WriteLine(r);
    Thread.Sleep(10);
}*/

//7 segment LED
/*
using CrowPi2SevenSegmentDisplay sevenSegDisplay = new CrowPi2SevenSegmentDisplay();
sevenSegDisplay.Clear();
var data = new[] { new { Addr=0,Segment=Segment.Top} , new { Addr = 1, Segment = Segment.Top },
                    new { Addr = 2, Segment = Segment.Top }, new { Addr=3,Segment=Segment.Top},
new { Addr = 3, Segment = Segment.TopRight }, new { Addr=3,Segment=Segment.BottomRight},
new { Addr = 3, Segment = Segment.Bottom }, new { Addr=2,Segment=Segment.Bottom},
new { Addr = 1, Segment = Segment.Bottom }, new { Addr=0,Segment=Segment.Bottom},
new { Addr = 0, Segment = Segment.BottomLeft }, new { Addr=0,Segment=Segment.TopLeft}};
while (true)
{
    foreach (var item in data)
    {
        sevenSegDisplay.Clear();
        sevenSegDisplay[item.Addr] = item.Segment;
        sevenSegDisplay.Flush();
        Thread.Sleep(300);
    }
}*/

/*
using CrowPi2SevenSegmentDisplay sevenSegDisplay = new CrowPi2SevenSegmentDisplay();
sevenSegDisplay.AddClosingHook(e=>e.Clear());
sevenSegDisplay.Clear();
for(int i=2;i<4;i++)
{
    Console.WriteLine($"Number:{i}");
    Show(i, Segment.Middle);
    Show(i, Segment.Top);
    Show(i, Segment.TopRight);
    Show(i, Segment.BottomRight);
    Show(i, Segment.Bottom);
    Show(i, Segment.BottomLeft);
    Show(i, Segment.TopLeft);
    Show(i, Segment.Dot);
    Show(i, Segment.None);
}

void Show(int i,Segment seg)
{
    sevenSegDisplay.Clear();
    sevenSegDisplay[i] = seg;
    Console.WriteLine(seg);
    Console.ReadKey();
}*/