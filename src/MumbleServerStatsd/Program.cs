namespace MumbleServerStatsd
{
    using System;
    using CommandLine;
    using CommandLine.Text;
    using MumbleServerStatsd.Ping;

    /// <summary>
    /// CLI Entrypoint.
    /// </summary>
    public class Program
    {
        public class Options
        {
            [Option("mumble-hostname", Required = true, HelpText = "Hostname or IP of the mumble server.")]
            public string MumbleHostname { get; set; }

            [Option("statsd-hostname", Required = true, HelpText = "Hostname or IP of the statsd server.")]
            public string StatsdHostname { get; set; }

            [Option("statsd-port", Default = 8125, HelpText = "Port of the statsd server (optional, 8125 if not set).")]
            public int StatsdPort { get; set; }

            [Option("mumble-port", Default = 64738, HelpText = "Port of the mumble server (optional, 64738 if not set).")]
            public int MumblePort { get; set; }
        }

        public static void Main(string[] args)
        {
            var parser = new CommandLine.Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments<Options>(args);
            var helpText = HelpText.AutoBuild(parserResult, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.Copyright = "";
                return h;
            }, e => e);

            parserResult
            .WithParsed<Options>(options => {
                PingResponse ping = PingUtils.PingServer(options.MumbleHostname, options.MumblePort);
                Statsd.SendGauge(options.StatsdHostname, options.StatsdPort, ping.ConnectedUsers);
            })
            .WithNotParsed(errs => {
                Console.Error.WriteLine(helpText);
            });
        }
    }
}
