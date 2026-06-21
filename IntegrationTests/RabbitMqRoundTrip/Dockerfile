# Build context is the REPO ROOT (see docker-compose.yml: build.context: ..), so that this
# Dockerfile can copy both the CFX SDK and the integration-test project. All COPY paths below are
# relative to the repo root.

# ---- build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only what the integration test needs to build: the SDK and this scenario.
COPY CFX/ ./CFX/
COPY IntegrationTests/RabbitMqRoundTrip/ ./IntegrationTests/RabbitMqRoundTrip/

RUN dotnet publish IntegrationTests/RabbitMqRoundTrip/RabbitMqRoundTrip.csproj \
    -c Release -o /app

# ---- runtime stage ----
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "RabbitMqRoundTrip.dll"]
