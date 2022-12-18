using Python.Runtime;
using System;

namespace CrowPi2.NET
{
    public class RC522Rfid
    {
        private dynamic device;
        public RC522Rfid()
        {
            PyModule module = (PyModule)Py.Import("pirc522.rfid");
            this.device = module.Eval($"RFID()");
        }

        public void Init()
        {
            this.device.init();
        }

        public int SpiTransfer(byte[] data)
        {
            return this.device.spi_transfer(data);
        }

        public void DevWrite(int address, byte value)
        {
            this.device.dev_write(address, value);
        }

        public byte DevRead(int address)
        {
            return this.device.dev_read(address);
        }

        public void SetBitmask(int address,byte mask)
        {
            this.device.set_bitmask(address,mask);
        }

        public void ClearBitmask(int address,byte mask)
        {
            this.device.clear_bitmask(address, mask);
        }

        public void SetAntenna(byte state)
        {
            this.device.set_antenna(state);
        }

        public void SetAntennaGain(int gain)
        {
            this.device.set_antenna_gain(gain);
        }

        public (int error, byte[] back_data, int back_length) CardWrite(int command, byte[] data)
        {
            var r = this.device.card_write(command, data);
            return (r[0], r[1], r[2]);
        }

        public byte[] CalculateCRC(byte[] data)
        {
            return this.device.calculate_crc(data);
        }

        public void WaitForTag()
        {
            this.device.wait_for_tag();
        }

        public (int error, int bits) Request(int req_mode= 0x26)
        {
            dynamic r = this.device.request(req_mode);
            dynamic error = r[0];
            dynamic data = r[1];
            return (error, data);
        }

        public (int error, byte[] data) Anticoll()
        {
            dynamic r = this.device.anticoll();
            return (r[0], r[1]);
        }

        public void SelectTag(byte[] uid)
        {
            this.device.select_tag(uid);
        }

        public int CardAuth(int auth_mode,int block_address,byte[] key, byte[] uid)
        {
            return this.device.card_auth(auth_mode,block_address,key,uid);
        }

        public (int error, byte[] back_data) StopCrypto()
        {
            var r = this.device.stop_crypto();
            return (r[0], r[1]);
        }

        public int Auth_a
        {
            get
            {
                return this.device.auth_a;
            }
        }

        public int Auth_b
        {
            get
            {
                return this.device.auth_b;
            }
        }

        public int Write(int block_address, byte[] data)
        {
            if(data.Length!=16)
            {
                throw new ArgumentOutOfRangeException(nameof(data),"length must be 16 exactly.");
            }
            return this.device.write(block_address,data);
        }

        public (int error, byte[] data) Read(int block_address)
        {
            dynamic r = this.device.read(block_address);
            return (r[0], r[1]);
        }

        public void IrqCallback(byte pin)
        {
            this.device.irq_callback(pin);
        }

        public void Reset()
        {
            this.device.reset();
        }

        public void Cleanup()
        {
            this.device.cleanup();
        }

        public RC522Util Util()
        {
            return new RC522Util(this.device.util());
        }
    }
}
