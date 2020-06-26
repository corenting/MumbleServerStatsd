using System;
using System.Net;
using System.Net.Sockets;

namespace MumbleServerStatsd.Ping
{
    public static class PingUtils
    {
        public static PingResponse PingServer(string hostname, int port)
        {
            PingRequest pingRequest = new PingRequest();

            using (UdpClient udpClient = new UdpClient(hostname, port))
            {
                udpClient.Send(pingRequest.ToBytes(), 12);

                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] response = udpClient.Receive(ref remoteIpEndPoint);
                PingResponse pingResponse = PingResponse.FromBytes(response);
                return pingResponse;
            }
        }
    }
}
