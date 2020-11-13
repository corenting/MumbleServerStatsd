RUNTIME_IDENTIFIER?=linux-x64
BUILD_FOLDER=src/MumbleServerStatsd/bin/Release/net5.0/$(RUNTIME_IDENTIFIER)/publish

.PHONY: release
release:
	dotnet publish src/MumbleServerStatsd -r $(RUNTIME_IDENTIFIER) -c Release /p:PublishTrimmed=true /p:PublishSingleFile=true /p:IncludeNativeLibrariesInSingleFile=true
	rm src/MumbleServerStatsd/bin/Release/net5.0/$(RUNTIME_IDENTIFIER)/publish/MumbleServerStatsd.pdb
	mkdir -p build
	zip -r -j build/mumble_server_statsd_$(RUNTIME_IDENTIFIER).zip $(BUILD_FOLDER)/MumbleServerStatsd*

.PHONY: release-all
release-all:
	RUNTIME_IDENTIFIER=linux-x64 make release
	RUNTIME_IDENTIFIER=linux-musl-x64 make release
	RUNTIME_IDENTIFIER=linux-arm make release
	RUNTIME_IDENTIFIER=linux-arm64 make release
	RUNTIME_IDENTIFIER=win-x64 make release
	RUNTIME_IDENTIFIER=win-arm64 make release

.PHONY: clean
clean:
	dotnet clean
	rm -rf build
