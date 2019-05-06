using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace PSUtil.Verification
{
    public class UDP
    {
        UdpClient udpClient = new UdpClient();
        IPEndPoint endPoint;
        public UDP(String IPPORT)
        {
            endPoint = new IPEndPoint(System.Net.Dns.GetHostAddresses(IPPORT.Split(':')[0])[0], int.Parse(IPPORT.Split(':')[1]));
            udpClient.Connect(endPoint);
            udpClient.Client.ReceiveTimeout = 1000;
            udpClient.Client.SendTimeout = 5000;
        }
        public void Send(String MSG)
        {
            List<byte> encoded = Encoding.UTF8.GetBytes(MSG).ToList();
            encoded.Insert(0, 0xf4);
            byte[] encodedary = encoded.ToArray();
            udpClient.Send(encodedary, encodedary.Length);
        }
        public string Receive()
        {
            byte[] encoded = udpClient.Receive(ref endPoint);
            return Encoding.UTF8.GetString(encoded);
        }
    }
}
