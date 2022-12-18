using Iot.Device.Display;
using Python.Runtime;
using System;
using UnitsNet;

namespace CrowPi2.NET
{
    public class CrowPi2SevenSegmentDisplay
    {
        public const byte DEFAULT_ADDRESS = 0x70;
        public const byte HT16K33_BLINK_CMD = 0x80;
        public const byte HT16K33_BLINK_DISPLAYON = 0x01;
        public const byte HT16K33_BLINK_OFF = 0x00;
        public const byte HT16K33_BLINK_2HZ = 0x02;
        public const byte HT16K33_BLINK_1HZ = 0x04;
        public const byte HT16K33_BLINK_HALFHZ = 0x06;
        public const byte HT16K33_SYSTEM_SETUP = 0x20;
        public const byte HT16K33_OSCILLATOR = 0x01;
        public const byte HT16K33_CMD_BRIGHTNESS = 0xE0;
        private dynamic segment;
        public CrowPi2SevenSegmentDisplay(byte address = 0x70)
        {
            PyModule sevenSegment = (PyModule)Py.Import("Adafruit_LED_Backpack.SevenSegment");
            this.segment = sevenSegment.Eval($"SevenSegment(address={address})");
        }

        /// <summary>
        /// Initialize driver with LEDs enabled and all turned off
        /// </summary>
        public void Begin()
        {
            this.segment.begin();
        }

        /// <summary>
        /// Blink display at specified frequency.  Note that frequency must be a value allowed by the HT16K33, specifically one of: HT16K33_BLINK_OFF, HT16K33_BLINK_2HZ, HT16K33_BLINK_1HZ, or HT16K33_BLINK_HALFHZ.
        /// </summary>
        /// <param name="frequency"></param>
        public int Blink
        {
            set
            {
                this.segment.set_blink(value);
            }
        }

        /// <summary>
        /// Set brightness of entire display to specified value (16 levels, from 0 to 15).
        /// </summary>
        /// <param name="brightness"></param>
        public int Brightness
        {
            set
            {
                this.segment.set_brightness(value);
            }
        }

        /// <summary>
        /// Sets specified LED (value of 0 to 127) to the specified value, False for off and True for on.
        /// </summary>
        /// <param name="led"></param>
        /// <param name="value"></param>
        public void SetLed(int led, bool value)
        {
            this.segment.set_led(led, value);
        }

        /// <summary>
        /// Write display buffer to display hardware
        /// </summary>
        public void WriteDisplay()
        {
            this.segment.write_display();
        }

        /// <summary>
        /// Clear contents of display buffer.
        /// </summary>
        public void Clear()
        {
            this.segment.clear();
        }

        /// <summary>
        /// Set whether the display is upside-down or not
        /// </summary>
        /// <param name="invert"></param>
        public bool Invert
        {
            set
            {
                this.segment.set_invert(value);
            }
        }

        /// <summary>
        /// Set digit at position to raw bitmask value.  Position should be a value of 0 to 3 with 0 being the left most digit on the display
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="bitMask"></param>
        public void SetDigitRaw(int pos, int bitMask)
        {
            this.segment.set_digit_raw(pos, bitMask);
        }

        public void SetDigitRaw(int pos, Segment bitMask)
        {
            this.SetDigitRaw(pos, (int)bitMask);
        }

        /// <summary>
        /// Turn decimal point on or off at provided position.  Position should be a value 0 to 3 with 0 being the left most digit on the display.Decimal should be True to turn on the decimal point and False to turn it off.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="isDecimal"></param>
        public void SetDecimal(int pos, bool isDecimal)
        {
            this.segment.set_decimal(pos, isDecimal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="digit">Digit should be a number 0-9, character A-F, space(all LEDs off), or dash(-)</param>
        /// <param name="isDecimal"></param>
        public void SetDigit(int pos, char digit, bool isDecimal = false)
        {
            this.segment.set_digit(pos, digit, isDecimal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="digit">0-9</param>
        /// <param name="isDecimal"></param>
        public void SetDigit(int pos, int digit, bool isDecimal = false)
        {
            if(digit<0||digit>9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "digit must >=0 and <=9");
            }
            char c = Convert.ToChar(48 + digit);
            this.segment.set_digit(pos, c, isDecimal);
        }

        /// <summary>
        /// turn the colon on with show colon True, or off with show colon False.
        /// </summary>
        /// <param name="show_colon"></param>
        public void SetColon(bool show_colon)
        {
            this.segment.set_colon(show_colon);
        }

        /// <summary>
        /// Print a 4 character long string of numeric values to the display. Characters in the string should be any supported character by set_digit, or a decimal point.Decimal point characters will be associated with the previous character.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="justify_right"></param>
        public void PrintNumberStr(string value, bool justify_right= true)
        {
            this.segment.print_number_str(value, justify_right);
        }

        /// <summary>
        /// rint a numeric value to the display.  If value is negative it will be printed with a leading minus sign.Decimal digits is the desired number of digits after the decimal point.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimal_digits"></param>
        /// <param name="justify_right"></param>
        public void PrintFloat(float value, int decimal_digits= 2, bool justify_right= true)
        {
            this.segment.print_float(value, decimal_digits, justify_right);
        }

        /// <summary>
        /// Print a numeric value in hexadecimal.  Value should be from 0 to FFFF.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="justify_right"></param>
        public void PrintHex(int value, bool justify_right= true)
        {
            this.segment.print_hex(value,justify_right);
        }

        public void Close()
        {
            this.segment.close();
        }
    }
}
