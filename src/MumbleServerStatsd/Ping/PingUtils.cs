namespace MumbleServerStatsd.Ping
{
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// Methods to ping server.
    /// </summary>
    public static class PingUtils
    {
        /// <summary>
        /// Ping a Mumble server for stats.
        /// </summary>
        /// <param name="hostname">The hostname of the server.</param>
        /// <param name="port">The port of the server.</param>
        /// <returns>
        /// The stats as a PingResponse object.
        /// </returns>
        public static PingResponse PingServer(string hostname, int port)
        {
            PingRequest pingRequest = new PingRequest();

            using (UdpClient udpClient = new UdpClient(hostname, port))
            {
                udpClient.Send(pingRequest.ToBytes(), 12);

                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] response = udpClient.Receive(ref remoteIpEndPoint);
                PingResponse pingResponse = PingResponse.FromBytes(response);
                return pingResponse;
            }
        }
    }
}
