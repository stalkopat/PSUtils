using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PSUtil.Verification
{
    class ServerCompatibility
    {
        public static String GetServerCompatibility(String IPPORT, String CHECKSUM)
        {
            UDP udp = new UDP(IPPORT);
            ChecksumPacket packet = new ChecksumPacket();
            packet.Checksum = CHECKSUM;
            string PacketJSON = JsonConvert.SerializeObject(packet);
            try
            {
                udp.Send(PacketJSON);
                string resp = udp.Receive();
                if(resp != "OK!")
                {
                    return resp;
                }
            }
            catch
            {
                return "Server not Reachable";
            }
            return "OK!";
            
        }        
    }
    class ChecksumPacket
    {
        public String Checksum;
    }
}
