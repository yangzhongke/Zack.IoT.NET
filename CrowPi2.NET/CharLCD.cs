using Python.Runtime;

namespace CrowPi2.NET
{
    public class CharLCD
    {
        private dynamic device;
        public CharLCD(int address= 0x21)
        {
            PyModule module = (PyModule)Py.Import("Adafruit_CharLCD");
            this.device = module.Eval($"Adafruit_CharLCDBackpack(address={address})");
        }

        /// <summary>
        /// Move the cursor back to its home (first line and first column).
        /// </summary>
        public void Home()
        {
            this.device.home();
        }

        /// <summary>
        /// Clear the LCD
        /// </summary>
        public void Clear()
        {
            this.device.clear();
        }

        /// <summary>
        /// Move the cursor to an explicit column and row position.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void SetCursor(int col, int row)
        {
            this.device.set_cursor(col,row);
        }

        /// <summary>
        /// Enable or disable the display.  Set enable to True to enable.
        /// </summary>
        /// <param name="enable"></param>
        public bool EnableDisplay
        {
            set
            {
                this.device.enable_display(value);
            }
        }

        /// <summary>
        /// Show or hide the cursor.  Cursor is shown if show is True.
        /// </summary>
        /// <param name="show"></param>
        public bool ShowCursor
        {
            set
            {
                this.device.show_cursor(value);
            }
        }

        /// <summary>
        /// Turn on or off cursor blinking.  Set blink to True to enable blinking.
        /// </summary>
        /// <param name="show"></param>
        public bool Blink
        {
            set
            {
                this.device.blink(value);
            }
        }

        /// <summary>
        /// Move display left one position.
        /// </summary>
        public void MoveLeft()
        {
            this.device.move_left();
        }

        /// <summary>
        /// Move display right one position.
        /// </summary>
        public void MoveRight()
        {
            this.device.move_right();
        }

        /// <summary>
        /// Set text direction
        /// </summary>
        public TextDirection TextDirection
        {
            set
            {
                if(value== TextDirection.LeftToRight)
                {
                    this.device.set_left_to_right();
                }
                else
                {
                    this.device.set_right_to_left();
                }
            }
        }

        /// <summary>
        /// Autoscroll will 'right justify' text from the cursor if set True, otherwise it will 'left justify' the text.
        /// </summary>
        public bool AutoScroll
        {
            set
            {
                this.device.autoscroll(value);
            }
        }

        /// <summary>
        /// Write text to display.  Note that text can include newlines.
        /// </summary>
        /// <param name="text"></param>
        public void Message(string text)
        {
            this.device.message(text);
        }

        /// <summary>
        /// Enable or disable the backlight. 
        /// </summary>
        public bool Backlight
        {
            set
            {
                this.device.set_backlight(value);
            }
        }
    }
}
