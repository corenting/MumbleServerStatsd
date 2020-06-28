namespace MumbleServerStatsd
{
    using System;
    using MumbleServerStatsd.Ping;

    /// <summary>
    /// CLI Entrypoint.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// statsd client for mumble-server.
        /// </summary>
        /// <param name="mumbleHostname">hostname or IP of the mumble server.</param>
        /// <param name="statsdHostname">hostname or IP of the statsd server.</param>
        /// <param name="statsdPort">port of the statsd server (optional, 8125 if not set).</param>
        /// <param name="mumblePort">port of the server (optional, 64738 if not set).</param>
        public static void Main(string mumbleHostname, string statsdHostname, int statsdPort = 8125, int mumblePort = 64738)
        {
            if (mumbleHostname == null)
            {
                Console.Error.WriteLine("Error: you need to specify an hostname (see --help for help).");
                Environment.Exit(1);
            }

            PingResponse ping = PingUtils.PingServer(mumbleHostname, mumblePort);
            Statsd.SendGauge(statsdHostname, statsdPort, ping.ConnectedUsers);
        }
    }
}
