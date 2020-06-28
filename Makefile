RUNTIME_IDENTIFIER=linux-x64

.PHONY: release
release:
	dotnet publish src/MumbleServerStatsd -p:PublishTrimmed=true -r $(RUNTIME_IDENTIFIER) -c Release /p:PublishSingleFile=true