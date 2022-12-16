import time
import datetime
from Adafruit_LED_Backpack import SevenSegment

def test():
	print("hello")
def add(i,j):
	return i+j

def led():
	segment = SevenSegment.SevenSegment(address=0x70)

	now = datetime.datetime.now()
	hour = now.hour
	minute = now.minute
	second = now.second

	segment.clear()
	segment.set_digit(0, int(hour / 10))    
	segment.set_digit(1, hour % 10)         
	segment.set_digit(2, int(minute / 10))  
	segment.set_digit(3, minute % 10)        
	segment.set_colon(2)
	segment.write_display()