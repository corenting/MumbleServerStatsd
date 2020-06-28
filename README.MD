# MumbleServerStatsd

Send the number of connected users of a mumble server as a statsd gauge.

```
Usage:
  MumbleServerStatsd [options]

Options:
  --mumble-hostname <mumble-hostname>    hostname or IP of the mumble server.
  --statsd-hostname <statsd-hostname>    hostname or IP of the statsd server.
  --statsd-port <statsd-port>            port of the statsd server (optional, 8125 if not set). [default: 8125]
  --mumble-port <mumble-port>            port of the server (optional, 64738 if not set). [default: 64738]
  --version                              Show version information
  -?, -h, --help                         Show help and usage information
```