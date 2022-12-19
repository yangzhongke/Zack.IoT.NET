using Python.Runtime;
using System;

namespace CrowPi2.NET
{
    public class SMBus : IDisposable
    {
        private dynamic device;
        public SMBus(int busId)
        {
            PyModule module = (PyModule)Py.Import("smbus");
            this.device = module.Eval($"SMBus({busId})");
        }

        public void Close()
        {
            this.device.close();
        }

        public void Open(byte bus)
        {
            this.device.open(bus);
        }

        public void ProcessCall(byte i2c_addr, byte register, byte value)
        {
            this.device.process_call(i2c_addr, register, value);
        }


        public byte[] ReadBlockData(byte i2c_addr, byte register)
        {
            return this.device.read_block_data(i2c_addr, register);
        }

        public byte ReadByte(byte i2c_addr)
        {
            return this.device.read_byte(i2c_addr);
        }

        public byte ReadByteData(byte i2c_addr, byte register)
        {
            return this.device.read_byte_data(i2c_addr, register);
        }

        public byte[] Read_I2C_BlockData(byte i2c_addr, byte register)
        {
            return this.device.read_i2c_block_data(i2c_addr,register);
        }

        public Int16 ReadWordData(byte i2c_addr, byte register)
        {
            return this.device.read_word_data(i2c_addr, register);
        }

        public void WriteBlockData(byte i2c_addr, byte register,byte[] data)
        {
            this.device.write_block_data(i2c_addr, register, data);
        }

        public void WriteByte(byte i2c_addr,byte value)
        {
            this.device.write_byte(i2c_addr, value);
        }

        public void WriteByteData(byte i2c_addr,int register,byte value)
        {
            this.device.write_byte_data(i2c_addr, register, value);
        }

        public void Write_I2C_BlockData(byte i2c_addr, byte register,byte[] data)
        {
            this.device.write_i2c_block_data(i2c_addr, register, data);
        }

        public void WriteQuick(byte i2c_addr)
        {
            this.device.write_quick(i2c_addr);
        }
        public void WriteWordData(byte i2c_addr, int register, Int16 value)
        {
            this.device.write_word_data(i2c_addr, register, value);
        }
        public void Dispose()
        {
            Close();
        }
    }
}
