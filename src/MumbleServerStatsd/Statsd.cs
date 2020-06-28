namespace MumbleServerStatsd
{
    using JustEat.StatsD;

    /// <summary>
    /// Handle StatsD client methods.
    /// </summary>
    public static class Statsd
    {
        /// <summary>
        /// Send a gauge to the statsd server.
        /// </summary>
        /// <param name="statsdHost">The hostname of the StatsD server.</param>
        /// <param name="statsdPort">The port of the StatsD server.</param>
        /// <param name="value">The value of the gauge.</param>
        /// <param name="prefix">The gauge prefix.</param>
        public static void SendGauge(string statsdHost, int statsdPort, double value, string prefix = "mumble_server")
        {
            var statsDConfig = new StatsDConfiguration { Host = statsdHost, Port = statsdPort, Prefix = prefix };
            IStatsDPublisher statsDPublisher = new StatsDPublisher(statsDConfig);

            statsDPublisher.Gauge(value, "connected_users");
        }
    }
}
