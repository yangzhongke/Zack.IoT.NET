using Iot.Device.Display;
using System.Device.Gpio;
using System.Device.I2c;
using Zack.IoT.NET;
using Python.Runtime;
using CrowPi2.NET;
using System.Drawing;
using System.Text.Unicode;
using System.Text;

Console.WriteLine("Go...");

CrowPi2Helpers.Start();

//RFID的读写1
/*
var rdr = new RC522Rfid();
var util = rdr.Util();
util.Debug = false;
Console.WriteLine("Waiting for tag");
rdr.WaitForTag();//等待卡
(var error, var _) = rdr.Request();
if (error > 0) return;
Console.WriteLine("检测到");
(var e1, var uid) = rdr.Anticoll();
if (e1 > 0) return;
string card_data = uid[0] + "," + uid[1] + "," + uid[2] + "," + uid[3];
Console.WriteLine("Card read UID: " + card_data);
util.SetTag(uid);//选择该卡片
util.Auth(rdr.Auth_b, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//对卡授权，默认授权码是 { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }，可以修改，但是不建议修改，因为有可能导致卡被锁定。读授权
util.ReadOut(4);//读取并打印第4块数据
util.ReadOut(4);
util.ReadOut(6);//读取并打印第6块数据
util.Auth(rdr.Auth_a, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//进行不同授权。写授权
util.DoAuth(util.BlockAddr(2, 1));//确认授权
rdr.Write(9, new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0x98, 0x76, 0x54, 0x32, 0x10, 0x69, 0x27, 0x46, 0x66, 0x66, 0x64 });//在第9块写入数据
util.Rewrite(9, new byte[] { 0, 0, 0xAB, 0xCD, 0xEF });//修改数据，0代表保持不变
util.ReadOut(9);
util.Dump();//打印卡信息
util.Deauth();//必须停止*/

/*
var rdr = new RC522Rfid();
var util = rdr.Util();
Console.WriteLine("Waiting for tag");
rdr.WaitForTag();//等待卡
(var error, var _) = rdr.Request();
if (error > 0) return;
Console.WriteLine("检测到");
(var e1, var uid) = rdr.Anticoll();
if (e1 > 0) return;
util.SetTag(uid);//选择该卡片
util.Auth(rdr.Auth_b, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//对卡授权，默认授权码是 { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }，可以修改，但是不建议修改，因为有可能导致卡被锁定。读授权
util.Auth(rdr.Auth_a, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });//进行不同授权。写授权
util.DoAuth(1);//确认授权
var a = rdr.Write(1, new byte[] { 1, 2, 3, 4, 5, 6, 0x76, 0x54, 0x32, 0x10, 0x69, 0x27, 0x46, 0x66, 0x66, 0x64 });//在第9块写入数据
Console.WriteLine($"a={a}");
util.ReadOut(1);
util.Deauth();//必须停止
*/

/*
var rdr = new RC522Rfid();
var util = rdr.Util();
util.Debug = true;
while(true)
{
    Console.WriteLine("Select Mode: r for reading, w for writing");
    var m = Console.ReadKey();
    var ch = m.KeyChar;
    if(ch != 'r'&& ch != 'w')
    {
        Console.WriteLine("only r and w are acceptable.");
        continue;
    }
    Console.WriteLine("Waiting for tag");
    rdr.WaitForTag();//等待卡
    (var error, var _) = rdr.Request();
    if (error > 0) return;
    Console.WriteLine("检测到卡");
    (var e1, var uid) = rdr.Anticoll();
    if (e1 > 0) return;
    util.SetTag(uid);//选择该卡片
    util.Auth(rdr.Auth_b, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
    Console.WriteLine("1111111:"+ util.DoAuth(9));
    if (ch=='r')
    {
        (int err, byte[] data)=rdr.Read(9);
        Console.WriteLine(Encoding.UTF8.GetString(data));
        Console.WriteLine("Reading done");
    }
    else
    {
        string name = "abcdefgz12345678";
        Console.WriteLine("2222222222:" + util.DoAuth(9));//确认授权
        rdr.Write(9, Encoding.UTF8.GetBytes(name));//
        Console.WriteLine("Writing done");
    }
    util.Deauth();
}
*/


//KeyMatrix
/*
CrowPi2KeyMatrix km = new CrowPi2KeyMatrix();
while(true)
{
    Console.WriteLine(km.GetKeyNum()+","+km.GetAdcValue());
    Thread.Sleep(200);
}*/


//DHT11
/*
var dht11 = new DHT11();
while(true)
{
    (bool isValid, double temperature, double humidity) = dht11.Read();
    if(isValid)
    {
        Console.WriteLine($"{isValid},{temperature},{humidity}");
    }
    Thread.Sleep(500);
}*/

//Pixcel Strip 1
/*
PixelStrip pixelStrip = new PixelStrip();
pixelStrip.Begin();
for(int i=0;i<64;i++)
{
    pixelStrip.SetPixelColor(i, Color.Green);
    pixelStrip.Brightness = i*3;
    pixelStrip.Show();
    Thread.Sleep(100);
}
pixelStrip.SetPixelColor(0, Color.Black);
pixelStrip.Show();
*/
/*
PixelStrip pixelStrip = new PixelStrip();
pixelStrip.Begin();
Random rand = Random.Shared;
for(int x=0;x<8;x++)
{
    for(int y=0;y<8;y++)
    {
        Color c = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        pixelStrip[x, y] = c;
        pixelStrip.Show();
        Thread.Sleep(100);
    }
}*/
//CharLCD
/*
CharLCD lcd = new CharLCD();
lcd.Backlight = false;
lcd.Message("Hello\nworld!");
Thread.Sleep(1000);
lcd.Clear();
lcd.ShowCursor = true;
lcd.Message("Show cursor");
Thread.Sleep(1000);
lcd.Clear();
lcd.Blink = true;
lcd.Message("Blink cursor");
Thread.Sleep(1000);
lcd.ShowCursor = false;
lcd.Blink = false;
lcd.Clear();
string message = "Scroll";
lcd.Message(message);
int lcd_columns = 16;
for(int i=0;i<lcd_columns-message.Length;i++)
{
    Thread.Sleep(500);
    lcd.MoveRight();
}
for (int i = 0; i < lcd_columns - message.Length; i++)
{
    Thread.Sleep(500);
    lcd.MoveLeft();
}
Thread.Sleep(1000);
lcd.Clear();
lcd.Backlight = true;
Console.WriteLine("done");
*/

//Light Sensor
/*
LightSensor lightSensor = new LightSensor();
while(true)
{
    Console.WriteLine(lightSensor.ReadLight());
    Thread.Sleep(500);
}*/

//Touch PIR Sensor
/*
RockerSensor sensor = new RockerSensor();
while(true)
{
    int xChannel = 1, yChannel = 0;
    int x = sensor.readChannel(xChannel);
    int y = sensor.readChannel(yChannel);
    Console.WriteLine($"{x},{y}");
    if(x>650)
    {
        Console.WriteLine("左");
    }
    if (x <400)
    {
        Console.WriteLine("右");
    }
    if (y > 650)
    {
        Console.WriteLine("上");
    }
    if (y<400)
    {
        Console.WriteLine("下");
    }
}*/

CrowPi2Helpers.Stop();

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