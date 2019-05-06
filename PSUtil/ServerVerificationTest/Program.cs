using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

namespace ServerVerificationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> Checksums = new List<string> { "1014c2a973f9ccd2a310039eb484dc27" };

            String ErrorResponse = "Invalid installation, please uninstall all Mods and try again!";

            UdpClient udp = new UdpClient(51200);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 51200);
            while (true)
            {
                byte[] req = udp.Receive(ref ep);
                string encoded = Encoding.Unicode.GetString(req);
                ChecksumPacket checksumPacket = JsonConvert.DeserializeObject<ChecksumPacket>(encoded);
                Console.WriteLine("New connection from {0}, Packet:{1}", ep.ToString(), encoded);
                if (Checksums.Contains(checksumPacket.Checksum))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes("OK!");
                    udp.Send(bytes, bytes.Length, ep);
                    ep = new IPEndPoint(IPAddress.Any, 51200);
                }
                else
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(ErrorResponse);
                    udp.Send(bytes, bytes.Length, ep);
                    ep = new IPEndPoint(IPAddress.Any, 51200);
                }
            }
        }
    }
    class ChecksumPacket
    {
        public String Checksum;
    }
}
