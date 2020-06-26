using System;
using MumbleServerStatsd.Ping;

namespace MumbleServerStatsd
{
    class Program
    {
        /// <summary>
        /// statsd client for mumble-server
        /// </summary>
        /// <param name="hostname">hostname or IP of the server.</param>
        /// <param name="port">port of the server (optional, 64738 if not set).</param>
        static void Main(string hostname, int port=64738)
        {
            PingUtils.PingServer(hostname, port);
        }
    }
}
