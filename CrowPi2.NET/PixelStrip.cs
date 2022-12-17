using Python.Runtime;
using System;
using System.Drawing;

namespace CrowPi2.NET
{
    public class PixelStrip
    {
        private dynamic device;
        private const int SIZE = 8;
        public PixelStrip(int pinNumber=12)
        {
            PyModule module = (PyModule)Py.Import("rpi_ws281x");
            int num = SIZE * SIZE;
            this.device = module.Eval($"PixelStrip({num},{pinNumber}, 800000, 10, False, 10,0)");
        }

        /// <summary>
        /// Initialize library, must be called once before other functions are called.
        /// </summary>
        public void Begin()
        {
            this.device.begin();
        }

        /// <summary>
        /// Update the display with the data from the LED buffer.
        /// </summary>
        public void Show()
        {
            this.device.show();
        }

        /// <summary>
        /// Set LED at position n to the provided 24-bit color
        /// </summary>
        /// <param name="n"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public void SetPixelColor(int n, int red, int green, int blue)
        {
            this.device.setPixelColorRGB(n, red, green, blue);
        }

        /// <summary>
        /// Set LED at position n to the provided 24-bit color
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public void SetPixelColor(int n, Color color)
        {
            SetPixelColor(n, color.R, color.G, color.B);
        }

        /// <summary>
        /// Get the color value for the LED at position n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Color GetPixelColor(int n)
        {
            dynamic color = this.device.getPixelColorRGB(n);
            return Color.FromArgb(color.r, color.g, color.b);
        }

        public Color this[int n]
        {
            get
            {
                return GetPixelColor(n);
            }
            set
            {
                SetPixelColor(n,value);
            }
        }

        static int CalcPosition(int x,int y)
        {
            if(x<0||x>=SIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(x),$"x>=0&&x<{SIZE}");
            }
            if (y < 0 || y >= SIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"y>=0&&y<{SIZE}");
            }
            return x * SIZE + y;
        }

        public Color this[int x,int y]
        {
            get
            {
                int pos = CalcPosition(x, y);
                return GetPixelColor(pos);
            }
            set
            {
                int pos = CalcPosition(x, y);
                SetPixelColor(pos, value);
            }
        }

        /// <summary>
        /// Scale each LED in the buffer by the provided brightness.  A brightness of 0 is the darkest and 255 is the brightest.
        /// </summary>
        public int Brightness
        {
            get
            {
                return this.device.getBrightness();
            }
            set
            {
                this.device.setBrightness(value);
            }
        }        
    }
}
