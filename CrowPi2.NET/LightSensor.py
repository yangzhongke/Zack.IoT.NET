import smbus 
bus = smbus.SMBus(1)  
class LightSensor():
    def __init__(self):
        self.DEVICE = 0x5c
        self.POWER_DOWN = 0x00
        self.POWER_ON = 0x01
        self.RESET = 0x07
        self.CONTINUOUS_LOW_RES_MODE = 0x13
        self.CONTINUOUS_HIGH_RES_MODE_1 = 0x10
        self.CONTINUOUS_HIGH_RES_MODE_2 = 0x11
        self.ONE_TIME_HIGH_RES_MODE_1 = 0x20
        self.ONE_TIME_HIGH_RES_MODE_2 = 0x21
        self.ONE_TIME_LOW_RES_MODE = 0x23
    def convertToNumber(self, data):
        return ((data[1] + (256 * data[0])) / 1.2)
    def readLight(self):
        data = bus.read_i2c_block_data(self.DEVICE,self.ONE_TIME_HIGH_RES_MODE_1)
        return self.convertToNumber(data)