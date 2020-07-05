RUNTIME_IDENTIFIER?=linux-x64
BUILD_FOLDER=src/MumbleServerStatsd/bin/Release/netcoreapp3.1/$(RUNTIME_IDENTIFIER)/publish
VERSION=$(shell git rev-parse --short HEAD)

.PHONY: release
release:
	dotnet publish src/MumbleServerStatsd -p:PublishTrimmed=true -r $(RUNTIME_IDENTIFIER) -c Release /p:PublishSingleFile=true
	rm src/MumbleServerStatsd/bin/Release/netcoreapp3.1/$(RUNTIME_IDENTIFIER)/publish/MumbleServerStatsd.pdb
	mkdir -p build
	zip -r -j build/mumble_server_statsd_$(VERSION)_$(RUNTIME_IDENTIFIER).zip $(BUILD_FOLDER)/MumbleServerStatsd*

.PHONY: clean
clean:
	dotnet clean
	rm -rf build