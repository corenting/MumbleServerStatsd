# MumbleServerStatsd

![Build](https://github.com/corenting/MumbleServerStatsd/workflows/Build/badge.svg) ![Latest Release](https://img.shields.io/github/v/release/corenting/MumbleServerStatsd) ![License](https://img.shields.io/github/license/corenting/MumbleServerStatsd)

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

## Download

Available in [Github releases](https://github.com/corenting/MumbleServerStatsd/releases/latest) for the following platforms :
- Linux x64
- Linux x64 (musl)
- Linux arm64
- Linux arm
- Windows x64
- Windows arm64