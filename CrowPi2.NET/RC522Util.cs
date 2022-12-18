namespace CrowPi2.NET
{
    public class RC522Util
    {
        private dynamic pyObj;
        internal RC522Util(dynamic pyObj)
        {
            this.pyObj = pyObj;
        }

        public bool Debug
        {
            get
            {
                return this.pyObj.debug;
            }
            set
            {
                this.pyObj.debug = value;
            }
        }

        public int BlockAddr(int sector,int block)
        {
            return this.pyObj.block_addr(sector, block);
        }

        public string SectorString(int block_address)
        {
            return this.pyObj.sector_string(block_address);
        }

        public void SetTag(byte[] uid)
        {
            this.pyObj.set_tag(uid);
        }

        public void Auth(int auth_method, byte[] key)
        {
            this.pyObj.auth(auth_method, key);
        }

        public void Deauth()
        {
            this.pyObj.deauth();
        }

        public bool IsTagSetAuth()
        {
            return this.pyObj.is_tag_set_auth();
        }

        public void DoAuth(int block_address, bool force= false)
        {
            this.pyObj.do_auth(block_address, force);
        }
        
        public bool WriteTrailer(int sector, byte[] key_a= null, byte[] auth_bits= null,
                      byte user_data= 0x69, byte[] key_b= null)
        {
            if(key_a==null)
                key_a = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            if(auth_bits==null)
                auth_bits = new byte[] { 0xFF, 0x07, 0x80 };
            if(key_b==null)
                key_b = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            return this.pyObj.write_trailer(sector,key_a,auth_bits,user_data,key_b);
        }

        public void Rewrite(int block_address, byte[] new_bytes)
        {
            this.pyObj.rewrite(block_address,new_bytes);
        }

        public void ReadOut(int block_address)
        {
            this.pyObj.read_out(block_address);
        }

        public (byte b1,byte b2,byte b3) GetAccessBits(byte c1, byte c2, byte c3)
        {
            var r = this.pyObj.get_access_bits(c1, c2, c3);
            return (r[0], r[1], r[2]);
        }

        public void Dump(int sectors= 16)
        {
            this.pyObj.dump(sectors);
        }
    }
}