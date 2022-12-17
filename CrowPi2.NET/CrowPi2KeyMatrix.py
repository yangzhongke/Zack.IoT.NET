import RPi.GPIO as GPIO
import spidev
spi = spidev.SpiDev()
spi.open(0,1)
spi.max_speed_hz=1000000
class CrowPi2KeyMatrix():
    def __init__(self):
        GPIO.setmode(GPIO.BCM)
        self.key_channel = 4
        self.adc_key_val=[30,90,160,230,280,330,400,470,530,590,650,720,780,840,890,960]
        self.key = -1
        self.num_keys = 16
    def ReadChannel(self,channel):
        adc = spi.xfer2([1,(8+channel)<<4,0])
        data = ((adc[1]&3) << 8) + adc[2]
        return data
    
    def GetAdcValue(self):
        adc_key_value = self.ReadChannel(self.key_channel)
        return adc_key_value
    def GetKeyNum(self):
        adc_key_value = self.GetAdcValue()
        for num in range(0,16):
            if adc_key_value < self.adc_key_val[num]:
                return num
        if adc_key_value >= self.num_keys:
            num = -1
            return num